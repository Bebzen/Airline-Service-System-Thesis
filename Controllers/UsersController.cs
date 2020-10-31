using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
            {
                return Forbid();
            }

            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
