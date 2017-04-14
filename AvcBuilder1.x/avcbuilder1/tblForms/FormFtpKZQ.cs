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
            simpleButton_save.Visible = false;
            simpleButton_f5.Enabled = false;
            simpleButton_connect.Click += simpleButton1_Click;
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MsgBox("设备地址或者用户名密码错误，请检查。");
           
        }
    }
}
