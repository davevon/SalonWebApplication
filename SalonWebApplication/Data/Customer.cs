using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Data
{
    public class Customer
    {
    public int  CustomerId {get;set;}
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerDOB { get; set; }
    public string CustomerContact { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerOccupation { get; set; }
    public string CustomerTRN { get; set; }
    }
}
