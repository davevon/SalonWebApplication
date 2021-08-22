using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        ICollection<Order> GetOrdersByID(int id);
    }
}

