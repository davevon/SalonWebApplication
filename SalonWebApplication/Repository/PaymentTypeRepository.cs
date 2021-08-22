using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Repository
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly ApplicationDbContext _db;// the database in initialise in the programm

        public PaymentTypeRepository(ApplicationDbContext db)// passing the database inside the parameter 
        {
            _db = db;// passing an object inside the so we can get the information for the database.
        }

        public bool Create(PaymentType entity)
        {
            _db.PaymentTypes.Add(entity);
            // throw new NotImplementedException();
            return save();
        }

        public bool Delete(PaymentType entity)
        {
            _db.PaymentTypes.Remove(entity);
            return save();
            //throw new NotImplementedException();
        }

        public ICollection<PaymentType> FindAll()
        {
            _db.PaymentTypes.ToList();
            return _db.PaymentTypes.ToList();
            //throw new NotImplementedException();
        }

        public PaymentType FindById(int id)
        {
            _db.PaymentTypes.Find(id);
            return _db.PaymentTypes.Find(id);
            // throw new NotImplementedException();
        }

        public ICollection<PaymentType> GetAppointmentsByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrdersDetails> GetOrderDetailsByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PaymentType> GetPaymentTypeByID(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PaymentType> GetPaymentTypesByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            var exist = _db.PaymentTypes.Any(q => q.PaymentTypeId == id);
            return exist;
        }

        public bool save()
        {
            return _db.SaveChanges() > 0;
            // throw new NotImplementedException();
        }

        public bool Update(PaymentType entity)
        {
            _db.PaymentTypes.Update(entity);
            return save();
            // throw new NotImplementedException();
        }

      


    }
}
