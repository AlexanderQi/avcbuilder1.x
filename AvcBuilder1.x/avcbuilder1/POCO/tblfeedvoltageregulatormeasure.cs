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
    
    public partial class tblfeedvoltageregulatormeasure
    {
        public string ID { get; set; }
        public Nullable<int> INPUTUABYCID { get; set; }
        public Nullable<int> OUTPUTUABYCID { get; set; }
        public Nullable<int> LINEIYCID { get; set; }
        public Nullable<int> TAPCHANGERYCID { get; set; }
        public Nullable<int> ACTIONCOUNTINDAYYCID { get; set; }
        public Nullable<int> ACTIONCOUNTINMONTHYCID { get; set; }
        public Nullable<int> ACTIONCOUNTTOTALYCID { get; set; }
        public Nullable<int> BRANCHSWITCHYXID { get; set; }
        public Nullable<int> CONTROLSWITCHYXID { get; set; }
        public Nullable<int> GUARDSIGNALYXID { get; set; }
        public Nullable<int> CONSERVATIONYCID { get; set; }
        public Nullable<int> FLOWDIRECTIONYXID { get; set; }
    }
}
