using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using log4net;
using log4net.Appender;

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
                conn = new MySqlConnection(connStr);
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

        public DataTable Query(String sql,ref DataTable dt)
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

    }
}
