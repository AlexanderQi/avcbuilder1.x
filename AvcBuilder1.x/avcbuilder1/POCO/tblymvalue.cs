//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AvcDb.entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblymvalue
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string SUBSTATIONID { get; set; }
        public string SHORTCUT { get; set; }
        public string CZH { get; set; }
        public string YMH { get; set; }
        public string ZFCZH { get; set; }
        public string ZFYMH { get; set; }
        public string VALUESTYLE { get; set; }
        public string VALUESOURCE { get; set; }
        public Nullable<double> YMVALUE { get; set; }
        public Nullable<System.DateTime> REFRESHTIME { get; set; }
        public Nullable<double> NEWVALUE { get; set; }
        public Nullable<System.DateTime> NEWREFRESHTIME { get; set; }
        public Nullable<double> OLDVALUE { get; set; }
        public Nullable<System.DateTime> OLDREFRESHTIME { get; set; }
        public Nullable<double> OFFSETVALUE { get; set; }
        public Nullable<double> MULTIPLEVALUE { get; set; }
        public Nullable<bool> NOTFRESH { get; set; }
        public Nullable<bool> REPLACED { get; set; }
        public Nullable<double> REPLACEDVALUE { get; set; }
        public Nullable<bool> ESTIMATED { get; set; }
        public Nullable<double> ESTIMATEDVALUE { get; set; }
        public Nullable<int> GRAPHID { get; set; }
    }
}
