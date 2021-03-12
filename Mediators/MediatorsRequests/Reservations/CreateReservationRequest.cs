using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Reservations
{
    public class CreateReservationRequest : IRequest<bool>
    {
        public int FlightId { get; set; }
        public int UserId { get; set; }
        public float Price { get; set; }
        public string SeatNumber { get; set; }
        public string TransactionId { get; set; }
        public bool IsValid { get; set; }
    }
}
