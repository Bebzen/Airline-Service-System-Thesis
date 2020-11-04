using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Users;

namespace AirlineServiceSoftware.DataAccess
{
    public interface IUserDataService
    {
        Task<IEnumerable<User>> GetUserByUsername(GetUserByUsernameRequest request);
        Task<IEnumerable<User>> GetUserById(GetUserByIdRequest request);
        Task<IEnumerable<User>> GetUsers(GetUsersRequest request);
    }
}
