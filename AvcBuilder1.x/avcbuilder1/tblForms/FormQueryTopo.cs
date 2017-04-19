using System;
using System.Data;
using System.Windows.Forms;
using AvcDb.entities;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using avcbuilder1.tblForms;
using avcbuilder1;
using DevExpress.XtraGrid.Views.Grid;

namespace avcbuilder1.tblForms
{
    public partial class FormQueryTopo : avcbuilder1.tblForms.FormQueryBase
    {
        public FormQueryTopo()
        {
            InitializeComponent();
        }

        public override void Ini()
        {
            base.Ini();
            //gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
           
            simpleButton_Save.Click += SimpleButton_Save_Click;
            simpleButton_Refresh.Click += SimpleButton_Refresh_Click;
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            // gridView1.InitNewRow += GridView1_InitNewRow;
            FormMain.Instance.AvcSrvConnected += Instance_OnAvcSrvConnected;
            FormMain.Instance.AvcSrvDisconnected += Instance_OnAvcSrvDisconnected;
            gridView1.OptionsView.ShowViewCaption = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            lookUpEdit1.Properties.DisplayMember = "NAME";
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.EditValueChanged += LookUpEdit1_EditValueChanged;
            Shown += FormQueryTopo_Shown;
        }

        private void LookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string fid = lookUpEdit1.EditValue.ToString();
            //tblgraphtopoterminal gt = new tblgraphtopoterminal();
            QueryById(fid, AvcIdType.FeedId);
            simpleButton_copy.Enabled = false;
        }

        private void FormQueryTopo_Shown(object sender, EventArgs e)
        {
            IniLookupEdit();
        }

        public void IniLookupEdit()
        {
            string sql = "select ID,NAME from tblfeeder;";
            if (dao == null)
            {
                dao = FormConnectSrv.Instance.Dao;
            }
            DataTable fdt = dao.Query(sql);
            lookUpEdit1.Properties.DataSource = fdt;
        }
        //private void GridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        //{
        //    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["FEEDID"], curId);
        //    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["ROWID"], 0);
        //}

        private void Instance_OnAvcSrvDisconnected(object sender, EventArgs e)
        {
            SetButtonsEnable(false);
            if (ds != null && ds.Tables.Count > 0)
                ds.Tables[0].Clear();

        }

        private void Instance_OnAvcSrvConnected(object sender, EventArgs e)
        {
            IniViewColumns();
            SimpleButton_Refresh_Click(null, null);
        }

        private void SimpleButton_Refresh_Click(object sender, EventArgs e)
        {
            IniLookupEdit();
            if (curSql != null)
            {
                QueryBySql(curSql);
            }
        }



