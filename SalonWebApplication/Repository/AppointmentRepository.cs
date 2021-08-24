using Microsoft.EntityFrameworkCore;
using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _db;// the database in initialise in the programm

        public AppointmentRepository(ApplicationDbContext db)// passing the database inside the parameter 
        {
            _db = db;// passing an object inside the so we can get the information for the database.
        }

        public bool Create(Appointment entity)
        {
            _db.Appointments.Add(entity);
            // throw new NotImplementedException();
            return save();
        }

        public bool Delete(Appointment entity)
        {
            _db.Appointments.Remove(entity);
            return save();
            //throw new NotImplementedException();
        }

        public ICollection<Appointment> FindAll()
        {
            _db.Appointments.Include(q => q.Customer).Include(q=>q.Service).Include(q => q.Employee).ToList();
            return _db.Appointments.ToList();
            //throw new NotImplementedException();
        }

        public Appointment FindById(int id)
        {
            _db.Appointments.Find(id);
            return _db.Appointments.Find(id);
            // throw new NotImplementedException();
        }

        public ICollection<Appointment> GetAppointmentsByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrdersDetails> GetOrderDetailsByID(int id)
        {
            throw new NotImplementedException();
        }

        /* public ICollection<Appointment> GetAppointmentsByID(int id)
         {
             throw new NotImplementedException();
         }

         public ICollection<Appointment> GetAppointmentByID(int id)
         {
             throw new NotImplementedException();
         }*/

        public bool isExist(int id)
        {
            _db.Appointments.Include(q => q.Customer).Include(q => q.Service).Include(q => q.Employee).ToList();
            var exist = _db.Appointments.Any(q => q.AppointmentId == id);
            return exist;
        }

        public bool save()
        {
            return _db.SaveChanges() > 0;
            // throw new NotImplementedException();
        }

        public bool Update(Appointment entity)
        {
            _db.Appointments.Update(entity);
            return save();
            // throw new NotImplementedException();
        }

       /* public ICollection<OrdersDetails> GetOrderDetailsByID(int id)
        {
            throw new NotImplementedException();
        }*/
    }
}


