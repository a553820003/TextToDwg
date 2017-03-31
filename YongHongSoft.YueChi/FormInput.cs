using System;
using System.Data;
using System.Windows.Forms;

namespace YongHongSoft.YueChi
{
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
            textBoxQLRZJH.Leave += textBox_Leave;
            textBoxFDDBRZJH.Leave += textBox_Leave;
            textBoxDLRZJH.Leave += textBox_Leave;
            maskedTextBoxBLC.Leave += TextBox_TypeCheckInt;
            maskedTextBoxJZDGS.Leave += TextBox_TypeCheckInt;
            maskedTextBoxPZMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxZDMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxPZYDMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxSCJZMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxPZJZMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxGLBLC.Leave += TextBox_TypeCheckInt;
            maskedTextBoxQTJTJSYDMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxZTS.Leave += TextBox_TypeCheckInt;
            maskedTextBoxZCS.Leave += TextBox_TypeCheckInt;
            maskedTextBoxFTJZMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxZYJZMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxJZZDMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxJZZMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxFHZCS.Leave += TextBox_TypeCheckInt;
            maskedTextBoxFHZYJZMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxFHFTJZMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxFHJZMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxFCZCS.Leave += TextBox_TypeCheckInt;
            maskedTextBoxAJZJGQFMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxTNMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxFTMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxJZMJ.Leave += TextBox_TypeCheckDouble;
            maskedTextBoxZS.Leave += TextBox_TypeCheckInt;
            maskedTextBoxTDMJ.Leave += TextBox_TypeCheckDouble;
            
            
        }


        private void textBoxQLRSYQ_TextChanged(object sender, EventArgs e)
        {
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            string zddm = maskedTextBoxZDDM.Text.ToUpper();

         

           
            var cnn = "Server=sunny-work;Port=3306;Database=yuechi; User=yuechi;Password=yuechi;";
            var helper = new MySqlHelper(cnn);

            try
            {
                var sql = "INSERT INTO 代理人 " +
                          "	(宗地代码,代理人姓名,证件种类,证件号,电话) " +
                          "VALUES " +
                          $"('{zddm}','{textBoxDLRXM.Text}','{comboBoxDLRZJZL.Text}','{textBoxDLRZJH.Text}'," +
                          $"'{maskedTextBoxDLRDHHM.Text}');";


                var count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 法定代表人 " +
                      "(宗地代码,法定代表人或负责人姓名,证件种类,证件号,电话) " +
                      "VALUES" +
                      $"('{zddm}','{textBoxFDDBRXM.Text}','{comboBoxFDDBRZJZL.Text}','{textBoxFDDBRZJH.Text}'," +
                      $"'{maskedTextBoxFDDBRDHHM.Text}')";


                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 权利人 " +
                      "(宗地代码,权利人,权利人类型,证件种类,证件号,通讯地址,权利类型,权利性质,土地权属来源证明材料)" +
                      "VALUES" +
                      $"('{zddm}','{textBoxQLRSYQ.Text}','{comboBoxQLRLX.Text}','{comboBoxQLRZJZL.Text}'," +
                      $"'{textBoxQLRZJH.Text}','{textBoxQLRTXDZ.Text}','{comboBoxQLRQLLX.Text}','{comboBoxQLRQLXZ.Text}'," +
                      $"'{textBoxQLRZMCL.Text}')";

                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 宗地 " +
                      "(宗地代码,所有权,坐落,权利设定方式,国民经济行业分类代码,预编宗地代码,不动产单元号," +
                      "比例尺,图幅号,北至,东至,南至,西至,批准面积,宗地面积,界址点个数,有无建设用地许可证," +
                      "有无集体土地建设用地使用权证,批准用地面积,实测建筑面积,有无建设规划许可证或房屋所有权证," +
                      "批准建筑面积,调查员,备注,共有情况,登记类型,登记日期,登记原因,等级,价格,批准用途,实际用途," +
                      "土地使用期限,共有权利人情况,说明,审核,丈量者,丈量日期,检查者,检查日期,概略比例尺,其他集体建设用地面积)" +
                      "VALUES" +
                      $"('{zddm}','{textBoxSYQ.Text}','{textBoxZL.Text}','{comboBoxQLSDFS.Text}','{textBoxHYFLDM.Text}','{textBoxYBZDDM.Text}'," +
                      $"'{textBoxBDCDYH.Text}',{Convert.ToInt32(maskedTextBoxBLC.Text.Trim())},'{textBoxTFH.Text}','{textBoxZL.Text}','{textBoxDZ.Text}','{textBoxNZ.Text}','{textBoxXZ.Text}'," +
                      $"{Convert.ToDouble(maskedTextBoxPZMJ.Text.Trim())},{Convert.ToDouble(maskedTextBoxZDMJ.Text.Trim())},{Convert.ToInt32(maskedTextBoxJZDGS.Text.Trim())},'{comboBoxJSYDXKZ.Text}','{comboBoxJTTDJSSYQZ.Text}'," +
                      $"{Convert.ToDouble(maskedTextBoxPZYDMJ.Text.Trim())},{Convert.ToDouble(maskedTextBoxSCJZMJ.Text.Trim())},'{comboBoxJSGHXKZ.Text}',{Convert.ToDouble(maskedTextBoxPZJZMJ.Text.Trim())},'{textBoxDCY.Text}'," +
                      $"'{textBoxBEIZHU.Text}','{comboBoxGYQK.Text}','{comboBoxDJLX.Text}','{DateTime.Parse(maskedTextBoxDJRQ.Text.Trim())}','{comboBoxDJYY.Text}','{textBoxDJ.Text}'," +
                      $"'{textBoxJG.Text}','{comboBoxPZYT.Text}','{comboBoxSJYT.Text}','{textBoxTDSYQX.Text}','{textBoxGYQLRQK.Text}','{textBoxSM.Text}'," +
                      $"'{textBoxSH.Text}','{textBoxZLZ.Text}','{DateTime.Parse(maskedTextBoxZLRQ.Text.Trim())}','{textBoxJCZ.Text}','{DateTime.Parse(maskedTextBoxJCRQ.Text.Trim())}',{Convert.ToInt32(maskedTextBoxGLBLC.Text.Trim())}," +
                      $"{Convert.ToDouble(maskedTextBoxQTJTJSYDMJ.Text.Trim())})";

                count = helper.ExecuteNonQuery(CommandType.Text, sql);


                sql = "insert into 房屋 " +
                      "(宗地代码,市区名称或代码,地籍区,地籍子区,宗地号,房屋代码,邮政编码,项目名称,房屋性质,产别,用途,规划用途,幢号,总套数,总层数,所在层,所在层总层数,房屋结构," +
                      "竣工时间,构筑物类型,分摊建筑面积,专有建筑面积,产权来源,修建时间,建筑占地面积,建筑总面积)" +
                      "VALUES" +
                      $"('{zddm}'," +
                      $"'{textBoxSQDM.Text}','{textBoxDJQ.Text}','{textBoxDJZQ.Text}','{textBoxZDH.Text}','{textBoxFWDM.Text}'," +
                      $"'{maskedTextBoxYZBM.Text}'," +
                      $"'{textBoxXMMC.Text}','{comboBoxFWXZ.Text}','{comboBoxCB.Text}','{comboBoxYT.Text}','{comboBoxGHYT.Text}','{textBoxZH.Text}'," +
                      $"{Convert.ToDouble(maskedTextBoxZTS.Text.Trim())},{Convert.ToInt32(maskedTextBoxZCS.Text.Trim())}," +
                      $"'{textBoxSZC.Text}','{textBoxSZCZCS.Text}','{comboBoxFWJG.Text.Trim()}','{textBoxJGSJ.Text}'," +
                      $"'{textBoxGZWLX.Text}',{Convert.ToDouble(maskedTextBoxFTJZMJ.Text.Trim())},{Convert.ToDouble(maskedTextBoxZYJZMJ.Text)}," +
                      $"'{textBoxCQLY.Text}','{DateTime.Parse(maskedTextBoxXJSJ.Text.Trim())}'," +
                      $"{Convert.ToDouble(maskedTextBoxJZZDMJ.Text.Trim())},{Convert.ToDouble(maskedTextBoxJZZMJ.Text.Trim())})";
                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 分户 " +
                      "(宗地代码,户号,结构,总层数,所在层次,专有建筑面积,分摊建筑面积,建筑面积)" +
                      "VALUES" +
                      $"('{zddm}','{textBoxHH.Text}','{textBoxJG.Text}',{Convert.ToDouble(maskedTextBoxFHZCS.Text.Trim())},'{textBoxSZCC.Text}',{Convert.ToDouble(maskedTextBoxFHZYJZMJ.Text.Trim())},{Convert.ToDouble(maskedTextBoxFHFTJZMJ.Text.Trim())},{Convert.ToDouble(maskedTextBoxFHJZMJ.Text.Trim())})";
                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 分层 " +
                      "(宗地代码,房屋名称,总层数,按建筑结构区分面积,测绘人员,检核人员,房屋用途,房屋结构,套内面积,分摊面积,建筑面积)" +
                      "VALUES" +
                      $"('{zddm}','{textBoxFWMC.Text}',{Convert.ToInt32(maskedTextBoxFCZCS.Text.Trim())},{Convert.ToDouble(maskedTextBoxAJZJGQFMJ.Text.Trim())}," +
                      $"'{textBoxCHRY.Text}','{textBoxJHRY.Text}','{comboBoxFWYT.Text}','{textBoxFWJG.Text}'," +
                      $"{Convert.ToDouble(maskedTextBoxTNMJ.Text.Trim())},{Convert.ToDouble(maskedTextBoxFTMJ.Text.Trim())},{Convert.ToDouble(maskedTextBoxJZMJ.Text.Trim())})";
                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 查封登记" +
                      "(宗地代码,查封机关,查封类型,查封范围,查封期限)" +
                      "VALUES" +
                      $"('{zddm}','{textBoxCFJG.Text}','{textBoxCFLX.Text}','{textBoxCFFW.Text}','{textBoxCFQX.Text}')";
                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 抵押权" +
                      "(宗地代码,抵押范围,被担保债权数额,债务履行期限)" +
                      "VALUES" +
                      $"('{zddm}','{textBoxDYFW.Text}','{textBoxDYBDBZQSE.Text}','{textBoxDYZWLXQX.Text}')";
                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 地役权" +
                      "(宗地代码,需役地坐落,需役地不动产单元号,地役权内容)" +
                      "VALUES" +
                      $"('{zddm}','{textBoxXYDZL.Text}','{textBoxXYDBDCDYH.Text}','{textBoxDYQNR.Text}')";
                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 发证记录 " +
                      "(宗地代码,不动产权证书号单一版,单一版证书流水号,不动产权证书号集成版,集成版证书流水号,不动产登记证明号," +
                      "证明号证书流水号,制证人,制证日期,发证人)" +
                      "VALUES" +
                      $"('{zddm}','{textBoxCQZSDYB.Text}','{textBoxDYBLSH.Text}','{textBoxCQZSJCB.Text}'," +
                      $"'{textBoxJCBLSH.Text}','{textBoxDJZMH.Text}','{textBoxZMHLSH.Text}','{textBoxZZR.Text}','{DateTime.Parse(maskedTextBoxZZRQ.Text)}'," +
                      $"'{textBoxFZR.Text}')";
                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 核收出让金税费 " +
                      "(宗地代码,取得价格,计税价格,交缴人,票证号,出让金,契税,登记费,转让手续费,工本费,合计)" +
                      "VALUES" +
                      $"('{zddm}','{textBoxQDJG.Text}','{textBoxJSJG.Text}','{textBoxJJR.Text}','{textBoxPZH.Text}','{textBoxCRJ.Text}','{textBoxQS.Text}'," +
                      $"'{textBoxDJF.Text}','{textBoxZRSXF.Text}','{textBoxGBF.Text}','{textBoxHJ.Text}')";
                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 林地 " +
                      "(宗地代码,主要树种,株数,林种,造林年度,小地名,林班,小班)" +
                      "VALUES" +
                      $"('{zddm}','{textBoxZYSZ.Text}',{maskedTextBoxZS.Text},'{textBoxLZ.Text}','{textBoxZLND.Text}'," +
                      $"'{textBoxXDM.Text}','{textBoxLB.Text}','{textBoxXB.Text}')";
                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 土地状况 " +
                      "(宗地代码,土地面积,土地用途,土地权利性质,使用承包期限)" +
                      "VALUES" +
                      $"('{zddm}','{Convert.ToDouble(maskedTextBoxTDMJ.Text.Trim())}','{comboBoxTDYT.Text}','{comboBoxTDQLXZ.Text}','{textBoxSYCBQX.Text}')";
                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 异议登记 " +
                      "(宗地代码,申请人,异议事项)" +
                      "VALUES" +
                      $"('{zddm}','{textBoxSQR.Text}','{textBoxYYSX.Text}')";
                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                sql = "insert into 预告登记 " +
                      "(宗地代码,预告登记种类,义务人,被担保债权数额,债务履行期限)" +
                      "VALUES" +
                      $"('{zddm}','{textBoxYGDJZL.Text}','{textBoxYWR.Text}','{textBoxBDBZQSE.Text}','{textBoxZWLXQX.Text}')";
                count = helper.ExecuteNonQuery(CommandType.Text, sql);

                MessageBox.Show("你更新了 " + count + " 条记录耶");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
        }

        #region  身份证验证

        private void textBox_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            var id = textBox.Text.Trim();

            var msg = IdCardValidationArgs.Validation(id);

            if (!string.IsNullOrEmpty(msg))
            {
                var dialogResult = MessageBox.Show(this, msg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button2);
                if (dialogResult != DialogResult.Yes)
                {
                    textBox.Focus();
                    textBox.SelectAll();
                }
            }
        }

        private void TextBox_TypeCheckDouble(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            var mtb = sender as MaskedTextBox;
            string text = string.Empty;
            if (tb != null)
            {
                text = tb.Text;
            }
            if (mtb != null)
            {
                text = mtb.Text;
            }
            if (!TextTypeValidation.IsDouble(text))
            {
                MessageBox.Show(this, "数据格式不正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tb != null)
                {
                     tb.Focus();
                }
                if (mtb != null)
                {
                    mtb.Focus();
                }
            }
        }

        private void TextBox_TypeCheckInt(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            var mtb = sender as MaskedTextBox;
            string text = string.Empty;
            if (tb != null)
            {
                text = tb.Text;
            }
            if(mtb!=null)
            {
                text = mtb.Text;
            }


            if (!TextTypeValidation.IsInt(text))
            {
                MessageBox.Show(this, "数据格式不正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (tb != null)
                {
                    tb.Focus();
                }
                if (mtb != null)
                {
                    mtb.Focus();
                }
            }
        }

        private void TextBox_IsEmpty(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            var mtb = sender as MaskedTextBox;
            string text = string.Empty;
            if (!TextTypeValidation.IsEmpty(text))
            {
                MessageBox.Show(this, "不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button2);

                if (tb != null)
                {
                    tb.Focus();
                }
                if (mtb != null)
                {
                    mtb.Focus();
                }
            }
        }
        #endregion
    }
}