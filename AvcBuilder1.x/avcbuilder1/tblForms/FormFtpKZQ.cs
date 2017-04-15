using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using myRemoteLib_v1;
using System.IO;

namespace avcbuilder1.tblForms
{
    public partial class FormFtpKZQ : avcbuilder1.tblForms.FormFtpBase
    {
        //ILog log;
        public FormFtpKZQ()
        {
            InitializeComponent();
            ButtonEnable(false);
            textEdit1.Text = "192.168.1.195";  //"192.168.0.230";
            simpleButton_connect.Click += simpleButton1_Click;
            simpleButton_f5.Click += SimpleButton_f5_Click;
            simpleButton_save.Click += SimpleButton_save_Click;
        }



        private void ButtonEnable(bool b)
        {
            xtraTabControl1.Enabled =
            simpleButton_save.Enabled =
            simpleButton_f5.Enabled = simpleButton_log.Enabled =
            simpleButton_reboot.Enabled = b;
            if (!b)
            {
                memoEdit_zjxtcfg.Text = "";
                memoEdit_104cfg.Text = "";
            }
        }

        string user = "softcore";
        string pw = "softcore";

        string userdownload = "avc";
        string pwdownload = "softcore";

        string path_zjxt = @"/home/softcore/bin/zjxt";
        string path_104 = @"/home/softcore/bin/jk104";
        string ip = "";
        string path_down = "d:";
        string cfgzjxt = "c3.xml";
        string cfg104 = "cfg.txt";
        string[] files = null;
        FtpWeb ftp = null;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (ip.Equals(textEdit1.Text.Trim()))
            {
                MsgBox("已经连接.");
                return;
            }
            ip = textEdit1.Text;
            ftp = new FtpWeb(ip, path_zjxt, userdownload, pwdownload);
            bool b = ftp.ftpPing();
            if (b)
            {
                ButtonEnable(true);
                SimpleButton_f5_Click(null, null);
            }
            else
            {
                ButtonEnable(false);
                MsgBox(ftp.errMsg);
                ftp = null;
            }
        }

        private void SimpleButton_f5_Click(object sender, EventArgs e)
        {
            if (ftp == null) return;
            ftp.GotoDirectory(path_zjxt, true);
            downloadFile(ftp, path_down, cfgzjxt, memoEdit_zjxtcfg);
            ftp.GotoDirectory(path_104, true);
            downloadFile(ftp, path_down, cfg104, memoEdit_104cfg);
        }

        private void SimpleButton_save_Click(object sender, EventArgs e)
        {
            if(xtraTabControl1.SelectedTabPageIndex == 0)
            {
                
            }
            MsgBox(xtraTabControl1.SelectedTabPage.Text);
        }

        private void downloadFile(FtpWeb ftp, string path,string fn, DevExpress.XtraEditors.MemoEdit memo)
        {
            bool b = ftp.Download(path, fn);
            if (b)
            {
                loadFile(path_down +"\\"+ cfgzjxt, memo);
                
            }
            else
            {
                MsgBox(ftp.errMsg);
                return;
            }
        }

        private void loadFile(string fn, DevExpress.XtraEditors.MemoEdit memo)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(fn, Encoding.UTF8);
                memo.Text = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        private void saveFile(string fn, DevExpress.XtraEditors.MemoEdit memo)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(fn, FileMode.Create);
                sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(memo.Text);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
                if (fs != null)
                    fs.Close();
            }
        }
    }
}
