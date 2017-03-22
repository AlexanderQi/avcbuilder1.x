using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

namespace mysqlDao_v1
{
    public static class myFunc
    {
       

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
         public static string[] getProperties(object model)
        {
            Type t = model.GetType();
            PropertyInfo[] pinfos = t.GetProperties();
            string[] props = new string[pinfos.Length];
            for(int i = 0; i < props.Length; i++)
            {
                props[i] = pinfos[i].Name.ToUpper();
            }
            return props;
        }

        public static string getTabName(object model)
        {
            return model.GetType().Name;
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
