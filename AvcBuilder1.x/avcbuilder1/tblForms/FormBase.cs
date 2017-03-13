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

namespace avcbuilder1.tblForms
{
    public partial class FormBase : DevExpress.XtraEditors.XtraForm
    {

        protected ILog log;
        protected string avc_conn = "";
        protected mysqlDAO MysqlDao;
        protected static FormBase instance = null;
        protected myConnInfo conninfo;

        public static FormBase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormBase();
                }
                return instance;
            }
        }
        protected FormBase()
        {
            lock (this)
            {
                log = LogManager.GetLogger("log");
                InitializeComponent();
            }
            
        }

        public void ShowInControl(Control owner)
        {
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.Parent = owner;
            owner.Tag = this;
            this.Show();
        }

        virtual public void Query(String sql) { }
 

        protected void MsgBox(string msg)
        {
            XtraMessageBox.Show(msg);
        }

        protected DialogResult MsgBox(string text, string caption, MessageBoxButtons buttons)
        {
            return XtraMessageBox.Show(text, caption, buttons);
        }
    }
}