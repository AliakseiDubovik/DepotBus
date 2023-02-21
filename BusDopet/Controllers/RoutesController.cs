using BusDepot.Models;
using DepotBus.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusDepot.Controllers
{
    [Route("route")]
    public class RoutesController : Controller
    {
        public RoutesController(DepotContext depotContext)
        {
            _depotContext = depotContext;
        }



        [HttpGet]
        public IEnumerable<Route> Get() => _depotContext.Routes;

        [HttpGet("{id}")] // получение конкретного маршрута

        public IActionResult Get(Guid id)

        {
            var route = _depotContext.Routes.SingleOrDefault(r => r.Id == id);
            if (route == null)
            {
                return NotFound();
            }
            return Ok(route);
        }

        private readonly DepotContext _depotContext;

        [HttpPut("update-route")]
        public IActionResult UpdatePut([FromBody] Route route)//обновление маршрута
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var storeRoute = _depotContext.Routes.SingleOrDefault(r => r.Id == route.Id);
            if (storeRoute == null)
            {
                return NotFound();
            }

            storeRoute.Start = route.Start;
            storeRoute.Finish = route.Finish; 
            storeRoute.TripId = route.TripId;
            _depotContext.SaveChanges();


            return Ok(storeRoute);
        }

        [HttpPost("add-route")] //добавление автобуса
        public IActionResult AddRoute ([FromForm]Route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            _depotContext.Routes.Add(route);

            _depotContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")] //удаление автобуса

        public IActionResult Delete(Guid id)
        {
            _depotContext.Routes.Remove(_depotContext.Routes.SingleOrDefault(b => b.Id == id));

            _depotContext.SaveChanges();

            return Ok();
        }

    }
   
}
