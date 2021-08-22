using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SalonWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Service> Services { get; set; }
         public DbSet<ServiceAppointment> ServiceAppointments { get; set; }
         public DbSet<Appointment> Appointments { get; set; }
         public DbSet<Employee> Employees { get; set; }
         public DbSet<PaymentType> PaymentTypes { get; set; }
         public DbSet<Product> Products { get; set; }
         public DbSet<Customer> Customers { get; set; }
         public DbSet<Order> Orders { get; set; }
         public DbSet<OrdersDetails> OrderDetails { get; set; }
        public DbSet<Memeber> Members { get; set; }

    }
}
