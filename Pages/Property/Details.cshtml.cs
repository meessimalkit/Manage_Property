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
    public class DetailsModel : PageModel
    {
        private readonly Manage_Property.Data.Manage_PropertyContext _context;

        public DetailsModel(Manage_Property.Data.Manage_PropertyContext context)
        {
            _context = context;
        }

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
    }
}
