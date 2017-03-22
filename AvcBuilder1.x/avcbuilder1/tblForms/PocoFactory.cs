using System;
using System.Reflection;
namespace AvcDb.entities
{
     public static class PocoFactory
    {

        public static object getPocoByName(string pocoName)
        {
            Assembly ass = Assembly.GetAssembly(typeof(tblalarm));
            Type t = ass.GetType("AvcDb.entities." + pocoName,true,true);
            if (t == null) return null;
            object poco = Activator.CreateInstance(t);
            return poco;
        }
    }
}
