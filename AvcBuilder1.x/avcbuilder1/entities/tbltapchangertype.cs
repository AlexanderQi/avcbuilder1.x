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
    
    public partial class tbltapchangertype
    {
        public string ID { get; set; }
        public string TYPENAME { get; set; }
        public Nullable<bool> ISOLTC { get; set; }
        public Nullable<int> LOWSTEP { get; set; }
        public Nullable<int> HIGHSTEP { get; set; }
        public Nullable<int> NEUTRALSTEP { get; set; }
        public Nullable<double> NEUTRALVOLTAGE { get; set; }
        public Nullable<double> STEPVOLTAGEINCREMENT { get; set; }
        public string SAMEVALUE { get; set; }
        public string MATEVALUE { get; set; }
    }
}
