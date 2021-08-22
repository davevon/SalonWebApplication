using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Data
{
    public class Order
    {
        [Key]
       public int  OrderId { get; set; }

        [ForeignKey("CustomerId")]

        public Customer Customers { get; set; }
       public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public double Total { get; set; }

        [ForeignKey ("PaymentTypeId")]
        public PaymentType PaymentTypes { get; set; }

        public int PaymentTypeId { get; set; }

        public List<OrdersDetails> OrderDetails { get; set; }
        public int ProductQuantities { get; set; }
        public double ProductPrices { get; set; }

    }
}


