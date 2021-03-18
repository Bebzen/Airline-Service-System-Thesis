using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Reservations
{
    public class EditReservationRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public bool IsValid { get; set; }
    }
}
