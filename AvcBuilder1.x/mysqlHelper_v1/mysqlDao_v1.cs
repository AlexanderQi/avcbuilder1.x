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
        myConnInfo conInfo;
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
                conInfo = getConnInfo(connectString);
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

        public DataTable GetFieldComment(string tblName)
        {
            string sql = @"select COLUMN_NAME ,column_comment from INFORMATION_SCHEMA.Columns where table_name = '" + tblName + "' and table_schema = '" + conInfo.DatabaseName + "'";
            DataTable t = Query(sql);
            foreach (DataRow dr in t.Rows)
            {
                if (dr.IsNull(1) || dr[1].ToString().Equals(""))
                {

                    dr[1] = dr[0];
                }
                else
                {
                    string comment = dr[1].ToString().Trim();
                    int p = comment.IndexOfAny(new char[] { ',', '.', ';', '\n', '\t', ' ', '。', '，', '；', ':', '：' });
                    if (p > 0)
                    {
                        comment = comment.Substring(0, p);
                    }
                    dr[1] = comment;
                }
            }
            t.AcceptChanges();
            return t;
        }


        /// <summary>
        /// 填充POCO 根据参数ROW
        /// </summary>
        /// <param name="poco">实体对象</param>
        /// <param name="row">system.data </param>
        /// <param name="PK_TO_UPPER">Prime key主键 必须是大写字母</param>
        /// <param name="pkValue">主键值</param>
        /// <returns></returns>
        public static object fillPoco(object poco, DataRow row, string PK_TO_UPPER = null, string pkValue = null)
        {
            Type t = poco.GetType();
            PropertyInfo[] props = t.GetProperties();
            int pkIndex = -1;
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].PropertyType.IsArray) continue;
                var val = row[props[i].Name];
                props[i].SetValue(poco, val, null);

                if (PK_TO_UPPER != null && props[i].Name.Equals(PK_TO_UPPER))
                    pkIndex = i;
            }
            if (pkIndex != -1)
                props[pkIndex].SetValue(poco, pkValue, null);
            return poco;
        }

        private string sql4newId = null;
        public void SetSqlForNewId(string sql)
        {
            sql4newId = sql;
        }

        public string getNewId()
        {

            if (sql4newId == null)
            {
                Random rd = new Random();
                uint default_id = (uint)(rd.NextDouble() * 1000000);
                return "38" + default_id.ToString();
            }
            else
                return ExecuteScalar(sql4newId).ToString();
        }
        /// <summary>
        /// DataTable save to Database
        /// </summary>
        /// <param name="dt">载有要保存信息的dataTable</param>
        /// <param name="EntityModel">实体对象</param>
        /// <param name="PK_TO_UPPER">大写的主键名称</param>
        public void SaveData(DataTable dt, object EntityModel, string PK_TO_UPPER)
        {
            if (dt == null || dt.Rows.Count == 0) return;
            string[] fields = mysqlDao_v1.myFunc.getProperties(EntityModel);
            StringBuilder sbUpdateSet = new StringBuilder();
            StringBuilder sb4row = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                switch (dr.RowState)
                {
                    case DataRowState.Added:
                        {
                            sbUpdateSet.Clear();
                            string newId = getNewId();     //AvcBuilder_func.getNewId(MysqlDao);
                            mysqlDAO.fillPoco(EntityModel, dr, PK_TO_UPPER, newId);  //注意:fill函数应该为新增记录的id考虑自增和非自增的情况.

                            string sql = mysqlDAO.getInsertSql(EntityModel);
                            sb4row.Append(sql).Append("\n");
                            break;
                        }//case
                    case DataRowState.Modified:
                        {
                            sbUpdateSet.Clear();
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                string caption = dt.Columns[i].Caption;
                                bool b = mysqlDao_v1.myFunc.ContainsField(fields, caption);
                                if (!b) continue;
                                if (!dr[i, DataRowVersion.Current].ToString().Equals(dr[i, DataRowVersion.Original].ToString()))
                                {
                                    sbUpdateSet.Append(dt.Columns[i].Caption).Append(" = '").Append(dr[i]).Append("',");
                                }
                            }//case
                            string sql = mysqlDAO.getUpdateSqlById(EntityModel, sbUpdateSet.ToString(), dr[PK_TO_UPPER].ToString());
                            sb4row.Append(sql).Append("\n");
                            break;
                        }//case

                    case DataRowState.Deleted:
                        {
                            break;
                        }//case
                }//switch
            } //foreach
        }//func


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------//


        /// <summary>
        /// 获取poco的插入语句
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 根据poco信息 构建删除语句
        /// </summary>
        /// <param name="poco"></param>
        /// <param name="pk_name">prime key name</param>
        /// <param name="pk_value">prime key value</param>
        /// <returns></returns>
        public static string getDeleteSql(object poco, string pk_name, object pk_value)
        {
            pk_name = pk_name.ToUpper();
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
            sb.Append(";");
            return sb.ToString();
        }

        public static string getDeleteSql(object poco, string String_After_WHERE)
        {
            //DELETE FROM `pwavc1`.`tblalarm` WHERE  `ID`=1000;
            if (String_After_WHERE == null || String_After_WHERE.Equals(""))
                String_After_WHERE = "TRUE";
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ");
            Type t = poco.GetType();
            sb.Append(t.Name);
            sb.Append(" WHERE ").Append(String_After_WHERE).Append(";");

            return sb.ToString();
        }

        public static string getQuerySql(object poco, string pk_name, object pk_value)
        {
            pk_name = pk_name.ToUpper();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            Type t = poco.GetType();
            PropertyInfo pr = t.GetProperty(pk_name);
            if (pr == null) return null;

            PropertyInfo[] pros = t.GetProperties();
            for (int i = 0; i < pros.Length; i++)
            {
                if (pros[i].PropertyType.IsArray) continue; //blob  field 不处理
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
            sb.Append(";");
            return sb.ToString();
        }

        /// <summary>
        /// 获取查询语句
        /// </summary>
        /// <param name="poco"></param>
        /// <param name="String_After_WHERE"> sql语句中WHERE关键字后面的语句，不包括“WHERE" 本身</param>
        /// <returns></returns>
        public static string getQuerySql(object poco, string String_After_WHERE)
        {
            if (String_After_WHERE == null || String_After_WHERE.Equals(""))
                String_After_WHERE = "TRUE";

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            Type t = poco.GetType();

            PropertyInfo[] pros = t.GetProperties();
            for (int i = 0; i < pros.Length; i++)
            {
                if (pros[i].PropertyType.IsArray) continue; //blob field 不处理
                if (i > 0) { sb.Append(","); }
                sb.Append(pros[i].Name);
            }
            sb.Append(" FROM ").Append(t.Name).Append(" WHERE ").Append(String_After_WHERE).Append(";");
            return sb.ToString();
        }

        /// <summary>
        /// 获取更新语句
        /// </summary>
        /// <param name="poco"></param>
        /// <param name="String_After_SET">sql update语句中SET关键字后面的语句，不包括“SET" 本身</param>
        /// <param name="String_After_WHERE">...</param>
        /// <returns></returns>
        public static string getUpdateSql(object poco, string String_After_SET, string String_After_WHERE)
        {
            if (String_After_WHERE == null || String_After_WHERE.Equals(""))
                String_After_WHERE = "TRUE";
            StringBuilder sb = new StringBuilder();
            Type t = poco.GetType();
            sb.Append("UPDATE ").Append(t.Name).Append(" SET ").Append(String_After_SET).Append(" WHERE ").Append(String_After_WHERE).Append(";");
            return sb.ToString();
        }

        public static string getUpdateSqlById(object poco, string String_After_SET, string idValue, string idCaption = "id")
        {
            if (idValue == null || idValue.Equals("")) return null;
            string where_str = string.Format("{0} = '{1}';", idCaption, idValue);
            return getUpdateSql(poco, String_After_SET, where_str);
        }

        public static string getLeftJoinQuerySql(object leftPoco, object rightPoco, string leftTabFields, string rightFields, string leftPK, string rightPK, string String_After_WHERE, bool BlobField = false)
        {
            if (leftPK == null || leftPK.Equals("")) return null;
            if (rightPK == null || rightPK.Equals("")) return null;
            if (leftTabFields == null || leftTabFields.Equals("")) return null;
            if (rightFields == null || rightPoco.Equals("")) return null;
            if (String_After_WHERE == null || String_After_WHERE.Equals(""))
                String_After_WHERE = "TRUE";
            StringBuilder sb = new StringBuilder();
            Type tleft = leftPoco.GetType();
            Type tright = rightPoco.GetType();

            sb.Append("SELECT ");
            string[] f1 = leftTabFields.Split(',');
            for (int i = 0; i < f1.Length; i++)
            {
                if (i > 0)
                    sb.Append(",");
                sb.Append("t1.").Append(f1[i]);
            }

            string[] f2 = rightFields.Split(',');
            for (int i = 0; i < f2.Length; i++)
            {
                sb.Append(",t2.").Append(f2[i]);
            }
            sb.Append(" FROM ").Append(tleft.Name).Append(" t1 LEFT JOIN ").Append(tright.Name).Append(" t2 ON");
            sb.Append(" t1.").Append(leftPK).Append(" = ").Append("t2.").Append(rightPK);
            sb.Append(" WHERE ").Append(String_After_WHERE).Append(";");
            return sb.ToString();
        }
    }



}
