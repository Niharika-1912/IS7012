using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryofOrigin { get; set; }

        public ICollection<WristWatch> Watches { get; set; }

    }
}
