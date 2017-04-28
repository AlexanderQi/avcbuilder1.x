using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using myRemoteLib_v1;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace avcbuilder1.tblForms
{
    public partial class FormFtpKZQ : avcbuilder1.tblForms.FormFtpBase
    {
        //ILog log;
        public FormFtpKZQ()
        {
            InitializeComponent();
            ButtonEnable(false);
            textEdit1.Text =  "192.168.0.230"; //"192.168.1.195"; 
           // ip = textEdit1.Text;
            simpleButton_connect.Click += simpleButton1_Click;
            simpleButton_f5.Click += SimpleButton_f5_Click;
            simpleButton_save.Click += SimpleButton_save_Click;
            simpleButton_log.Click += SimpleButton_log_Click;
            simpleButton_reboot.Click += SimpleButton_reboot_Click;
            simpleButton_upXJXT.Click += SimpleButton_upXJXT_Click;
        }

        private void SimpleButton_upXJXT_Click(object sender, EventArgs e)
        {
            if (ftp == null) return;
            FolderBrowserDialog bd = new FolderBrowserDialog();
            bd.Description = "选择区域控制器更新文件路径:";
            if (bd.ShowDialog() != DialogResult.OK) return;
            
            bool b = true;
            string zjxt_filename = bd.SelectedPath + "\\zjxt2.jar";
            string jk_filename = bd.SelectedPath + "\\iec104.jar";
            string sh_filename = bd.SelectedPath + "\\run_zjxt.sh";
            int num_update = 0;
            if (File.Exists(zjxt_filename))  //路径下有专家系统文件
            {
                ftp.GotoDirectory(ftp_path_zjxt, true);
                b = ftp.Upload(zjxt_filename);
                num_update++;
                if (b)
                    MsgBox("专家系统更新成功");
                else
                    MsgBox(ftp.errMsg);
            }
            if (File.Exists(jk_filename))  //路径下接口文件
            {
                ftp.GotoDirectory(ftp_path_104, true);
                b = ftp.Upload(jk_filename);
                num_update++;
                if (b)
                    MsgBox("接口更新成功");
                else
                    MsgBox(ftp.errMsg);
            }
            if (File.Exists(sh_filename))  //路径下启动脚本文件
            {
                ftp.GotoDirectory(ftp_path_sh, true);
                b = ftp.Upload(sh_filename);
                num_update++;
                if (b)
                    MsgBox("启动程序更新成功");
                else
                    MsgBox(ftp.errMsg);
            }
            if(num_update == 0)
            {
                MsgBox(string.Format("路径:{0} 没有区域控制器更新文件", bd.SelectedPath));
            }

        }

  

        Process cmd = null;
        private void SimpleButton_reboot_Click(object sender, EventArgs e)
        {
            //plink.exe -ssh -pw moxa root@192.168.0.230 "sh /home/softcore/sh/stopAll.sh;"
            //plink.exe -ssh -pw raspberry pi@192.168.1.195 "echo dadddad----a |wall"
            string fn = "tool\\plink.exe";
            if (!File.Exists(fn))
            {
                MsgBox("缺少组件，无法执行.");
                return;
            }
            string rootpw = "moxa";
            string linuxcmd = "reboot";
            //string linuxcmd_test = "echo this os will reboot | wall";
            string args = string.Format("-ssh -pw {2} root@{0} \"{1}\"", ip, linuxcmd, rootpw);
            
            try
            {
                if (cmd == null)
                {
                    cmd = new Process();
                    cmd.StartInfo.Arguments = args;
                    cmd.StartInfo.FileName = fn;
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.RedirectStandardError = true;
                    cmd.StartInfo.CreateNoWindow = true; //对于控制台程序可以不打开控制台窗口。
                    cmd.StartInfo.UseShellExecute = false; //同时不能用shell执行，否则控制台窗口就会被打开。

                    cmd.EnableRaisingEvents = true;
                    cmd.Exited += Cmd_Exited;
                    cmd.OutputDataReceived += Cmd_OutputDataReceived ;
                    cmd.ErrorDataReceived += Cmd_ErrorDataReceived;
                }
                cmd.Start();
                cmd.BeginOutputReadLine();
                cmd.BeginErrorReadLine();
                cmd.WaitForExit();
                //Thread.Sleep(5000);         
                ip = "";
            }
            catch (Exception ex)
            {
                if (cmd != null)
                    cmd.Kill();
                MsgBox(ex.Message);
            }
            finally
            {
                if (cmd != null)
                    cmd.Close();
            }
        }

        private void Cmd_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;
            string str = e.Data;
            if (str.IndexOf("conn") >= 0) //plink 第一次登录ssh服务器时,会询问是否接受公钥,等屁话一大堆,必须回复y/n,否则挂起主线程.
            {
                cmd.StandardInput.Write("y\r");
            }
        }

        private void Cmd_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

        }

        private void Cmd_Exited(object sender, EventArgs e)
        {
            MsgBox("重启指令已发送.");
        }

        private void ButtonEnable(bool b)
        {
            simpleButton_upXJXT.Enabled =
            simpleButton_reboot.Enabled = 
            xtraTabControl1.Enabled =
            simpleButton_save.Enabled =
            simpleButton_f5.Enabled = simpleButton_log.Enabled =b;
            
           // 
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

        string ftp_path_zjxt = @"/home/softcore/bin/zjxt";
        string ftp_path_104 = @"/home/softcore/bin/JK104";
        string ftp_path_sh = @"/home/softcore/sh";

        string ip = "";
        string local_path_down = "d:";
        string cfgzjxt = "c3p0-config-zjxt2.xml";
        string cfg104 = "cfg.txt";
        string[] files = null;
        FtpWeb ftp = null;

        string file_zjxt = "zjxt2.jar";
        string file_jk = "iec104.jar";

        string zjxt_log = "zjxt2.log";
        string ftp_path_zjxt_log = @"/home/softcore/log/zjxt2";

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (ip.Equals(textEdit1.Text.Trim()))
            {
                MsgBox("已经连接.");
                return;
            }
            ip = textEdit1.Text;
            ftp = new FtpWeb(ip, ftp_path_zjxt, userdownload, pwdownload);
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
            ftp.GotoDirectory(ftp_path_zjxt, true);
            downloadFile(ftp, local_path_down, cfgzjxt, memoEdit_zjxtcfg);
            ftp.GotoDirectory(ftp_path_104, true);
            downloadFile(ftp, local_path_down, cfg104, memoEdit_104cfg);
        }

        private void SimpleButton_save_Click(object sender, EventArgs e)
        {
            string sourcefile = null;
            if(xtraTabControl1.SelectedTabPageIndex == 0)
            {
                sourcefile = local_path_down + "\\" + cfgzjxt;
                bool b = saveFile(sourcefile, memoEdit_zjxtcfg);
                if (b)
                {
                    ftp.GotoDirectory(ftp_path_zjxt, true);
                    b =  ftp.Upload(sourcefile);
                    if (!b)
                        MsgBox(ftp.errMsg);
                    else
                        MsgBox(xtraTabControl1.SelectedTabPage.Text + " 下装成功.");
                }
            }
            else
            {
                sourcefile = local_path_down + "\\" + cfg104;
                bool b = saveFile(sourcefile, memoEdit_104cfg);
                if (b)
                {
                    ftp.GotoDirectory(ftp_path_104, true);
                    b = ftp.Upload(sourcefile);
                    if (!b)
                        MsgBox(ftp.errMsg);
                    else
                        MsgBox(xtraTabControl1.SelectedTabPage.Text + " 下装成功.");
                }
            }
        }

        private void SimpleButton_log_Click(object sender, EventArgs e)
        {
            if (ftp == null) return;
            FolderBrowserDialog bd = new FolderBrowserDialog();
            bd.Description = "选择 "+zjxt_log+" 日志存放路径:";
            if (bd.ShowDialog() != DialogResult.OK) return;
            ftp.GotoDirectory(ftp_path_zjxt_log,true);
            bool b = ftp.Download(bd.SelectedPath, zjxt_log);
            if (b)
                MsgBox("日志已保存在 " + bd.SelectedPath);
            else
                MsgBox(ftp.errMsg);
        }

        private void downloadFile(FtpWeb ftp, string path,string fn, DevExpress.XtraEditors.MemoEdit memo)
        {
            bool b = ftp.Download(path, fn);
            if (b)
            {
                loadFile(path +"\\"+ fn, memo);
            }
            else
            {
                MsgBox(ftp.errMsg);
                return;
            }
        }

        private bool loadFile(string fn, DevExpress.XtraEditors.MemoEdit memo)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(fn, Encoding.UTF8); //Encoding.GetEncoding("GBK")
                memo.Text = sr.ReadToEnd();
                sr.Close();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
                return false;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        private bool saveFile(string fn, DevExpress.XtraEditors.MemoEdit memo)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(fn, FileMode.Create);
                sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(memo.Text);
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
                return false;
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
