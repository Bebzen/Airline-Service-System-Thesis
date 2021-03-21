using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Services.Crews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineServiceSoftware.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CrewsController : ControllerBase
    {
        private readonly ICrewService _crewService;

        public CrewsController(ICrewService crewService)
        {
            _crewService = crewService;
        }

        [Authorize(Roles = Role.Dispatcher)]
        [HttpGet("GetAllPilots")]
        public IActionResult GetAllPilots()
        {
            var pilots = _crewService.GetAllPilots();
            if (pilots == null) return NotFound();
            return Ok(pilots);
        }

        [Authorize(Roles = Role.Dispatcher)]
        [HttpGet("GetAllCrews")]
        public IActionResult GetAllCrews()
        {
            var crews = _crewService.GetAllCrews();
            if (crews == null) return NotFound();
            return Ok(crews);
        }

        [Authorize(Roles = Role.Dispatcher)]
        [HttpPost("CreateCrew")]
        public IActionResult CreateCrew([FromBody] Crew crewData)
        {
            if ((crewData.Captain.Id == crewData.FirstOfficer.Id) ||
                (crewData.Captain.Id == crewData.SecondOfficer.Id) ||
                (crewData.FirstOfficer.Id == crewData.SecondOfficer.Id))
            {
                return BadRequest(new { message = "Crew was not modified." });
            }
            var result = _crewService.CreateCrew(crewData);
            if (!result)
            {
                return BadRequest(new { message = "Crew was not modified." });
            }
            return Ok(result);

        }

        [Authorize(Roles = Role.Dispatcher)]
        [HttpPost("EditCrew")]
        public IActionResult EditCrew([FromBody] Crew crewData)
        {
            var result = _crewService.EditCrew(crewData);
            if (!result)
            {
                return BadRequest(new { message = "Crew was not modified." });
            }
            return Ok(result);
        }

        [Authorize(Roles = Role.Dispatcher)]
        [HttpDelete("DeleteCrew/{Id}")]
        public IActionResult DeleteCrew(int Id)
        {
            var result = _crewService.DeleteCrew(Id);
            if (!result)
            {
                return BadRequest(new { message = "Crew was not deleted." });
            }
            return Ok(result);

        }  
    }
}
