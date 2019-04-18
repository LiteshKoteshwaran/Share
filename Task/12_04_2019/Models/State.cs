using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _12_04_2019.Models
{
    public class State
    {
        public State()
        {
            this.Addresses = new HashSet<Address>();
            this.Districts = new HashSet<District>();
        }
        public int StateID { get; set; }
        public string States { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<District> Districts { get; set; }

    }
}