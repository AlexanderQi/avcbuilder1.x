using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using mysqlDao_v1;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraBars;
using avcbuilder1.tblForms;
using DevExpress.XtraTab;
using AvcDb.entities;
using DevExpress.XtraTreeList.Nodes;

namespace avcbuilder1
{
    /// <summary>
    /// 1号界面
    /// </summary>
    public partial class FormMain : XtraForm
    {
        ILog log;
        // List<FormQueryBase> frms = new List<FormQueryBase>();
        private static FormMain instance;
        public delegate void AvcTreeFocusChangedHandle(object sender, AvcTreeEventArgs e);
        public delegate void AvcSrvConnectedHandle(object sender, EventArgs e);
        public delegate void AvcSrvDisconnectedHandle(object sender, EventArgs e);

        public event AvcTreeFocusChangedHandle AvcTreeFocusChanged;
        public event AvcSrvConnectedHandle AvcSrvConnected;
        public event AvcSrvDisconnectedHandle AvcSrvDisconnected;
        internal static FormMain Instance
        {
            get
            {
                if (instance == null)
                    new FormMain();
                return instance;
            }
        }

        public FormMain()
        {
            lock (this)
            {
                instance = this;
                InitializeComponent();
                xtraTabControl_element.SelectedPageChanged += XtraTabControl_element_SelectedPageChanged;
                barButtonItem_volt.ItemClick += barButtonItem_add_ItemClick;
                barButtonItem_trans.ItemClick += barButtonItem_add_ItemClick;
                barButtonItem_cap.ItemClick += barButtonItem_add_ItemClick;
                barButtonItem_refresh.ItemClick += BarButtonItem_refresh_ItemClick;

                simpleButton_trans.Click += simpleButton_vol_Click;
                simpleButton_line.Click += simpleButton_vol_Click;
                simpleButton_tap.Click += simpleButton_vol_Click;

                log = LogManager.GetLogger("log");
                IniTreeTable();
                IniForms();
            }
        }

        private void BarButtonItem_refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            TreeLoad();
        }

