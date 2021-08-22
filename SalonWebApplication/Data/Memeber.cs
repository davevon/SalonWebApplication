using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace SalonWebApplication.Data
{
    public class Memeber : IdentityUser
    {
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        

    }
}
