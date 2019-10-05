using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectV2.Models
{
    public class Admin
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide an  Admin name")]
        [Display(Name = "Admin Name")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Please provide the Tournament Name Managed")]
        [Display(Name = "Managing Tournaments")]
        public string ManagingTournament { get; set; }

        public ICollection<Tournament> Tournaments { get; set; }
    }
}
