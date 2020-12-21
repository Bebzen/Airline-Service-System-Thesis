using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Helpers;
using AirlineServiceSoftware.Mediators.MediatorsRequests;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Users;
using BCrypt.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AirlineServiceSoftware.Services.Login
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        private readonly AppSettings _appSettings;
        private readonly IUserDataService _userDataService;
        public UserService(IOptions<AppSettings> appSettings, IMediator mediator, IUserDataService userDataService)
        {
            _mediator = mediator;
            _appSettings = appSettings.Value;
            _userDataService = userDataService;
        }
        public User Authenticate(string username, string password)
        {
            // use this to generate passwords for future user testing
            var generatePassword = BCrypt.Net.BCrypt.HashPassword(password);
            //
            var users = _mediator.Send(new GetUserByUsernameRequest() {Username = username}).Result;
            var user = users.SingleOrDefault();
            if (user == null)
            {
                return null;
            }
            var isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (!isValid)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

        public IEnumerable<User> GetUsers()
        {
            var users = _mediator.Send(new GetUsersRequest()).Result;
            users = users.WithoutPasswords();
            return users;
        }

        public User GetUserById(int id)
        {
            var users = _mediator.Send(new GetUserByIdRequest() {Id = id}).Result;
            var user = users.FirstOrDefault();
            return user.WithoutPassword();
        }

        public bool CreateUser(User newUser)
        {
            bool result;
            try
            {
                result = _mediator.Send(new CreateUserRequest()
                {
                    Username = newUser.Username,
                    Password = newUser.Password,
                    Role = newUser.Role,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    PhoneNumber = newUser.PhoneNumber,
                    Email = newUser.Email,
                    Pesel = newUser.Pesel,
                    DocumentID = newUser.DocumentId
                }).Result;
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool EditUser(User editUser)
        {
            if (editUser.Password == null)
            {
                editUser.Password = "noChange";
            }
            bool result;
            try
            {
                result = _mediator.Send(new EditUserRequest()
                {
                    Id = editUser.Id,
                    Username = editUser.Username,
                    Password = editUser.Password,
                    Role = editUser.Role,
                    FirstName = editUser.FirstName,
                    LastName = editUser.LastName,
                    PhoneNumber = editUser.PhoneNumber,
                    Email = editUser.Email,
                    Pesel = editUser.Pesel,
                    DocumentID = editUser.DocumentId
                }).Result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool DeleteUser(int id)
        {
            bool result;
            try
            {
                result = _mediator.Send(new DeleteUserRequest()
                {
                    Id = id
                }).Result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
