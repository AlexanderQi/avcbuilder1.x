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

namespace avcbuilder1
{
    static class Program
    {
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
