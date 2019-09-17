using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Pages
{
    public class ManufacturerProfileModel : PageModel
    {

        private CoreCrudContext _context;
        public ManufacturerProfileModel(CoreCrudContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }
        public IActionResult OnGet(int? id)

        {

           if (id == null)
                {
                    return NotFound();
                }


                Manufacturer = _context.Manufacturer.Include(i=>i.Watches).FirstOrDefault(i=>i.ID==id);

            if (Manufacturer == null)
            {
                return NotFound();
            }


            return Page();

        }
    }
}

