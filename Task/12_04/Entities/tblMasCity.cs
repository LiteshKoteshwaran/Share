//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _12_04.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMasCity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMasCity()
        {
            this.tblAddresses = new HashSet<tblAddress>();
        }
    
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int CityDistrictID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAddress> tblAddresses { get; set; }
        public virtual tblMasDistrict tblMasDistrict { get; set; }
    }
}
