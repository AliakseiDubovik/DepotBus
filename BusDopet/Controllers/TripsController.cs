using BusDepot.Models;
using DepotBus.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusDepot.Controllers
{

    //[Route("trip")] 

    public class TripsController : Controller
    {
        public TripsController(DepotContext depotContext)
        {
            _depotContext = depotContext;
        }


        private readonly DepotContext _depotContext;

        public Guid NextTripId { get; private set; }

        [HttpGet]
        public IEnumerable<Trip> Get() => _depotContext.Trips; 


        [HttpGet("{id}")] // получение конкретной поездки

        public IActionResult Get(Guid id)

        {
            var trip = _depotContext.Trips.SingleOrDefault(t => t.Id == id);
            if (trip == null)
            {
                return NotFound();
            }
            return Ok(trip);
        }

        [HttpDelete("{id}")] //удаление поездки

        public IActionResult Delete(Guid id)
        {
            _depotContext.Trips.Remove(_depotContext.Trips.SingleOrDefault(t => t.Id == id));
            _depotContext.SaveChanges();
            return Ok();
        }

        [HttpPost] //добавление поездки
        public IActionResult Post(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            trip.Id = NextTripId;
            _depotContext.Trips.Add(trip);
            _depotContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { Id = trip.Id }, trip);
        }

        [HttpPost("add-trip")]
        public IActionResult PostBody([FromBody] Trip trip) => Post(trip);

        public IActionResult Put(Trip trip)//обновление поездки
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var storeTrip = _depotContext.Trips.SingleOrDefault(t => t.Id == trip.Id);
            if (storeTrip == null)
            {
                return NotFound();
            }
            storeTrip.StarDateTime = trip.StarDateTime;
            storeTrip.FinishDateTime = trip.FinishDateTime;
            storeTrip.BusId = trip.BusId; 
            storeTrip.Incident = trip.Incident;

            _depotContext.SaveChanges();

            return Ok(storeTrip);
        }

        [HttpPut("update-trip")]
            public IActionResult PutBody([FromBody] Trip trip) => Put(trip);



       
        
    }
}
