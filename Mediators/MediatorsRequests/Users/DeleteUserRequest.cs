using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Users
{
    public class DeleteUserRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
