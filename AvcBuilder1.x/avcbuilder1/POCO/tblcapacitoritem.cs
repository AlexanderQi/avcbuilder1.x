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
    
    public partial class tblcapacitoritem
    {
        public string ID { get; set; }
        public string CAPACITORID { get; set; }
        public string NAME { get; set; }
        public string ALIASNAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string SUBSTATIONID { get; set; }
        public Nullable<int> ORDINAL { get; set; }
        public string VOLTAGELEVELID { get; set; }
        public Nullable<double> RATEDVOLTAGE { get; set; }
        public Nullable<double> RATEDCAPACITY { get; set; }
        public Nullable<double> VOLTAGECHANGE { get; set; }
        public Nullable<double> REACTIVECHANGE { get; set; }
        public Nullable<double> EXPECTLIFETIME { get; set; }
        public Nullable<System.DateTime> STARTUSINGTIME { get; set; }
        public Nullable<int> GRAPHID { get; set; }
    }
}
