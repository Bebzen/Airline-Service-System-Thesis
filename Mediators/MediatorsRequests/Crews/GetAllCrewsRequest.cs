using AirlineServiceSoftware.Entities;
using MediatR;
using System.Collections.Generic;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Crews
{
    public class GetAllCrewsRequest : IRequest<IEnumerable<Crew>>
    {
    }
}
