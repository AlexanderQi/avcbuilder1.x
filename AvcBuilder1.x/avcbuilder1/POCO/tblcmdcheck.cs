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
    
    public partial class tblcmdcheck
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> DTIME { get; set; }
        public string CMDID { get; set; }
        public string ELEMENTID { get; set; }
        public string ACTIONFIELD { get; set; }
        public string ACTIONTOTALFIELD { get; set; }
    }
}
