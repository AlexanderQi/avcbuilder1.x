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
    
    public partial class tblgraphfile
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public byte[] CIMCONTENT { get; set; }
        public byte[] SVGCONTENT { get; set; }
        public byte[] SCGCONTENT { get; set; }
        public byte[] TOPOCONTENT { get; set; }
        public byte[] TOPSOURCES { get; set; }
        public string CIMDIGESTS { get; set; }
        public string SVGDIGESTS { get; set; }
        public string SCGDIGESTS { get; set; }
        public string TOPODIGESTS { get; set; }
        public Nullable<System.DateTime> LASTEDITTIME { get; set; }
        public string LASTEDITUSEID { get; set; }
        public string TOPOCHECKED { get; set; }
        public string PROGRAMID { get; set; }
    }
}