using System.Collections.Generic;
using AirlineServiceSoftware.Entities;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Reservations
{
    public class GetUserReservationsRequest : IRequest<IEnumerable<Reservation>>
    {
        public int Id { get; set; }
    }
}
