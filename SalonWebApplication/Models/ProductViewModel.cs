using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SalonWebApplication.Models
{
    public class ProductViewModel
    {
        [Key]
        public int ProductId { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
        [DisplayName("Product Name")]
        [Required]

        public string ProductName { get; set; }
        [DisplayName("Product Cost")]
        [Required]

        public float ProductCost { get; set; }
        [DisplayName("Product Quantity")]
        [Required]

        public int ProductQty { get; set; }
        

        public string ProductImg { get; set; }
        [DisplayName("Product Image")]


        [Required(ErrorMessage = "Please upload an image")]
        [Display(Name = "Picture")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public Microsoft.AspNetCore.Http.IFormFile Picture { get; set;}


    }
}
