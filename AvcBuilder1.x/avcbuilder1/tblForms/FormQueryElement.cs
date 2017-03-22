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
    public partial class FormQueryElement : avcbuilder1.tblForms.FormQueryBase
    {
        public FormQueryElement() : base()
        {
            InitializeComponent();
        }

        public DialogResult ShowEditModal(AvcTreeEventArgs ae)
        {
            if (ae == null) return DialogResult.None;
            try
            {
                gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                SetCaption(ae.Caption);
                QueryById(ae.Id, ae.IdType);
                return ShowDialog();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                MsgBox(e.Message);
                return DialogResult.None;
            }

        }

        public DialogResult ShowAddModal(AvcTreeEventArgs ae)
        {
            if (ae == null) return DialogResult.None;
            try
            {
                gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;

                SetCaption(ae.ParentCaption + " ▶ " + ae.Caption);
                AvcIdType targetType = (AvcIdType)(ae.tag);
                return QueryAndAdd(ae.IdType, ae.Id,targetType);
               
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                MsgBox(e.Message);
                return DialogResult.None;
            }

        }

        public override void Ini()
        {
            base.Ini();
           
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            simpleButton_Save.Click += SimpleButton_Save_Click;
            simpleButton_Refresh.Click += SimpleButton_Refresh_Click;
            FormMain.Instance.AvcSrvConnected += Instance_OnAvcSrvConnected;
            FormMain.Instance.AvcSrvDisconnected += Instance_OnAvcSrvDisconnected;
            //gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            //gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.InitNewRow += GridView1_InitNewRow;
        }



        private void GridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[PkName], PkValue);
        }

        private void Instance_OnAvcSrvDisconnected(object sender, EventArgs e)
        {
            SetButtonsEnable(false);
            if (ds.Tables.Count > 0)
                ds.Tables[0].Clear();

        }

        private void Instance_OnAvcSrvConnected(object sender, EventArgs e)
        {
            IniViewColumns();
            SimpleButton_Refresh_Click(null, null);
        }

        private void SimpleButton_Refresh_Click(object sender, EventArgs e)
        {
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

            //此处应该做必填项检查。
            try
            {
                PkName = "ID";
                int r = dao.SaveData(ds.Tables[0], curPoco, PkName);
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


        private void IniViewColumns()
        {
            if (curPoco == null) return;
            if (gridView1.Columns.Count > 0) { gridView1.Columns.Clear(); }
            if (dao == null)
            {
                dao = FormConnectSrv.Instance.Dao;
            }
            gridView1.BeginUpdate();
            //GridColumn cur = AddGridColumn("ENAME", "设备名称");
            //cur.Fixed = FixedStyle.Left;
            //cur.BestFit();

            Type t = curPoco.GetType();
            string curTabName = t.Name;
            DataTable dt = dao.GetFieldComment(curTabName);//更换中文列名
            foreach (DataRow dr in dt.Rows)
            {
                GridColumn gridCol = AddGridColumn(dr[0].ToString(), dr[1].ToString());
                if (gridCol.FieldName.Equals(PkName))
                {
                    gridCol.Visible = false;
                    //gridCol.Fixed = FixedStyle.Left;
                    //gridCol.OptionsColumn.AllowEdit = false;
                }
                if (gridCol.FieldName.ToUpper().Equals("ID"))
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


        public override void Query(string pkName, string pkValue)
        {
            object poco = PocoFactory.getPocoByName(PrimeTableName);
            PkName = pkName;
            PkValue = pkValue;
            curSql = mysqlDao_v1.mysqlDAO.getQuerySql(poco, pkName, pkValue);
            QueryBySql(curSql);
        }

        string curSql = null;
        string PkValue = null;
        AvcIdType idType = AvcIdType.OtherId;
        object curPoco = null;
        string PkName = null;
        public override void QueryById(string Id, AvcIdType IdType)
        {
            PkValue = Id;
            idType = IdType;
            PkName = "ID";
            try
            {
                curPoco = PocoFactory.getPocoByName(PrimeTableName);
                curSql = mysqlDao_v1.mysqlDAO.getQuerySql(curPoco, PkName, PkValue);
                QueryBySql(curSql);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
            }
        }

        public DialogResult QueryAndAdd(AvcIdType currentType, string IdFromParentOfFocusNode, AvcIdType TargetType)
        {
            curPoco = null;
            PkValue = IdFromParentOfFocusNode;
            if (currentType == AvcIdType.ServerId)
            {
                PkName = "ID";
                curPoco = new tblsubcontrolarea();
            }
            if (currentType == AvcIdType.AreaId)
            {
                PkName = "SUBCONTROLAREAID";
                curPoco = new tblsubstation();
            }
            else if (currentType == AvcIdType.StationId)
            {
                PkName = "SUBSTATIONID";
                curPoco = new tblfeeder();
            }
            else if (currentType == AvcIdType.CapId)
            {
                PkName = "FEEDCAPACITORID";
                curPoco = new tblfeedcapacitoritem();
            }


            if (currentType == AvcIdType.FeedId)
            {
                if (TargetType == AvcIdType.CapId)
                {
                    PkName = "FEEDID";
                    curPoco = new tblfeedcapacitor();
                }
                else if (TargetType == AvcIdType.TransId)
                {
                    PkName = "FEEDID";
                    curPoco = new tblfeedtrans();
                }
                else if (TargetType == AvcIdType.VolRegId)
                {
                    PkName = "FEEDID";
                    curPoco = new tblfeedvoltageregulator();
                }
            }

            if(curPoco == null)
            {
                MsgBox("Id类型错误,添加失败");
                return DialogResult.None;
            }
            string sql_where = string.Format("{0} = {1};", PkName, PkValue);
            curSql = mysqlDao_v1.mysqlDAO.getQuerySql(curPoco, sql_where);
            QueryBySql(curSql);
            gridView1.AddNewRow();
            this.DialogResult = DialogResult.OK;
            return ShowDialog();
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
                SetButtonsEnable(true);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
            }
        }
    }//class
}
