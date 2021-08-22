using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Models
{
    public class OrdersDetailsViewModel
    {
        [Key]
        public int OrderDetailsId { get; set; }

        public OrderViewModel Order { get; set; }
        
        public int OrderId { get; set; }

        public int Quantity { get; set; }
        public ProductViewModel Product { get; set; }
        public int ProductId { get; set; }
    }
}
