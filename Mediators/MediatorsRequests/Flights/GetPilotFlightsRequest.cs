using System.Collections.Generic;
using AirlineServiceSoftware.Entities;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Flights
{
    public class GetPilotFlightsRequest : IRequest<IEnumerable<Flight>>
    {
        public int Id { get; set; }
    }
}
