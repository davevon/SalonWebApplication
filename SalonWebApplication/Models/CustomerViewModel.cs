using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonWebApplication.Helpers;

namespace SalonWebApplication.Models
{
    public class CustomerViewModel
    {
        [Key]
        public int CustomerId { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }
        [Required]

        [DisplayName("Customer First Name")]
        public string CustomerFirstName { get; set; }
        [Required]

        [DisplayName("Customer Last Name")]
        public string CustomerLastName { get; set; }
        
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Birth")]
        [Required]
        [DateLessThanTodayValidion("The Date of birth should be past date")]
        public String CustomerDOB { get; set; }
        

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
          ErrorMessage = "Entered phone format is not valid.")]

        [DisplayName("Customer Contact")]
        public string CustomerContact { get; set; }
        [Required]

        [DisplayName("Customer Address")]
        public string CustomerAddress { get; set; }

        [DisplayName("Customer Occupation")]
        public string CustomerOccupation { get; set; }
       

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "TRN")]
        [Required(ErrorMessage = "TAX REGISTRATION NUMBER REQUIRED!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$",
          ErrorMessage = "TRN format is not valid.")]
        public string CustomerTRN { get; set; }
    }
}
