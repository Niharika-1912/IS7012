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
    public class IndexModel : PageModel
    {
        private CoreCrudContext _context;
        public IndexModel(CoreCrudContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            CountOfDeepDiveCompatibleWatches = _context.WristWatch
                                                    .Where(x => x.HighWaterResistance == true)
                                                    .Count();

            CountOfRolexWatches = _context.Manufacturer
                                    .Where(x => x.Name == "Rolex")
                                    .Count();

            CountOfLeatherWatches = _context.WristWatch
                                        .Where(x => x.StrapMaterial == "Leather")
                                        .Count();
            CountOfStainlessSteelWatches = _context.WristWatch
                                        .Where(x => x.StrapMaterial == "Stainless Steel")
                                        .Count();




        }

        public int CountOfRolexWatches { get; set; }
        public int CountOfDeepDiveCompatibleWatches { get; set; }
        public int CountOfLeatherWatches { get; set; }
        public int CountOfStainlessSteelWatches { get; set; }
    }
}