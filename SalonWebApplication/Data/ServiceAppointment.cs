using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Data
{
    public class ServiceAppointment
    {
        public int ServiceAppointmentId { get; set; }

        [ForeignKey("ServiceId")]
        public Service Services { get; set; }
        public int ServiceId { get; set; }


        [ForeignKey("AppointmentId")]
        public Appointment Appointments { get; set; }
        public int AppointmentId { get; set; }
           

        

    }
}
