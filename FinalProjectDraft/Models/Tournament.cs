using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectDraft.Models
{
    public class Tournament
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        [Display(Name = "Tournament Name")]
        public string Tournament_Name { get; set; }

        [Display(Name = "Tournament Start Date")]
        public DateTime Tournament_Start_Date { get; set; }

        [Display(Name = "Tournament End Date")]
        public DateTime Tournament_End_Date { get; set; }
        
        public string Location { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Match> Matches { get; set; }

        public int Admin_ID { get; set; }
        public Admin Admin { get; set; }

    }
    

          

    }



