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
    
    public partial class tbl_Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Role()
        {
            this.tbl_System_Account = new HashSet<tbl_System_Account>();
        }
    
        public string Role_ID { get; set; }
        public string Role_Description { get; set; }
        public string Role_Permission { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_System_Account> tbl_System_Account { get; set; }
    }
}
