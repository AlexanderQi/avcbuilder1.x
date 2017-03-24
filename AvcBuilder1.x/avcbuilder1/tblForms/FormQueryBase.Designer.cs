namespace avcbuilder1.tblForms
{
    partial class FormQueryBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQueryBase));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_Save = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.simpleButton_copy = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Find = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 50);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(883, 444);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 14F);
            this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.FindNullPrompt = "";
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.RowHeight = 30;
            this.gridView1.ViewCaption = " ";
            this.gridView1.ViewCaptionHeight = 30;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.simpleButton_Save);
            this.panelControl1.Controls.Add(this.simpleButton_copy);
            this.panelControl1.Controls.Add(this.simpleButton_Refresh);
            this.panelControl1.Controls.Add(this.simpleButton_Find);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(883, 50);
            this.panelControl1.TabIndex = 1;
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
            // simpleButton_copy
            // 
            this.simpleButton_copy.ImageIndex = 2;
            this.simpleButton_copy.ImageList = this.imageCollection1;
            this.simpleButton_copy.Location = new System.Drawing.Point(94, 5);
            this.simpleButton_copy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton_copy.Name = "simpleButton_copy";
            this.simpleButton_copy.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.simpleButton_copy.Size = new System.Drawing.Size(40, 40);
            this.simpleButton_copy.TabIndex = 2;
            this.simpleButton_copy.ToolTip = "复制数据到新行";
            this.simpleButton_copy.Click += new System.EventHandler(this.simpleButton_copy_Click);
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
            // FormQueryBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(883, 494);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormQueryBase";
            this.Text = "状态";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        protected DevExpress.XtraEditors.SimpleButton simpleButton_Find;
        protected DevExpress.XtraEditors.SimpleButton simpleButton_copy;
        protected DevExpress.XtraEditors.SimpleButton simpleButton_Refresh;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        protected DevExpress.XtraEditors.SimpleButton simpleButton_Save;
    }
}
