using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _12_04_2019.Models
{
    public class District
    {
        public District()
        {
            this.Addresses = new HashSet<Address>();
            this.Cities = new HashSet<City>();
        }
        public int DistrictID { get; set; }
        public string Districts { get; set; }
        public int DistrictStateID { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<City> Cities { get; set; }
        public State State { get; set; }

    }
}