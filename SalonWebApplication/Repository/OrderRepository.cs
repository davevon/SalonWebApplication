using Microsoft.EntityFrameworkCore;
using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;// the database in initialise in the programm

        public OrderRepository(ApplicationDbContext db)// passing the database inside the parameter 
        {
            _db = db;// passing an object inside the so we can get the information for the database.
        }

        public bool Create(Order entity)
        {
            _db.Orders.Add(entity);
            return save();
            // throw new NotImplementedException();
        }
               

        public bool Delete(Order entity)
        {
            _db.Orders.Remove(entity);
            return save();
            // throw new NotImplementedException();
        }

     

        public ICollection<Order> FindAll()
        {            
          
            return _db.Orders.Include(q => q.Customers)
                .Include(q => q.PaymentTypes).ToList();
            // throw new NotImplementedException();
        }

        public Order FindById(int id)
        {

            _db.Orders.Include(q => q.Customers)
                .Include(q => q.PaymentTypes)
                .FirstOrDefault(q => q.OrderId == id);
          

            return _db.Orders.Find(id);
            // throw new NotImplementedException();
        }

        public ICollection<OrdersDetails> GetOrderDetailsByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetOrdersByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            
            var exist = _db.Orders.Any(q => q.OrderId == id);
            return exist;
        }

        public bool save()
        {
            return _db.SaveChanges() > 0;
            // throw new NotImplementedException();
        }

        public bool Update(Order entity)
        {
            _db.Orders.Update(entity);
            return save();
            // throw new NotImplementedException();
        }

      
       
    }
}
