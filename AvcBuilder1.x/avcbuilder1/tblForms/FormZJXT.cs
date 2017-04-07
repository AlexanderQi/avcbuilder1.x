using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using mysqlDao_v1;


namespace avcbuilder1.tblForms
{
    public partial class FormZJXT : avcbuilder1.tblForms.FormBase
    {
        mysqlDao_v1.mysqlDAO dao = null;
        public FormZJXT()
        {
            InitializeComponent();
            gridControl1.Enabled = false;
            simpleButton_refresh.Enabled = checkEdit1.Enabled = false;
            FormMain.Instance.AvcSrvConnected += Instance_AvcSrvConnected;
            FormMain.Instance.AvcSrvDisconnected += Instance_AvcSrvDisconnected;
            checkEdit1.Click += CheckEdit1_Click;
            timer1.Interval = 2500;
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (dao == null) return;
           
            RefreshGrid();
        }

        long id = 1;
        DataTable mdt = null;
        private void RefreshGrid()
        {
            string sql = null;
            if (id == 1)
                sql = "select Id,msg,msgtime from tblmsglist where time_to_sec(timediff(current_timestamp,msgtime))<30";
            else
                sql = "select Id,msg,msgtime from tblmsglist where id > "+id;
            try
            {
                if (mdt == null)
                {
                    mdt = dao.Query(sql);
                    if(mdt.Rows.Count > 0)
                        id = (long)mdt.Rows[mdt.Rows.Count-1][0];

                    gridControl1.BeginUpdate();
                    gridView1.BeginUpdate();

                    gridControl1.DataSource = mdt;

                    gridView1.EndUpdate();
                    gridControl1.EndUpdate();
                }
                else
                {
                    DataTable dt = dao.Query(sql);
                    if (dt.Rows.Count > 0)
                        id = (long)dt.Rows[dt.Rows.Count-1][0];
                    gridView1.BeginUpdate();
                    if (mdt.Rows.Count > 10000)
                    {
                        for (int i = 0; i < 1000; i++)
                            mdt.Rows.RemoveAt(i);
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        mdt.ImportRow(dr);
                    }
                    
                    mdt.AcceptChanges();
                    gridView1.EndUpdate();
                    gridView1.MoveLastVisible();
                }
                labelControl1.Text = DateTime.Now.ToString("HH:mm:ss") + " Last Id:"+id ;
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }



        }

        private void CheckEdit1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Instance_AvcSrvDisconnected(object sender, EventArgs e)
        {
            simpleButton_refresh.Enabled = checkEdit1.Enabled = false;
            gridControl1.Enabled = false;
            timer1.Enabled = false;
        }

        private void Instance_AvcSrvConnected(object sender, EventArgs e)
        {
            dao = FormConnectSrv.Instance.Dao;
            simpleButton_refresh.Enabled = checkEdit1.Enabled = true;
            gridControl1.Enabled = true;
        }

        private void simpleButton_refresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkEdit1.Checked;
        }
    }
}
