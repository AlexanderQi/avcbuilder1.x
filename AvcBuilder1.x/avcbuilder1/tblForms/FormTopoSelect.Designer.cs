namespace avcbuilder1.tblForms
{
    partial class FormTopoSelect
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
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.simpleButton_ok = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_cancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxControl1.Location = new System.Drawing.Point(13, 13);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(396, 272);
            this.checkedListBoxControl1.TabIndex = 0;
            // 
            // simpleButton_ok
            // 
            this.simpleButton_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_ok.Location = new System.Drawing.Point(426, 13);
            this.simpleButton_ok.Name = "simpleButton_ok";
            this.simpleButton_ok.Size = new System.Drawing.Size(99, 23);
            this.simpleButton_ok.TabIndex = 1;
            this.simpleButton_ok.Text = "确定";
            this.simpleButton_ok.Click += new System.EventHandler(this.simpleButton_ok_Click);
            // 
            // simpleButton_cancel
            // 
            this.simpleButton_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton_cancel.Location = new System.Drawing.Point(426, 42);
            this.simpleButton_cancel.Name = "simpleButton_cancel";
            this.simpleButton_cancel.Size = new System.Drawing.Size(99, 23);
            this.simpleButton_cancel.TabIndex = 3;
            this.simpleButton_cancel.Text = "取消";
            this.simpleButton_cancel.Click += new System.EventHandler(this.simpleButton_cancel_Click);
            // 
            // FormTopoSelect
            // 
            this.AcceptButton = this.simpleButton_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.CancelButton = this.simpleButton_cancel;
            this.ClientSize = new System.Drawing.Size(536, 297);
            this.ControlBox = true;
            this.Controls.Add(this.simpleButton_cancel);
            this.Controls.Add(this.simpleButton_ok);
            this.Controls.Add(this.checkedListBoxControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormTopoSelect";
            this.Text = "拓扑连接关系";
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ok;
        private DevExpress.XtraEditors.SimpleButton simpleButton_cancel;
    }
}
