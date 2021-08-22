using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Data
{
    public class OrdersDetails
    { 
        [Key]
         public int OrderDetailsId { get; set; }

        [ForeignKey("OrderId")]
        public Order Orders { get; set; }
        public int OrderId { get; set; }
        [Required]

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
       
        public int ProductId{ get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }


    }
}
