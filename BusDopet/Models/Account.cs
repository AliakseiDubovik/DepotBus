using BusDepot1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BusDepot.Models
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public EmployeeType Type { get; set; }
    }

   

}
