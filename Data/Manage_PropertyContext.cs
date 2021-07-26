using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Manage_Property.Models;

namespace Manage_Property.Data
{
    public class Manage_PropertyContext : DbContext
    {
        public Manage_PropertyContext (DbContextOptions<Manage_PropertyContext> options)
            : base(options)
        {
        }

        public DbSet<Manage_Property.Models.Auction> Auction { get; set; }

        public DbSet<Manage_Property.Models.Customer> Customer { get; set; }

        public DbSet<Manage_Property.Models.Dealer> Dealer { get; set; }

        public DbSet<Manage_Property.Models.Properties> Properties { get; set; }
    }
}
