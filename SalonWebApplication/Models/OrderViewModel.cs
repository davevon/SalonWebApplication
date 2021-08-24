using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Models
{
    public class OrderViewModel
    {
        [Key]
        [DisplayName("Order#")]
        public int OrderId { get; set; }    

         
        public CustomerViewModel Customer { get; set; }
        [IgnoreMap]
        public IEnumerable<SelectListItem> Customers { get; set; }
        [DisplayName(" Name")]
        [Required]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        [DisplayName("Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]        
        [Required(ErrorMessage = "The Order Date is required.")]
        public DateTime  OrderDate { get; set; }
                

        public double Total { get; set; }

        public PaymentTypeViewModel PaymentType { get; set; }
        [IgnoreMap]
        public IEnumerable<SelectListItem> PaymentTypes { get; set; }
        [DisplayName("Payment")]
        public int PaymentTypeId { get; set; }
        /*  public string Paymentname { get; set; }*/

        public List<OrdersDetailsViewModel> OrdersDetails { get; set; }

        [Display(Name ="Product")]
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        [IgnoreMap]
        public IEnumerable<SelectListItem> Products { get; set; }

        /*        public string ProductName { get; set; }*/
        [DisplayName("Product Quantity")]
        public int ProductQuantities { get; set; }

        [DisplayName("Product Price")]
        public double ProductPrices { get; set; }
    }
}
