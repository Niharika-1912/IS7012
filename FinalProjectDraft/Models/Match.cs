using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectDraft.Models
{
    public class Match
    {
        public int ID { get; set; }
        public string Match_Name { get; set; }
        public string Tournament_Name { get; set; }
        public string Location { get; set; }
                
        public int Tournament_ID { get; set; }
        public Tournament Tournament { get; set; }
    }
}
