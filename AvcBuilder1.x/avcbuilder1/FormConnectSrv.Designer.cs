namespace avcbuilder1
{
    partial class FormConnectSrv
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleButton_ok = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_srv = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_user = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_pw = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_dn = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_dn = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_save = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_srv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_user.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_pw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_dn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton_ok
            // 
            this.simpleButton_ok.Location = new System.Drawing.Point(414, 325);
            this.simpleButton_ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton_ok.Name = "simpleButton_ok";
            this.simpleButton_ok.Size = new System.Drawing.Size(86, 30);
            this.simpleButton_ok.TabIndex = 0;
            this.simpleButton_ok.Text = "确定";
            this.simpleButton_ok.Click += new System.EventHandler(this.simpleButton_ok_Click);
            // 
            // simpleButton_cancel
            // 
            this.simpleButton_cancel.Location = new System.Drawing.Point(521, 325);
            this.simpleButton_cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton_cancel.Name = "simpleButton_cancel";
            this.simpleButton_cancel.Size = new System.Drawing.Size(86, 30);
            this.simpleButton_cancel.TabIndex = 1;
            this.simpleButton_cancel.Text = "取消";
            this.simpleButton_cancel.Click += new System.EventHandler(this.simpleButton_cancel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(64, 113);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 18);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "数据库服务器：";
            // 
            // textEdit_srv
            // 
            this.textEdit_srv.Location = new System.Drawing.Point(182, 108);
            this.textEdit_srv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit_srv.Name = "textEdit_srv";
            this.textEdit_srv.Size = new System.Drawing.Size(425, 24);
            this.textEdit_srv.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(64, 157);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "用户名：";
            // 
            // textEdit_user
            // 
            this.textEdit_user.Location = new System.Drawing.Point(182, 152);
            this.textEdit_user.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit_user.Name = "textEdit_user";
            this.textEdit_user.Size = new System.Drawing.Size(425, 24);
            this.textEdit_user.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(64, 204);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 18);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "密码：";
            // 
            // textEdit_pw
            // 
            this.textEdit_pw.Location = new System.Drawing.Point(182, 199);
            this.textEdit_pw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit_pw.Name = "textEdit_pw";
            this.textEdit_pw.Size = new System.Drawing.Size(425, 24);
            this.textEdit_pw.TabIndex = 3;
            // 
            // labelControl_dn
            // 
            this.labelControl_dn.Location = new System.Drawing.Point(64, 253);
            this.labelControl_dn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl_dn.Name = "labelControl_dn";
            this.labelControl_dn.Size = new System.Drawing.Size(75, 18);
            this.labelControl_dn.TabIndex = 2;
            this.labelControl_dn.Text = "数据库名：";
            // 
            // textEdit_dn
            // 
            this.textEdit_dn.Location = new System.Drawing.Point(182, 248);
            this.textEdit_dn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit_dn.Name = "textEdit_dn";
            this.textEdit_dn.Size = new System.Drawing.Size(425, 24);
            this.textEdit_dn.TabIndex = 3;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(182, 58);
            this.comboBoxEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(425, 24);
            this.comboBoxEdit1.TabIndex = 4;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(64, 62);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 18);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "连接信息：";
            // 
            // simpleButton_save
            // 
            this.simpleButton_save.Location = new System.Drawing.Point(309, 325);
            this.simpleButton_save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton_save.Name = "simpleButton_save";
            this.simpleButton_save.Size = new System.Drawing.Size(86, 30);
            this.simpleButton_save.TabIndex = 6;
            this.simpleButton_save.Text = "保存连接";
            this.simpleButton_save.Click += new System.EventHandler(this.simpleButton_save_Click);
            // 
            // FormConnectSrv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 438);
            this.Controls.Add(this.simpleButton_save);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.textEdit_dn);
            this.Controls.Add(this.textEdit_pw);
            this.Controls.Add(this.textEdit_user);
            this.Controls.Add(this.textEdit_srv);
            this.Controls.Add(this.labelControl_dn);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton_cancel);
            this.Controls.Add(this.simpleButton_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConnectSrv";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "连接AVC服务器";
            this.Activated += new System.EventHandler(this.FormConnectSrv_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_srv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_user.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_pw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_dn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton_ok;
        private DevExpress.XtraEditors.SimpleButton simpleButton_cancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit_srv;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit_user;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit_pw;
        private DevExpress.XtraEditors.LabelControl labelControl_dn;
        private DevExpress.XtraEditors.TextEdit textEdit_dn;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton_save;
    }
}