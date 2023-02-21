using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusDepot.Models
{
    public class Trip
    {
        public Guid Id { get; set; }

        public DateTime StarDateTime { get; set; }

        public DateTime FinishDateTime { get; set; }

        public Guid BusId { get; set; }

        public string Incident { get; set; }
    }

}
