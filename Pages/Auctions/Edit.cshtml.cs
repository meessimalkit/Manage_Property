using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manage_Property.Data;
using Manage_Property.Models;

namespace Manage_Property.Pages.Auctions
{
    public class EditModel : PageModel
    {
        private readonly Manage_Property.Data.Manage_PropertyContext _context;

        public EditModel(Manage_Property.Data.Manage_PropertyContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["Customer_DetailId"] = new SelectList(_context.Set<Customer>(), "Id", "Customer_Name");
           ViewData["Dealer_DetailId"] = new SelectList(_context.Set<Dealer>(), "Id", "Dealer_Name");
           ViewData["Property_DetailId"] = new SelectList(_context.Set<Properties>(), "Id", "Area");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Auction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionExists(Auction.Id))
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

        private bool AuctionExists(int id)
        {
            return _context.Auction.Any(e => e.Id == id);
        }
    }
}
