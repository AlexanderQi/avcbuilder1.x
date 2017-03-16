using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AvcDb.entities;
using System.Reflection;
using mysqlDao_v1;
namespace avcUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            tblalarm a = new tblalarm();
            a.aContent = "xxx";
            a.ID = 999;
            a.aType = "cao";
            a.aShowTag = 99;
            a.aTime = DateTime.Now;
            Type t = a.GetType();
            //Console.WriteLine(t.Name);
            //Console.WriteLine(t.FullName);

            //PropertyInfo p = t.GetProperty("aContent");
            //p.SetValue(a, "aaa");
            //Console.WriteLine(a.aContent);
            //object o = p.GetValue(a);
            //Console.WriteLine(o);

            //PropertyInfo p = t.GetProperty("aTime");
            //p.SetValue(a, DateTime.Now);
            //Console.WriteLine(t.Name +"的"+ p.Name + "的类型是:" + p.PropertyType.ToString());
            //p = t.GetProperty("ID");
            //Console.WriteLine(t.Name + "的" + p.Name + "的类型是:" + p.PropertyType.ToString());

            string sql = mysqlDAO.getInsertSql(a);
            Console.WriteLine(sql);

            tblbreaker b = new tblbreaker();
            b.ID = "asdasdf111";
            b.NAME = "breaker1";
            // b.STARTUSINGTIME = DateTime.Now;
            sql = mysqlDAO.getInsertSql(b);
            Console.WriteLine(sql);
            sql = mysqlDAO.getDeleteSql(b, "ID", "asdasdf111");
            Console.WriteLine(sql);
            sql = mysqlDAO.getQuerySql(b, "ID", "1asdasdf111");
            Console.WriteLine(sql);
            sql = mysqlDAO.getUpdateSql(a, "atype='dadada',ashowtag=111", "id=1");
            Console.WriteLine(sql);
        }


        [TestMethod]
        public void TestMethod2()
        {
            tblfeedcapacitor c = new tblfeedcapacitor();
            tblfeedcapacitormeasure m = new tblfeedcapacitormeasure();
           string  sql = mysqlDAO.getLeftJoinQuerySql(c, m, "name,feedid", "*", "id", "id", null);
            Console.WriteLine(sql);
            //m.QCYCID
            sql = mysqlDAO.getLeftJoinQuerySql(c, m, "name,feedid", "IYCID,QCYCID", "id", "id", null);
            Console.WriteLine(sql);
        }
    }
}
