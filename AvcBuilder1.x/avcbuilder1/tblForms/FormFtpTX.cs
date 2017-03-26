using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace avcbuilder1.tblForms
{
    public partial class FormFtpTX : avcbuilder1.tblForms.FormFtpBase
    {
        public FormFtpTX()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MsgBox("通信管理机地址或用户名密码错误，请检查。");
        }
    }
}
