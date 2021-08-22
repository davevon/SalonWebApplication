using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonWebApplication.Helpers;

namespace SalonWebApplication.Models
{
    public class EmployeeViewModel
    {
        [Key]
        [DisplayName("Id Number")]
        public int EmployeeId { get; set; }
        public IEnumerable <SelectListItem> Employees { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Employee Image")]
        public string EmployeeImg { get; set; }

        [Required(ErrorMessage = "Please upload an image")]
        [Display(Name = "Image")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public Microsoft.AspNetCore.Http.IFormFile Image { get; set; }
        [Required]
           [DisplayName("Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DateLessThanTodayValidion("The Date of birth should be past date")]
        public string EmployeeDOb { get; set; }
        [Required]

        [DisplayName("Gender")]
        public string EmployeeGender { get; set; }


    [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
          ErrorMessage = "Entered phone format is not valid.")]

        public string EmployeeContact { get; set; }

    }
}
