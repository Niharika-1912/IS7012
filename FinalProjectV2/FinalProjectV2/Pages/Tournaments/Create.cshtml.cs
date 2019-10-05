using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProjectV2.Models;

namespace FinalProjectV2.Pages.Tournaments
{
    public class CreateModel : PageModel
    {
        private readonly FinalProjectV2.Models.FinalProjectV2Context _context;

        public CreateModel(FinalProjectV2.Models.FinalProjectV2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AdminId"] = new SelectList(_context.Admin, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Tournament Tournament { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tournament.Add(Tournament);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}