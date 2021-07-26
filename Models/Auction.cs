using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manage_Property.Models
{
    public class Auction
    {
        public int Id { get; set; }

        [Required]
        public Decimal Bid_Price { get; set; }

        public int Property_DetailId { get; set; }
        public Properties Property_Detail { get; set; }

        public int Customer_DetailId { get; set; }

        public Customer Customer_Detail { get; set; }

        public int Dealer_DetailId { get; set; }

        public Dealer Dealer_Detail { get; set; }
    }
}
