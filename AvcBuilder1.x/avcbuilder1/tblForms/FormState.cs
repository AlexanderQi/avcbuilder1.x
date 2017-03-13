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
    public partial class FormState : avcbuilder1.tblForms.FormBase
    {

        new public static FormBase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormState();
                }
                return instance;
            }
        }

        public FormState()
        {
            instance = this;
            InitializeComponent();
            gridView1.ShowFindPanel();
        }

        DataTable mdt;
        override public void Query(string sql)
        {
            MysqlDao = FormConnectSrv.Instance.MySqlDao;
            if (MysqlDao == null) return;
            try
            {
                if(sql == null)
                {
                    sql = @"select t.name,e.ELEMENTID,e.CONTROLSTATE 控制状态,e.HANDUNLOCKPROTECTIONSTATE 人工保护,
e.AUTOUNLOCKPROTECTIONSTATE 自动保护, e.EXCEPTIONSTATE 异常状态,
 e.ACTIONOUTSTATE 动作次数, e.BELOCKSTATE 闭锁状态, e.LOCKSTARTTIME 闭锁时间
 from tblelement t left
 join tblelementstate e on t.id = e.ELEMENTID";
                }
                mdt = MysqlDao.Query(sql);
                gridControl1.DataSource = mdt;
                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridView1.ShowFindPanel();
        }
    }
}
