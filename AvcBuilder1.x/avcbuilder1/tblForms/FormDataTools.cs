using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using avcbuilder1;
using mysqlDao_v1;
using AvcDb.entities;

namespace avcbuilder1.tblForms
{
    public partial class FormDataTools : avcbuilder1.tblForms.FormBase
    {
        public mysqlDAO dao;
        public FormDataTools()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Shown += FormDataTools_Shown;
        }

        private void FormDataTools_Shown(object sender, EventArgs e)
        {
            if (dao == null)
            {
                dao = FormConnectSrv.Instance.Dao;
            }
            if (auto == null)
                auto = new AvcAutoMeasure(dao);
        }

        private void simpleButton_exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        AvcAutoMeasure auto;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
            tblfeedcapacitormeasure m = new tblfeedcapacitormeasure();
            auto.DeleteByElementId(m, null);
          
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            auto.ProcedureElement(new tblfeedcapacitor(), new tblfeedcapacitormeasure());
        }
    }
}
