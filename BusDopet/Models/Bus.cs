using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusDepot.Models
{
    public class Bus
    {
       

        public Guid Id { get; set; }

        [Required]
        public string Color { get; set; }

        
        public string Brand { get; set; }

        
    }
}
