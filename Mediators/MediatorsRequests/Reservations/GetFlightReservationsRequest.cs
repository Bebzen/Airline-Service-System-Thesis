using System.Collections.Generic;
using AirlineServiceSoftware.Entities;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Reservations
{
    public class GetFlightReservationsRequest : IRequest<IEnumerable<ReservationUserResponse>>
    {
        public int Id { get; set; }
    }
}
