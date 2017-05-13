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
    class AvcAutoProduce
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
        private int ych_seed = 1000;
        private int yxh_seed = 1000;
        public AvcAutoProduce(mysqlDao_v1.mysqlDAO dao)
        {
            this.dao = dao;
        }

        /// <summary>
        /// 自动生成Element表信息.
        /// </summary>
        /// <param name="poco"></param>
        //public void ProcedureTblCommnDetail(object poco, object DetialPoco)
        //{
        //    sendMsg(myPoco.getTabName(poco) + " 生成基本信息..."+ myPoco.getTabName(DetialPoco), 0);
        //    string sql = mysqlDAO.getQuerySql(poco, "");
        //    DataTable pocoDt = dao.Query(sql);

        //    sql = mysqlDAO.getDeleteSql(DetialPoco, null);
        //    dao.Execute(sql);
        //    foreach (DataRow row in pocoDt.Rows)
        //    {
        //        myPoco.setPropertyValue(DetialPoco, "ID", row["ID"]);
        //        sql = mysqlDAO.getInsertSql(DetialPoco);
        //        dao.Execute(sql);
        //    }
        //}

        public void DeleteBasic()
        {
            tblelement e = new tblelement();
            string sql = mysqlDAO.getDeleteSql(e, null);
            dao.Execute(sql);
            sendMsg("清空tblelement表", 0);

            tblelementaction ea = new tblelementaction();
            sql = mysqlDAO.getDeleteSql(ea, null);
            dao.Execute(sql);
            sendMsg("清空tblelementaction表", 0);

            tblelementstate es = new tblelementstate();
            sql = mysqlDAO.getDeleteSql(es, null);
            dao.Execute(sql);
            sendMsg("清空tblelementstate表", 0);

            tblelementruntime er = new tblelementruntime();
            sql = mysqlDAO.getDeleteSql(er, null);
            dao.Execute(sql);
            sendMsg("清空tblelementruntime表", 0);
        }

        public void DeleteLimit()
        {
            tblelementlimit l = new tblelementlimit();
            string sql = mysqlDAO.getDeleteSql(l, null);
            dao.Execute(sql);
            sendMsg("清空tblelementlimit表", 0);
        }

        public long? getElementStyle(object poco)
        {
            if (poco is tblfeedtrans)
                return 28;
            else if (poco is tblfeedcapacitor)
                return 29;
            else if (poco is tblfeedvoltageregulator)
                return 30;
            else if (poco is tblfeedapf)
                return 31;
            else if (poco is tblfeedtsf)
                return 32;
            else if (poco is tblfeedsvg)
                return 33;
            else if (poco is tblfeeder)
                return 37;
            else
                return null;
        }

        public void ProcedureElement(object poco)
        {
            sendMsg(myPoco.getTabName(poco) + " 生成element...", 0);
            string sql = mysqlDAO.getQuerySql(poco, "");
            DataTable pocoDt = dao.Query(sql);
            tblelement e = new tblelement();
            foreach (DataRow row in pocoDt.Rows)
            {
                e.ID = row["ID"].ToString();
                e.NAME = row["NAME"].ToString();
                if (poco is tblfeeder)
                    e.FEEDID = e.ID;
                else
                    e.FEEDID = row["FEEDID"].ToString();
                e.VOLTAGELEVELID = row["VOLTAGELEVELID"].ToString();
                e.PARENTID = e.FEEDID;
                e.ELEMENTSTYLE = getElementStyle(poco);
                sql = mysqlDAO.getInsertSql(e);
                dao.Execute(sql);
            }
            sendMsg(" 生成element 完成", 0);
        }

        public void ProcedureAction(object poco)
        {
            sendMsg(myPoco.getTabName(poco) + " 生成tblelementaction...", 0);
            string sql = mysqlDAO.getQuerySql(poco, "");
            DataTable pocoDt = dao.Query(sql);
            tblelementaction e = new tblelementaction();
            foreach (DataRow row in pocoDt.Rows)
            {
                e.ID = 0;
                e.ELEMENTID = row["ID"].ToString();
                e.ELEMENTSTYLE = getElementStyle(poco);
                sql = mysqlDAO.getInsertSql(e);
                dao.Execute(sql);
            }
        }

        public void ProcedureRuntime(object poco)
        {
            sendMsg(myPoco.getTabName(poco) + " 生成tblelementruntime...", 0);
            string sql = mysqlDAO.getQuerySql(poco, "");
            DataTable pocoDt = dao.Query(sql);
            tblelementruntime e = new tblelementruntime();
            foreach (DataRow row in pocoDt.Rows)
            {
                e.ELEMENTID = row["ID"].ToString();
                e.ELEMENTSTYLE = Convert.ToInt32(getElementStyle(poco));
                sql = mysqlDAO.getInsertSql(e);
                dao.Execute(sql);
            }
            sendMsg( "生成tblelementruntime 完成", 0);
        }

        public void ProcedureState(object poco)
        {
            sendMsg(myPoco.getTabName(poco) + " 生成State...", 0);
            string sql = mysqlDAO.getQuerySql(poco, "");
            DataTable pocoDt = dao.Query(sql);
            tblelementstate e = new tblelementstate();

            sql = "show columns from tblelementstate";
            DataTable defaults = dao.Query(sql);
            foreach (DataRow row in pocoDt.Rows)
            {
                e.ELEMENTID = row["ID"].ToString();
                e.CONTROLSTATE = "建议";
                e.ELEMENTSTYLE = getElementStyle(poco);
                //int? x = Convert.ToInt32(defaults.Select("Field = 'ADVICELOCKSEC'")[0]["Default"]);                
                //sendMsg(x.ToString(), 2);

                e.ADVICELOCKSEC = Convert.ToInt32(defaults.Select("Field = 'ADVICELOCKSEC'")[0]["Default"]);
                e.PREPARLOCKSEC = Convert.ToInt32(defaults.Select("Field = 'PREPARLOCKSEC'")[0]["Default"]);
                e.SUCCESSLOCKSEC = Convert.ToInt32(defaults.Select("Field = 'SUCCESSLOCKSEC'")[0]["Default"]);
                e.FAILURELOCKSEC = Convert.ToInt32(defaults.Select("Field = 'FAILURELOCKSEC'")[0]["Default"]);
                e.SLIPTAPLOCKSEC = Convert.ToInt32(defaults.Select("Field = 'SLIPTAPLOCKSEC'")[0]["Default"]);
                e.REPEATEDFAILURELOCKSEC = Convert.ToInt32(defaults.Select("Field = 'REPEATEDFAILURELOCKSEC'")[0]["Default"]);
                e.REPEATEDFAILURECOUNT = Convert.ToInt32(defaults.Select("Field = 'REPEATEDFAILURECOUNT'")[0]["Default"]);
                e.MAXREPEATEDFAILURECOUNT = Convert.ToInt32(defaults.Select("Field = 'MAXREPEATEDFAILURECOUNT'")[0]["Default"]);

                sql = mysqlDAO.getInsertSql(e);
                dao.Execute(sql);
            }
            sendMsg("生成State 完成", 0);
        }

        public void ProcedureLimit(object poco)
        {
            sendMsg(myPoco.getTabName(poco) + " 生成限值...", 0);
            string sql = mysqlDAO.getQuerySql(poco, "");
            DataTable pocoDt = dao.Query(sql);

            foreach (DataRow row in pocoDt.Rows)
            {
                tblelementlimit e = new tblelementlimit();
                e.ELEMENTID = row["ID"].ToString();
                e.LIMITNAME = row["NAME"].ToString();
                e.ISTEMP = false;
                e.LIMITKIND = "电压";
                e.ELEMENTSTYLE = getElementStyle(poco);

                int vollevel = int.Parse(row["VOLTAGELEVELID"].ToString());
                if (vollevel == 1)
                {
                    e.L_LIMIT = 200;
                    e.LL_LIMIT = 195;

                    e.H_LIMIT = 225;
                    e.HH_LIMIT = 230;
                }
                else if (vollevel == 2)
                {
                    e.L_LIMIT = 360;
                    e.LL_LIMIT = 350;

                    e.H_LIMIT = 400;
                    e.HH_LIMIT = 405;

                }
                else if (vollevel == 4)
                {
                    e.L_LIMIT = 10100;
                    e.LL_LIMIT = 10000;

                    e.H_LIMIT = 10500;
                    e.HH_LIMIT = 10600;
                }
                e.LIMITGROUPNAME = "[21-0点]";
                e.PERIODBEGIN = new TimeSpan(21, 0, 0);
                e.PERIODEND = new TimeSpan(23, 59, 59);
                sql = mysqlDAO.getInsertSql(e);
                dao.Execute(sql);
                e.LIMITGROUPNAME = "[0-8点]";
                e.PERIODBEGIN = new TimeSpan(0, 0, 0);
                e.PERIODEND = new TimeSpan(8, 0, 0);
                sql = mysqlDAO.getInsertSql(e);
                dao.Execute(sql);
                e.LIMITGROUPNAME = "[8-21点]";
                if (vollevel == 1)
                {
                    e.L_LIMIT = 205;
                    e.LL_LIMIT = 200;

                    e.H_LIMIT = 230;
                    e.HH_LIMIT = 235;
                }
                else if (vollevel == 2)
                {
                    e.L_LIMIT = 365;
                    e.LL_LIMIT = 355;

                    e.H_LIMIT = 405;
                    e.HH_LIMIT = 410;

                }
                else if (vollevel == 3)
                {
                    e.L_LIMIT = 10150;
                    e.LL_LIMIT = 10100;

                    e.H_LIMIT = 10550;
                    e.HH_LIMIT = 10650;
                }
                e.PERIODBEGIN = new TimeSpan(8, 0, 0);
                e.PERIODEND = new TimeSpan(21, 0, 0);
                sql = mysqlDAO.getInsertSql(e);
                dao.Execute(sql);

                e.LIMITKIND = "功率因数";
                e.LIMITGROUPNAME = "[0-24点]";
                e.LL_LIMIT = 0.999f;
                e.L_LIMIT = 0.999f;
                e.H_LIMIT = 0.999f;
                e.HH_LIMIT = 0.999f;
                e.PERIODBEGIN = new TimeSpan(0, 0, 0);
                e.PERIODEND = new TimeSpan(23, 59, 59);
                sql = mysqlDAO.getInsertSql(e);
                dao.Execute(sql);

                e.LIMITKIND = "动作次数";
                e.LIMITGROUPNAME = "[0-24点]";
                e.LL_LIMIT = 20;
                e.L_LIMIT = 20;
                e.H_LIMIT = 20;
                e.HH_LIMIT = 20;
                e.PERIODBEGIN = new TimeSpan(0, 0, 0);
                e.PERIODEND = new TimeSpan(23, 59, 59);
                sql = mysqlDAO.getInsertSql(e);
                dao.Execute(sql);
            }//for
            sendMsg("自动生成限值完成", 0);
        }

        public void DeleteYKYT()
        {
            sendMsg("清除设备（自动生成的）遥控遥调信息...", 0);
            string sql = "delete from tblytparam where CHANNEL= 99;";
            dao.Execute(sql);
            sql = "delete from tblykparam where CHANNEL= 99;";
            dao.Execute(sql);
            sendMsg("清除完成.", 0);
        }

        public void ProcedureYKYT(object poco)
        {
            sendMsg("生成设备遥控遥调参数...", 0);
            string tblName = myPoco.getTabName(poco);
            sendMsg(tblName + "自动生成遥控遥调基本信息...", 0);
            string sql = string.Format(@"select t.ID,t.NAME,t.FEEDID,f.SUBSTATIONID SID,ar.ID AID from {0} t 
left join tblfeeder f on t.FEEDID=f.ID 
left join tblsubstation ss on f.SUBSTATIONID = ss.ID
left join tblsubcontrolarea ar on ar.ID = ss.SUBCONTROLAREAID;", tblName);

            DataTable dt = dao.Query(sql);
            string yt_sql_templet = @"insert into tblytparam(ID,YTKIND,CONTROLAREA,STATIONID,CMDELEMENTID,CZH,YTH,NAME,CHANNEL) 
values({0},'{1}',{2},{3},{4},{5},{6},'{7}',99);";
            string yk_sql_templet = @"insert into tblykparam(ID,YKKIND,CONTROLAREA,STATIONID,CMDELEMENTID,
UPPER_CZH, UPPER_YKYTH, LOWER_CZH, LOWER_YKYTH, NAME, CHANNEL,UPPER_YKYTVALUE,LOWER_YKYTVALUE) 
values({0},'{1}',{2},{3},{4},1,{5},1,{5},'{6}',99,1,0);";
            string str_id = dao.getNewId();
            int int_id = int.Parse(str_id);
            int yth = 1000;
            int ykh = 1000;
            foreach (DataRow row in dt.Rows)
            {
                string ename = row["NAME"].ToString();
                string eid = row["ID"].ToString();
                string aid = row["AID"].ToString();
                string sid = row["SID"].ToString();
                if (poco.GetType() == typeof(tblfeedcapacitor))
                {
                    string yt_sql = string.Format(yt_sql_templet, int_id++, "工作模式", aid, sid, eid, 1, yth++, ename + "-工作模式");
                    dao.Execute(yt_sql);
                    yt_sql = string.Format(yt_sql_templet, int_id++, "功率因数目标值", aid, sid, eid, 1, yth++, ename + "-功率因数目标值");
                    dao.Execute(yt_sql);
                    yt_sql = string.Format(yt_sql_templet, int_id++, "电压上限值", aid, sid, eid, 1, yth++, ename + "-电压上限值");
                    dao.Execute(yt_sql);
                    yt_sql = string.Format(yt_sql_templet, int_id++, "电压下限值", aid, sid, eid, 1, yth++, ename + "-电压下限值");
                    dao.Execute(yt_sql);
                    yt_sql = string.Format(yt_sql_templet, int_id++, "电压目标值", aid, sid, eid, 1, yth++, ename + "-电压目标值");
                    dao.Execute(yt_sql);
                }
                else {
                    string yk_sql = string.Format(yk_sql_templet, int_id++,"遥控",aid,sid,eid,ykh++,ename+"-遥控");
                    dao.Execute(yk_sql);
                }
            }
            //dao.SaveData(dt, poco, "ID");
            sendMsg(tblName + "自动生成遥控遥调 完成", 0);
        }


        public void ProcedureMeasure(object poco, object measurePoco)
        {
            string tblName = myPoco.getTabName(poco);
            sendMsg(tblName + "自动生成量测...", 0);
            string sql = null;
            if(measurePoco.GetType() != typeof(tblfeedcapacitoritemmeasure)) { 
                sql = string.Format(@"select t.ID,t.NAME,t.FEEDID,f.SUBSTATIONID SID,ar.ID AID from {0} t 
left join tblfeeder f on t.FEEDID=f.ID 
left join tblsubstation ss on f.SUBSTATIONID = ss.ID
left join tblsubcontrolarea ar on ar.ID = ss.SUBCONTROLAREAID;", tblName);
            }
            else
            {
                sql = @"select t.ID,t.NAME,c.FEEDID,f.SUBSTATIONID SID,ar.ID AID from tblfeedcapacitoritem t 
left join tblfeedcapacitor c on t.FEEDCAPACITORID = c.ID
left join tblfeeder f on c.FEEDID = f.ID 
left join tblsubstation ss on f.SUBSTATIONID = ss.ID
left join tblsubcontrolarea ar on ar.ID = ss.SUBCONTROLAREAID;";
            }
            DataTable dt = dao.Query(sql);
            foreach (DataRow row in dt.Rows)
            {
                string ename = row["NAME"].ToString();
                string eid = row["ID"].ToString();
                string aid = row["AID"].ToString();
                string sid = row["SID"].ToString();
                sendMsg(ename + "开始添加量测...", 1);
                WriteMeasure(ename, eid, aid, sid, measurePoco);
            }
            dao.SaveData(dt, poco, "ID");
            sendMsg(tblName + "自动生成量测完成", 0);
        }



        private void WriteMeasure(string elementName, string eid, string aid, string sid, object measurePoco)
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
                    WriteYC(int_ycyxid, cfn_chinese, aid, sid, eid);
                }
                else if (cfn.IndexOf("YXID") >= 0)
                {
                    WriteYX(int_ycyxid, cfn_chinese, aid, sid, eid);
                }

                int_ycyxid++;
            }
            sql = mysqlDAO.getInsertSql(measurePoco);
            int r = dao.Execute(sql);
            sendMsg(eid + " 执行完成，记录数： " + r, 2);
        }

        private DateTime curTime = DateTime.Now;
        private void WriteYC(int ID, string Name, string areaId, string stationId, string elementId)
        {
            tblycvalue yc = new tblycvalue();
            yc.ID = ID.ToString();
            yc.NAME = Name;
            yc.CONTROLAREA = areaId;
            yc.SUBSTATIONID = stationId;
            yc.EQUIPMENTID = elementId;

            yc.YCH = ych_seed.ToString();
            ych_seed++;
            yc.YCVALUE = 0.0f;
            yc.CZH = "1";
            yc.REPLACED = false;
            yc.ESTIMATED = false;
            yc.NOTFRESH = false;
            yc.MULTIPLEVALUE = 1;
            yc.OFFSETVALUE = 0;
            yc.CHANNEL = 99;
            yc.REFRESHTIME = curTime;
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
            yx.YXH = yxh_seed.ToString();
            yxh_seed++;
            yx.YXVALUE = 1;

            yx.CZH = "1";
            yx.REPLACED = false;
            yx.ESTIMATORREPLACED = false;
            yx.NOTFRESH = false;
            yx.MULTIPLEVALUE = 1;
            yx.OFFSETVALUE = 0;
            yx.CHANNEL = 99;
            yx.REFRESHTIME = curTime;

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
                sendMsg("将删除旧遥测遥信表信息", 2);

                string sql = mysqlDAO.getDeleteSql(yc, "CHANNEL = 99");
                int r = dao.Execute(sql);
                sendMsg("删除自动生成的旧遥测表信息 " + r, 2);
                sql = mysqlDAO.getDeleteSql(yx, "CHANNEL = 99");
                r = dao.Execute(sql);
                sendMsg("删除自动生成的旧遥信表信息 记录数：" + r, 2);
            }
            else
            {
                sendMsg("将删除旧遥测遥信表信息 设备ID =" + elementId, 2);

                string ws = string.Format("EQUIPMENTID = {0} AND CHANNEL = 99", elementId);
                string sql = mysqlDAO.getDeleteSql(yc, ws);

                int r = dao.Execute(sql);
                sendMsg("删除旧遥测表信息 " + r, 2);
                sql = mysqlDAO.getDeleteSql(yx, ws);
                r = dao.Execute(sql);
                sendMsg("删除旧遥信表信息 记录数：" + r, 2);

            }
        }
    }
}
