using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _12_04.Models
{
    public class City
    {
        public City()
        {
            this.Addresses = new HashSet<Address>();
        }
        public int CityID { get; set; }
        public string Cities { get; set; }
        public int CityDistrictID { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public District District { get; set; }
    }
}