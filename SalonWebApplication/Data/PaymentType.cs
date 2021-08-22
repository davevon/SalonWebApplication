using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Data
{
    public class PaymentType
    {  
        [Key]
        public int PaymentTypeId { get; set; }
        [Required]

        public string PaymentName { get; set; }
      
    }
}
