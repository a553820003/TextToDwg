using System.Windows.Forms;

namespace YongHongSoft.YueChi
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void toolStripButtonInput_Click(object sender, System.EventArgs e)
        {
            FormInput input=new FormInput();
            input.TopLevel = false;
            input.ShowInTaskbar = false;
            input.Parent = this;
            input.Show();
        }

        private void toolStripButtonOutMap_Click(object sender, System.EventArgs e)
        {
            FormOutMap outMap = new FormOutMap();
            outMap.TopLevel = false;
            outMap.ShowInTaskbar = false;
            outMap.Parent = this;
            outMap.Show();
        }
    }
}
