using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Users
{
    public class DeleteUserRequest : IRequest<Boolean>
    {
        public int Id { get; set; }
    }
}
