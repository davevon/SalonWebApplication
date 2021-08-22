using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SalonWebApplication.Models
{
    public class PaymentTypeViewModel
    {
        [Key]
        [DisplayName("Payment Type Id")]
        public int PaymentTypeId { get; set; }
        public IEnumerable<SelectListItem> PaymentTypes { get; set; }
        
        [Required]

        [DisplayName("Payment Name")]
        public string PaymentName { get; set; }
      
    }
}
