using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        ICollection<Employee> GetEmployeesByID(int id);
    }
}


