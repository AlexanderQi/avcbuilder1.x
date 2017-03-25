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
    class AvcAutoMeasure
    {
        
        private mysqlDao_v1.mysqlDAO dao;
        public AvcAutoMeasure(mysqlDao_v1.mysqlDAO dao)
        {
            this.dao = dao;
        }


        public void ProcedureElement(object poco,object measurePoco)
        {
            string sql = mysqlDAO.getQuerySql(poco, "");
            DataTable dt = dao.Query(sql);
            foreach (DataRow row in dt.Rows)
            {
                string eid = row["ID"].ToString();                
                ProdureMeasure(eid, measurePoco);
                 
            }
            dao.SaveData(dt, poco, "ID");
        }

        private void ProdureMeasure(string eid,object measurePoco)
        {
            DeleteByElementId(measurePoco, eid);

            //select COLUMN_NAME ,column_comment from I
            DataTable fieldName = dao.GetFieldComment(myPoco.getTabName(measurePoco));
            string sql = mysqlDAO.getQuerySql(measurePoco, "");
            DataTable dt = dao.Query(sql);

            myPoco.setPropertyValue(measurePoco, "ID", eid);
            string str_ycyxid = dao.getNewId(); //每次id转换成整数后，距上次id有51的差。而且一步量测表不会超过51个字段。
            int int_ycyxid = int.Parse(str_ycyxid);

            foreach (DataRow  row in fieldName.Rows) //遍历量测表字段，生成对应YCYXID
            {
                string cfn = row[0].ToString();  //当前字段名
                if (cfn.Equals("ID")) continue; //主键ID 继续
                myPoco.setPropertyValue(measurePoco, cfn, int_ycyxid);
                int_ycyxid++;
            }
            sql = mysqlDAO.getInsertSql(measurePoco);
            dao.Execute(sql);
          
        }

        private void WriteYC(int ID,string Name, string areaId,string stationId, string elementId)
        {
            tblycvalue yc = new tblycvalue();
            yc.ID = ID.ToString();
            yc.NAME = Name;
            yc.CONTROLAREA = areaId;
            yc.SUBSTATIONID = stationId;
            yc.EQUIPMENTID = elementId;
            string sql = mysqlDAO.getInsertSql(yc);
            dao.Execute(sql);
        }

        private void WriteYX(int ID, string Name, string areaId, string stationId, string elementId)
        {
            tblyxvalue yx = new tblyxvalue();
            yx.ID = ID.ToString();
            yx.NAME = Name;
            yx.CONTROLAREA = areaId;
            yx.SUBSTATIONID = stationId;
            yx.EQUIPMENTID = elementId;

            string sql = mysqlDAO.getInsertSql(yx);
            dao.Execute(sql);
        }

        public void DeleteByElementId(object measurePoco, string elementId)
        {
            if (elementId != null)
            {
                string sql = mysqlDAO.getDeleteSql(measurePoco, "ID", elementId);
                dao.Execute(sql);
            }
            else
            {
                string sql = mysqlDAO.getDeleteSql(measurePoco, null);
                dao.Execute(sql);
            }
        }

        public void DeleteYCYXByElementId(string elementId)
        {
            tblycvalue yc = new tblycvalue();
            tblyxvalue yx = new tblyxvalue();
            string sql = mysqlDAO.getDeleteSql(yc, "EQUIPMENTID", elementId);
            dao.Execute(sql);
            sql = mysqlDAO.getDeleteSql(yx, "EQUIPMENTID", elementId);
            dao.Execute(sql);
 
        }
    }
}
