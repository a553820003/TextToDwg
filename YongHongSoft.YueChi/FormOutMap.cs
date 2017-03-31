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
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                UserInputInfor.InputFiles=new List<string>();
                string textOfLabel = Path.GetDirectoryName(fileDialog.FileNames[0])+"\\";
                foreach (string fileName in fileDialog.FileNames)
                {
                    textOfLabel+=Path.GetFileName(fileName)+" , ";
                    UserInputInfor.InputFiles.Add(fileName);
                }
                label2.Text = textOfLabel;
            }
        }

        private void ChooseOutputFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                label3.Text = "输出位置:" + foldPath;
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
            //设置dwg类型
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
