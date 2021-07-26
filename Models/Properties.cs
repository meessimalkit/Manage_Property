using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manage_Property.Models
{
    public class Properties
    {
        public int Id { get; set; }

        public string Property_Type { get; set; }
        [Required]

        public string Area { get; set; }
        [Required]

        public decimal Price { get; set; }
        [Required]

        public string Facilities { get; set; }
    }
}
