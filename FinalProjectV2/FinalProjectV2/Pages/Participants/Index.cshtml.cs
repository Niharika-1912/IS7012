using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProjectV2.Models;

namespace FinalProjectV2.Pages.Participants
{
    public class IndexModel : PageModel
    {
        private readonly FinalProjectV2.Models.FinalProjectV2Context _context;

        public IndexModel(FinalProjectV2.Models.FinalProjectV2Context context)
        {
            _context = context;
        }

        public IList<Participant> Participant { get;set; }

        public async Task OnGetAsync()
        {
            Participant = await _context.Participant
                .Include(p => p.Match).ToListAsync();
        }
    }
}