        private void SimpleButton_Save_Click(object sender, EventArgs e)
        {

            if (MsgBox("确定保存到数据库吗,原有数据将会被覆盖?", "保存提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            
            string pkName = "ROWID";
            //此处应该做必填项检查。
            try
            {
               
                int r = dao.SaveData(ds.Tables[0], new tblgraphtopoterminal(), pkName);
                if (r < 0)
                {
                    MsgBox("发生错误，保存失败");
                }
                else
                    MsgBox(string.Format("操作成功， {0} 条记录。", r));
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }


        RepositoryItemButtonEdit linksButton = new RepositoryItemButtonEdit();
        private void IniViewColumns()
        {
            if (gridView1.Columns.Count > 0) { return; }
            if (dao == null)
            {
                dao = FormConnectSrv.Instance.Dao;
            }
            gridView1.BeginUpdate();
            linksButton.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis;
            linksButton.ButtonClick += LinksButton_ButtonClick;
           
            //GridColumn cur = AddGridColumn("ENAME", "设备名称");
            //cur.Fixed = FixedStyle.Left;
            //cur.BestFit();

            //更换中文列名
            DataTable dt = dao.GetFieldComment("tblgraphtopoterminal");
            foreach (DataRow dr in dt.Rows)
            {
                GridColumn gridCol = AddGridColumn(dr[0].ToString(), dr[1].ToString());
                if (gridCol.FieldName.Equals("ID"))
                {
                    gridCol.Fixed = FixedStyle.Left;
                    gridCol.OptionsColumn.AllowFocus = false;
                }
                else if (gridCol.FieldName.Equals("NAME"))
                {
                    gridCol.Fixed = FixedStyle.Left;
                    gridCol.OptionsColumn.AllowFocus = false;
                    gridCol.MinWidth = 200;
                }
                else if (gridCol.FieldName.Equals("FEEDID"))
                {
                    gridCol.Fixed = FixedStyle.Left;
                    gridCol.OptionsColumn.AllowFocus = false;
                }
                else if(gridCol.FieldName.Equals("LINKS"))
                {
                    gridCol.ColumnEdit = linksButton;
                    gridCol.MinWidth = 400;
                }
                else if (gridCol.FieldName.Equals("TAG"))
                {
                    gridCol.Fixed = FixedStyle.Left;
                    gridCol.OptionsColumn.AllowFocus = false;
                }
                else
                {
                    gridCol.Visible = false;
                }
                //if (gridCol.FieldName.Equals("LOCKSTARTTIME"))
                //{
                //    gridCol.ColumnEdit = new RepositoryItemTimeEdit();
                //}
                //else if (gridCol.FieldName.Equals("CONTROLSTATE"))
                //{
                //    RepositoryItemComboBox box = new RepositoryItemComboBox();
                //    box.Items.Add("不参与计算");
                //    box.Items.Add("建议");
                //    box.Items.Add("控制");
                //    box.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor; //只能选择不能编辑文本。
                //    gridCol.ColumnEdit = box;
                //}//if

            }//for
            gridView1.EndUpdate();
        }//func

        FormTopoSelect fts = null;
        private void LinksButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //MsgBox(gridView1.GetFocusedRowCellValue(gridView1.FocusedColumn).ToString());
            if(fts == null)
            {
                fts = new FormTopoSelect();
            }
            string links = gridView1.GetFocusedRowCellValue(gridView1.FocusedColumn).ToString();
            fts.ShowModal(curId, links);
            if (fts.NewLinks != null)
            {
                //gridView1.SetFocusedRowCellValue(gridView1.FocusedColumn, fts.NewLinks);
                gridView1.BeginUpdate();
                ds.Tables[0].Rows[gridView1.FocusedRowHandle][gridView1.FocusedColumn.ColumnHandle] = fts.NewLinks;
                gridView1.EndDataUpdate();
            }
               
        }

        string curSql = null;
        string curId = null;
        public override void QueryById(string Id, AvcIdType IdType)
        {
            curId = Id;
            tblgraphtopoterminal sta = new tblgraphtopoterminal();

            curSql = mysqlDao_v1.mysqlDAO.getQuerySql(sta, "FEEDID", Id);
            QueryBySql(curSql);

        }


        public void QueryBySql(string sql)
        {
            if (sql == null || sql.Equals("")) return;
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
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
                //if (ds.Tables[0].Rows.Count == 0)
                //{
                //    gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                //}
                //else
                //{
                //    gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                //}
                SetButtonsEnable(true);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
            }
        }

        private void simpleButton_iniTopo_Click(object sender, EventArgs e)
        {
            //TODO DS
            if (ds.Tables.Count == 0) return;

            if (MsgBox("将会覆盖以前的拓扑信息，是否继续？", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            tblgraphtopoterminal topo = new tblgraphtopoterminal();
            string sql = mysqlDao_v1.mysqlDAO.getDeleteSql(topo, "FEEDID", curId);
            dao.Execute(sql);

            gridView1.BeginUpdate();
            DataTable dt_topo = ds.Tables[0];  //tblgraphtopoterminal table
            dt_topo.Clear();
            string fid = curId;
            tblelement ele = new tblelement();
            sql = mysqlDao_v1.mysqlDAO.getQuerySql(ele, "FEEDID", fid);
            DataTable element_dt = dao.Query(sql);
            foreach(DataRow dr in element_dt.Rows)
            {
                DataRow newdr = dt_topo.NewRow();
                newdr["ROWID"] = 0;  //auto increment when the field's value is zero
                newdr["ID"] = dr["ID"];
                newdr["FEEDID"] = dr["FEEDID"];
                newdr["TAG"] = dr["ELEMENTSTYLE"];
                newdr["NAME"] = dr["NAME"];
                dt_topo.Rows.Add(newdr);
            }
            dao.SaveData(dt_topo, new tblgraphtopoterminal(), "ROWID");
            gridView1.EndUpdate();
            QueryBySql(curSql);
        }
    }
}
