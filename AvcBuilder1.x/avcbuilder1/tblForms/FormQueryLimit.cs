﻿using System;
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
    public partial class FormQueryLimit : FormQueryBase
    {
        public FormQueryLimit() : base()
        {
            InitializeComponent();
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
            string t = DateTime.Now.ToShortTimeString();
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["LIMITNAME"],gridView1.ViewCaption+"限值-"+ds.Tables[0].Rows.Count );
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["LIMITGROUPNAME"], gridView1.ViewCaption + "分组");
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["ELEMENTID"], curId);
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["PERIODBEGIN"], t);
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["PERIODEND"], t);
        }

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
            string pkName = "ID";
            //此处应该做必填项检查。
            try
            {
                int r = dao.SaveData(ds.Tables[0], new tblelementlimit(), pkName);
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
            if (gridView1.Columns.Count > 0) { return; }
            if (dao == null)
            {
                dao = FormConnectSrv.Instance.Dao;
            }
            gridView1.BeginUpdate();

            DataTable dt = dao.GetFieldComment("tblelementlimit");
            foreach (DataRow dr in dt.Rows)
            {
                GridColumn gridCol = AddGridColumn(dr[0].ToString(), dr[1].ToString());
                if (gridCol.FieldName.Equals("ELEMENTID"))
                {
                    gridCol.Fixed = FixedStyle.Left;
                    gridCol.OptionsColumn.AllowEdit = false;
                    gridCol.OptionsColumn.AllowFocus = false;
                }
                if (gridCol.FieldName.Equals("ID"))
                {
                    gridCol.Fixed = FixedStyle.Left;
                    gridCol.Visible = false;
                }
                if (gridCol.FieldName.IndexOf("NAME") >= 0)
                {
                    gridCol.Fixed = FixedStyle.Left;
                }
                if (gridCol.FieldName.Equals("PERIODBEGIN"))
                {
                    //gridCol.ColumnEdit = repositoryItemTimeEdit1;
                }
                if (gridCol.FieldName.Equals("PERIODEND"))
                {
                  //  gridCol.ColumnEdit = repositoryItemTimeEdit1;
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

            }//for
            gridView1.EndUpdate();
        }//func

        string curSql = null;
        string curId = null;
        public override void QueryById(string Id, AvcIdType IdType)
        {
            curId = Id;
            tblelement ele = new tblelement();
            tblelementlimit sta = new tblelementlimit();
            if (IdType == AvcIdType.FeedId || IdType == AvcIdType.StationId || IdType == AvcIdType.AreaId || IdType == AvcIdType.ServerId)
            {
                MsgBox("你选择的是管理单位，请选择馈线下的具体设备。");
            }
            else
            {
                curSql = mysqlDao_v1.mysqlDAO.getQuerySql(sta, "ELEMENTID", Id);
                QueryBySql(curSql);
            }
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
