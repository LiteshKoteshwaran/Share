using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _12_04.Models
{
    public class Address
    {
        public Address()
        {
            this.EmployeeDetails = new HashSet<Employee>();
        }
        public int AddressID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public int StateID { get; set; }
        public int DistrictID { get; set; }
        public int CityID { get; set; }
        public string Pincode { get; set; }

        public City City { get; set; }
        public District District { get; set; }
        public State State { get; set; }
        public ICollection<Employee> EmployeeDetails { get; set; }
    }
}