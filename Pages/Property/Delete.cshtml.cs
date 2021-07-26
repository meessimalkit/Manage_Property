using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Manage_Property.Data;
using Manage_Property.Models;

namespace Manage_Property.Pages.Property
{
    public class DeleteModel : PageModel
    {
        private readonly Manage_Property.Data.Manage_PropertyContext _context;

        public DeleteModel(Manage_Property.Data.Manage_PropertyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Properties Properties { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Properties = await _context.Properties.FirstOrDefaultAsync(m => m.Id == id);

            if (Properties == null)
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

            Properties = await _context.Properties.FindAsync(id);

            if (Properties != null)
            {
                _context.Properties.Remove(Properties);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
