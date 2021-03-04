using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Flights
{
    public class EditFlightStatusRequest :IRequest<bool>
    {
        public int Id { get; set; }
        public string DestinationAirportName { get; set; }
        public string TakeoffHour { get; set; }
        public string LandingHour { get; set; }
        public bool IsCompleted { get; set; }
    }
}
