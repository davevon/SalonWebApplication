using Microsoft.EntityFrameworkCore;
using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Repository
{
    public class ServiceAppointmentRepository : IServiceAppointmentRepository
    {
        private readonly ApplicationDbContext _db;
        public ServiceAppointmentRepository(ApplicationDbContext db)// passing the database inside the parameter 
        {
            _db = db;// passing an object inside the so we can get the information for the database.
        }
        public bool Create(ServiceAppointment entity)
        {
            _db.ServiceAppointments.Add(entity);
            return save();
        }

        public bool Delete(ServiceAppointment entity)
        {
            _db.ServiceAppointments.Remove(entity);
            return save();
            //throw new NotImplementedException();throw new NotImplementedException();
        }

        public ICollection<ServiceAppointment> FindAll()
        {
            _db.ServiceAppointments.Include(q => q.Services).Include(q => q.Appointments).ToList();
            // _db.ServiceAppointments.ToList();
            return _db.ServiceAppointments.ToList();
            //throw new NotImplementedException();
        }

        public ServiceAppointment FindById(int id)
        {
            _db.ServiceAppointments.Find(id);
            return _db.ServiceAppointments.Find(id);
        }

        public ICollection<OrdersDetails> GetOrderDetailsByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ServiceAppointment> GetServiceAppointmentByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ServiceAppointment> GetServiceAppointmentsByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            _db.ServiceAppointments.Include(q => q.Services).Include(q => q.Appointments).ToList();

            var exist = _db.ServiceAppointments.Any(q => q.ServiceAppointmentId == id);
            return exist;
        }

        public bool save()
        {
            return _db.SaveChanges() > 0;
            // throw new NotImplementedException(); 

        }

        public bool Update(ServiceAppointment entity)
        {
            _db.ServiceAppointments.Update(entity);
            return save();
        }



    }
}
