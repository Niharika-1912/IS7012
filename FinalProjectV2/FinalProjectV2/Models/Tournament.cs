using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectV2.Models
{
    public class Tournament
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide a  Tournament name")]
        [Display(Name = "Tournament Name")]
        public string TournamentName { get; set; }

        public static ValidationResult TournamentStartDateInPastOrNearFuture(DateTime? TournamentStartDate, ValidationContext context)
        {
            if (TournamentStartDate == null)
            {
                return ValidationResult.Success;
            }
            var futureDate = DateTime.Today.AddMonths(6);
            if (TournamentStartDate < futureDate)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"Start date must be before {futureDate.ToShortDateString()}");
        }


        [DataType(DataType.Date)]
        [Display(Name = "Tournament Start Date")]
        public DateTime TournamentStartDate { get; set; }
        public static ValidationResult TournamentEndDateAfterStartDate(DateTime? TournamentEndDate, DateTime? TournamentStartDate, ValidationContext context)
        {
            if (TournamentEndDate == null)
            {
                return ValidationResult.Success;
            }
            if (TournamentEndDate >= TournamentStartDate)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Tournament end date must be same as start date or after the Start date");

        }
        [CustomValidation(typeof(Tournament), "TournamentEndDateAfterStartDate")]

        [DataType(DataType.Date)]
        [Display(Name = "Tournament End Date")]
        public DateTime TournamentEndDate { get; set; }

        public static ValidationResult LocationNotBlankForAcitveTournaments(string Location, bool IsActive, ValidationContext context)
        {
            if (IsActive == false)
            {
                return ValidationResult.Success;
            }
            var active = context.ObjectInstance as Tournament;
            if (IsActive == false)
            {
                return ValidationResult.Success;
            }
            if (IsActive & Location == null)
            {
                return new ValidationResult($"Location Cannot be Blank for Active tournaments");
            }
            return ValidationResult.Success;
        }
        public string Location { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public int AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}

