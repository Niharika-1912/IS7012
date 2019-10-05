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
    public class DetailsModel : PageModel
    {
        private readonly FinalProjectV2.Models.FinalProjectV2Context _context;

        public DetailsModel(FinalProjectV2.Models.FinalProjectV2Context context)
        {
            _context = context;
        }

        public Tournament Tournament { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournament = await _context.Tournament
                .Include(t => t.Admin).FirstOrDefaultAsync(m => m.ID == id);

            if (Tournament == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
