using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Flights
{
    public class DeleteFlightRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
