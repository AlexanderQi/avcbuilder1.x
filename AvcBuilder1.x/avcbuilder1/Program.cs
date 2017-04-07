using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using log4net;
using log4net.Config;
using System.IO;
using Microsoft.Win32;


namespace avcbuilder1
{
    static class Program
    {
        static void RegCheck()
        {
            string str = "SOFTWARE\\avcbuilder";
            RegistryKey key = Registry.CurrentUser;

            try
            {
                RegistryKey software = key.OpenSubKey(str, true);
                if(software == null)
                {
                    software = key.CreateSubKey(str);
                    key.Close();
                    key.OpenSubKey(str);
                }
                object v = software.GetValue("xstart");
                DateTime d;
                if (v == null)
                {
                    d = DateTime.Now;
                    software.SetValue("xstart", d);
                }
                else
                {
                    d = Convert.ToDateTime(v);
                }
                //MessageBox.Show("软件注册于" + d);
                TimeSpan ts = DateTime.Now - d;
                if(ts.Days > 30)
                {
                    MessageBox.Show("软件注册已过期.");
                    Environment.Exit(0);
                }
                //MessageBox.Show("软件注册于" + d + " 已用"+ts.Days+"天");
            }
            catch (Exception ex)
            {
                log.Debug(ex.Message);
                MessageBox.Show("软件注册信息错误.请重新安装.");
                //throw;
            }


        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            //UserLookAndFeel.Default.SetSkinStyle("Visual Studio 2013 Dark");
            InitLog();
            log.Debug("AvcBuilder started.");
            RegCheck();
            //Application.Run(new FormMain());

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-Hans");//zh-Hans
            Application.Run(new FormMain());
        }

        private static ILog log;
        private static void InitLog()
        {
            var logfile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Log4net.config");
            XmlConfigurator.ConfigureAndWatch(logfile);
            log = LogManager.GetLogger("log");
        }
    }
}
