using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        public string Name { get; set; }

        [Display(Name = "Country of Origin")]
        public string CountryofOrigin { get; set; }

        public ICollection<WristWatch> Watches { get; set; }

    }
}
