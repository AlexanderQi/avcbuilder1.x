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
            this.simpleButton_IniData = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.simpleButton_Apply = new DevExpress.XtraEditors.SimpleButton();
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
            this.gridControl1.Location = new System.Drawing.Point(0, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(883, 456);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = ".";
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "编辑此处增加新行";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView1.OptionsFind.FindNullPrompt = "";
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.simpleButton_IniData);
            this.panelControl1.Controls.Add(this.simpleButton_Apply);
            this.panelControl1.Controls.Add(this.simpleButton_Find);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(883, 38);
            this.panelControl1.TabIndex = 1;
            // 
            // simpleButton_IniData
            // 
            this.simpleButton_IniData.ImageIndex = 6;
            this.simpleButton_IniData.ImageList = this.imageCollection1;
            this.simpleButton_IniData.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButton_IniData.Location = new System.Drawing.Point(83, 2);
            this.simpleButton_IniData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton_IniData.Name = "simpleButton_IniData";
            this.simpleButton_IniData.Size = new System.Drawing.Size(81, 33);
            this.simpleButton_IniData.TabIndex = 2;
            this.simpleButton_IniData.Text = "初始化数据";
            this.simpleButton_IniData.ToolTip = "自动填写默认数据，会覆盖原数据。";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("show_32x32.png", "images/actions/show_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/show_32x32.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "show_32x32.png");
            this.imageCollection1.InsertGalleryImage("add_32x32.png", "images/actions/add_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_32x32.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "add_32x32.png");
            this.imageCollection1.InsertGalleryImage("remove_32x32.png", "images/actions/remove_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_32x32.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "remove_32x32.png");
            this.imageCollection1.InsertGalleryImage("editname_32x32.png", "images/actions/editname_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/editname_32x32.png"), 3);
            this.imageCollection1.Images.SetKeyName(3, "editname_32x32.png");
            this.imageCollection1.InsertGalleryImage("apply_32x32.png", "images/actions/apply_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_32x32.png"), 4);
            this.imageCollection1.Images.SetKeyName(4, "apply_32x32.png");
            this.imageCollection1.InsertGalleryImage("cancel_32x32.png", "images/actions/cancel_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_32x32.png"), 5);
            this.imageCollection1.Images.SetKeyName(5, "cancel_32x32.png");
            this.imageCollection1.InsertGalleryImage("bodepartment_32x32.png", "images/business%20objects/bodepartment_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bodepartment_32x32.png"), 6);
            this.imageCollection1.Images.SetKeyName(6, "bodepartment_32x32.png");
            // 
            // simpleButton_Apply
            // 
            this.simpleButton_Apply.ImageIndex = 4;
            this.simpleButton_Apply.ImageList = this.imageCollection1;
            this.simpleButton_Apply.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButton_Apply.Location = new System.Drawing.Point(42, 2);
            this.simpleButton_Apply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton_Apply.Name = "simpleButton_Apply";
            this.simpleButton_Apply.Size = new System.Drawing.Size(37, 33);
            this.simpleButton_Apply.TabIndex = 1;
            this.simpleButton_Apply.Text = "提交";
            this.simpleButton_Apply.ToolTip = "将修改内容提交数据库";
            // 
            // simpleButton_Find
            // 
            this.simpleButton_Find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.simpleButton_Find.ImageIndex = 0;
            this.simpleButton_Find.ImageList = this.imageCollection1;
            this.simpleButton_Find.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButton_Find.Location = new System.Drawing.Point(2, 2);
            this.simpleButton_Find.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton_Find.Name = "simpleButton_Find";
            this.simpleButton_Find.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.simpleButton_Find.Size = new System.Drawing.Size(37, 33);
            this.simpleButton_Find.TabIndex = 0;
            this.simpleButton_Find.Text = "搜索";
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
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        protected DevExpress.XtraEditors.SimpleButton simpleButton_Find;
        protected DevExpress.XtraEditors.SimpleButton simpleButton_IniData;
        protected DevExpress.XtraEditors.SimpleButton simpleButton_Apply;
    }
}
