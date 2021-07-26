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
    public class IndexModel : PageModel
    {
        private readonly Manage_Property.Data.Manage_PropertyContext _context;

        public IndexModel(Manage_Property.Data.Manage_PropertyContext context)
        {
            _context = context;
        }

        public IList<Dealer> Dealer { get;set; }

        public async Task OnGetAsync()
        {
            Dealer = await _context.Dealer.ToListAsync();
        }
    }
}
