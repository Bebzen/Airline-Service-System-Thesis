using AirlineServiceSoftware.Entities;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Crews
{
    public class CreateCrewRequest : IRequest<bool>
    {
        public string CrewName { get; set; }
        public User Captain { get; set; }
        public User FirstOfficer { get; set; }
        public User SecondOfficer { get; set; }
    }
}