        private void XtraTabControl_element_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            AvcTreeEventArgs av = newAvcTreeEventArgs();
            FormBase frm = e.Page.Tag as FormBase;
            if (frm != null)
                frm.RefreshForm();
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
            TreeTable.Columns.Add("TYPE", typeof(int));
            TreeTable.Columns.Add("TBL", typeof(string));
            //TreeTable.Columns.Add("tag", typeof(int));
            //TreeTable.Columns.Add("style", typeof(int));
            CreateTreeRoot();
            treeList1.DataSource = TreeTable;
        }

        private DataRow CreateTreeRoot()
        {
            root = TreeTable.NewRow();
            root["IMAGEINDEX"] = 0;
            root["ID"] = -1;
            root["PID"] = -2;
            root["NAME"] = "AVC Server";
            root["INFO"] = "未连接";
            root["TYPE"] = AvcIdType.ServerId;

            //root["tag"] = 0;
            TreeTable.Rows.Add(root);
            return root;
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
                if (Dao == null)
                {
                    return;
                }
                treeList1.BeginUpdate();
                TreeTable.Clear();
                DataRow root = CreateTreeRoot();
                root["INFO"] = "已连接";
                string sql = "select ID,NAME from tblsubcontrolarea"; //mysqlDAO.getQuerySql(new tblsubcontrolarea(), null); 
                LoadTbl(sql, -1, 1, "管理单位", AvcIdType.AreaId, "tblsubcontrolarea");

                sql = "select ID,NAME,SUBCONTROLAREAID as PID from tblsubstation;";
                LoadTbl(sql, 2, "变电站", AvcIdType.StationId, "tblsubstation");

                sql = "select ID,NAME,SUBSTATIONID as PID from tblfeeder;";
                LoadTbl(sql, 3, "馈线", AvcIdType.FeedId, "tblfeeder");


                sql = "select ID,NAME,FEEDID as PID from tblfeedcapacitor t";
                LoadTbl(sql, 4, "电容器", AvcIdType.CapId, "tblfeedcapacitor");

                //sql = "select ID,NAME,FEEDID as PID from tblfeedcapacitor t where t.VOLTAGELEVELID=4";
                //LoadTbl(sql, 4, "线路电容器", AvcIdType.CapId, "tblfeedcapacitor");

                //sql = "select ID,NAME,FEEDID as PID from tblfeedcapacitor t where t.VOLTAGELEVELID = 2 or t.VOLTAGELEVELID = 1";
                //LoadTbl(sql, 5, "配电电容器", AvcIdType.CapId, "tblfeedcapacitor");

                sql = "select ID,NAME,FEEDCAPACITORID as PID from tblfeedcapacitoritem";
                LoadTbl(sql, 8, "电容器子组", AvcIdType.Cap_itemId, "tblfeedcapacitoritem");

                sql = "select ID,NAME,FEEDID as PID from tblfeedtrans";
                LoadTbl(sql, 6, "配电变压器", AvcIdType.TransId, "tblfeedtrans");

                sql = "select id,name,FEEDID as PID from tblfeedvoltageregulator";
                LoadTbl(sql, 7, "线路调压器", AvcIdType.VolRegId, "tblfeedvoltageregulator");
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
        private void LoadTbl(string sql, int pid, int ImgIndex, string info, AvcIdType idTtype, string tblName)
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
                    tree_row["NAME"] = row["NAME"].ToString();
                    tree_row["INFO"] = info;
                    tree_row["TYPE"] = idTtype;
                    tree_row["TBL"] = tblName;
                    TreeTable.Rows.Add(tree_row);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void LoadTbl(string sql, int ImgIndex, string info, AvcIdType idType, string tblName)
        {
            LoadTbl(sql, 0xff, ImgIndex, info, idType, tblName);
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            //FormMain_BackColorChanged(this, null);
            this.HelpButton = true;
        }

        /// <summary>
        /// “连接..."按钮功能会动态改变，根据Caption属性内容，执行‘连接’或‘断开’数据库功能。
        /// 并触发连接或断开事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem_connect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonItem_connect.Caption.Equals("连接..."))
            {
                DialogResult dia = FormConnectSrv.Instance.Open();
                if (dia != DialogResult.OK) return;
                this.Dao = FormConnectSrv.Instance.Dao;
                panelControl_buttons.Enabled = true;
                IniTreeTable();
                TreeLoad();
                if (AvcSrvConnected != null)
                {
                    AvcSrvConnected(this, new EventArgs());
                }
            }

            if (barButtonItem_connect.Caption.Equals("断开..."))
            {
                IniTreeTable();
                panelControl_buttons.Enabled = false;
                if (AvcSrvDisconnected != null)
                    AvcSrvDisconnected(this, new EventArgs());
            }
        }


        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right
                    && ModifierKeys == Keys.None
                    && treeList1.State == DevExpress.XtraTreeList.TreeListState.Regular)
            {

                TreeListHitInfo hitInfo = treeList1.CalcHitInfo(e.Location);
                if (hitInfo.Node != null)
                {
                    if (hitInfo.Node != treeList1.FocusedNode)
                        hitInfo.Node.Selected = true;

                    if (hitInfo.Node["ID"].ToString().Equals("-1"))
                    {
                        if ((hitInfo.Node["INFO"] as string).Equals("未连接"))
                            barButtonItem_connect.Caption = "连接...";
                        else
                            barButtonItem_connect.Caption = "断开...";
                    }
                    Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
                    popupMenuBefore(hitInfo.Node);
                    popupMenu1.ShowPopup(p);
                    return;
                }
            }
        }

        //private void callQuery(string Caption, string Id, AvcIdType idType)
        //{
        //    XtraTabPage p = xtraTabControl_element.SelectedTabPage;
        //    FormBase frm = (FormBase)p.Tag;
        //    if (frm != null)
        //    {
        //        if (Id != null && (!Id.Equals("")))
        //        {
        //            if (frm is FormQueryBase)
        //            {
        //                FormQueryBase fq = (FormQueryBase)frm;
        //                fq.SetCaption(Caption);
        //                fq.QueryById(Id, idType);
        //            }else if(frm is FormCardBase)
        //            {
        //                FormCardBase fc = (FormCardBase)frm;
        //                fc.SetCaption(Caption);
        //                fc.QueryById(Id, idType);
        //            }
        //        }
        //    }
        //}


        public static FormQueryElement FormElement;
        public void IniForms()
        {
            FormZJXT fzjxt = new FormZJXT();
            fzjxt.ShowInControl(xtraTabPage_zjxt);

            FormFtpKZQ fkzq = new FormFtpKZQ();
            fkzq.ShowInControl(xtraTabPage_control);
            FormFtpTX ftx = new FormFtpTX();
            ftx.ShowInControl(xtraTabPage_communication);

            FormElement = new FormQueryElement();
            FormElement.Ini();
            FormElement.DataChaged += FormElement_DataChaged;

            FormBase frm = new FormQueryState();
            frm.ShowInControl(xtraTabPage_state);
            frm = new FormQueryLimit();
            frm.ShowInControl(xtraTabPage_limit);
            frm = new FormQueryProtect();
            frm.ShowInControl(xtraTabPage_protect);
            frm = new FormQueryYC();
            frm.ShowInControl(xtraTabPage_yc);
            frm = new FormQueryYX();
            frm.ShowInControl(xtraTabPage_yx);
            frm = new FormQueryYK();
            frm.ShowInControl(xtraTabPage_yk);
            frm = new FormQueryYT();
            frm.ShowInControl(xtraTabPage_yt);
            frm = new FormQueryAction();
            frm.ShowInControl(xtraTabPage_num);
            frm = new FormQueryRunTime();
            frm.ShowInControl(xtraTabPage1_time);

            xtraTabPage_measure.PageVisible = false;
            //frm = new FormCardMeasure();
            //frm.ShowInControl(xtraTabPage_measure);

            frm = new FormQueryCapaCtrl();
            frm.ShowInControl(xtraTabPage_capaCt);

            frm = new FormQueryElement();
            frm.ShowInControl(xtraTabPage1_param);


        }

        private void FormElement_DataChaged(object sender, EventArgs e)
        {
            TreeLoad();
        }

        private AvcTreeEventArgs newAvcTreeEventArgs()
        {
            TreeListNode e = treeList1.FocusedNode;
            string Caption = e["NAME"].ToString();
            string str = e["INFO"].ToString();
            string Id = e["ID"].ToString();
            string tbl = e["TBL"].ToString();
            AvcIdType a = (AvcIdType)((int)e["TYPE"]);
            AvcTreeEventArgs av = new AvcTreeEventArgs(Id, a);
            av.Caption = Caption;
            av.Msg = tbl;
            TreeListNode pe = e.ParentNode;
            if (pe != null)
            {
                av.ParentId = pe["ID"].ToString();
                av.ParentCaption = pe["NAME"].ToString();
            }
            return av;
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

            if (treeList1.FocusedNode == null || treeList1.FocusedNode["ID"].ToString().Equals("-1"))
                return;
            if (AvcTreeFocusChanged != null)
            {
                AvcTreeEventArgs av = newAvcTreeEventArgs();
                switch (av.IdType)
                {
                    case AvcIdType.AreaId:
                    case AvcIdType.FeedId:
                    case AvcIdType.ServerId:
                    case AvcIdType.StationId:
                    case AvcIdType.Cap_itemId:
                        {
                            //xtraTabPage1_param.Select();
                            foreach (XtraTabPage p in xtraTabControl_element.TabPages)
                                if (p != xtraTabPage1_param)
                                    p.PageEnabled = false;

                            if(av.IdType == AvcIdType.Cap_itemId)
                            {
                                xtraTabPage_yk.PageEnabled = true;
                                xtraTabPage_yx.PageEnabled = true;
                                xtraTabPage_num.PageEnabled = true;
                                xtraTabPage1_time.PageEnabled = true;
                            }
                            if(av.IdType == AvcIdType.FeedId || av.IdType == AvcIdType.StationId || av.IdType == AvcIdType.AreaId)
                            {
                                xtraTabPage_state.PageEnabled = true;
                            }
                            break;
                        }
              
                    default:
                        {
                            foreach (XtraTabPage p in xtraTabControl_element.TabPages)
                                    p.PageEnabled = true;
                            if (av.IdType != AvcIdType.CapId)
                                xtraTabPage_capaCt.PageEnabled =false;
                            
                            break;
                        }
                }
                AvcTreeFocusChanged(this, av);
            }
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {

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

        int maxInfoLen = 8192;
        public void showInfo(string info)
        {
            if (richTextBox1.TextLength > maxInfoLen)
                richTextBox1.Clear();
            richTextBox1.AppendText(info + '\n');
            richTextBox1.HideSelection = false;
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



        string curCaption = null;
        string curNodeInfo = null;
        string curNodeId = null;
        public void popupMenuBefore(TreeListNode node)
        {
            barSubItem_element.Enabled = barButtonItem_add.Enabled = barButtonItem_del.Enabled = false;

            curCaption = node["NAME"].ToString();
            curNodeInfo = node["INFO"].ToString();
            curNodeId = node["ID"].ToString();
            AvcIdType ai = (AvcIdType)((int)node["TYPE"]);
            barButtonItem_tree_find.Enabled = barButtonItem_refresh.Enabled = root["INFO"].ToString().Equals("已连接");
            TreeListNode parentNode = node.ParentNode;
            if (parentNode == null)
            {
                if (ai == AvcIdType.ServerId)
                {
                    barButtonItem_connect.Visibility = BarItemVisibility.Always;
                    if (curNodeInfo.Equals("已连接"))
                        barButtonItem_add.Enabled = true;
                }
                else
                {
                    node["INFO"] += "[垃圾数据]";
                    barButtonItem_del.Enabled = true;
                }
            }
            else
            {
                barButtonItem_connect.Visibility = BarItemVisibility.Never;
                AvcIdType pai = (AvcIdType)((int)parentNode["TYPE"]);
                barButtonItem_del.Enabled = true;
                if (ai == AvcIdType.FeedId)
                    barSubItem_element.Enabled = true;
                else
                    barButtonItem_add.Enabled = true;
            }

            switch (ai)
            {
                case AvcIdType.ServerId: { barButtonItem_add.Caption = "添加区域..."; break; }
                case AvcIdType.AreaId: { barButtonItem_add.Caption = "添加变电站..."; break; }
                case AvcIdType.StationId: { barButtonItem_add.Caption = "添加馈线..."; break; }
                case AvcIdType.CapId: { barButtonItem_add.Caption = "添加电容子组..."; break; }
                default: { barButtonItem_add.Caption = "添加..."; break; }
            }
        }

        private void barButtonItem_add_ItemClick(object sender, ItemClickEventArgs e)
        {
            AvcTreeEventArgs av = newAvcTreeEventArgs();

            if (e.Item == barButtonItem_cap)
                av.tag = (int)AvcIdType.CapId;
            else if (e.Item == barButtonItem_trans)
                av.tag = (int)AvcIdType.TransId;
            else if (e.Item == barButtonItem_volt)
                av.tag = (int)AvcIdType.VolRegId;
            FormElement.ShowAddModal(av);
        }


        private void barButtonItem_del_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                TreeListNode node = treeList1.FocusedNode;
                string caption = node["NAME"].ToString();
                if (XtraMessageBox.Show(string.Format("确定删除 {0} 该记录吗?", caption), "删除提示", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                String id = node["ID"].ToString();
                AvcIdType ai = (AvcIdType)((int)node["TYPE"]);
                string tbl = node["TBL"].ToString();
                object poco = PocoFactory.getPocoByName(tbl);  //, "AvcDb.entities"
                if (poco != null)
                {
                    string sql = mysqlDAO.getDeleteSql(poco, "ID", id);
                    int r = Dao.Execute(sql);
                    XtraMessageBox.Show(string.Format("操作成功,{0}条记录.", r));
                    TreeLoad();
                }
                else
                {
                    XtraMessageBox.Show(string.Format("类型错误,{0}.", tbl));
                }
                //tbl 字符串反射反射反射反射
                //mysqlDAO.getDeleteSql()
            }
            catch (Exception ex)
            {
                log.Error(ex);
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void barCheckItem_id_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            treeListColumn_id.Visible = barCheckItem_id.Checked;
            treeList1.BestFitColumns();
        }

        FormQueryAvcType ftype = null;
        private void simpleButton_vol_Click(object sender, EventArgs e)
        {
            if (ftype == null)
            {

                ftype = new FormQueryAvcType();
                ftype.FormBorderStyle = FormBorderStyle.Sizable;
                ftype.ControlBox = true;
                ftype.MinimizeBox = false;
                ftype.StartPosition = FormStartPosition.CenterScreen;
                ftype.Ini();
            }
            if (sender == simpleButton_vol)
                ftype.ShowModal("tblvoltagelevel", simpleButton_vol.ToolTip);
            else if (sender == simpleButton_trans)
                ftype.ShowModal("tbltransformertype", simpleButton_trans.ToolTip);
            else if (sender == simpleButton_line)
                ftype.ShowModal("tblconductortype", simpleButton_line.ToolTip);
            else if (sender == simpleButton_tap)
                ftype.ShowModal("tbltapchangertype", simpleButton_tap.ToolTip);
        }

        FormDataTools fdt;
        private void simpleButton_tools_Click(object sender, EventArgs e)
        {
            if (fdt == null)
            {
                fdt = new FormDataTools();
            }
            fdt.ShowDialog();
        }

        private void xtraTabControl2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
        }

        FormQueryTopo ftopo;
        private void simpleButton_topo_Click(object sender, EventArgs e)
        {
            if(ftopo == null)
            {
                ftopo = new FormQueryTopo();
                ftopo.Ini();
            }
            ftopo.ShowDialog();
        }
    }//class

    public class AvcTreeEventArgs : EventArgs
    {
        private string caption;  //主键字段名  
        private string id;          //主键字段值
        private string parentId;
        private string parentCaption;
        public string Msg;
        private AvcIdType idt;
        public int tag;
        public AvcTreeEventArgs(string id, AvcIdType idType) : base()
        {
            this.id = id;
            this.idt = idType;
        }

        public string Caption
        {
            get
            {
                return caption;
            }

            set
            {
                caption = value;
            }
        }

        public string Id { get { return id; } }
        public AvcIdType IdType { get { return idt; } }

        public string ParentId
        {
            get
            {
                return parentId;
            }

            set
            {
                parentId = value;
            }
        }

        public string ParentCaption
        {
            get
            {
                return parentCaption;
            }

            set
            {
                parentCaption = value;
            }
        }
    }//class

    public enum AvcIdType { ServerId = -1, AreaId = 0, StationId = 1, FeedId = 2, ElementId = 3, CapId = 4, Cap_itemId = 5, TransId = 6, VolRegId = 7, OtherId = 8 };
}//namespace
