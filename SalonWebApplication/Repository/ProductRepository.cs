using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _db;// the database in initialise in the programm

        public ProductRepository(ApplicationDbContext db)// passing the database inside the parameter 
        {
            _db = db;// passing an object inside the so we can get the information for the database.
        }

        public bool Create(Product entity)
        {
            _db.Products.Add(entity);
            // throw new NotImplementedException();
            return save();
        }

        public bool Delete(Product entity)
        {
            _db.Products.Remove(entity);
            return save();
            //throw new NotImplementedException();
        }

        public ICollection<Product> FindAll()
        {
            _db.Products.ToList();
            return _db.Products.ToList();
            //throw new NotImplementedException();
        }

        public Product FindById(int id)
        {
            _db.Products.Find(id);
            return _db.Products.Find(id);
            // throw new NotImplementedException();
        }

        public ICollection<OrdersDetails> GetOrderDetailsByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetProductssByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            var exist = _db.Products.Any(q => q.ProductId == id);
            return exist;
        }

        public bool save()
        {
            return _db.SaveChanges() > 0;
            // throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            _db.Products.Update(entity);
            return save();
            // throw new NotImplementedException();
        }

       
    }
}
