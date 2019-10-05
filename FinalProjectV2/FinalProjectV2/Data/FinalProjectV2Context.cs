using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProjectV2.Models;

namespace FinalProjectV2.Models
{
    public class FinalProjectV2Context : DbContext
    {
        public FinalProjectV2Context (DbContextOptions<FinalProjectV2Context> options)
            : base(options)
        {
        }

        public DbSet<FinalProjectV2.Models.Participant> Participant { get; set; }
        public DbSet<FinalProjectV2.Models.Match> Match { get; set; }
        public DbSet<FinalProjectV2.Models.Tournament> Tournament { get; set; }
        public DbSet<FinalProjectV2.Models.Admin> Admin { get; set; }

        
    }
}
