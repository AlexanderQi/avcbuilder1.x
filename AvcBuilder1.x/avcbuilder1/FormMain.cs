using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Configuration;
using mysqlDao_v1;
using DevExpress.XtraEditors;
using System.Collections;
using DevExpress.XtraTreeList;
using DevExpress.XtraBars;
using avcbuilder1.tblForms;
using DevExpress.XtraTab;

namespace avcbuilder1
{
    /// <summary>
    /// 1号界面
    /// </summary>
    public partial class FormMain : XtraForm
    {
        ILog log;
        // List<FormQueryBase> frms = new List<FormQueryBase>();
        static internal FormMain Instance;
        public FormMain()
        {
            Instance = this;
            InitializeComponent();
            log = LogManager.GetLogger("log");
            IniTreeTable();
            IniForms();
        }

        /// <summary>
        /// 初始化树形列表
        /// </summary>
        DataTable TreeTable = null;
        DataRow root;
        private void IniTreeTable()
        {
            if (TreeTable != null)
            {
                TreeTable.Columns.Clear();
                TreeTable.Clear();
            }
            else
                TreeTable = new DataTable();
            treeList1.Nodes.Clear();
            treeList1.DataSource = null;

            TreeTable.Columns.Add("ImageIndex", typeof(int));
            TreeTable.Columns.Add("ID", typeof(string));
            TreeTable.Columns.Add("ParentID", typeof(string));
            TreeTable.Columns.Add("name", typeof(string));
            TreeTable.Columns.Add("info", typeof(string));
            TreeTable.Columns.Add("tag", typeof(int));
            //TreeTable.Columns.Add("style", typeof(int));

            treeList1.DataSource = TreeTable;

            root = TreeTable.NewRow();
            root["ImageIndex"] = 0;
            root["ID"] = -1;
            root["ParentID"] = -2;
            root["name"] = "AVC Server";
            root["info"] = "未连接";
            root["tag"] = 0;
            TreeTable.Rows.Add(root);

            FormQueryState.Instance.DataClosedHandle();
        }

