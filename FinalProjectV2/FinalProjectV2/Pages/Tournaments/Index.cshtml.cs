using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProjectV2.Models;

namespace FinalProjectV2.Pages.Tournaments
{
    public class IndexModel : PageModel
    {
        private readonly FinalProjectV2.Models.FinalProjectV2Context _context;

        public IndexModel(FinalProjectV2.Models.FinalProjectV2Context context)
        {
            _context = context;
        }

        public IList<Tournament> Tournament { get;set; }

        public async Task OnGetAsync()
        {
            Tournament = await _context.Tournament
                .Include(t => t.Admin).ToListAsync();
        }
    }
}
