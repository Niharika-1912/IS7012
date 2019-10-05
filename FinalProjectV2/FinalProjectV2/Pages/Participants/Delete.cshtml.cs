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
    public class DeleteModel : PageModel
    {
        private readonly FinalProjectV2.Models.FinalProjectV2Context _context;

        public DeleteModel(FinalProjectV2.Models.FinalProjectV2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Participant Participant { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Participant = await _context.Participant
                .Include(p => p.Match).FirstOrDefaultAsync(m => m.ID == id);

            if (Participant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Participant = await _context.Participant.FindAsync(id);

            if (Participant != null)
            {
                _context.Participant.Remove(Participant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
