﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreCrud.Pages
{
    public class AuctionModel : PageModel
    {
        private CoreCrudContext _context;
        public AuctionModel(CoreCrudContext context)
        {
            _context = context;
        }
        public ICollection<WristWatch> Watches { get; set; }
        public void OnGet(int? id)
        {
            Watches = _context.WristWatch.OrderBy(x => x.PriceUSD).ToList();
        }
    }
}
