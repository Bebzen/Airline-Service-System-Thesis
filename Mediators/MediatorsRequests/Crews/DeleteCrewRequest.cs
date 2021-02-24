using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Crews
{
    public class DeleteCrewRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
