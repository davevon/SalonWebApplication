using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using SalonWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _db;
        public ServiceRepository(ApplicationDbContext db)// passing the database inside the parameter 
        {
            _db = db;// passing an object inside the so we can get the information for the database.
        }
        public bool Create(Service entity)
        {
            _db.Services.Add(entity);
                return save();
        }

        public bool Delete(Service entity)
        {
            _db.Services.Remove(entity);
            return save();
            //throw new NotImplementedException();throw new NotImplementedException();
        }

        public ICollection<Service> FindAll()
        {
            _db.Services.ToList();
            return _db.Services.ToList();
            //throw new NotImplementedException();
        }

        public Service FindById(int id)
        {
            _db.Services.Find(id);
            return _db.Services.Find(id);
        }

        public ICollection<OrdersDetails> GetOrderDetailsByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Service> GetServicesByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            var exist = _db.Services.Any(q => q.ServiceId == id);
            return exist;
        }

        public bool save()
        {
            return _db.SaveChanges() > 0;
            // throw new NotImplementedException(); 

        }

        public bool Update(Service entity)
        {
            _db.Services.Update(entity);
            return save();
        }

        public object Update(ServiceViewModel service)
        {
            throw new NotImplementedException();
        }
    }
}
