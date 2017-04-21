namespace avcbuilder1.tblForms
{
    partial class FormYkYtExpri
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
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.listBoxControl_yk = new DevExpress.XtraEditors.ListBoxControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.radioButton_up = new System.Windows.Forms.RadioButton();
            this.radioButton_down = new System.Windows.Forms.RadioButton();
            this.simpleButton_yk = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_yt = new DevExpress.XtraEditors.SimpleButton();
            this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            this.listBoxControl_yt = new DevExpress.XtraEditors.ListBoxControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl_yk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl_yt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(775, 489);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.simpleButton_yk);
            this.xtraTabPage1.Controls.Add(this.radioButton_down);
            this.xtraTabPage1.Controls.Add(this.radioButton_up);
            this.xtraTabPage1.Controls.Add(this.memoEdit1);
            this.xtraTabPage1.Controls.Add(this.listBoxControl_yk);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(768, 453);
            this.xtraTabPage1.Text = "遥控";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.labelControl1);
            this.xtraTabPage2.Controls.Add(this.textEdit1);
            this.xtraTabPage2.Controls.Add(this.simpleButton_yt);
            this.xtraTabPage2.Controls.Add(this.memoEdit2);
            this.xtraTabPage2.Controls.Add(this.listBoxControl_yt);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(768, 453);
            this.xtraTabPage2.Text = "遥调";
            // 
            // listBoxControl_yk
            // 
            this.listBoxControl_yk.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxControl_yk.Location = new System.Drawing.Point(0, 0);
            this.listBoxControl_yk.Name = "listBoxControl_yk";
            this.listBoxControl_yk.Size = new System.Drawing.Size(256, 453);
            this.listBoxControl_yk.TabIndex = 0;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.memoEdit1.Location = new System.Drawing.Point(256, 0);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(512, 318);
            this.memoEdit1.TabIndex = 1;
            // 
            // radioButton_up
            // 
            this.radioButton_up.AutoSize = true;
            this.radioButton_up.Location = new System.Drawing.Point(262, 340);
            this.radioButton_up.Name = "radioButton_up";
            this.radioButton_up.Size = new System.Drawing.Size(95, 22);
            this.radioButton_up.TabIndex = 2;
            this.radioButton_up.TabStop = true;
            this.radioButton_up.Text = "升档/合闸";
            this.radioButton_up.UseVisualStyleBackColor = true;
            // 
            // radioButton_down
            // 
            this.radioButton_down.AutoSize = true;
            this.radioButton_down.Location = new System.Drawing.Point(262, 377);
            this.radioButton_down.Name = "radioButton_down";
            this.radioButton_down.Size = new System.Drawing.Size(95, 22);
            this.radioButton_down.TabIndex = 3;
            this.radioButton_down.TabStop = true;
            this.radioButton_down.Text = "降档/分闸";
            this.radioButton_down.UseVisualStyleBackColor = true;
            // 
            // simpleButton_yk
            // 
            this.simpleButton_yk.Location = new System.Drawing.Point(262, 418);
            this.simpleButton_yk.Name = "simpleButton_yk";
            this.simpleButton_yk.Size = new System.Drawing.Size(123, 25);
            this.simpleButton_yk.TabIndex = 4;
            this.simpleButton_yk.Text = "发送遥控指令";
            // 
            // simpleButton_yt
            // 
            this.simpleButton_yt.Location = new System.Drawing.Point(542, 339);
            this.simpleButton_yt.Name = "simpleButton_yt";
            this.simpleButton_yt.Size = new System.Drawing.Size(123, 25);
            this.simpleButton_yt.TabIndex = 7;
            this.simpleButton_yt.Text = "发送遥调指令";
            // 
            // memoEdit2
            // 
            this.memoEdit2.Dock = System.Windows.Forms.DockStyle.Top;
            this.memoEdit2.Location = new System.Drawing.Point(256, 0);
            this.memoEdit2.Name = "memoEdit2";
            this.memoEdit2.Size = new System.Drawing.Size(512, 318);
            this.memoEdit2.TabIndex = 6;
            // 
            // listBoxControl_yt
            // 
            this.listBoxControl_yt.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxControl_yt.Location = new System.Drawing.Point(0, 0);
            this.listBoxControl_yt.Name = "listBoxControl_yt";
            this.listBoxControl_yt.Size = new System.Drawing.Size(256, 453);
            this.listBoxControl_yt.TabIndex = 5;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(313, 340);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(209, 24);
            this.textEdit1.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(262, 343);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 18);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "遥调值";
            // 
            // FormYkYtExpri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.ClientSize = new System.Drawing.Size(775, 489);
            this.ControlBox = true;
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormYkYtExpri";
            this.Text = "AVC Builder 遥控遥调试验";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl_yk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl_yt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_yk;
        private System.Windows.Forms.RadioButton radioButton_down;
        private System.Windows.Forms.RadioButton radioButton_up;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl_yk;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_yt;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl_yt;
    }
}
