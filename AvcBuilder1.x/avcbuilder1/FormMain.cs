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
using AvcDb.entities;

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
        public delegate void TreeFocusChangedHandle(object sender, AvcTreeEventArgs e);
        public delegate void AvcSrvConnectedHandle(object sender, EventArgs e);
        public delegate void AvcSrvDisconnectedHandle(object sender, EventArgs e);
        public event TreeFocusChangedHandle OnTreeFocusChanged;
        public event AvcSrvConnectedHandle OnAvcSrvConnected;
        public event AvcSrvDisconnectedHandle OnAvcSrvDisconnected;

        public FormMain()
        {
            Instance = this;
            InitializeComponent();
            log = LogManager.GetLogger("log");
            IniTreeTable();
            IniForms();
        }

        private void emitTreeFocusChangedEvent(string id, AvcIdType idType)
        {
            if (OnTreeFocusChanged != null)
            {
                AvcTreeEventArgs e = new AvcTreeEventArgs(id, idType);
                OnTreeFocusChanged(this, e);
            }
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

            TreeTable.Columns.Add("IMAGEINDEX", typeof(int));
            TreeTable.Columns.Add("ID", typeof(string));
            TreeTable.Columns.Add("PID", typeof(string));
            TreeTable.Columns.Add("NAME", typeof(string));
            TreeTable.Columns.Add("INFO", typeof(string));
            //TreeTable.Columns.Add("tag", typeof(int));
            //TreeTable.Columns.Add("style", typeof(int));

            treeList1.DataSource = TreeTable;

            root = TreeTable.NewRow();
            root["IMAGEINDEX"] = 0;
            root["ID"] = -1;
            root["PID"] = -2;
            root["NAME"] = "AVC Server";
            root["INFO"] = "未连接";
            //root["tag"] = 0;
            TreeTable.Rows.Add(root);
        }

        /// <summary>
        /// 从数据库载入树形列表信息
        /// </summary>
        /// <param name="tag">备用</param>
        mysqlDAO Dao = null;
        private void TreeLoad()
        {
            try
            {
                Dao = FormConnectSrv.Instance.Open();
                if (Dao == null)
                {
                    return;
                }
                root["INFO"] = "已连接";

                treeList1.BeginUpdate();

                string sql = "select ID,NAME from tblsubcontrolarea"; //mysqlDAO.getQuerySql(new tblsubcontrolarea(), null); 
                LoadTbl(sql, -1, 1, "管理单位");

                sql = "select ID,NAME,SUBCONTROLAREAID as PID from tblsubstation;";
                LoadTbl(sql, 2, "变电站");

                sql = "select ID,NAME,SUBSTATIONID as PID from tblfeeder;";
                LoadTbl(sql, 3, "馈线");

                sql = "select ID,NAME,FEEDID as PID from tblfeedcapacitor t where t.VOLTAGELEVELID=4";
                LoadTbl(sql, 4, "线路电容器");
                sql = "select ID,NAME,FEEDID as PID from tblfeedcapacitor t where t.VOLTAGELEVELID=2";
                LoadTbl(sql, 5, "配电电容器");

                sql = "select ID,NAME,FEEDCAPACITORID as PID from tblfeedcapacitoritem";
                LoadTbl(sql, 8, "电容器子组");

                sql = "select ID,NAME,FEEDID as PID from tblfeedtrans";
                LoadTbl(sql, 6, "配电变压器");

                sql = "select id,name,FEEDID as PID from tblfeedvoltageregulator";
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
                DataTable dt = Dao.Query(sql);
                foreach (DataRow row in dt.Rows)
                {
                    DataRow tree_row = TreeTable.NewRow();
                    tree_row["IMAGEINDEX"] = ImgIndex;
                    string id = row["ID"].ToString();
                    tree_row["ID"] = id;
                    if (pid < 0)
                        tree_row["PID"] = pid;
                    else
                        tree_row["PID"] = row["PID"];
                    tree_row["NAME"] = row["NAME"].ToString() + "【" + id + "】";
                    tree_row["INFO"] = info;

                    TreeTable.Rows.Add(tree_row);
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

        /// <summary>
        /// “连接..."按钮功能会动态改变，根据Caption属性内容，执行‘连接’或‘断开’数据库功能。
        /// 并触发连接或断开事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem_connect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IniTreeTable();
            EventArgs ea = new EventArgs();
            if (barButtonItem_connect.Caption.Equals("连接..."))
            {
                TreeLoad();
                if (OnAvcSrvConnected != null)
                    OnAvcSrvConnected(this, ea);
            }
            else if (OnAvcSrvDisconnected != null)
            {
                OnAvcSrvDisconnected(this, ea);
            }
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
                        if ((hitInfo.Node["INFO"] as string).Equals("未连接"))
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

        private void callQuery(string Id, AvcIdType idType)
        {
            XtraTabPage p = xtraTabControl_element.SelectedTabPage;
            FormQueryBase frm = (FormQueryBase)p.Tag;
            if (frm != null)
            {
                if (Id != null && (!Id.Equals("")) )
                {
                    frm.QueryById(Id, idType);
                }
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
            FormQueryBase frm = new FormQueryState();
            frm.ShowInControl(xtraTabPage_state);
            frm = new FormQueryLimit();
            frm.ShowInControl(xtraTabPage_limit);

        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode == null) return;
            string str = treeList1.FocusedNode["INFO"].ToString();
            string Id = treeList1.FocusedNode["ID"].ToString();
            switch (str)
            {
                case "配电电容器":
                case "线路电容器":
                case "线路调压器":
                case "配电变压器":
                case "电容器子组":
                    {
                        callQuery(Id, AvcIdType.ElementId);
                        break;
                    }
                case "馈线":
                    {
                        callQuery(Id, AvcIdType.FeedId);
                        break;
                    }
                default:
                    {
                        callQuery(null, AvcIdType.OtherId);
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


        public void showInfo(string info)
        {

            richTextBox1.AppendText(info + '\n');
            richTextBox1.HideSelection = false;
        }

        private void FormMain_BackColorChanged(object sender, EventArgs e)
        {
            richTextBox1.BackColor = textEdit1.BackColor;
            richTextBox1.ForeColor = textEdit1.ForeColor;
        }

        private int indexOfFind = 0;
        private void simpleButton_find_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text.Trim().Equals("")) return;
            indexOfFind = 0;
            int len = richTextBox1.Text.Length;
            indexOfFind = richTextBox1.Find(textEdit1.Text, 0, len, RichTextBoxFinds.None);
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                int len = richTextBox1.Text.Length;
                indexOfFind = richTextBox1.Find(textEdit1.Text, indexOfFind + 1, len, RichTextBoxFinds.None);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                simpleButton_find_Click(this, null);
            }
        }
    }//class

    public class AvcTreeEventArgs : EventArgs
    {
        private string id;
        private AvcIdType idt;
        public AvcTreeEventArgs(string id, AvcIdType idType) : base()
        {
            this.id = id;
            this.idt = idType;
        }
        public string Id { get { return id; } }
        public AvcIdType IdType { get { return idt; } }
    }//class

    public enum AvcIdType { AreaId = 0, StationId = 1, FeedId = 2, ElementId = 3, OtherId = 4 };
}//namespace
