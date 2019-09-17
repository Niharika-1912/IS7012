using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class WristWatch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public string StrapMaterial { get; set; }
        public bool HighWaterResistance { get; set; }
        public decimal PriceUSD { get; set; }

        public int ManufacturerID { get; set; }
        public Manufacturer Manufacturer { get; set; }

        [NotMapped]
        public string DeepDiveCompatible
        {
            get
            {

                if (HighWaterResistance == true)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }

            }
        }
    }
}