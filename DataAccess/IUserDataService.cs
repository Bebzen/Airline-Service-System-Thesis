using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Unicode;
using System.Threading.Tasks;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Users;
using MediatR;

namespace AirlineServiceSoftware.DataAccess
{
    public interface IUserDataService
    {
        Task<IEnumerable<User>> GetUserByUsername(GetUserByUsernameRequest request);
        Task<IEnumerable<User>> GetUserById(GetUserByIdRequest request);
        Task<IEnumerable<User>> GetAllUsers(GetUsersRequest request);
        Task<bool> CreateUser(CreateUserRequest request);
        Task<bool> EditUser(EditUserRequest request);
        Task<bool> DeleteUser(DeleteUserRequest request);
    }
}
