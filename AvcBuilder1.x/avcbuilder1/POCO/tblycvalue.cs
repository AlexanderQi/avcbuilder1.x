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
    
    public partial class tblycvalue
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string CONTROLAREA { get; set; }
        public string SUBSTATIONID { get; set; }
        public string EQUIPMENTID { get; set; }
        public string CZH { get; set; }
        public string YCH { get; set; }
        public Nullable<double> YCVALUE { get; set; }
        public Nullable<System.DateTime> REFRESHTIME { get; set; }
        public Nullable<double> OFFSETVALUE { get; set; }
        public Nullable<double> MULTIPLEVALUE { get; set; }
        public Nullable<bool> NOTFRESH { get; set; }
        public Nullable<bool> REPLACED { get; set; }
        public Nullable<double> REPLACEDVALUE { get; set; }
        public Nullable<bool> ESTIMATED { get; set; }
        public Nullable<double> ESTIMATEDVALUE { get; set; }
        public Nullable<int> CHANNEL { get; set; }
        public Nullable<int> VALID { get; set; }
        public string CHOOSESTATE { get; set; }
        public string ZFYCH { get; set; }
        public string ZFCZH { get; set; }
        public Nullable<int> VALUESTYLE { get; set; }
        public Nullable<int> GRAPHID { get; set; }
        public string SHORTCUT { get; set; }
    }
}
