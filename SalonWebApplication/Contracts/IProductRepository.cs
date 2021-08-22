using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Contracts
{
   public interface IProductRepository : IRepositoryBase<Product>
    {
        ICollection<Product> GetProductssByID(int id);
    }
}


