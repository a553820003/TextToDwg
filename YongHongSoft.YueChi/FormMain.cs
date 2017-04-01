using System.Windows.Forms;

namespace YongHongSoft.YueChi
{
    public partial class FormMain : Form
    {
        private FormInput input;
        private FormOutMap outMap;
        public FormMain()
        {
            InitializeComponent();
        }

        private void toolStripButtonInput_Click(object sender, System.EventArgs e)
        {
            if (this.input == null)
            {
                FormInput input = new FormInput();
                this.input = input;
                input.TopLevel = false;
                input.ShowInTaskbar = false;
                input.Parent = this;
                input.Show();
                if (this.outMap != null)
                    outMap.Hide();
            }
            else
            {
                input.Show();
                if(this.outMap!=null)
                outMap.Hide();
            }
        }

        private void toolStripButtonOutMap_Click(object sender, System.EventArgs e)
        {
            if (this.outMap == null)
            {
                FormOutMap outMap = new FormOutMap();
                this.outMap = outMap;
                outMap.TopLevel = false;
                outMap.ShowInTaskbar = false;
                outMap.Parent = this;
                outMap.Show();
                if (this.input != null)
                {
                    input.Hide();
                }
            }
            else
            {
                outMap.Show();
                if (this.input != null)
                {
                    input.Hide();
                }
            }
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {

        }
    }
}
