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
    
    public partial class tblelementaction
    {
        public int ID { get; set; }
        public string ELEMENTID { get; set; }
        public Nullable<long> ELEMENTSTYLE { get; set; }
        public Nullable<int> UPPERONCOUNTSELF { get; set; }
        public Nullable<int> DOWNOFFCOUNTSELF { get; set; }
        public Nullable<int> UPPERONCOUNTOTHER { get; set; }
        public Nullable<int> DOWNOFFCOUNTOTHER { get; set; }
        public Nullable<int> UPPERONCOUNTTOTAL { get; set; }
        public Nullable<int> DOWNOFFCOUNTTOTAL { get; set; }
        public Nullable<int> YTCOUNTSELF { get; set; }
        public Nullable<int> YTCOUNTOTHER { get; set; }
        public Nullable<int> FAILURECOUNT { get; set; }
        public Nullable<int> SUCCESSCOUNT { get; set; }
        public Nullable<System.DateTime> LASTACTIONTIME { get; set; }
    }
}
