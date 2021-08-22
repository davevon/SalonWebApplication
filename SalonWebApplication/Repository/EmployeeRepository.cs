using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
            private readonly ApplicationDbContext _db;// the database in initialise in the programm

            public EmployeeRepository(ApplicationDbContext db)// passing the database inside the parameter 
            {
                _db = db;// passing an object inside the so we can get the information for the database.
            }

            public bool Create(Employee entity)
            {
                _db.Employees.Add(entity);
                // throw new NotImplementedException();
                return save();
            }
         

        public bool Delete(Employee entity)
            {
                _db.Employees.Remove(entity);
                return save();
                //throw new NotImplementedException();
            }

       

        public ICollection<Employee> FindAll()
            {
                _db.Employees.ToList();
                return _db.Employees.ToList();
                //throw new NotImplementedException();
            }

        public Employee FindById(int id)
            {
                _db.Employees.Find(id);
                return _db.Employees.Find(id);
                // throw new NotImplementedException();
            }

            public ICollection<Employee> GetEmployeesByID(int id)
            {
                throw new NotImplementedException();
            }

        public ICollection<OrdersDetails> GetOrderDetailsByID(int id)   //WHAT IS THIS??
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
            {
                var exist = _db.Employees.Any(q => q.EmployeeId == id);
                return exist;
            }

            public bool save()
            {
                return _db.SaveChanges() > 0;
                // throw new NotImplementedException();
            }

            public bool Update(Employee entity)
            {
                _db.Employees.Update(entity);
                return save();
                // throw new NotImplementedException();
            }

      /*  bool IRepositoryBase<Employee>.isExist(int id)
        {
            throw new NotImplementedException();
        }*/
    }
}
