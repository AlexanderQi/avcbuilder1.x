using System;
using MySql.Data.MySqlClient;
using System.Data;
using log4net;
using System.Reflection;
using System.Text;
namespace mysqlDao_v1
{


    public class myConnInfo
    {
        public string User;
        public string ServerIp;
        public string Password;
        public string DatabaseName;
        public string DatabaseType;
    }

    public class mysqlDAO
    {
        private string connStr;
        private MySqlConnection conn;
        private DataTable dt;
        ILog log;

        public static myConnInfo getConnInfo(string ConnectString)
        {
            //Server=139.196.55.11;User=guest_;Password=11111111;Database=nttbl; Charset=utf8; Pooling=true; Max Pool Size=16;
            myConnInfo cinfo = null;
            cinfo = new myConnInfo();
            string[] ss = ConnectString.Split('=', ';');
            for (int i = 0; i < ss.Length; i++)
            {
                string tmp = ss[i].ToUpper().TrimStart(' ').TrimEnd(' ');
                if (tmp.Equals("SERVER"))
                {
                    cinfo.ServerIp = ss[i + 1];
                }
                else if (tmp.Equals("DATABASE"))
                {
                    cinfo.DatabaseName = ss[i + 1];
                }
                else if (tmp.Equals("USER"))
                {
                    cinfo.User = ss[i + 1];
                }
                else if (tmp.Equals("PASSWORD"))
                {
                    cinfo.Password = ss[i + 1];
                }
            }
            return cinfo;
        }

        public mysqlDAO(string connectString)
        {

            log = LogManager.GetLogger("log");
            connStr = connectString;
            try
            {
                conn = new MySqlConnection(connectString);

                //log.Debug("*** 新建数据源: "+conn.ConnectionString);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }




        private bool Ping()
        {
            bool b = conn.Ping();
            //log.Debug("Ping DB:" + conn.DataSource + conn.Database+" return=" + b);
            return b;
        }

        public void TestConnect()
        {
            try
            {
                conn.Close();
                conn.Open();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        public void ConnectClose()
        {
            conn.Close();
        }

        public int Execute(String sql)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                int r = MySqlHelper.ExecuteNonQuery(conn, sql, null);
                return r;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public object ExecuteScalar(String sql)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable Query(String sql)
        {
            lock (this)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    //log.Debug(conn.DataSource+conn.Database+"  "+sql);
                    MySqlDataAdapter mda = new MySqlDataAdapter(sql, conn);
                    dt = new DataTable();
                    mda.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public DataTable Query(String sql, ref DataTable dt)
        {
            lock (this)
            {
                if (dt == null) return dt;
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    MySqlDataAdapter mda = new MySqlDataAdapter(sql, conn);
                    dt.Columns.Clear();
                    dt.Clear();
                    mda.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static string getInsertSql(object poco)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ");
            Type t = poco.GetType();
            sb.Append(t.Name).Append(" (");
            PropertyInfo[] pros = t.GetProperties();
            for (int i = 0; i < pros.Length; i++)
            {
                if (pros[i].PropertyType.IsArray) continue; //blob or text field 不处理
                if (i > 0) { sb.Append(","); }
                sb.Append(pros[i].Name);
            }
            sb.Append(") VALUES (");
            for (int i = 0; i < pros.Length; i++)
            {

                if (pros[i].PropertyType.IsArray) continue; //blob or text field 不处理
                if (i > 0) { sb.Append(","); }

                object val = pros[i].GetValue(poco, null);
                if (val == null)
                {
                    sb.Append("NULL");
                }
                else if (pros[i].PropertyType == typeof(string) ||
                    pros[i].PropertyType == typeof(DateTime) ||
                    pros[i].PropertyType == typeof(Nullable<DateTime>))
                {
                    sb.Append("'").Append(val.ToString()).Append("'");
                }
                else { sb.Append(val.ToString()); }
            }
            sb.Append(");");
            return sb.ToString();
        }

        public static string getDeleteSql(object poco, string pk_name, object pk_value)
        {
            //DELETE FROM `pwavc1`.`tblalarm` WHERE  `ID`=1000;
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ");
            Type t = poco.GetType();
            PropertyInfo pr = t.GetProperty(pk_name);
            if (pr == null) return null;

            sb.Append(t.Name);
            if (pk_name == null && pk_value == null) { return sb.ToString(); }// All data will be deleted.

            sb.Append(" WHERE ").Append(pk_name).Append(" = ");
            if (pr.PropertyType == typeof(string) ||
                    pr.PropertyType == typeof(DateTime) ||
                    pr.PropertyType == typeof(Nullable<DateTime>))
            {
                sb.Append("'").Append(pk_value).Append("'");
            }
            else
            {
                sb.Append(pk_value);
            }
            return sb.ToString();
        }

        public static string getDeleteSql(object poco, string String_After_WHERE)
        {
            //DELETE FROM `pwavc1`.`tblalarm` WHERE  `ID`=1000;
            if (String_After_WHERE == null || String_After_WHERE.Equals("")) return null;
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ");
            Type t = poco.GetType();
            sb.Append(t.Name);
            sb.Append(" WHERE ").Append(String_After_WHERE);
           
            return sb.ToString();
        }

        public static string getQuerySql(object poco, string pk_name, object pk_value)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            Type t = poco.GetType();
            PropertyInfo pr = t.GetProperty(pk_name);
            if (pr == null) return null;

            PropertyInfo[] pros = t.GetProperties();
            for (int i = 0; i < pros.Length; i++)
            {
                if (pros[i].PropertyType.IsArray) continue; //blob or text field 不处理
                if (i > 0) { sb.Append(","); }
                sb.Append(pros[i].Name);
            }
            sb.Append(" FROM ").Append(t.Name).Append(" WHERE ").Append(pk_name).Append(" = ");
            if (pr.PropertyType == typeof(string) ||
                    pr.PropertyType == typeof(DateTime) ||
                    pr.PropertyType == typeof(Nullable<DateTime>))
            {
                sb.Append("'").Append(pk_value).Append("'");
            }
            else
            {
                sb.Append(pk_value);
            }
            return sb.ToString();
        }

        public static string getQuerySql(object poco, string String_After_WHERE)
        {
            if (String_After_WHERE == null || String_After_WHERE.Equals(""))
                String_After_WHERE = "true;";

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            Type t = poco.GetType();

            PropertyInfo[] pros = t.GetProperties();
            for (int i = 0; i < pros.Length; i++)
            {
                if (pros[i].PropertyType.IsArray) continue; //blob or text field 不处理
                if (i > 0) { sb.Append(","); }
                sb.Append(pros[i].Name);
            }
            sb.Append(" FROM ").Append(t.Name).Append(" WHERE ").Append(String_After_WHERE);

            return sb.ToString();
        }
    }
}
