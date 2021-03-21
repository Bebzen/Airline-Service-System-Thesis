using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Helpers;
using AirlineServiceSoftware.Models;
using AirlineServiceSoftware.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineServiceSoftware.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Username or Password is incorrect" });
            }
            return Ok(user);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("GetUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("GetUsers/{id?}")]
        public IActionResult GetUserById(int id)
        {
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
            {
                return Forbid();
            }

            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] User UserData)
        {
            var dataValidationResult = UserData.Password.IsValidPassword(); if (dataValidationResult == false) return BadRequest(new { message = "Invalid Password." });
            if (UserData.Pesel != null) dataValidationResult = UserData.Pesel.IsValidPESEL(); if (dataValidationResult == false) return BadRequest(new { message = "Invalid PESEL." });
            if (UserData.DocumentId != null) dataValidationResult = UserData.DocumentId.IsValidID(); if (dataValidationResult == false) return BadRequest(new { message = "Invalid ID." });
            var result = _userService.CreateUser(UserData);
            if (!result)
            {
                return BadRequest(new { message = "User was not added." });
            }

            return Ok(result);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("EditUser")]
        public IActionResult EditUser([FromBody] User UserData)
        {
            var dataValidationResult = true;
            if (UserData.Password != null) dataValidationResult = UserData.Password.IsValidPassword(); if (dataValidationResult == false) return BadRequest(new { message = "Invalid data." });
            if (UserData.Pesel != null) dataValidationResult = UserData.Pesel.IsValidPESEL(); if (dataValidationResult == false) return BadRequest(new { message = "Invalid data." });
            if (UserData.DocumentId != null) dataValidationResult = UserData.DocumentId.IsValidID(); if (dataValidationResult == false) return BadRequest(new { message = "Invalid data." });
            var result = _userService.EditUser(UserData);
            if (!result)
            {
                return BadRequest(new { message = "User was not modified." });
            }
            return Ok(result);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("DeleteUser/{Id}")]
        public IActionResult DeleteUser(int Id)
        {
            var result = _userService.DeleteUser(Id);
            if (!result)
            {
                return BadRequest(new { message = "User was not deleted." });
            }
            return Ok(result);
        }
    }
}
