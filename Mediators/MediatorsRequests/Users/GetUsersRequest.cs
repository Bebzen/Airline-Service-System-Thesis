using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineServiceSoftware.Entities;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Users
{
    public class GetUsersRequest : IRequest<IEnumerable<User>>
    {
    }
}
