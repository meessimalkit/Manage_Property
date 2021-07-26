using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Manage_Property.Data;
using Manage_Property.Models;

namespace Manage_Property.Pages.Auctions
{
    public class CreateModel : PageModel
    {
        private readonly Manage_Property.Data.Manage_PropertyContext _context;

        public CreateModel(Manage_Property.Data.Manage_PropertyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Customer_DetailId"] = new SelectList(_context.Set<Customer>(), "Id", "Customer_Name");
        ViewData["Dealer_DetailId"] = new SelectList(_context.Set<Dealer>(), "Id", "Dealer_Name");
        ViewData["Property_DetailId"] = new SelectList(_context.Set<Properties>(), "Id", "Area");
            return Page();
        }

        [BindProperty]
        public Auction Auction { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Auction.Add(Auction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
