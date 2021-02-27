using AirlineServiceSoftware.Entities;
using MediatR;
using System.Collections.Generic;


namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Flights
{
    public class GetAllFlightsRequest : IRequest<IEnumerable<Flight>>
    {
    }
}
