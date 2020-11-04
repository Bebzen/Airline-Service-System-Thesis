using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineServiceSoftware.Entities;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Users
{
    public class GetUserByIdRequest: IRequest<IEnumerable<User>>
    {
        public int Id { get; set; }
    }
}
