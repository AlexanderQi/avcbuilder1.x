using System;
using System.Data;
using System.Windows.Forms;
using AvcDb.entities;
using DevExpress.XtraEditors.Repository;
using avcbuilder1.tblForms;
using avcbuilder1;
using mysqlDao_v1;



namespace avcbuilder1.tblForms
{
    public partial class FormTopoSelect : avcbuilder1.tblForms.FormBase
    {
        public FormTopoSelect()
        {
            InitializeComponent();
            Ini();
        }

        public void Ini()
        {
            StartPosition = FormStartPosition.CenterScreen;
            Text = "选择连接设备";
            checkedListBoxControl1.CustomItemDisplayText += CheckedListBoxControl1_CustomItemDisplayText;
            
        }

        private void CheckedListBoxControl1_CustomItemDisplayText(object sender, DevExpress.XtraEditors.CustomItemDisplayTextEventArgs e)
        {
            AvcTopoItem ati = (AvcTopoItem)(e.Value);
            e.DisplayText = ati.Cation;
           
        }

        protected mysqlDAO dao;
        public string NewLinks = null;
        public void ShowModal(string feedid, string Links)
        {
            tblelement e = new tblelement();
            string sql = mysqlDAO.getQuerySql(e, "FEEDID", feedid);
            if (dao == null)
            {
                dao = FormConnectSrv.Instance.Dao;
            }
            DataTable dt = dao.Query(sql);
            checkedListBoxControl1.Items.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                AvcTopoItem ati = new AvcTopoItem();
                ati.Cation = dr["NAME"].ToString();
                ati.Id = dr["ID"].ToString();
                ati.FeedId = dr["FEEDID"].ToString();
                int i = checkedListBoxControl1.Items.Add(ati);
                if (Links.IndexOf(ati.Id) >= 0)
                {
                    checkedListBoxControl1.SetItemChecked(i, true);
                }
            }
            ShowDialog();
            NewLinks = null;
            if (DialogResult != DialogResult.OK) return;
            for(int i = 0; i < checkedListBoxControl1.Items.Count; i++)
            {
                if (checkedListBoxControl1.GetItemChecked(i))
                {
                    AvcTopoItem ati = (AvcTopoItem)checkedListBoxControl1.GetItemValue(i);
                    NewLinks += ati.Id+";";
                }
            }
            if(NewLinks != null)
                NewLinks = NewLinks.Remove(NewLinks.Length - 1, 1);
        }

        private void simpleButton_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void simpleButton_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            NewLinks = null;
        }
    }//class

    public class AvcTopoItem
    {
        public string Cation { get; set; }
        public string Id { get; set; }
        public string FeedId { get; set; }
    }
}
