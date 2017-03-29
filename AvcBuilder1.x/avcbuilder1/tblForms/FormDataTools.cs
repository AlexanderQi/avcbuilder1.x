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
using System.Threading.Tasks;

namespace avcbuilder1.tblForms
{
    public partial class FormDataTools : avcbuilder1.tblForms.FormBase
    {
        Action<string> AsyncShowMsg = null;
        public mysqlDAO dao;
        public FormDataTools()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Shown += FormDataTools_Shown;
            AsyncShowMsg = new Action<string>(ShowMsg);

        }
        private void FormDataTools_Shown(object sender, EventArgs e)
        {
            if (dao == null)
            {
                dao = new mysqlDAO(FormConnectSrv.Instance.avc_conn);
                dao.SetSqlForNewId(FormConnectSrv.sql4NewId);
            }
            auto = new AvcAutoProduce(dao);
            auto.ProduceMsg += Auto_ProduceMsg;
            
        }
        AvcAutoProduce auto;

        private void autoMeasure()
        {
           
            
            //auto.ProcedureTblElement(new tblfeedtrans());
            //auto.ProcedureTblElement(new tblfeedvoltageregulator());

            auto.ProcedureMeasure(new tblfeedcapacitor(), new tblfeedcapacitormeasure());
            auto.ProcedureMeasure(new tblfeedtrans(), new tblfeedtransmeasure());
            auto.ProcedureMeasure(new tblfeedvoltageregulator(), new tblfeedvoltageregulatormeasure());
        }

        private void autoBasic()
        {
            auto.DeleteBasic();
            tblfeedcapacitor cap = new tblfeedcapacitor();
            tblfeedtrans trans = new tblfeedtrans();
            tblfeedvoltageregulator vol = new tblfeedvoltageregulator();

            auto.ProcedureElement(cap);
            auto.ProcedureElement(trans);
            auto.ProcedureElement(vol);

            auto.ProcedureState(cap);
            auto.ProcedureState(trans);
            auto.ProcedureState(vol);

            tblfeeder f = new tblfeeder();
            auto.ProcedureState(f);
        }

        private void autoLimit()
        {
            auto.DeleteLimit();
            tblfeedcapacitor cap = new tblfeedcapacitor();
            tblfeedtrans trans = new tblfeedtrans();
            tblfeedvoltageregulator vol = new tblfeedvoltageregulator();
            auto.ProcedureLimit(cap);
            auto.ProcedureLimit(trans);
            auto.ProcedureLimit(vol);
        }

        private void Auto_ProduceMsg(object sender, AvcMsgEventArgs e)
        {
            this.Invoke(AsyncShowMsg, e.Msg);            
        }


        
        private void ShowMsg(string msg)
        {
            listBoxControl1.Items.Add(msg);
        }

        

        private void simpleButton_exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MsgBox("将会清空量测信息，且不可恢复,是否继续？", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            listBoxControl1.Items.Clear();
            AvcAutoProduce am = new AvcAutoProduce(dao);
            am.ProduceMsg += Auto_ProduceMsg;
            tblfeedcapacitormeasure m = new tblfeedcapacitormeasure();
            am.DeleteYCYXByElementId(null);
            am.DeleteByElementId(m, null);
            am.DeleteByElementId(new tblfeedtransmeasure(), null);
            am.DeleteByElementId(new tblfeedvoltageregulatormeasure(), null);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (MsgBox("将会覆盖量测信息，且不可恢复,是否继续？", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            try
            {
                listBoxControl1.Items.Clear();
                Task task = new Task(new Action(autoMeasure));
                task.Start();
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (MsgBox("将会覆盖以下表信息(设备汇总,状态,动作次数,运行时间)，且不可恢复,是否继续？", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            try
            {
                listBoxControl1.Items.Clear();
                Task task = new Task(new Action(autoBasic));
                task.Start();
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (MsgBox("将会覆盖限值表信息，且不可恢复,是否继续？", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            try
            {
                listBoxControl1.Items.Clear();
                Task task = new Task(new Action(autoLimit));
                task.Start();
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            auto.DeleteBasic();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            auto.DeleteLimit();
        }
    }
}
