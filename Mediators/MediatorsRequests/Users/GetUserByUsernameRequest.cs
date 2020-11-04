using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineServiceSoftware.Entities;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests
{
    public class GetUserByUsernameRequest : IRequest<IEnumerable<User>>
    {
        public string Username { get; set; }
    }
}
