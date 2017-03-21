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
    public partial class FormCardMeasure : avcbuilder1.tblForms.FormCardBase
    {
        public FormCardMeasure() : base()
        {
            InitializeComponent();
        }

        public override void Ini()
        {
            base.Ini();
            //gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
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
            //gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["ID"], curId);
        }

        private void Instance_OnAvcSrvDisconnected(object sender, EventArgs e)
        {
            SetButtonsEnable(false);
            if (ds.Tables.Count > 0)
                ds.Tables[0].Clear();

        }

        private void Instance_OnAvcSrvConnected(object sender, EventArgs e)
        {
            iniInplaceEditors();
            //IniViewColumns();
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
                int r = dao.SaveData(ds.Tables[0], curPoco, pkName);
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

        RepositoryItemLookUpEdit ycEditor = null;
        private void iniInplaceEditors()
        {
            string sql = "select id YCID,name 遥测名 from tblycvalue;";
            if (dao == null)
                dao = FormConnectSrv.Instance.Dao;
            DataTable dt = dao.Query(sql);
            ycEditor = new RepositoryItemLookUpEdit();
            ycEditor.DataSource = dt;
            ycEditor.DisplayMember = "YCID";
            ycEditor.ValueMember = "YCID";
        }


        private void IniViewColumns()
        {
            if (curPoco == null) return;

            if (gridView1.Columns.Count > 0)
            {
                gridView1.Columns.Clear();
            }
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
                if (gridCol.FieldName.Equals(pkName))
                {
                    gridCol.Fixed = FixedStyle.Left;
                    gridCol.OptionsColumn.AllowEdit = false;
                }
                if (gridCol.FieldName.IndexOf("YCID") > 0)
                {
                    gridCol.ColumnEdit = ycEditor;
                }
                //else if (gridCol.FieldName.Equals("CONTROLSTATE"))
                //{
                //    RepositoryItemComboBox box = new RepositoryItemComboBox();
                //    box.Items.Add("不参与计算");
                //    box.Items.Add("建议");
                //    box.Items.Add("控制");
                //    box.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor; //只能选择不能编辑文本。
                //    gridCol.ColumnEdit = box;
                //}//if
                gridCol.BestFit();
            }//for
            gridView1.EndUpdate();
        }//func

        string curSql = null;
        string curId = null;
        AvcIdType idType = AvcIdType.OtherId;
        object curPoco = null;
        string pkName = "ID";
        public override void QueryById(string Id, AvcIdType IdType)
        {
            curId = Id;
            idType = IdType;

            if (IdType == AvcIdType.FeedId)
            {
                curPoco = new tblfeedermeasure();
            }
            else if (IdType == AvcIdType.CapId)
            {
                curPoco = new tblfeedcapacitormeasure();
            }
            else if (IdType == AvcIdType.Cap_itemId)
            {
                curPoco = new tblfeedcapacitoritemmeasure();
            }
            else if (IdType == AvcIdType.TransId)
            {
                curPoco = new tblfeedtransmeasure();
            }
            else if (IdType == AvcIdType.VolRegId)
            {
                curPoco = new tblfeedvoltageregulatormeasure();

            }
            else
            {
                return;
            }

            curSql = mysqlDao_v1.mysqlDAO.getQuerySql(curPoco, pkName, Id);
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
                //gridView1.BestFitColumns();
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
