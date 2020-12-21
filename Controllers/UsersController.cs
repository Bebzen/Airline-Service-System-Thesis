using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Models;
using AirlineServiceSoftware.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineServiceSoftware.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

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
                return BadRequest(new {message = "Username or Password is incorrect"});
            }
            return Ok(user);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("GetUsers/{id?}")]
        public IActionResult GetById(int id)
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
            var passwordValidation = Regex.Matches(UserData.Password, @"^(?=.*[a - z])(?=.*[A - Z])(?=.*[0 - 9])(?=.*[$@$!%? &])[A - Za - z\d$@$!%? &]{ 8,}$").Count;
            if (passwordValidation == 0)
            {
                var result = _userService.CreateUser(UserData);
                if (!result)
                {
                    return BadRequest(new { message = "User was not added." });
                }
                return Ok(result);
            }
            else return BadRequest(new { message = "Invalid password."});
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("EditUser")]
        public IActionResult EditUser([FromBody] User UserData)
        {
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
                return BadRequest(new { message = "User was not deleted."});
            }
            return Ok(result);
        }
    }
}
