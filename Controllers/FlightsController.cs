﻿using AirlineServiceSoftware.Entities;
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

        [Authorize(Roles = Role.Dispatcher)]
        [HttpPost("CreateFlight")]
        public IActionResult CreateFlight([FromBody] Flight flightData)
        {
            flightData.FlightDate = flightData.FlightDate.AddDays(1);
            var result = _flightService.CreateFlight(flightData);
            if (!result)
            {
                return BadRequest(new { message = "Flight was not created." });
            }
            return Ok(result);

        }

        [Authorize(Roles = Role.Dispatcher)]
        [HttpGet("GetAllFlights")]
        public IActionResult GetAllFlights()
        {
            var flights = _flightService.GetAllFlights();
            if (flights == null) return NotFound();
            return Ok(flights);
        }

        [Authorize(Roles = Role.Dispatcher)]
        [HttpPost("EditFlight")]
        public IActionResult EditFlight([FromBody] Flight flightData)
        {
            flightData.FlightDate = flightData.FlightDate.AddDays(1);
            var result = _flightService.EditFlight(flightData);
            if (!result)
            {
                return BadRequest(new { message = "Crew was not modified." });
            }
            return Ok(result);
        }

        [Authorize(Roles = Role.Dispatcher)]
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

        [Authorize(Roles = Role.Pilot)]
        [HttpGet("GetPilotFlights/{id}")]
        public IActionResult GetPilotFlights(int id)
        {
            var flights = _flightService.GetPilotFlights(id);
            if (flights == null) return NotFound();
            return Ok(flights);
        }

        [Authorize(Roles = Role.Pilot)]
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

        [HttpGet("GetFlight/{Id}")]
        public IActionResult GetFlight(int Id)
        {
            var result = _flightService.GetFlight(Id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
