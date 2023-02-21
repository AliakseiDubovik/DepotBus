using BusDepot.Models;
using DepotBus.Data;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusDepot.Controllers
{
    [Route("bus")]
    public class BusesController : Controller
    {
        public Guid NextBusId { get; private set; }

        [HttpGet]
        public IEnumerable<Bus> Get() => _depotContext.Buses;

        [HttpGet("{id}")] // получение конкретного автобуса
        
        public IActionResult Get(Guid id)

        {
            var bus = _depotContext.Buses.SingleOrDefault(b => b.Id == id);
            if (bus == null)
            {
                return NotFound();
            }
            return Ok(bus);
        }



        [HttpDelete("{id}")] //удаление автобуса

        public IActionResult Delete(Guid id)
        {
            _depotContext.Buses.Remove(_depotContext.Buses.SingleOrDefault(b => b.Id == id));

            _depotContext.SaveChanges();

            return Ok();
        }

       

        [HttpPost] //добавление автобуса
        public IActionResult Post(Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bus.Id = NextBusId;
            _depotContext.Buses.Add(bus);

            _depotContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { Id = bus.Id }, bus);
        }

        [HttpPost("add-bus")]
        public IActionResult PostBody([FromBody] Bus bus) => Post(bus);

        [HttpPut]
        public IActionResult Put(Bus bus)//обновление автобуса
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var storeBus = _depotContext.Buses.SingleOrDefault(b => b.Id == bus.Id);
            if(storeBus == null)
            {
                return NotFound();
            }
            storeBus.Brand = bus.Brand;
            storeBus.Color = bus.Color;

            _depotContext.SaveChanges();

            return Ok(storeBus);

        }

        [HttpPut("update-bus")]
        public IActionResult PutBody([FromBody] Bus bus) => Put(bus);
        
        



        public BusesController(DepotContext depotContext)
        {
            _depotContext = depotContext;
        }


        private readonly DepotContext _depotContext;


      
    }

}
