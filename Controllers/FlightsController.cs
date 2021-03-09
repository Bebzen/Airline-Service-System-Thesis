using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Services.Flights;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineServiceSoftware.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [Authorize(Roles = "Admin, Dispatcher")]
        [HttpPost("CreateFlight")]
        public IActionResult CreateFlight([FromBody] Flight flightData)
        {
            var result = _flightService.CreateFlight(flightData);
            if (!result)
            {
                return BadRequest(new { message = "Flight was not modified." });
            }
            return Ok(result);

        }

        [Authorize(Roles = "Admin, Dispatcher")]
        [HttpGet("GetAllFlights")]
        public IActionResult GetAllFlights()
        {
            var flights = _flightService.GetAllFlights();
            if (flights == null) return NotFound();
            return Ok(flights);
        }

        [Authorize(Roles = "Admin, Dispatcher")]
        [HttpPost("EditFlight")]
        public IActionResult EditFlight([FromBody] Flight flightData)
        {
            var result = _flightService.EditFlight(flightData);
            if (!result)
            {
                return BadRequest(new { message = "Crew was not modified." });
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin, Dispatcher")]
        [HttpDelete("DeleteFlight/{Id}")]
        public IActionResult DeleteFlight(int Id)
        {
            var result = _flightService.DeleteFlight(Id);
            if (!result)
            {
                return BadRequest(new { message = "Crew was not deleted." });
            }
            return Ok(result);

        }

        [Authorize(Roles = "Admin, Pilot")]
        [HttpGet("GetPilotFlights/{Id}")]
        public IActionResult GetPilotFlights(int Id)
        {
            var flights = _flightService.GetPilotFlights(Id);
            if (flights == null) return NotFound();
            return Ok(flights);
        }

        [Authorize(Roles = "Admin, Pilot")]
        [HttpPost("EditFlightStatus")]
        public IActionResult EditFlightStatus([FromBody] Flight flightData)
        {
            var result = _flightService.EditFlightStatus(flightData);
            if (!result)
            {
                return BadRequest(new { message = "Flight was not modified." });
            }
            return Ok(result);
        }

        [HttpPost("SearchFlights")]
        public IActionResult SearchFlights([FromBody] SearchParameters searchParameters)
        {
            searchParameters.DepartureDate = searchParameters.DepartureDate.AddDays(1);
            var flights = _flightService.SearchFlights(searchParameters);
            return Ok(flights);
        }
    }
}
