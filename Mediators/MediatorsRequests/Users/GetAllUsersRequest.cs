using MediatR;
using System.Collections.Generic;
using AirlineServiceSoftware.Entities;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Users
{
    public class GetAllUsersRequest : IRequest<IEnumerable<User>>
    {
    }
}
