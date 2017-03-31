namespace YongHongSoft.YueChi
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripButtonInput = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOutMap = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonInput,
            this.toolStripButtonOutMap});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1005, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 491);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1005, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripButtonInput
            // 
            this.toolStripButtonInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonInput.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonInput.Image")));
            this.toolStripButtonInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInput.Name = "toolStripButtonInput";
            this.toolStripButtonInput.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonInput.Text = "数据录入";
            this.toolStripButtonInput.Click += new System.EventHandler(this.toolStripButtonInput_Click);
            // 
            // toolStripButtonOutMap
            // 
            this.toolStripButtonOutMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonOutMap.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOutMap.Image")));
            this.toolStripButtonOutMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOutMap.Name = "toolStripButtonOutMap";
            this.toolStripButtonOutMap.Size = new System.Drawing.Size(36, 22);
            this.toolStripButtonOutMap.Text = "制图";
            this.toolStripButtonOutMap.Click += new System.EventHandler(this.toolStripButtonOutMap_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 513);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonInput;
        private System.Windows.Forms.ToolStripButton toolStripButtonOutMap;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

