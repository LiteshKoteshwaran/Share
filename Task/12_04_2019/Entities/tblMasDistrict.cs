//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _12_04_2019.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMasDistrict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMasDistrict()
        {
            this.tblAddresses = new HashSet<tblAddress>();
            this.tblMasCities = new HashSet<tblMasCity>();
        }
    
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int DistrictStateID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAddress> tblAddresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMasCity> tblMasCities { get; set; }
        public virtual tblMasState tblMasState { get; set; }
    }
}
