using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace avcbuilder1.tblForms
{
    public partial class FormQueryState : FormQueryBase
    {
        private static FormQueryState instance;
        new public static FormQueryBase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormQueryState();
                }
                return instance;
            }
        }

        private FormQueryState()
        {
            instance = this;
            InitializeComponent();
        }

        static private string QueryString = @"select t.ID,t.name 名称,e.CONTROLSTATE 控制状态,e.HANDUNLOCKPROTECTIONSTATE 人工保护,e.AUTOUNLOCKPROTECTIONSTATE 自动保护, e.EXCEPTIONSTATE 异常状态,
             e.ACTIONOUTSTATE 动作次数, e.BELOCKSTATE 闭锁状态, e.LOCKSTARTTIME 闭锁时间,
e.FAILURELOCKSEC 失败闭锁时间, e.SLIPTAPLOCKSEC 滑档闭锁时间, e.REPEATEDFAILURELOCKSEC 连续失败闭锁时间,
e.REPEATEDFAILURECOUNT 连续失败次数, e.MAXREPEATEDFAILURECOUNT 最大连续失败次数
 from tblelement t left join tblelementstate e on t.id = e.ELEMENTID";

        //       static private string Sql = @"select t.ID, t.name 名称,e.ADVICELOCKSEC 建议闭锁时间,e.PREPARLOCKSEC 预置闭锁时间,e.SUCCESSLOCKSEC 成功闭锁时间,
        //e.FAILURELOCKSEC 失败闭锁时间, e.SLIPTAPLOCKSEC 滑档闭锁时间, e.REPEATEDFAILURELOCKSEC 连续失败闭锁时间,
        //e.REPEATEDFAILURECOUNT 连续失败次数, e.MAXREPEATEDFAILURECOUNT 最大连续失败次数
        //from tblelement t  left join tblelementstate e on t.id = e.ELEMENTID";
        public override void QueryById(string id)
        {
            string sql = QueryString + " where id=" + id;
            QueryBySql(sql);
        }



        DataTable mdt;
        public override void QueryBySql(string sql)
        {
            MysqlDao = FormConnectSrv.Instance.MySqlDao;
            if (MysqlDao == null) return;
            try
            {
                if (sql == null)
                {
                    sql = QueryString;
                }
                mdt = MysqlDao.Query(sql);
                gridControl1.DataSource = mdt;
                gridView1.BeginUpdate();
                gridView1.Columns[0].Visible = false; //id field
                gridView1.Columns[1].BestFit();
                gridView1.Columns[1].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;  //name field
                for(int i=0;i<gridView1.Columns.Count;i++)
                {
                    if (i <= 1) continue;
                    gridView1.Columns[i].MinWidth = 60;
                    gridView1.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                }
                gridView1.EndUpdate();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
            }
        }


    }
}
