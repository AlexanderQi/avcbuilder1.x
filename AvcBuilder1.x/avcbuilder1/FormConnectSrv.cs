using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using log4net;
using mysqlDao_v1;

using System.Configuration;
using System.Collections;

namespace avcbuilder1
{
    public partial class FormConnectSrv : DevExpress.XtraEditors.XtraForm
    {

        ILog log;


        private string avc_conn = "";
        public mysqlDAO Dao;
        private static FormConnectSrv instance = null;
        public myConnInfo conninfo;

        public static FormConnectSrv Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormConnectSrv();
                }
                return instance;
            }
        }
        private FormConnectSrv()
        {
            lock (this)
            {
                InitializeComponent();
                log = LogManager.GetLogger("log");

            }
        }

        private void ClearInfo()
        {
            textEdit_dn.Text = textEdit_pw.Text = textEdit_srv.Text = textEdit_user.Text = "";
            comboBoxEdit1.Properties.Items.Clear();
        }

        private void LoadConnInfo()
        {
            ClearInfo();
            IEnumerator ie = ConfigurationManager.ConnectionStrings.GetEnumerator();
            int index = 0;
            while (ie.MoveNext())
            {
                ConnectionStringSettings cs = ie.Current as ConnectionStringSettings;
                if (cs.Name.IndexOf("SqlServer") >= 0) continue;
                int i = comboBoxEdit1.Properties.Items.Add(cs.Name);
                if (cs.Name.Equals("avcdb"))
                {
                    index = i;
                }
            }
            if (comboBoxEdit1.Properties.Items.Count > 0)
            {
                avc_conn = comboBoxEdit1.Properties.Items[index] as string;
                comboBoxEdit1.SelectedIndex = index;
            }
        }

        private void ShowInfo(string connstr)
        {
            conninfo = mysqlDAO.getConnInfo(connstr);
            textEdit_srv.Text = conninfo.ServerIp;
            textEdit_user.Text = conninfo.User;
            textEdit_pw.Properties.PasswordChar = '★';
            textEdit_pw.Text = conninfo.Password;
            textEdit_dn.Text = conninfo.DatabaseName;
        }


        private string getConnStrByUI()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Server=").Append(textEdit_srv.Text).Append(";User=").Append(textEdit_user.Text)
                        .Append(";Password=").Append(textEdit_pw.Text).Append(";Database=")
                        .Append(textEdit_dn.Text).Append(";Charset=utf8; Pooling=true; Max Pool Size=8;");
            return sb.ToString();
        }

        private string getConnNameByUI()
        {
            return textEdit_srv.Text + "-" + textEdit_dn.Text + "-" + textEdit_user.Text;
        }

        private bool validateInfo()
        {
            if (textEdit_srv.Text.Trim().Equals(string.Empty) ||
                textEdit_dn.Text.Trim().Equals(string.Empty) ||
                textEdit_pw.Text.Trim().Equals(string.Empty) ||
                textEdit_user.Text.Trim().Equals(string.Empty))
            {
                XtraMessageBox.Show("信息不完整，都是必填项。", "完整性检查", MessageBoxButtons.OKCancel);
                return false;
            }
            return true;
        }

        public mysqlDAO Open()
        {
            LoadConnInfo();
            ShowDialog();
            return Dao;
        }

        private void simpleButton_cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        internal static string sql4NewId = @"select `MAXVALUE`+13 newid from tblsequencenumber;update tblsequencenumber set `MAXVALUE` = `MAXVALUE`+13,  `MinVALUE` = `MinVALUE`+13 where name = 'NewID';";//里面有两个SQL语句一个查一个改。13是ID增量，可自定义。
        private void simpleButton_ok_Click(object sender, EventArgs e)
        {
            try
            {
                Dao = new mysqlDAO(avc_conn);
                Dao.SetSqlForNewId(sql4NewId);
                Dao.CmdExecute += Dao_OnSqlExecute; ;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                log.Error(ex.Message);
            }
            finally
            {
                DialogResult = DialogResult.OK;
                Hide();
            }
        }

        private void Dao_OnSqlExecute(object sender, EventDaoArgs args)
        {
            FormMain.Instance.showInfo(args.CommandInfo);
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cn = comboBoxEdit1.Properties.Items[comboBoxEdit1.SelectedIndex] as string;
            avc_conn = ConfigurationManager.ConnectionStrings[cn].ConnectionString;
            ShowInfo(avc_conn);
        }

        private void simpleButton_save_Click(object sender, EventArgs e)
        {
            if (validateInfo())
            {
                string cn = getConnNameByUI();
                string conn = getConnStrByUI();

                try
                {
                    Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    //cfg.AppSettings.Settings.Add(new KeyValueConfigurationElement(connName, connStr));
                    //if (cfg.ConnectionStrings.ConnectionStrings[cn] != null)
                    //{
                    //    XtraMessageBox.Show("连接记录已保存");
                    //    return;
                    //}
                    cfg.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(cn, conn));
                    cfg.Save();
                    //ConfigurationManager.RefreshSection("appSettings");
                    ConfigurationManager.RefreshSection("connectionStrings");
                    LoadConnInfo();

                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    XtraMessageBox.Show(ex.ToString());
                }

            }
        }

        private void FormConnectSrv_Activated(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text.Equals(""))
            {
                avc_conn = ConfigurationManager.ConnectionStrings["avcdb"].ConnectionString;
            }
            else
            {
                avc_conn = ConfigurationManager.ConnectionStrings[comboBoxEdit1.Text].ConnectionString;
            }
            ShowInfo(avc_conn);
        }
    }

    public static class AvcBuilder_func
    {
 
    }
}