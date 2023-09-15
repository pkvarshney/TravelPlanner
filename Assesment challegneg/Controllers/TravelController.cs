using TravelPlanner.Entities;
using TravelPlanner.Models;
using TravelPlanner.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TravelPlanner.Controllers
{
    [Route("[controller]")]
    public class TravelController : Controller
    {
        private ITravelService _serv;
        public TravelController(ITravelService serv)
        {
            _serv = serv;
        }


        [HttpPost]
        public IActionResult GetTravelItineraries([FromBody] TravelRequest request)
        {

            var resp = _serv.GetTravelItineraries(request);
            return Ok(JsonSerializer.Serialize(resp));
        }
    }
}
