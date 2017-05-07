using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using avcbuilder1;
using log4net;
using mysqlDao_v1;
using AvcDb.entities;

namespace avcbuilder1.tblForms
{
    public partial class FormYkYtExpri : avcbuilder1.tblForms.FormBase
    {
        ILog log = null;
        mysqlDAO dao = null;
        public FormYkYtExpri()
        {
            StartPosition = FormStartPosition.CenterScreen;
            log = LogManager.GetLogger("log");
            InitializeComponent();
            listBoxControl_yk.SelectedIndexChanged += ListBoxControl_yk_SelectedIndexChanged;
            listBoxControl_yt.SelectedIndexChanged += ListBoxControl_yt_SelectedIndexChanged;
            simpleButton_yk.Click += SimpleButton_yk_Click;
            simpleButton_yt.Click += SimpleButton_yt_Click;
            radioButton_up.Click += RadioButton1_Click;
            radioButton_down.Click += RadioButton2_Click;
            textEdit1.EditValueChanged += TextEdit1_EditValueChanged;
        }

        tblykparam curyk = new tblykparam();
        tblytparam curyt = new tblytparam();
        tblcommand curcmd_yk = new tblcommand();
        tblcommand curcmd_yt = new tblcommand();
        private void showCmd()
        {
            string strf = null;
             if(xtraTabControl1.SelectedTabPageIndex == 0)
            {                
                strf = "{1} {0} 厂站号:{2} 点号:{3} 遥控值:{4}";
                string str = string.Format(strf, curyk.NAME, curcmd_yk.CMDDATETIME, curcmd_yk.CZH, curcmd_yk.YKYTH, curcmd_yk.YKYTVALUE);
                memoEdit1.Text = str;
            }
            else
            {
                strf = "{1} {0} 厂站号:{2} 点号:{3} 遥调值:{4}";
                string str = string.Format(strf, curyt.NAME, curcmd_yt.CMDDATETIME, curcmd_yt.CZH, curcmd_yt.YKYTH, curcmd_yt.YTVALUE);
                memoEdit2.Text = str;
            }
        }

        private void TextEdit1_EditValueChanged(object sender, EventArgs e)
        {
            float value;
            bool b = float.TryParse(textEdit1.Text, out value);
            if (b)
            {
                curcmd_yt.YTVALUE = value;
                showCmd();
            }
        }

        private void RadioButton2_Click(object sender, EventArgs e)
        {
            RadioButton1_Click(sender, e);
        }

        private void RadioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton_up.Checked)
            {
                curcmd_yk.CZH = int.Parse(curyk.UPPER_CZH);
                curcmd_yk.YKYTH = int.Parse(curyk.UPPER_YKYTH);
                curcmd_yk.YKYTVALUE = curyk.UPPER_YKYTVALUE;
            }
            else
            {
                curcmd_yk.CZH = int.Parse(curyk.LOWER_CZH);
                curcmd_yk.YKYTH = int.Parse(curyk.LOWER_YKYTH);
                curcmd_yk.YKYTVALUE = curyk.LOWER_YKYTVALUE;
            }
            showCmd();
        }

        private void SimpleButton_yt_Click(object sender, EventArgs e)
        {
            string sql = mysqlDAO.getInsertSql(curcmd_yt);
            try
            {
                dao.Execute(sql);
                MsgBox("命令已保存.");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
            }
        }

        private void SimpleButton_yk_Click(object sender, EventArgs e)
        {
            if (curcmd_yk.YKYTVALUE == null)
            {
                MsgBox(curyk.NAME + " 遥控值未定义");
                return;
            }
            string sql = mysqlDAO.getInsertSql(curcmd_yk);
            try
            {
                dao.Execute(sql);
                MsgBox("命令已保存.");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
            }
        }

        private void ListBoxControl_yt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxControl_yt.SelectedIndex;
            if (i == -1) return;
            DataRow dr = dtyt.Rows[i];
            mysqlDAO.fillPoco(curyt, dr);
            curcmd_yt.CMDELEMENTID = curyt.CMDELEMENTID;
            curcmd_yt.CONTROLAREA = int.Parse(curyt.CONTROLAREA);
            curcmd_yt.CHANNEL = curyt.CHANNEL;
            curcmd_yt.CZH = int.Parse(curyt.CZH);
            curcmd_yt.YKYTH = int.Parse(curyt.YTH);
            curcmd_yt.DEALTAG = 0;
            curcmd_yt.CMDDATETIME = DateTime.Now;
            curcmd_yt.YKYTTYPE = 1;
            curcmd_yk.ID = ++cmdid_index;
            curcmd_yk.SCHEMEID = curcmd_yk.ID;
            curcmd_yk.SCHEMEINDEX = 0;
            showCmd();
        }

        int cmdid_index = 60000;
        private void ListBoxControl_yk_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxControl_yk.SelectedIndex;
            if (i == -1) return;
            DataRow dr = dtyk.Rows[i];
            mysqlDAO.fillPoco(curyk, dr);
            curcmd_yk.CMDELEMENTID = curyk.CMDELEMENTID;
            curcmd_yk.CONTROLAREA = int.Parse(curyk.CONTROLAREA);
            curcmd_yk.CHANNEL = curyk.CHANNEL;
            curcmd_yk.DEALTAG = 0;
            curcmd_yk.CMDDATETIME = DateTime.Now;
            curcmd_yk.YKYTTYPE = 0;
            curcmd_yk.ID = ++cmdid_index;
            curcmd_yk.SCHEMEID = curcmd_yk.ID;
            curcmd_yk.SCHEMEINDEX = 0;      
            showCmd();
        }

        DataTable dtyk = null;
        DataTable dtyt = null;
        override public void Ini()
        {
            base.Ini();
            if (dao == null)
                dao = FormConnectSrv.Instance.Dao;
            try
            {
                string sql = mysqlDAO.getQuerySql(new tblykparam(), null);
                dtyk = dao.Query(sql);

                sql = mysqlDAO.getQuerySql(new tblytparam(), null);
                dtyt = dao.Query(sql);
                loadList();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MsgBox(ex.Message);
            }
        }

        private void loadList()
        {
            try
            {
                listBoxControl_yk.BeginUpdate();
                listBoxControl_yk.DisplayMember = "NAME";
                listBoxControl_yk.ValueMember = "ID";
                listBoxControl_yk.DataSource = dtyk;
                listBoxControl_yk.EndUpdate();

                listBoxControl_yt.BeginUpdate();
                listBoxControl_yt.DisplayMember = "NAME";
                listBoxControl_yt.ValueMember = "ID";
                listBoxControl_yt.DataSource = null;
                listBoxControl_yt.DataSource = dtyt;
                listBoxControl_yt.EndUpdate();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
