//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BesicApp1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_PAGE_MASTER
    {
        public int REFID { get; set; }
        public string PNAME { get; set; }
        public string PADDRESS { get; set; }
        public Nullable<bool> ISPARENT { get; set; }
        public Nullable<bool> ISACTIVE { get; set; }
        public Nullable<bool> ISDELETE { get; set; }
        public Nullable<System.DateTime> CREATEDON { get; set; }
        public Nullable<int> CREATEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDON { get; set; }
        public Nullable<int> MODIFIEDBY { get; set; }
    }
}