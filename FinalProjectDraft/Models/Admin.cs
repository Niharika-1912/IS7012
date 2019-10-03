using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectDraft.Models
{
    public class Admin
    {
        public int ID { get; set; }
        public string Admin_Name { get; set; }
        public string Managing_Tournament { get; set; }



        public ICollection<Tournament> Tournaments { get; set; }
    }
}
