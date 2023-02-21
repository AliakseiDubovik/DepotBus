using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusDepot.Models
{
    public class Route
    {   
        public Guid Id {get;set; }
            
        public string Start { get; set; }

        public string Finish { get; set; }

        public Guid TripId { get; set; }


    }
}
