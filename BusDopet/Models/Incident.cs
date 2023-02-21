using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusDepot.Models
{
    public class Incident
    {
        public Guid Id { get; set; }

        public string DiscriptionProblem { get; set; }

        public string Mechanic { get; set; }
    }
}
