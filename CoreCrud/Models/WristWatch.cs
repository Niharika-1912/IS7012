using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class WristWatch
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
       
        public string Name { get; set; }

        [StringLength(500)]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }


        public static ValidationResult ManufacturingDateInThePast(DateTime? ManufacturingDate, ValidationContext context)
        {
            if (ManufacturingDate == null)
            {
                return ValidationResult.Success;
            }
            if (ManufacturingDate < DateTime.Today)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Manufacturing date must be in the past");
            
    }
        [CustomValidation(typeof(WristWatch), "ManufacturingDateInThePast")]
        [DataType(DataType.Date)]
        [Display(Name = "Manufacturing Date")]
        public DateTime? ManufacturingDate { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "2 - 100 characters only")]

        [Display(Name = "Strap Material")]
        public string StrapMaterial { get; set; }

        [Display(Name = "High Water Resistance")]
        public bool HighWaterResistance { get; set; }

        

        public static ValidationResult PriceUSDWhenHighWaterResistance(decimal PriceUSD, ValidationContext context)
        {
            if (PriceUSD >10000)
            {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as WristWatch;
            if (instance == null)
            {
                return ValidationResult.Success;
            }
            if (instance.HighWaterResistance && PriceUSD < 10000)
            {
                return new ValidationResult($"High water resistant watches must be 10000 and above");
            }
            return ValidationResult.Success;
        }
        [CustomValidation(typeof(WristWatch), "PriceUSDWhenHighWaterResistance")]
        [Range(3000, 100000)]
        [Display(Name = "Price (USD)")]
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