        /// <summary>
        /// 从数据库载入树形列表信息
        /// </summary>
        /// <param name="tag">备用</param>
        mysqlDAO mdao = null;
        private void TreeLoad()
        {
            try
            {
                mdao = FormConnectSrv.Instance.Open();
                if (mdao == null)
                {
                    return;
                }
                root["info"] = "已连接";

                treeList1.BeginUpdate();

                string sql = "select id,name from tblsubcontrolarea";
                LoadTbl(sql, -1, 1, "管理单位");

                sql = "select id,name,SUBCONTROLAREAID as pid from tblsubstation;";
                LoadTbl(sql, 2, "变电站");

                sql = "select id,name,SUBSTATIONID as pid from tblfeeder;";
                LoadTbl(sql, 3, "馈线");

                sql = "select id,name,feedid as pid from tblfeedcapacitor t where t.VOLTAGELEVELID=4";
                LoadTbl(sql, 4, "线路电容器");
                sql = "select id,name,feedid as pid from tblfeedcapacitor t where t.VOLTAGELEVELID=2";
                LoadTbl(sql, 5, "配电电容器");

                sql = "select id,name,FEEDCAPACITORID as pid from tblfeedcapacitoritem";
                LoadTbl(sql, 8, "电容器子组");

                sql = "select id,name,FEEDID as pid from tblfeedtrans";
                LoadTbl(sql, 6, "配电变压器");

                sql = "select id,name,FEEDID as pid from tblfeedvoltageregulator";
                LoadTbl(sql, 7, "线路调压器");
                treeList1.ExpandAll();
                treeList1.BestFitColumns();
                treeList1.EndUpdate();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                XtraMessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 载入下级子表
        /// </summary>
        /// <param name="sql">sql for subtable</param>
        /// <param name="pid">parent id 如果小于0 则属于程序内部指定，否则是数据库表中的上级id</param>
        /// <param name="ImgIndex">index of imagelist</param>
        /// <param name="info">infomation of recorder</param>
        private void LoadTbl(string sql, int pid, int ImgIndex, string info)
        {

            try
            {
                DataTable dt = mdao.Query(sql);
                foreach (DataRow i in dt.Rows)
                {
                    DataRow dr = TreeTable.NewRow();
                    dr["ImageIndex"] = ImgIndex;
                    string id = i["id"].ToString();
                    dr["ID"] = id;
                    if (pid < 0)
                        dr["ParentID"] = pid;
                    else
                        dr["ParentID"] = i["pid"];
                    dr["name"] = i["name"].ToString() + "【" + id + "】";
                    dr["info"] = info;

                    TreeTable.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void LoadTbl(string sql, int ImgIndex, string info)
        {
            LoadTbl(sql, 0xff, ImgIndex, info);
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            FormMain_BackColorChanged(this, null);
        }

        private void barButtonItem_connect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IniTreeTable();
            if (barButtonItem_connect.Caption.Equals("连接..."))
                TreeLoad();

        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right
                    && ModifierKeys == Keys.None
                    && treeList1.State == DevExpress.XtraTreeList.TreeListState.Regular)
            {

                TreeListHitInfo hitInfo = treeList1.CalcHitInfo(e.Location);
                //if (hitInfo.HitInfoType == HitInfoType.Cell)
                //{
                //    treeList1.SetFocusedNode(hitInfo.Node);
                //}

                if (hitInfo.Node != null)
                {
                    if (hitInfo.Node["ID"].ToString().Equals("-1"))
                    {
                        if ((hitInfo.Node["info"] as string).Equals("未连接"))
                        {
                            barButtonItem_connect.Caption = "连接...";
                        }
                        else
                        {
                            barButtonItem_connect.Caption = "断开...";
                        }
                        Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
                        popupMenu1.ShowPopup(p);
                        return;
                    }

                }
            }
        }

        private void callQuery(string Id,AvcIdType idt)
        {
            XtraTabPage p = xtraTabControl_element.SelectedTabPage;
            FormQueryBase frm = (FormQueryBase)p.Tag;
            if (frm != null)
            {
                if (Id == null)  //call form's default query
                    frm.QueryBySql(null);
                else if (idt == AvcIdType.ElementId)
                    frm.QueryById(Id);
                else if (idt == AvcIdType.FeedId)
                    frm.QueryByFeedId(Id);
                frm.DataLoadedHandle();
            }
        }



        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            TreeListHitInfo hitInfo = treeList1.CalcHitInfo(e.ControlMousePosition);
            if (hitInfo.Node != null)
            {
                e.Info = new DevExpress.Utils.ToolTipControlInfo(treeList1, hitInfo.Node["name"].ToString() + " ID:" + hitInfo.Node["ID"].ToString());
            }
        }


        public void IniForms()
        {
            FormQueryBase frm = FormQueryState.Instance;
            frm.ShowInControl(xtraTabPage_state);

        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode == null) return;
            string str = treeList1.FocusedNode["info"].ToString();
            string Id = treeList1.FocusedNode["ID"].ToString();
            switch (str)
            {
                case "配电电容器":
                case "线路电容器":
                case "线路调压器":
                case "配电变压器":
                case "电容器子组":
                    {
                        callQuery(Id,AvcIdType.ElementId);
                        break;
                    }
                case "馈线":
                    {
                        callQuery(Id,AvcIdType.FeedId);
                        break;
                    }
                default:
                    {
                        callQuery(null,AvcIdType.OtherId);
                        break;
                    }
            }
        }

        private bool tree_findpanel_visible = false;
        private void barButtonItem_tree_find_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tree_findpanel_visible) 
                treeList1.HideFindPanel();
            else
                treeList1.ShowFindPanel();
            tree_findpanel_visible = !tree_findpanel_visible;
        }


        public void showInfo(string sql)
        {
            richTextBox1.AppendText(sql);
            richTextBox1.HideSelection = false;
        }

        private void FormMain_BackColorChanged(object sender, EventArgs e)
        {
            richTextBox1.BackColor = textEdit1.BackColor;
            richTextBox1.ForeColor = textEdit1.ForeColor;
        }
    }//class



    public enum AvcIdType { AreaId = 0, StationId = 1, FeedId = 2, ElementId = 3, OtherId = 4 };
}
