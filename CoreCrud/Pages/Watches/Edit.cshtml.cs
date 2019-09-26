using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Pages.Watches
{
    public class EditModel : PageModel
    {
        private readonly CoreCrud.Models.CoreCrudContext _context;

        public EditModel(CoreCrud.Models.CoreCrudContext context)
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
            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturer, "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ManufacturerID"] = new SelectList(_context.Manufacturer, "ID", "Name");
                return Page();
            }

            _context.Attach(WristWatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WristWatchExists(WristWatch.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WristWatchExists(int id)
        {
            return _context.WristWatch.Any(e => e.Id == id);
        }
    }
}
