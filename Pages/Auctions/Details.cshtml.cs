using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Manage_Property.Data;
using Manage_Property.Models;

namespace Manage_Property.Pages.Auctions
{
    public class DetailsModel : PageModel
    {
        private readonly Manage_Property.Data.Manage_PropertyContext _context;

        public DetailsModel(Manage_Property.Data.Manage_PropertyContext context)
        {
            _context = context;
        }

        public Auction Auction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Auction = await _context.Auction
                .Include(a => a.Customer_Detail)
                .Include(a => a.Dealer_Detail)
                .Include(a => a.Property_Detail).FirstOrDefaultAsync(m => m.Id == id);

            if (Auction == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
