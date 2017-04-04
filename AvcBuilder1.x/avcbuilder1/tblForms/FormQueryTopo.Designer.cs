namespace avcbuilder1.tblForms
{
    partial class FormQueryTopo
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_iniTopo = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lookUpEdit1);
            this.panelControl1.Controls.Add(this.simpleButton_iniTopo);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.SetChildIndex(this.simpleButton_Find, 0);
            this.panelControl1.Controls.SetChildIndex(this.simpleButton_Refresh, 0);
            this.panelControl1.Controls.SetChildIndex(this.simpleButton_copy, 0);
            this.panelControl1.Controls.SetChildIndex(this.simpleButton_Save, 0);
            this.panelControl1.Controls.SetChildIndex(this.labelControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.simpleButton_iniTopo, 0);
            this.panelControl1.Controls.SetChildIndex(this.lookUpEdit1, 0);
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.DisplayFormat.FormatString = "MM-dd HH:mm:ss";
            this.repositoryItemTimeEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit1.EditFormat.FormatString = "HH:mm:ss";
            this.repositoryItemTimeEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit1.Mask.EditMask = "HH:mm:ss";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(198, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "馈线：";
            // 
            // simpleButton_iniTopo
            // 
            this.simpleButton_iniTopo.Location = new System.Drawing.Point(347, 23);
            this.simpleButton_iniTopo.Name = "simpleButton_iniTopo";
            this.simpleButton_iniTopo.Size = new System.Drawing.Size(112, 21);
            this.simpleButton_iniTopo.TabIndex = 6;
            this.simpleButton_iniTopo.Text = "初始化拓扑信息";
            this.simpleButton_iniTopo.Click += new System.EventHandler(this.simpleButton_iniTopo_Click);
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(198, 23);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(143, 20);
            this.lookUpEdit1.TabIndex = 7;
            // 
            // FormQueryTopo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(883, 448);
            this.ControlBox = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = false;
            this.Name = "FormQueryTopo";
            this.Text = "拓扑信息";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton simpleButton_iniTopo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
    }
}
