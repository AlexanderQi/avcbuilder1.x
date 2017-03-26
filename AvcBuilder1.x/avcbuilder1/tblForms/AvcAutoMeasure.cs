using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using mysqlDao_v1;
using avcbuilder1;
using AvcDb.entities;

namespace avcbuilder1.tblForms
{
    class AvcMsgEventArgs : EventArgs
    {
        public AvcMsgEventArgs(string msg) : base()
        {
            Msg = msg;
        }
        public AvcMsgEventArgs() : base()
        {
        }
        internal string Msg;
    }
    class AvcAutoMeasure
    {
        public delegate void ProduceMsgHandle(object sender, AvcMsgEventArgs e);
        public event ProduceMsgHandle ProduceMsg;
        private mysqlDao_v1.mysqlDAO dao;
        private AvcMsgEventArgs ame = new AvcMsgEventArgs();
        private void sendMsg(string msg, int level)
        {
            string lev = null;
            for (int i = 0; i < level; i++)
                lev += "       ";
            ame.Msg = lev + msg;
            if (ProduceMsg != null)
            {
                ProduceMsg(this, ame);
            }
        }

        public AvcAutoMeasure(mysqlDao_v1.mysqlDAO dao)
        {
            this.dao = dao;
        }


        public void ProcedureElement(object poco, object measurePoco)
        {
            sendMsg(myPoco.getTabName(poco) + "自动生成量测...", 0);
            string sql = mysqlDAO.getQuerySql(poco, "");
            DataTable dt = dao.Query(sql);
            foreach (DataRow row in dt.Rows)
            {
                string ename = row["NAME"].ToString();
                string eid = row["ID"].ToString();
                sendMsg(ename + "开始添加量测...", 1);
                ProdureMeasure(ename, eid, measurePoco);

            }
            dao.SaveData(dt, poco, "ID");
        }

        private void ProdureMeasure(string elementName, string eid, object measurePoco)
        {
            DeleteByElementId(measurePoco, eid);
            DeleteYCYXByElementId(eid);
            //select COLUMN_NAME ,column_comment from I
            DataTable fieldName = dao.GetFieldComment(myPoco.getTabName(measurePoco));
            string sql = mysqlDAO.getQuerySql(measurePoco, "");
            DataTable dt = dao.Query(sql);

            myPoco.setPropertyValue(measurePoco, "ID", eid);
            string str_ycyxid = dao.getNewId(); //每次id转换成整数后，距上次id有51的差。而且一步量测表不会超过51个字段。
            int int_ycyxid = int.Parse(str_ycyxid);

            foreach (DataRow row in fieldName.Rows) //遍历量测表字段，生成对应YCYXID
            {
                string cfn = row[0].ToString();  //当前字段名
                if (cfn.Equals("ID")) continue; //主键ID 继续
                sendMsg(cfn + " = " + int_ycyxid, 2);
                myPoco.setPropertyValue(measurePoco, cfn, int_ycyxid);

                string cfn_chinese = elementName + "-" + row[1].ToString().Replace("编号", "");
                if (cfn.IndexOf("YCID") >= 0)
                {
                    WriteYC(int_ycyxid, cfn_chinese, "1", "1", eid);
                }
                else if (cfn.IndexOf("YXID") >= 0)
                {
                    WriteYX(int_ycyxid, cfn_chinese, "1", "1", eid);
                }

                int_ycyxid++;
            }
            sql = mysqlDAO.getInsertSql(measurePoco);
            int r = dao.Execute(sql);
            sendMsg(eid + " 执行结果 " + r, 2);
        }

        private void WriteYC(int ID, string Name, string areaId, string stationId, string elementId)
        {
            tblycvalue yc = new tblycvalue();
            yc.ID = ID.ToString();
            yc.NAME = Name;
            yc.CONTROLAREA = areaId;
            yc.SUBSTATIONID = stationId;
            yc.EQUIPMENTID = elementId;
            yc.YCH = "-1";
            yc.CZH = "-1";
            string sql = mysqlDAO.getInsertSql(yc);
            int r = dao.Execute(sql);
            sendMsg(string.Format("遥测信息 ID = {0} 名称 = {1} 设备ID = {2} 结果 = {3}", ID, Name, elementId, r), 4);
        }

        private void WriteYX(int ID, string Name, string areaId, string stationId, string elementId)
        {
            tblyxvalue yx = new tblyxvalue();
            yx.ID = ID.ToString();
            yx.NAME = Name;
            yx.CONTROLAREA = areaId;
            yx.SUBSTATIONID = stationId;
            yx.EQUIPMENTID = elementId;
            yx.YXH = "-1";
            yx.CZH = "-1";
            string sql = mysqlDAO.getInsertSql(yx);
            int r = dao.Execute(sql);
            sendMsg(string.Format("遥信信息 ID = {0} 名称 = {1} 设备ID = {2} 结果 = {3}", ID, Name, elementId, r), 4);
        }

        public void DeleteByElementId(object measurePoco, string elementId)
        {
            //sendMsg(string.Format("将删除 {0} 信息 设备ID = {1}", myPoco.getTabName(measurePoco), elementId),2);
            string sql;
            if (elementId != null)
            {
                sql = mysqlDAO.getDeleteSql(measurePoco, "ID", elementId);
            }
            else
            {
                sql = mysqlDAO.getDeleteSql(measurePoco, null);
            }
            int r = dao.Execute(sql);
            sendMsg(myPoco.getTabName(measurePoco) + " 删除旧量测信息 " + r, 2);
        }

        public void DeleteYCYXByElementId(string elementId)
        {
            tblycvalue yc = new tblycvalue();
            tblyxvalue yx = new tblyxvalue();
            if (elementId == null)
            {
                sendMsg("将删除旧遥测遥信表信息",2);

                string sql = mysqlDAO.getDeleteSql(yc, null);
                int r = dao.Execute(sql);
                sendMsg("删除旧遥测表信息 " + r, 2);
                sql = mysqlDAO.getDeleteSql(yx, null);
                r = dao.Execute(sql);
                sendMsg("删除旧遥信表信息 " + r, 2);
            }
            else
            {
                sendMsg("将删除旧遥测遥信表信息 设备ID =" + elementId, 2);

                string sql = mysqlDAO.getDeleteSql(yc, "EQUIPMENTID", elementId);
                int r = dao.Execute(sql);
                sendMsg("删除旧遥测表信息 " + r, 2);
                sql = mysqlDAO.getDeleteSql(yx, "EQUIPMENTID", elementId);
                r = dao.Execute(sql);
                sendMsg("删除旧遥信表信息 " + r, 2);

            }
        }
    }
}
