using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SalonWebApplication.Models
{
    public class ServiceViewModel
    {
        [Key]
        [DisplayName("Service Id")]
        public int ServiceId { get; set; }
        public IEnumerable<SelectListItem> Services { get; set; }

        [DisplayName("Service Name")]
        public string ServiceName { get; set; }
        [Required]

        [DisplayName("Service Cost")]
        public int ServiceCost { get; set; }
        [Required]
        

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString = @" {0:mm\:ss}")]
        public TimeSpan Duration { get; set; }
        public string TimeDuration { get; set; }
    }
}
