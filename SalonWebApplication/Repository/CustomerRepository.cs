using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        
    private readonly ApplicationDbContext _db;// the databease in initialise in the programm

    public CustomerRepository(ApplicationDbContext db)// paassing the database inside the parameter 
    {
        _db = db;// passing an object inside the so we can get the information for the database.
    }

    public bool Create(Customer entity)
    {
        _db.Customers.Add(entity);
        // throw new NotImplementedException();
        return save();
    }

    public bool Delete(Customer entity)
    {
        _db.Customers.Remove(entity);
        return save();
        //throw new NotImplementedException();
    }

    public ICollection<Customer> FindAll()
    {
        _db.Customers.ToList();
        return _db.Customers.ToList();
        //throw new NotImplementedException();
    }

    public Customer FindById(int id)
    {
        _db.Customers.Find(id);
        return _db.Customers.Find(id);
        // throw new NotImplementedException();
    }

    public ICollection<Customer> GetCustomersByID(int id)
    {
        throw new NotImplementedException();
    }

    public ICollection<Customer> GetCustomerByID(int id)
    {
        throw new NotImplementedException();
    }

        public ICollection<OrdersDetails> GetOrderDetailsByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
    {
        var exist = _db.Customers.Any(q => q.CustomerId == id);
        return exist;
    }

    public bool save()
    {
        return _db.SaveChanges() > 0;
        // throw new NotImplementedException();
    }

    public bool Update(Customer entity)
    {
        _db.Customers.Update(entity);
        return save();
        // throw new NotImplementedException();
    }



}
}



