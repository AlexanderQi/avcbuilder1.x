using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace avcbuilder1.tblForms
{
    public partial class FormDataTools : avcbuilder1.tblForms.FormBase
    {
        public FormDataTools()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void simpleButton_exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}
