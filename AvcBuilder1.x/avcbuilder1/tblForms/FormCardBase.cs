﻿using System;
using System.Data;
using mysqlDao_v1;
using DevExpress.XtraGrid.Columns;

namespace avcbuilder1.tblForms
{
    public partial class FormCardBase : avcbuilder1.tblForms.FormBase
    {
        protected string avc_conn = "";
        protected mysqlDAO dao;
        protected myConnInfo conninfo;
        protected DataSet ds;

        protected FormCardBase():base()
        {
            InitializeComponent();
            
        }

        public override void Ini()
        {
            FormMain.Instance.AvcTreeFocusChanged += Instance_AvcTreeFocusChanged;
            FormMain.Instance.AvcSrvDisconnected += Instance_AvcSrvDisconnected;
            FormMain.Instance.AvcSrvConnected += Instance_AvcSrvConnected;
            gridView1.HideFindPanel();
            SetButtonsEnable(false);
        }

        private void Instance_AvcSrvConnected(object sender, EventArgs e)
        {
            Enabled = true;
        }

        private void Instance_AvcSrvDisconnected(object sender, EventArgs e)
        {
            Enabled = false;
            SetCaption(" ");
        }



        AvcTreeEventArgs oldAvcEvent = null;
        private void Instance_AvcTreeFocusChanged(object sender, AvcTreeEventArgs e)
        {
            int vt = (int)e.IdType;
            if (vt > 3 && vt < 8)
            {
                oldAvcEvent = e;
                if (Visible)
                {
                    QueryById(e.Id, e.IdType);
                    SetCaption(e.Caption);
                }
            }
        }

        public override void RefreshForm()
        {
            if (!Enabled) return;
            base.RefreshForm();
            if (oldAvcEvent != null)
            {
                QueryById(oldAvcEvent.Id, oldAvcEvent.IdType);
                SetCaption(oldAvcEvent.Caption);
            }
        }

        public virtual void SetCaption(string caption)
        {
            gridView1.ViewCaption = caption;
        }

        /// <summary>
        /// 用中文名称添加视图的列
        /// </summary>
        /// <param name="tableField">数据库表的字段名</param>
        /// <param name="chineseCaption">中文名来自comment注释</param>
        /// <returns></returns>
        protected GridColumn AddGridColumn(string tableField, string chineseCaption)
        {
            GridColumn col = gridView1.Columns.Add();
            col.FieldName = tableField;
            col.Caption = chineseCaption;
            col.CustomizationCaption = chineseCaption;

            col.MinWidth = 70;
            col.Visible = true;
            return col;
        }

        /// <summary>
        /// 根据value值，设置保存，刷新，数据初始化，查找按钮的有效性值。
        /// </summary>
        /// <param name="value">button.enabled = value</param>
        protected void SetButtonsEnable(bool value)
        {
            simpleButton_Save.Enabled = simpleButton_Refresh.Enabled = simpleButton_IniData.Enabled = simpleButton_Find.Enabled = value;
        }


        virtual public void QueryById(String Id, AvcIdType IdType) { }

        protected bool findpanel_visible = true;
        private void simpleButton_Find_Click(object sender, EventArgs e)
        {
            if (findpanel_visible)
                gridView1.ShowFindPanel();
            else
                gridView1.HideFindPanel();
            findpanel_visible = !findpanel_visible;
        }
    }//class
}
