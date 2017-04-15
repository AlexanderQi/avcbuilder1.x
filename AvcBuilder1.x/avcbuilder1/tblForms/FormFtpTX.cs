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
            simpleButton_save.Visible = false;
            simpleButton_f5.Enabled = false;
            simpleButton_connect.Click += simpleButton1_Click;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MsgBox("通信管理机地址或网络异常，请检查。");
        }
    }
}
