//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Taxi_Monitering
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Attedance
    {
        public string Att_Id { get; set; }
        public Nullable<int> Att_Value { get; set; }
        public Nullable<System.DateTime> Att_tkn_Time { get; set; }
        public string Taxi_ID { get; set; }
        public string Emp_Id { get; set; }
    
        public virtual tbl_Employee tbl_Employee { get; set; }
        public virtual tbl_Taxi tbl_Taxi { get; set; }
    }
}