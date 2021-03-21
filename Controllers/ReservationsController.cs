using System.Reflection.Metadata.Ecma335;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Services.Reservations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineServiceSoftware.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("CreateReservation")]
        public IActionResult CreateReservation(Reservation reservationData)
        {
            var result = _reservationService.CreateReservation(reservationData);
            if (!result)
            {
                return BadRequest(new { message = "Transaction was not created." });
            }

            return Ok(result);
        }

        [HttpGet("GetUserReservations/{id}")]
        public IActionResult GetUserReservations(int id)
        {
            var reservations = _reservationService.GetUserReservations(id);
            if (reservations == null) return NotFound();
            return Ok(reservations);
        }

        [Authorize(Roles = Role.Dispatcher)]
        [HttpGet("GetFlightReservations/{id}")]
        public IActionResult GetFlightReservations(int id)
        {
            var reservations = _reservationService.GetFlightReservations(id);
            if (reservations == null) return NotFound();
            return Ok(reservations);
        }

        [HttpGet("GetTakenSeats/{id}")]
        public IActionResult GetTakenSeats(int id)
        {
            var seats = _reservationService.GetTakenSeats(id);
            return Ok(seats);
        }

        [Authorize(Roles = Role.Dispatcher)]
        [HttpPost("EditReservation")]
        public IActionResult EditReservation([FromBody] Reservation editReservation)
        {
            var result = _reservationService.EditReservation(editReservation.Id, editReservation.IsValid);
            return Ok(result);
        }
    }
}
