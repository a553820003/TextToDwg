using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApplication2;

namespace YongHongSoft.YueChi
{
    public partial class FormOutMap : Form
    {
        public FormOutMap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void ChooseInputFile(object sender, EventArgs e)
        {
            //打开对话框选择输入文件
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "CAD图形文件|*.dwg";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                UserInputInfor.InputFiles=new List<string>();
                //显示输入文件路径及文件名
                string textOfLabel = Path.GetDirectoryName(fileDialog.FileNames[0])+"\\";
                foreach (string fileName in fileDialog.FileNames)
                {
                    textOfLabel+=Path.GetFileName(fileName)+" , ";
                    //存储输入文件的路径名
                    UserInputInfor.InputFiles.Add(fileName);
                }
                label2.Text = textOfLabel;
            }
        }

        private void ChooseOutputFolder(object sender, EventArgs e)
        {
            //打开对话框选择输出文件夹
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                label3.Text = "输出位置:" + foldPath;
                //存储输出文件路径给全局变量
                UserInputInfor.OutputFolder = foldPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!IsSetTypeOfDwg())
            {
                MessageBox.Show("请选择dwg类型!");
                return;
            }
            if (!IsSetInput())
            {
                MessageBox.Show("请选择输入文件或者输入文件夹!");
                return;
            }
            if (!IsSetOutput())
            {
                MessageBox.Show("请选择输出文件夹!");
                return;
            }
            //获取用户输入的dwg类型
            GetValueOfRadioBtns();
            //逐个处理dwg文件,自动添加text
            foreach (string fileName in UserInputInfor.InputFiles)
            {
                UserInputInfor.HandleDwg(fileName);
            }
            MessageBox.Show("完成!");
        }
        //获取radioBtn的值,默认为房产分户图
        private DwgType GetValueOfRadioBtns()
        {
            DwgType type=DwgType.Fht;
            if (radioButton1.Checked == true)
            {
                //获取dwg类型的时候设置字体和对齐方式
                //分户图设置为宋体,对齐方式true代表居中对齐
                type=DwgType.Fht;
                UserInputInfor.FontName = "宋体";
                UserInputInfor.IsAlign = true;
            }
            else if (radioButton2.Checked == true)
            {
                type = DwgType.Fct;
                UserInputInfor.FontName = "等线体";
                UserInputInfor.IsAlign = true;
            }
            else if (radioButton3.Checked == true)
            {
                type = DwgType.Zdt;
                UserInputInfor.FontName = "宋体";
                UserInputInfor.IsAlign = false;
            }
            UserInputInfor.Type = type;
            return type;
        }
        private bool IsSetInput()
        {
            return (label2.Text.Length > 6) ? true : false;
        }

        private bool IsSetOutput()
        {
            return (label3.Text.Length > 5) ? true : false;
        }

        private bool IsSetTypeOfDwg()
        {
            bool result;
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
                result = false;
            else
            {
                result = true;
            }
            return result;
        }
    }
}
