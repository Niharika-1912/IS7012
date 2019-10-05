using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectV2.Models
{
    public class Match
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide a  Match name")]
        [Display(Name = "Match Name")]
        public string MatchName { get; set; }

        [Required(ErrorMessage = "Please provide a  Tournament name")]
        [Display(Name = "Tournament Name")]
        public string TournamentName { get; set; }
        public string Location { get; set; }

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

    }
}
