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
using DevExpress.XtraEditors.Repository;

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
            int r = dao.SaveData(ds.Tables[0], new tblelementstate(), "ELEMENTID");
            //SaveData(ds.Tables[0], new tblelementstate(),"ID");
            if (r < 0)
            {
                MsgBox("发生错误，保存失败");
            }
            else
                MsgBox(string.Format("保存记录 {0} 条", r));
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
            if (dao == null)
            {
                MsgBox("未连接数据库.");
                return;
            }
            gridView1.BeginUpdate();
            GridColumn cur = AddGridColumn("NAME", "设备名称");
            cur.Fixed = FixedStyle.Left;
            cur.BestFit();

            //更换中文列名
            DataTable dt = dao.GetFieldComment("tblelementstate");
            foreach (DataRow dr in dt.Rows)
            {
                GridColumn gridCol = AddGridColumn(dr[0].ToString(), dr[1].ToString());
                tblelementstate tbl = new tblelementstate();
                //tbl.CONTROLSTATE
                if (gridCol.FieldName.Equals("LOCKSTARTTIME"))
                {
                    gridCol.ColumnEdit = new RepositoryItemTimeEdit();
                }
                else if (gridCol.FieldName.Equals("CONTROLSTATE"))
                {
                    RepositoryItemComboBox box = new RepositoryItemComboBox();
                    box.Items.Add("不参与计算");
                    box.Items.Add("建议");
                    box.Items.Add("控制");
                    box.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor; //只能选择不能编辑文本。
                    gridCol.ColumnEdit = box;
                }
            }
            gridView1.EndUpdate();
        }

        /// <summary>
        /// 用中文名称添加视图的列
        /// </summary>
        /// <param name="tableField">数据库表的字段名</param>
        /// <param name="chineseCaption">中文名来自comment注释</param>
        /// <returns></returns>
        private GridColumn AddGridColumn(string tableField, string chineseCaption)
        {
            GridColumn col = gridView1.Columns.Add();
            col.FieldName = tableField;
            col.Caption = chineseCaption;
            col.CustomizationCaption = chineseCaption;

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
            curSql = mysqlDao_v1.mysqlDAO.getLeftJoinQuerySql(ele, sta, "ID,NAME", "*", "ID", "ELEMENTID", "L.FEEDID=" + FeedId);

            QueryBySql(curSql);
        }

        public override void QueryById(string id)
        {
            tblelement ele = new tblelement();
            tblelementstate sta = new tblelementstate();
            curSql = mysqlDao_v1.mysqlDAO.getLeftJoinQuerySql(ele, sta, "ID,NAME", "*", "ID", "ELEMENTID", "L.ID=" + id);
            QueryBySql(curSql);
        }



        public override void QueryBySql(string sql)
        {

            dao = FormConnectSrv.Instance.Dao;
            if (dao == null) return;
            try
            {
                IniViewColumns();
                if (ds == null)
                {
                    ds = new DataSet();
                    ds.Tables.Add();
                }

                DataTable dt = ds.Tables[0];
                dao.Query(sql, ref dt);
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
