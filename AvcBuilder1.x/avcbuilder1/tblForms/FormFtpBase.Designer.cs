namespace avcbuilder1.tblForms
{
    partial class FormFtpBase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFtpBase));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_connect = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.simpleButton_f5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_save = new DevExpress.XtraEditors.SimpleButton();
            this.check_channel = new DevExpress.XtraEditors.CheckEdit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_channel.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelControl1);
            this.flowLayoutPanel1.Controls.Add(this.textEdit1);
            this.flowLayoutPanel1.Controls.Add(this.simpleButton_connect);
            this.flowLayoutPanel1.Controls.Add(this.simpleButton_f5);
            this.flowLayoutPanel1.Controls.Add(this.simpleButton_save);
            this.flowLayoutPanel1.Controls.Add(this.check_channel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(894, 48);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 6);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(12, 6, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "设备地址:";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(98, 5);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(286, 28);
            this.textEdit1.TabIndex = 1;
            // 
            // simpleButton_connect
            // 
            this.simpleButton_connect.ImageIndex = 2;
            this.simpleButton_connect.ImageList = this.imageCollection1;
            this.simpleButton_connect.Location = new System.Drawing.Point(392, 4);
            this.simpleButton_connect.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton_connect.Name = "simpleButton_connect";
            this.simpleButton_connect.Size = new System.Drawing.Size(92, 34);
            this.simpleButton_connect.TabIndex = 2;
            this.simpleButton_connect.Text = "连接";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("refresh2_16x16.png", "images/actions/refresh2_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/refresh2_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "refresh2_16x16.png");
            this.imageCollection1.InsertGalleryImage("saveto_16x16.png", "images/save/saveto_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/saveto_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "saveto_16x16.png");
            this.imageCollection1.InsertGalleryImage("feature_16x16.png", "images/support/feature_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/feature_16x16.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "feature_16x16.png");
            // 
            // simpleButton_f5
            // 
            this.simpleButton_f5.ImageIndex = 0;
            this.simpleButton_f5.ImageList = this.imageCollection1;
            this.simpleButton_f5.Location = new System.Drawing.Point(492, 4);
            this.simpleButton_f5.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton_f5.Name = "simpleButton_f5";
            this.simpleButton_f5.Size = new System.Drawing.Size(94, 34);
            this.simpleButton_f5.TabIndex = 3;
            this.simpleButton_f5.Text = "刷新";
            // 
            // simpleButton_save
            // 
            this.simpleButton_save.ImageIndex = 1;
            this.simpleButton_save.ImageList = this.imageCollection1;
            this.simpleButton_save.Location = new System.Drawing.Point(594, 4);
            this.simpleButton_save.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton_save.Name = "simpleButton_save";
            this.simpleButton_save.Size = new System.Drawing.Size(134, 34);
            this.simpleButton_save.TabIndex = 4;
            this.simpleButton_save.Text = "保存并下装";
            // 
            // check_channel
            // 
            this.check_channel.EditValue = true;
            this.check_channel.Location = new System.Drawing.Point(736, 6);
            this.check_channel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.check_channel.Name = "check_channel";
            this.check_channel.Properties.Caption = "默认通道";
            this.check_channel.Size = new System.Drawing.Size(100, 26);
            this.check_channel.TabIndex = 5;
            // 
            // FormFtpBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.ClientSize = new System.Drawing.Size(894, 367);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "FormFtpBase";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_channel.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        public DevExpress.XtraEditors.SimpleButton simpleButton_f5;
        public DevExpress.XtraEditors.SimpleButton simpleButton_save;
        public DevExpress.XtraEditors.SimpleButton simpleButton_connect;
        public DevExpress.XtraEditors.TextEdit textEdit1;
        public DevExpress.XtraEditors.CheckEdit check_channel;
    }
}
