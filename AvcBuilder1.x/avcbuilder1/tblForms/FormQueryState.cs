using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AvcDb.entities;
using mysqlDao_v1;
using DevExpress.XtraGrid.Columns;

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

        DataSet ds;

        private FormQueryState() : base()
        {

            instance = this;
            InitializeComponent();
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            simpleButton_Save.Click += SimpleButton_Save_Click;
            //gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            //gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;

            // gridView1.InitNewRow += GridView1_InitNewRow;
        }

        private void SimpleButton_Save_Click(object sender, EventArgs e)
        {
            if (MsgBox("确定保存到数据库吗,原有数据将会被覆盖?", "保存提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            SaveData(ds.Tables[0], new tblelementstate(),"id");
            MsgBox("已保存");
        }

        private void SaveData(DataTable dt, object EntityModel, string idCaption)
        {
            if (dt == null || dt.Rows.Count == 0) return;
            string[] fields = mysqlDao_v1.myFunc.getProperties(EntityModel);
            StringBuilder sbUpdateSet = new StringBuilder();
            StringBuilder sb4row = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                switch (dr.RowState)
                {
                    case DataRowState.Added:
                        {
                            sbUpdateSet.Clear();

                            mysqlDAO.FillPoco(EntityModel, dr);  //注意:fill函数应该为新增记录的id考虑自增和非自增的情况.
                            
                            string sql = mysqlDAO.getInsertSql(EntityModel);
                            sb4row.Append(sql).Append("\n");
                            break;
                        }
                    case DataRowState.Modified:
                        {
                            sbUpdateSet.Clear();
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                string caption = dt.Columns[i].Caption;
                                bool b = mysqlDao_v1.myFunc.ContainsField(fields, caption);
                                if (!b) continue;
                                if (!dr[i, DataRowVersion.Current].ToString().Equals(dr[i, DataRowVersion.Original].ToString()))
                                {
                                    sbUpdateSet.Append(dt.Columns[i].Caption).Append(" = '").Append(dr[i]).Append("',");
                                }
                            }
                            string sql = mysqlDAO.getUpdateSqlById(EntityModel, sbUpdateSet.ToString(), dr[idCaption].ToString());
                            sb4row.Append(sql).Append("\n");
                            break;
                        }

                    case DataRowState.Deleted:
                        {
                            break;
                        }
                }
            }
        }

        public override void DataLoadedHandle()
        {
            base.DataLoadedHandle();
        }

        public override void DataClosedHandle()
        {
            base.DataClosedHandle();
        }


        private void IniViewColumns()
        {

            if (gridView1.Columns.Count > 0) { return; }
            if (MysqlDao == null)
            {
                MsgBox("未连接数据库.");
                return;
            }
            gridView1.BeginUpdate();
            GridColumn cur = AddGridColumn("name", "设备名称");
            cur.Fixed = FixedStyle.Left;
            cur.BestFit();

            DataTable dt = MysqlDao.GetFieldComment("tblelementstate");
            foreach (DataRow dr in dt.Rows)
            {
                AddGridColumn(dr[0].ToString(), dr[1].ToString());
            }
            gridView1.EndUpdate();
        }

        private GridColumn AddGridColumn(string Field, string Caption)
        {
            GridColumn col = gridView1.Columns.Add();
            col.FieldName = Field;
            col.Caption = Caption;
            col.CustomizationCaption = Caption;

            col.MinWidth = 70;
            col.Visible = true;
            return col;
        }


        string curSql = "";
        public override void QueryByFeedId(string FeedId)
        {
            //gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            tblelement ele = new tblelement();
            tblelementstate sta = new tblelementstate();
            curSql = mysqlDao_v1.mysqlDAO.getLeftJoinQuerySql(ele, sta, "name", "*", "id", "elementid", "t1.feedid=" + FeedId);

            QueryBySql(curSql);
        }

        public override void QueryById(string id)
        {
            tblelement ele = new tblelement();
            tblelementstate sta = new tblelementstate();
            curSql = mysqlDao_v1.mysqlDAO.getLeftJoinQuerySql(ele, sta, "name", "*", "id", "elementid", "t1.id=" + id);
            QueryBySql(curSql);
        }



        public override void QueryBySql(string sql)
        {

            MysqlDao = FormConnectSrv.Instance.MySqlDao;
            if (MysqlDao == null) return;
            try
            {
                IniViewColumns();
                if (ds == null)
                {
                    ds = new DataSet();
                    ds.Tables.Add();
                }

                DataTable dt = ds.Tables[0];
                MysqlDao.Query(sql, ref dt);
                //foreach(DataColumn dc in dt.Columns)
                //{
                //    Console.WriteLine(dc.ColumnName);
                //}
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
            }
        }


    }
}
