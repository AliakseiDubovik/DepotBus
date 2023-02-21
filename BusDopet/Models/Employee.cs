using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusDepot1.Models
{
    public class Employee
    {
        public Guid Id { get;set;}

        public string Name { get; set; }

        public EmployeeType Type { get; set; }

    }

    

}
