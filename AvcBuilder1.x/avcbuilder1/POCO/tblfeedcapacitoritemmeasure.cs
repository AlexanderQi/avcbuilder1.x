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
    
    public partial class tblfeedcapacitoritemmeasure
    {
        public string ID { get; set; }
        public Nullable<int> SWITCHYXID { get; set; }
        public string SWITCHID { get; set; }
    
        public virtual tblfeedcapacitoritem tblfeedcapacitoritem { get; set; }
    }
}
