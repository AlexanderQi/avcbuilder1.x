//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AvcDb.entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblreactor
    {
        public string ID { get; set; }
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
        public Nullable<int> LOWERORDER { get; set; }
        public Nullable<int> UPPERORDER { get; set; }
        public Nullable<bool> HASITEMS { get; set; }
        public Nullable<double> EXPECTLIFETIME { get; set; }
        public Nullable<System.DateTime> STARTUSINGTIME { get; set; }
        public Nullable<int> GRAPHID { get; set; }
    }
}
