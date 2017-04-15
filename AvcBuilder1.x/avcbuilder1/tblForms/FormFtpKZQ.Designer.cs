namespace avcbuilder1.tblForms
{
    partial class FormFtpKZQ
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage_zjxtcfg = new DevExpress.XtraTab.XtraTabPage();
            this.memoEdit_zjxtcfg = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage1_104cfg = new DevExpress.XtraTab.XtraTabPage();
            this.memoEdit_104cfg = new DevExpress.XtraEditors.MemoEdit();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.simpleButton_reboot = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_log = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage_zjxtcfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_zjxtcfg.Properties)).BeginInit();
            this.xtraTabPage1_104cfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_104cfg.Properties)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 63);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_zjxtcfg;
            this.xtraTabControl1.Size = new System.Drawing.Size(670, 298);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_zjxtcfg,
            this.xtraTabPage1_104cfg});
            // 
            // xtraTabPage_zjxtcfg
            // 
            this.xtraTabPage_zjxtcfg.Controls.Add(this.memoEdit_zjxtcfg);
            this.xtraTabPage_zjxtcfg.Name = "xtraTabPage_zjxtcfg";
            this.xtraTabPage_zjxtcfg.Size = new System.Drawing.Size(664, 269);
            this.xtraTabPage_zjxtcfg.Text = "专家系统配置";
            // 
            // memoEdit_zjxtcfg
            // 
            this.memoEdit_zjxtcfg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit_zjxtcfg.Location = new System.Drawing.Point(0, 0);
            this.memoEdit_zjxtcfg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.memoEdit_zjxtcfg.Name = "memoEdit_zjxtcfg";
            this.memoEdit_zjxtcfg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memoEdit_zjxtcfg.Size = new System.Drawing.Size(664, 269);
            this.memoEdit_zjxtcfg.TabIndex = 0;
            // 
            // xtraTabPage1_104cfg
            // 
            this.xtraTabPage1_104cfg.Controls.Add(this.memoEdit_104cfg);
            this.xtraTabPage1_104cfg.Name = "xtraTabPage1_104cfg";
            this.xtraTabPage1_104cfg.Size = new System.Drawing.Size(664, 269);
            this.xtraTabPage1_104cfg.Text = "104接口配置";
            // 
            // memoEdit_104cfg
            // 
            this.memoEdit_104cfg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit_104cfg.Location = new System.Drawing.Point(0, 0);
            this.memoEdit_104cfg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.memoEdit_104cfg.Name = "memoEdit_104cfg";
            this.memoEdit_104cfg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memoEdit_104cfg.Size = new System.Drawing.Size(664, 269);
            this.memoEdit_104cfg.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.simpleButton_reboot);
            this.flowLayoutPanel2.Controls.Add(this.simpleButton_log);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(670, 32);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // simpleButton_reboot
            // 
            this.simpleButton_reboot.Location = new System.Drawing.Point(3, 3);
            this.simpleButton_reboot.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.simpleButton_reboot.Name = "simpleButton_reboot";
            this.simpleButton_reboot.Size = new System.Drawing.Size(115, 25);
            this.simpleButton_reboot.TabIndex = 0;
            this.simpleButton_reboot.Text = "重启区域控制器";
            // 
            // simpleButton_log
            // 
            this.simpleButton_log.Location = new System.Drawing.Point(124, 3);
            this.simpleButton_log.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.simpleButton_log.Name = "simpleButton_log";
            this.simpleButton_log.Size = new System.Drawing.Size(115, 25);
            this.simpleButton_log.TabIndex = 3;
            this.simpleButton_log.Text = "获取系统日志";
            // 
            // FormFtpKZQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(670, 365);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FormFtpKZQ";
            this.Controls.SetChildIndex(this.flowLayoutPanel2, 0);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage_zjxtcfg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_zjxtcfg.Properties)).EndInit();
            this.xtraTabPage1_104cfg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_104cfg.Properties)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_zjxtcfg;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1_104cfg;
        private DevExpress.XtraEditors.MemoEdit memoEdit_zjxtcfg;
        private DevExpress.XtraEditors.MemoEdit memoEdit_104cfg;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton simpleButton_reboot;
        private DevExpress.XtraEditors.SimpleButton simpleButton_log;
    }
}
