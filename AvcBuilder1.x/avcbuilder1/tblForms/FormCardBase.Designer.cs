namespace avcbuilder1.tblForms
{
    partial class FormCardBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCardBase));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_Save = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_IniData = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Find = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("refresh2_32x32.png", "images/actions/refresh2_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/refresh2_32x32.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "refresh2_32x32.png");
            this.imageCollection1.InsertGalleryImage("show_32x32.png", "images/actions/show_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/show_32x32.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "show_32x32.png");
            this.imageCollection1.InsertGalleryImage("topbottomrules_32x32.png", "images/conditional%20formatting/topbottomrules_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/conditional%20formatting/topbottomrules_32x32.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "topbottomrules_32x32.png");
            this.imageCollection1.InsertGalleryImage("exportmodeldifferences_32x32.png", "images/data/exportmodeldifferences_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/data/exportmodeldifferences_32x32.png"), 3);
            this.imageCollection1.Images.SetKeyName(3, "exportmodeldifferences_32x32.png");
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.Location = new System.Drawing.Point(0, 50);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(759, 425);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ActiveFilterEnabled = false;
            this.gridView1.Appearance.CardCaption.Font = new System.Drawing.Font("Tahoma", 14F);
            this.gridView1.Appearance.CardCaption.Options.UseFont = true;
            this.gridView1.Appearance.CardCaption.Options.UseTextOptions = true;
            this.gridView1.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.EmptySpace.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.FieldCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.FieldCaption.Options.UseFont = true;
            this.gridView1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.FieldValue.Options.UseFont = true;
            this.gridView1.Appearance.FieldValue.Options.UseTextOptions = true;
            this.gridView1.Appearance.FieldValue.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.FocusedCardCaption.Font = new System.Drawing.Font("Tahoma", 14F);
            this.gridView1.Appearance.FocusedCardCaption.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionCardCaption.Font = new System.Drawing.Font("Tahoma", 14F);
            this.gridView1.Appearance.HideSelectionCardCaption.Options.UseFont = true;
            this.gridView1.Appearance.SelectedCardCaption.Font = new System.Drawing.Font("Tahoma", 14F);
            this.gridView1.Appearance.SelectedCardCaption.Options.UseFont = true;
            this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 14F);
            this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.CardCaptionFormat = "{1}";
            this.gridView1.CardInterval = 4;
            this.gridView1.CardScrollButtonBorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.CardWidth = 800;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.FocusedCardTopFieldIndex = 0;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AutoHorzWidth = true;
            this.gridView1.OptionsFind.FindNullPrompt = "";
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsView.ShowCardExpandButton = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowLines = false;
            this.gridView1.OptionsView.ShowQuickCustomizeButton = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = " ";
            this.gridView1.ViewCaptionHeight = 30;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.MinWidth = 60;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.simpleButton_Save);
            this.panelControl1.Controls.Add(this.simpleButton_IniData);
            this.panelControl1.Controls.Add(this.simpleButton_Refresh);
            this.panelControl1.Controls.Add(this.simpleButton_Find);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(759, 50);
            this.panelControl1.TabIndex = 3;
            // 
            // simpleButton_Save
            // 
            this.simpleButton_Save.ImageIndex = 3;
            this.simpleButton_Save.ImageList = this.imageCollection1;
            this.simpleButton_Save.Location = new System.Drawing.Point(139, 5);
            this.simpleButton_Save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton_Save.Name = "simpleButton_Save";
            this.simpleButton_Save.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.simpleButton_Save.Size = new System.Drawing.Size(40, 40);
            this.simpleButton_Save.TabIndex = 3;
            this.simpleButton_Save.ToolTip = "保存表格内容到数据库。";
            // 
            // simpleButton_IniData
            // 
            this.simpleButton_IniData.ImageIndex = 2;
            this.simpleButton_IniData.ImageList = this.imageCollection1;
            this.simpleButton_IniData.Location = new System.Drawing.Point(94, 5);
            this.simpleButton_IniData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton_IniData.Name = "simpleButton_IniData";
            this.simpleButton_IniData.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.simpleButton_IniData.Size = new System.Drawing.Size(40, 40);
            this.simpleButton_IniData.TabIndex = 2;
            this.simpleButton_IniData.ToolTip = "自动填写默认数据，会覆盖原数据。";
            // 
            // simpleButton_Refresh
            // 
            this.simpleButton_Refresh.ImageIndex = 0;
            this.simpleButton_Refresh.ImageList = this.imageCollection1;
            this.simpleButton_Refresh.Location = new System.Drawing.Point(48, 5);
            this.simpleButton_Refresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton_Refresh.Name = "simpleButton_Refresh";
            this.simpleButton_Refresh.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.simpleButton_Refresh.Size = new System.Drawing.Size(40, 40);
            this.simpleButton_Refresh.TabIndex = 1;
            this.simpleButton_Refresh.ToolTip = "从数据库刷新数据";
            // 
            // simpleButton_Find
            // 
            this.simpleButton_Find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.simpleButton_Find.ImageIndex = 1;
            this.simpleButton_Find.ImageList = this.imageCollection1;
            this.simpleButton_Find.Location = new System.Drawing.Point(2, 5);
            this.simpleButton_Find.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton_Find.Name = "simpleButton_Find";
            this.simpleButton_Find.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.simpleButton_Find.Size = new System.Drawing.Size(40, 40);
            this.simpleButton_Find.TabIndex = 0;
            this.simpleButton_Find.ToolTip = "显示或隐藏搜索栏";
            this.simpleButton_Find.Click += new System.EventHandler(this.simpleButton_Find_Click);
            // 
            // FormCardBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(759, 475);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormCardBase";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection1;
        public DevExpress.XtraGrid.GridControl gridControl1;
        protected DevExpress.XtraEditors.PanelControl panelControl1;
        protected DevExpress.XtraEditors.SimpleButton simpleButton_Save;
        protected DevExpress.XtraEditors.SimpleButton simpleButton_IniData;
        protected DevExpress.XtraEditors.SimpleButton simpleButton_Refresh;
        protected DevExpress.XtraEditors.SimpleButton simpleButton_Find;
        public DevExpress.XtraGrid.Views.Card.CardView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
