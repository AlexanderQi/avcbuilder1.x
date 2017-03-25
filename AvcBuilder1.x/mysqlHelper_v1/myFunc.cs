using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

namespace mysqlDao_v1
{
    public static class myPoco
    {
       public static void setPropertyValue(object poco, string PropertyName, object PropertyValue)
        {
            Type t = poco.GetType();
            PropertyInfo[] pinfos = t.GetProperties();
            for (int i = 0; i < pinfos.Length; i++)
                if (pinfos[i].Name.ToUpper().Equals(PropertyName.ToUpper()))
                {
                    pinfos[i].SetValue(poco, PropertyValue,null);
                    break;
                }
        }

        public static object getPropertyValue(object poco, string PropertyName)
        {
            Type t = poco.GetType();
            PropertyInfo[] pinfos = t.GetProperties();
            for (int i = 0; i < pinfos.Length; i++)
                if (pinfos[i].Name.ToUpper().Equals(PropertyName.ToUpper()))
                {
                    return pinfos[i].GetValue(poco, null);
                }
            return null;
        }

        public static string getPropertyName(object poco, string nameInsensitive)
        {
            Type t = poco.GetType();
            PropertyInfo[] pinfos = t.GetProperties();
            nameInsensitive = nameInsensitive.ToUpper();
            for (int i = 0; i < pinfos.Length; i++)
                if (pinfos[i].Name.ToUpper().Equals(nameInsensitive))
                    return pinfos[i].Name;
            return null;
        }
         public static string[] getProperties(object poco)
        {
            Type t = poco.GetType();
            PropertyInfo[] pinfos = t.GetProperties();
            string[] props = new string[pinfos.Length];
            for(int i = 0; i < props.Length; i++)
            {
                props[i] = pinfos[i].Name.ToUpper();
            }
            return props;
        }

        public static string getTabName(object poco)
        {
            return poco.GetType().Name;
        }

        public static bool ContainsField(string[] fields, string fieldName)
        {
            int a = Array.IndexOf(fields, fieldName.ToUpper());
            return a == -1 ? false : true;
        }

        public static void pocoLoadRow(object poco, DataRow row)
        {
            Type t = poco.GetType();
            PropertyInfo[] props = t.GetProperties();
            for(int i = 0; i < props.Length; i++)
            {
                if (props[i].PropertyType.IsArray) continue;
                var val = row[props[i].Name];
                props[i].SetValue(poco, val, null);
            }
        }
    }


}
