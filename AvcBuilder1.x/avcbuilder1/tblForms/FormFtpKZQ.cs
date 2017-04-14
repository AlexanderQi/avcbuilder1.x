using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace avcbuilder1.tblForms
{
    public partial class FormFtpKZQ : avcbuilder1.tblForms.FormFtpBase
    {
        public FormFtpKZQ()
        {
            InitializeComponent();
            ButtonEnable(false);
            textEdit1.Text = "192.168.0.230";
            simpleButton_connect.Click += simpleButton1_Click;
        }

        private void ButtonEnable(bool b)
        {
            xtraTabControl1.Enabled =
            simpleButton_save.Enabled = 
            simpleButton_f5.Enabled =
            simpleButton_reboot.Enabled = simpleButton_rezjxt.Enabled = simpleButton_re104.Enabled = b;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MsgBox("设备地址或者用户名密码错误，请检查。");
           
        }
    }
}
