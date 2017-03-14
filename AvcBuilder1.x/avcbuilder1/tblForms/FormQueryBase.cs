using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using log4net;
using mysqlDao_v1;
using System.Configuration;
using System.Collections;


namespace avcbuilder1.tblForms
{
    public partial class FormQueryBase : avcbuilder1.tblForms.FormBase
    {
        protected string avc_conn = "";
        protected mysqlDAO MysqlDao;
        protected myConnInfo conninfo;

       /// <summary>
       /// 暴露类单例属性，由子类实现。
       /// </summary>
        public static FormQueryBase Instance
        {
            get {return null;}
        }

        protected FormQueryBase()
        {
            InitializeComponent();
            gridView1.HideFindPanel();
            SetButtonsEnable(false);

        }

        virtual public void DataLoadedHandle()
        {
            SetButtonsEnable(true);
        }

        virtual public void DataClosedHandle()
        {
            SetButtonsEnable(false);
        }
      
        protected void SetButtonsEnable(bool value)
        {
            simpleButton_Apply.Enabled = simpleButton_IniData.Enabled = simpleButton_Find.Enabled = value;
        }

        virtual public void QueryByAreaId(String FeedId) { }
        virtual public void QueryByStationId(String FeedId) { }
        virtual public void QueryByFeedId(String FeedId) { }
        virtual public void QueryById(String Id) { }
        virtual public void QueryBySql(String Sql) { }

        protected bool findpanel_visible = true;
        private void simpleButton_Find_Click(object sender, EventArgs e)
        {
            if (findpanel_visible)
                gridView1.ShowFindPanel();
            else
                gridView1.HideFindPanel();
            findpanel_visible = !findpanel_visible;
        }
    }
}
