﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreCrud.Models;

namespace CoreCrud.Pages.Watches
{
    public class CreateModel : PageModel
    {
        private readonly CoreCrud.Models.CoreCrudContext _context;

        public CreateModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ManufacturerID"] = new SelectList(_context.Manufacturer, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public WristWatch WristWatch { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name");
                return Page();
            }

            _context.WristWatch.Add(WristWatch);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}