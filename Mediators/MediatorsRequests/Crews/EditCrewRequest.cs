using AirlineServiceSoftware.Entities;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Crews
{
    public class EditCrewRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public string CrewName { get; set; }
        public User Captain { get; set; }
        public User FirstOfficer { get; set; }
        public User SecondOfficer { get; set; }
    }
}
