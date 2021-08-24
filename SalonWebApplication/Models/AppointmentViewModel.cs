﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Models
{
    public class AppointmentViewModel
    {
        [Key]
        public int AppointmentId { get; set; }
        [DisplayName("Date ")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string AppointmentDate { get; set; }
        [DisplayName(" Time")]
        [DataType(DataType.DateTime), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]

        public string AppointmentTime { get; set; }

        public EmployeeViewModel Employee { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }
        [DisplayName("Worker")]
        public int EmployeeId { get; set; }
        

        public CustomerViewModel Customer { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        [DisplayName("Customer")]
        public int CustomerId { get; set; }


        public ServiceViewModel Service { get; set; }
        public IEnumerable<SelectListItem> Services { get; set; }
        [DisplayName("Service")]
        public int ServiceId { get; set; }



    }
}
