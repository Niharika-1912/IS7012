using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Pages.Watches
{
    public class DeleteModel : PageModel
    {
        private readonly CoreCrud.Models.CoreCrudContext _context;

        public DeleteModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WristWatch WristWatch { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WristWatch = await _context.WristWatch
                .Include(w => w.Manufacturer).FirstOrDefaultAsync(m => m.Id == id);

            if (WristWatch == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WristWatch = await _context.WristWatch.FindAsync(id);

            if (WristWatch != null)
            {
                _context.WristWatch.Remove(WristWatch);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
