using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProjectV2.Models;

namespace FinalProjectV2.Pages.Admins
{
    public class DetailsModel : PageModel
    {
        private readonly FinalProjectV2.Models.FinalProjectV2Context _context;

        public DetailsModel(FinalProjectV2.Models.FinalProjectV2Context context)
        {
            _context = context;
        }

        public Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Admin = await _context.Admin.FirstOrDefaultAsync(m => m.ID == id);

            if (Admin == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
