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
    
    public partial class TBL_USER_MASTER
    {
        public int USERID { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public Nullable<int> ROLE_ID { get; set; }
        public Nullable<int> REG_ID { get; set; }
        public Nullable<bool> IS_ACTIVE { get; set; }
        public Nullable<bool> IS_DELETE { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_ON { get; set; }
        public Nullable<int> MODIFIED_BY { get; set; }
    }
}