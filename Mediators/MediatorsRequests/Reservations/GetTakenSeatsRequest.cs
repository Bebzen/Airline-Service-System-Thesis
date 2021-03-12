using System.Collections.Generic;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Reservations
{
    public class GetTakenSeatsRequest : IRequest<IEnumerable<string>>
    {
        public int Id { get; set; }
    }
}
