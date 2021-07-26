using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Manage_Property.Data;
using Manage_Property.Models;

namespace Manage_Property.Pages.Dealers
{
    public class DeleteModel : PageModel
    {
        private readonly Manage_Property.Data.Manage_PropertyContext _context;

        public DeleteModel(Manage_Property.Data.Manage_PropertyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dealer Dealer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dealer = await _context.Dealer.FirstOrDefaultAsync(m => m.Id == id);

            if (Dealer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dealer = await _context.Dealer.FindAsync(id);

            if (Dealer != null)
            {
                _context.Dealer.Remove(Dealer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
