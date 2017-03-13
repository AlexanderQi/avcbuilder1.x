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
            gridView1.ShowFindPanel();
        }

        virtual public void QueryById(String id) { }

        //DataTable mdt;
        virtual public void QueryBySql(string sql)
        {
//           
        }

    }
}
