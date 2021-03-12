using AirlineServiceSoftware.Entities;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Flights
{
    public class GetFlightRequest : IRequest<Flight>
    {
        public int Id { get; set; }
    }
}
