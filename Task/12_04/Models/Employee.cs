using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _12_04.Models
{
    public class Employee
    {
        public Employee()
        {
            this.CommunicationAddress = new Address();
            this.PermanentAddress =new Address();
            this.Cities = new List<City>();
            this.Districts = new List<District>();
            this.States = new List<State>();
        }
        public int EmployeeID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Email { get; set; }
        public int? PermanentAddressID { get; set; }
        public int CommunicationAddressID { get; set; }
        //public List<SelectListItem> States { get; set; }
        //public List<SelectListItem> Districts { get; set; }
        //public List<SelectListItem> Cities { get; set; }

        public List<State> States { get; set; }
        public List<District> Districts { get; set; }
        public List<City> Cities { get; set; }
        public Address PermanentAddress{ get; set; }

        [Required]
        public Address CommunicationAddress{ get; set; }
    }
}