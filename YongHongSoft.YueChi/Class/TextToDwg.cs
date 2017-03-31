using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.IO;
using Teigha.DatabaseServices;
using Teigha.Geometry;
using Teigha.Runtime;
using MySql.Data.MySqlClient;
using YongHongSoft.YueChi;

namespace WindowsFormsApplication2
{
    class TextToDwg
    {
        private string pathOfDwg;
        private textEntity[] txtEntityArray;
        private bool isHorAlignCenter=true;
        private string outputPathOfDwg;
        //构造函数
        public TextToDwg(string inputPath,string outputPath, textEntity[] inputTextEntityArray,bool isAlign)
        {
            //源dwg路径和初始化输入文字要素数据
            pathOfDwg = inputPath;
            txtEntityArray = inputTextEntityArray;
            isHorAlignCenter=isAlign;
            outputPathOfDwg = outputPath;
        }
        public void CreateText()
        {
            using (Teigha.Runtime.Services srv = new Teigha.Runtime.Services())
            {
                //设置输出路径
                FileStreamBuf fileBuf = new FileStreamBuf(outputPathOfDwg, false, FileShareMode.DenyNo, FileCreationDisposition.CreateAlways);
                try
                {
                    using (Database pDb = new Database(false, false))
                    {
                        //读取数据库
                        pDb.ReadDwgFile(pathOfDwg, FileShare.ReadWrite, true, "");
                        HostApplicationServices.WorkingDatabase = pDb;//必要语句?
                        Debug.WriteLine("File Version: " + pDb.OriginalFileVersion);
                        using (Transaction acTrans = pDb.TransactionManager.StartTransaction())
                        {
                            // 以只读方式打开块表  
                            BlockTable acBlkTbl;
                            acBlkTbl = acTrans.GetObject(pDb.BlockTableId,
                                                         OpenMode.ForRead) as BlockTable;
                            // 以写方式打开模型空间块表记录  
                            BlockTableRecord acBlkTblRec;
                            acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                            OpenMode.ForWrite) as BlockTableRecord;
                            //创建单行文本对象数组  

                            //测试，左下角点
                            Point3d p= getBasicPoint(acBlkTblRec, acTrans);

                            Debug.WriteLine(p.X + " , " + p.Y+"基点");

                            DBText[] dbTextArray = initialDBTextArray(pDb,acBlkTblRec, acTrans);
                            for (int i = 0; i < dbTextArray.Length; i++) {
                                //将文字实体添加到块表记录中
                                acBlkTblRec.AppendEntity(dbTextArray[i]);
                                acTrans.AddNewlyCreatedDBObject(dbTextArray[i], true);
                            }
                            acTrans.Commit();
                        }
                        pDb.SaveAs(fileBuf, SaveType.Save13, DwgVersion.AC1021, true, 16);
                        //将fileBuf引用为空,释放内存占用
                        fileBuf = null;
                    }
                }
                catch (System.Exception e)
                {
                    Debug.WriteLine("Teigha?NET for .dwg files Error: " + e.Message);
                }
            }
        }
        private DBText[] initialDBTextArray(Database pDb,BlockTableRecord acBlkTblRec,Transaction acTrans)
        {
            //txtEntityArray为数据源，本函数将其包装为DBText类
            DBText[] dbTextArray = new DBText[txtEntityArray.Length];
                for (int i = 0; i < txtEntityArray.Length; i++)
                {
                    DBText currentDBText = new DBText();
                    currentDBText.SetDatabaseDefaults(pDb);
                    currentDBText.Annotative = AnnotativeStates.True;

                    currentDBText.Position = txtEntityArray[i].mposition;
                    //必须在指定数据库和设置注释性以后才能设置高度，不然高度有出入
                    currentDBText.Height = txtEntityArray[i].height;
                    currentDBText.TextString = txtEntityArray[i].mcontent;
                    currentDBText.WidthFactor = 1;
                    //设置宋体，通过获取源文件文字要素的TextStyle得到
                    currentDBText.TextStyleId = getFontStyleId(acBlkTblRec, acTrans);
                    
                    
                    //Annotative属性为true后才能正确对齐
                    if (isHorAlignCenter)
                    {
                        currentDBText.HorizontalMode = TextHorizontalMode.TextCenter;
                        currentDBText.VerticalMode = TextVerticalMode.TextVerticalMid;
                        currentDBText.AlignmentPoint = currentDBText.Position;
                    }
                    dbTextArray[i] = currentDBText;
                }
            return dbTextArray;
        }
        //获取宋体的styleID ，目前只找到这种办法，通过遍历已有dbText元素来得到，直接设置新建文字实体的styleID的方法暂未找到
        private ObjectId getFontStyleId(BlockTableRecord acBlkTblRec, Transaction acTrans)
        {
            foreach (ObjectId objs in acBlkTblRec)//遍历图中的所有块表
            {
                
                if (objs.ObjectClass.Name == "AcDbText") 
                {
                    DBText dbt = new DBText();
                    dbt = acTrans.GetObject(objs, OpenMode.ForRead) as DBText;
                    //如果遍历到的图元为空，则开始下次循环
                    if (dbt == null) continue;
                    if (dbt.TextStyleName == UserInputInfor.FontName)
                        return dbt.TextStyleId;
                }
            }
            ObjectId result=new ObjectId();
            return result; 
            
        }
        //获取表格的左下角点坐标，作为基点,此方法只在直线和多段线要素中筛选得到最左下角的基点
        private Point3d getBasicPoint(BlockTableRecord acBlkTblRec, Transaction acTrans)
        {
            Point3d basicPoint=new Point3d(0,0,0) ;
            Line line;
            Teigha.DatabaseServices.Polyline polyLine;
            ArrayList pointArray = new ArrayList();
            
            double min=0;
            double sum;

            foreach (ObjectId obj in acBlkTblRec)//遍历图中的所有图元
            {
                //将所有直线的端点添加进点集合
                if (obj.ObjectClass.Name == "AcDbLine") 
                {
                    line = acTrans.GetObject(obj, OpenMode.ForRead) as Line;
                    if (line == null) continue;

                    pointArray.Add(line.StartPoint);
                    pointArray.Add(line.EndPoint);
                }
                //将所有多段线的端点添加进点集合
                if (obj.ObjectClass.Name == "AcDbPolyline")
                {
                    polyLine = acTrans.GetObject(obj, OpenMode.ForRead) as Teigha.DatabaseServices.Polyline;
                    if (polyLine == null) continue;
                    for (int i = 0; i < polyLine.NumberOfVertices; i++) 
                    {
                        Point3d mpoint = polyLine.GetPoint3dAt(i);
                        pointArray.Add(mpoint);
                    }
                }
            }
            if (pointArray.Count < 1) return basicPoint;
            //初始化最小值和基点
            basicPoint = (Point3d)pointArray[0];
            min = basicPoint.X + basicPoint.Y;
            //遍历点集合,得到左下角基点
            for (int i = 1; i < pointArray.Count; i++)
            {
                sum = ((Point3d)pointArray[i]).X + ((Point3d)pointArray[i]).Y;
                if (sum < min) 
                {
                    min = sum;
                    basicPoint = ((Point3d)pointArray[i]);
                }
            }
            return basicPoint;
        }
        //根据左下角基点将相对坐标转换成绝对坐标
        public void transformCoordinateByBasePoint() 
        {
            using (Teigha.Runtime.Services srv = new Teigha.Runtime.Services())
            {
                using (Database pDb = new Database(false, false))
                {
                    //读取数据库
                    pDb.ReadDwgFile(pathOfDwg, FileShare.ReadWrite, true, "");
                    using (Transaction acTrans = pDb.TransactionManager.StartTransaction())
                    {
                        // 以只读方式打开块表  
                        BlockTable acBlkTbl;
                        acBlkTbl = acTrans.GetObject(pDb.BlockTableId,
                            OpenMode.ForRead) as BlockTable;
                        // 以写方式打开模型空间块表记录  
                        BlockTableRecord acBlkTblRec;
                        acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                            OpenMode.ForWrite) as BlockTableRecord;
                        Point3d basePoint = getBasicPoint(acBlkTblRec, acTrans);
                        foreach (var entity in txtEntityArray)
                        {
                            double X = entity.mposition.X + basePoint.X;
                            double Y = entity.mposition.Y + basePoint.Y;
                            Point3d point = new Point3d(X, Y, 0);
                            entity.mposition = point;
                        }
                    }
                }
            }
        }
    }
    class textEntity{
        public string mcontent;
        public Point3d mposition;
        public double height;
        public textEntity()
        {   
        }
        public textEntity(string content,Point3d position){
            mcontent = content;
            mposition = position;
        }
    }
    public static class UserInputInfor
    {
        public static List<string> InputFiles;
        public static string OutputFolder;
        public static DwgType Type;
        public static string FontName;
        public static bool IsAlign;
        public static List<Label> labelList;
        public static void HandleDwg(string fileName)
        {
            if (!(Path.GetExtension(fileName) == ".dwg"))
                return;
            textEntity[] txtEt;
            string parcelCode = Path.GetFileNameWithoutExtension(fileName);
            //读取XML文件
            DwgStore myDwgStore = new DwgStore();
            myDwgStore = myDwgStore.Load();
            var dwgList = myDwgStore.Dwg;
            int typeOfDwg = (int)UserInputInfor.Type;
            //获取点位集合
            labelList = dwgList[typeOfDwg].Label;
            //从数据库获取text数据,得到处理后的labelList
            fillTextOfLabel(parcelCode, labelList);
            txtEt = new textEntity[labelList.Count];
            //将坐标和text包装成textEntity[]对象
            for (int i = 0; i < txtEt.Length; i++)
            {
                txtEt[i] = new textEntity();
                //设置文字高度
                txtEt[i].height = Convert.ToDouble(dwgList[typeOfDwg].FontHeight);
                //现在只需要从数据库更新文本内容即可,图类可自动识别
                //设置文字内容
                txtEt[i].mcontent = labelList[i].Text;
                double x, y;
                //读取文字坐标
                x = Convert.ToDouble(labelList[i].X);
                y = Convert.ToDouble(labelList[i].Y);
                txtEt[i].mposition = new Teigha.Geometry.Point3d(x, y, 0);
            }
            string name = Path.GetFileName(fileName);
            //输出类型改为.dxf
            string newName = name.Replace(".dwg", ".dxf");
            string outputPath = UserInputInfor.OutputFolder + "\\" + newName;
            TextToDwg ttd = new TextToDwg(fileName, outputPath, txtEt, UserInputInfor.IsAlign);
            //如果输入的是相对坐标,就转换坐标系
            ttd.transformCoordinateByBasePoint();
            //开始自动添加文本
            ttd.CreateText();
        }

        public static List<Label> fillTextOfLabel(string parcelCode,List<Label> labelList)
        {
            List<Label> resultLabelList=new List<Label>();
            try
            {
                string M_str_sqlcon = "server=sunny-work;user id=yuechi;password=yuechi;database=yuechi"; //根据自己的设置
                MySqlConnection mycon = new MySqlConnection();
                mycon.ConnectionString = M_str_sqlcon;
                MySqlDataReader dataReader = null;
                try
                {
                    switch (UserInputInfor.Type)
                    {
                        case DwgType.Fht : fillFht(labelList, dataReader, mycon, parcelCode);
                            break;
                        case DwgType.Fct: fillFct(labelList, dataReader, mycon, parcelCode);
                            break;
                        case DwgType.Zdt: fillZdt(labelList, dataReader, mycon, parcelCode);
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    if(dataReader!=null)
                    dataReader.Close();
                    mycon.Close();
                }
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("error"+e.Message);
            }
            return labelList;
        }
        //从数据库获取分户图的数据
        public static void fillFht(List<Label> labelList, MySqlDataReader dataReader, MySqlConnection mycon, string parcelCode) 
        {
            mycon.Open();
            string sql = string.Format("select * from 分户 where 宗地代码='{0}'", parcelCode);
            MySqlCommand cmd = new MySqlCommand(sql, mycon);
            
            dataReader = cmd.ExecuteReader();
            dataReader.Read();
            //在fht_xml中遍历字段,获取值
            if (dataReader.HasRows)
            {
                //在数据表 分户 里面获取值
                for (int i = 0; i < labelList.Count; i++)
                {
                    string currentField = labelList[i].Field;
                    if (currentField == "幢号" || currentField == "坐落")
                        continue;
                    labelList[i].Text = dataReader[currentField].ToString();
                }
            }
            //在数据表 房屋 里面获取幢号
            dataReader.Close();
            sql = string.Format("select * from 房屋 where 宗地代码='{0}'", parcelCode);
            cmd = new MySqlCommand(sql, mycon);
            dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                labelList[1].Text = dataReader["幢号"].ToString();
            }
            dataReader.Close();
            //在数据表 宗地 里面获取坐落
            sql = string.Format("select * from 宗地 where 宗地代码='{0}'", parcelCode);
            cmd = new MySqlCommand(sql, mycon);
            dataReader = null;
            dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                labelList[9].Text = dataReader["坐落"].ToString();
            }
            dataReader.Close();
        }
        public static void fillFct(List<Label> labelList, MySqlDataReader dataReader, MySqlConnection mycon, string parcelCode) 
        {
            mycon.Open();
            string sql = string.Format("select * from 分层 where 宗地代码='{0}'", parcelCode);
            MySqlCommand cmd = new MySqlCommand(sql, mycon);

            dataReader = cmd.ExecuteReader();
            dataReader.Read();
            //在fct_xml中遍历字段,获取值

            //在数据表 分层 里面获取值
            if (dataReader.HasRows)
            {
                for (int i = 0; i < labelList.Count; i++)
                {
                    string currentField = labelList[i].Field;
                    if (currentField == "坐落")
                        continue;
                    labelList[i].Text = dataReader[currentField].ToString();
                }
            }
            dataReader.Close();
            //在数据表 宗地 里面获取坐落
            sql = string.Format("select * from 宗地 where 宗地代码='{0}'", parcelCode);
            cmd = new MySqlCommand(sql, mycon);
            dataReader = null;
            dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                labelList[0].Text = dataReader["坐落"].ToString();
            }
            dataReader.Close();
        }
        public static void fillZdt(List<Label> labelList, MySqlDataReader dataReader, MySqlConnection mycon, string parcelCode)
        {
            mycon.Open();
            string sql = string.Format("select * from 宗地 where 宗地代码='{0}'", parcelCode);
            MySqlCommand cmd = new MySqlCommand(sql, mycon);

            dataReader = cmd.ExecuteReader();
            dataReader.Read();
            //在fct_xml中遍历字段,获取值

            //在数据表 分层 里面获取值
            if (dataReader.HasRows)
            {
                for (int i = 0; i < labelList.Count; i++)
                {
                    string currentField = labelList[i].Field;
                    if (currentField == "土地权利人")
                        continue;
                    if (i < 4)
                        labelList[i].Text = dataReader[currentField].ToString();
                    switch (i)
                    {
                        case 4: labelList[i].Text = "宗地总面积: " + dataReader[currentField].ToString();
                            break;
                        case 5: labelList[i].Text = "宗地建筑占地面积: " + dataReader[currentField].ToString();
                            break;
                        case 6: labelList[i].Text = "批准农村宅基地面积: " + dataReader[currentField].ToString();
                            break;
                        case 7: labelList[i].Text = "其他集体建设用地面积: " + dataReader[currentField].ToString();
                            break;
                    }
                }
            }
            dataReader.Close();
            //在数据表 宗地 里面获取坐落
            sql = string.Format("select * from 权利人 where 宗地代码='{0}'", parcelCode);
            cmd = new MySqlCommand(sql, mycon);
            dataReader = null;
            dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                labelList[0].Text = dataReader["权利人"].ToString();
            }
            dataReader.Close();
        }
    }
    public enum DwgType
    {
        Fht,
        Fct,
        Zdt
    }
}
