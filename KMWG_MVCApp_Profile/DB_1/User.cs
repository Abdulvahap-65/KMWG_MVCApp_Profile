//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KMWG_MVCApp_Profile.DB_1
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Addresses = new HashSet<Addresses>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> BDate { get; set; }
        public Nullable<int> Kilo { get; set; }
        public Nullable<int> UserGroupId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public Nullable<int> Country { get; set; }
        public string Subject { get; set; }
        public byte[] Photo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
