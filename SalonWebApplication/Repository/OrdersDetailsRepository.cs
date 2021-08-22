using Microsoft.EntityFrameworkCore;
using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Repository
{
    public class OrdersDetailsRepository : IOrdersDetailsRepository
    {
        private readonly ApplicationDbContext _db;// the database in initialise in the program 

        public OrdersDetailsRepository(ApplicationDbContext db)// passing the database inside the parameter 
        {
            _db = db;// passing an object inside the so we can get the information for the database.
        }

        public bool Create(OrdersDetails entity)
        {
            _db.OrderDetails.Add(entity);
            // throw new NotImplementedException();
            return save();
        }

        public bool Delete(OrdersDetails entity)
        {
            _db.OrderDetails.Remove(entity);
            return save();
            //throw new NotImplementedException();
        }

        public ICollection<OrdersDetails> FindAll()
        {
            _db.OrderDetails.Include(q => q.Product).ToList();
            return _db.OrderDetails.ToList();
            //throw new NotImplementedException();
        }

        public OrdersDetails FindById(int id)
        {
            _db.OrderDetails.Find(id);
            return _db.OrderDetails.Find(id);
            // throw new NotImplementedException();
        }

        public ICollection<OrdersDetails> GetOrderDetailsByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrdersDetails> GetOrdersDetailsByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            var exist = _db.OrderDetails.Any(q => q.OrderDetailsId == id);
            return exist;
        }

        public bool save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(OrdersDetails entity)
        {
            _db.OrderDetails.Update(entity);
            return save();
            // throw new NotImplementedException();
        }
    }
}
