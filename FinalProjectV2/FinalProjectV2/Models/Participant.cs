using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectV2.Models
{
    public class Participant
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "Please provide a  user name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Gender { get; set; }
        
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [StringLength(5, MinimumLength = 2, ErrorMessage = "1-5 characters only")]
        [Display(Name = "Nick Name")]
        public string NickName { get; set; }
        

        public int MatchId { get; set; }
        public Match Match { get; set; }

}
}
