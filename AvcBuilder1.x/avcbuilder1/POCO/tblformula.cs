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
    
    public partial class tblformula
    {
        public string ID { get; set; }
        public Nullable<int> FOREIGNID { get; set; }
        public string FORMULANAME { get; set; }
        public string FORMULAKIND { get; set; }
        public string FORMULACONTENT { get; set; }
        public Nullable<bool> ENABLE { get; set; }
        public Nullable<int> PID { get; set; }
    }
}
