using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _12_04.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Cities = new List<SelectListItem>();
            this.Districts = new List<SelectListItem>();
            this.States = new List<SelectListItem>();
        }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int EmployeeAddressID { get; set; }
        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> Districts { get; set; }
        public List<SelectListItem> Cities { get; set; }

        public Address EmployeeAddress{ get; set; }
    }
}