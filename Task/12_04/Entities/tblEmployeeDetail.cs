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
    
    public partial class tblEmployeeDetail
    {
        public int EmployeeDetailsID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int CommunicationAddressID { get; set; }
        public int PermanentAddressID { get; set; }
    
        public virtual tblAddress tblAddress { get; set; }
        public virtual tblAddress tblAddress1 { get; set; }
    }
}
