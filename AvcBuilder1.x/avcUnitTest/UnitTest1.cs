using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AvcDb.entities;
using System.Reflection;
using mysqlDao_v1;
using System.Configuration;
using System.Data;
using avcbuilder1;


namespace avcUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            tblsubstation a = new tblsubstation();
            //a.aContent = "xxx";
            //a.ID = 999;
            //a.aType = "cao";
            //a.aShowTag = 99;
            //a.aTime = DateTime.Now;
            Type t = a.GetType();
            foreach(PropertyInfo p in t.GetProperties())
            {

                Console.WriteLine(string.Format("{0} IsAbstract {1}", p.Name, p.PropertyType.IsAbstract));
                Console.WriteLine(string.Format("{0} IsAnsiClass {1}", p.Name, p.PropertyType.IsAnsiClass));
                Console.WriteLine(string.Format("{0} IsClass {1}", p.Name, p.PropertyType.IsClass));
                Console.WriteLine(string.Format("{0} IsPointer {1}", p.Name, p.PropertyType.IsPointer));
                Console.WriteLine(string.Format("{0} IsPrimitive {1}", p.Name, p.PropertyType.IsPrimitive));
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------");
            }
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
            string sql = mysqlDAO.getLeftJoinQuerySql(c, m, "name,feedid", "*", "id", "id", null);
            Console.WriteLine(sql);
            //m.QCYCID
            sql = mysqlDAO.getLeftJoinQuerySql(c, m, "name,feedid", "IYCID,QCYCID", "id", "id", null);
            Console.WriteLine(sql);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string comment = @" 我去年买了
个表我不要了.";
            Console.WriteLine(comment + "\nlen:" + comment.Length);
            int p = comment.IndexOfAny(new char[] { ',', '.', ';', '\n', '\t', ' ', '。', '，', '；' });
            comment = comment.Substring(0, p);
            Console.WriteLine(comment + "\nlen:" + comment.Length);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string[] fields = mysqlDao_v1.myPoco.getProperties(new tblsubstation());
            foreach (string str in fields)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("------------------------------");
            string caption = "atype";
            int a = Array.IndexOf(fields, caption.ToUpper());
            bool b = mysqlDao_v1.myPoco.ContainsField(fields, caption);
            Console.WriteLine(caption + " Pos: " + a + " result: " + b);

            caption = "ids";
            a = Array.IndexOf(fields, caption.ToUpper());
            b = mysqlDao_v1.myPoco.ContainsField(fields, caption);
            Console.WriteLine(caption + " Pos: " + a + " result: " + b);
        }

        [TestMethod]
        public void TestMethod5_forDB()
        {
            string conn = ConfigurationManager.ConnectionStrings["avcdb"].ConnectionString;
            mysqlDAO md = new mysqlDAO(conn);
            DataTable dt = md.GetFieldComment("tblgraphfile");
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(string.Format("{0}    {1}", dr[0], dr[1]));
            }
        }

        [TestMethod]
        public void TestMethod6()
        {
            Assembly ass;
               ass = Assembly.GetAssembly(typeof(tblalarm));
            //ass = Assembly.GetAssembly(typeof(tblalarm));
           // ass = Assembly.GetEntryAssembly();
            Console.WriteLine(ass.FullName);
            Type t = ass.GetType("AvcDb.entities.tblfeeder",true,true);
            object obj = Activator.CreateInstance(t, true);
            if (obj != null)
                Console.WriteLine(string.Format("obj fullname: {0}", t.FullName));
            else
                Console.WriteLine("failed");
        }

    }
}