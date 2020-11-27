using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineServiceSoftware.Entities;

namespace AirlineServiceSoftware.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        Boolean CreateUser(User newUser);
        Boolean EditUser(User editUser);
        bool DeleteUser(int id);
    }
}
