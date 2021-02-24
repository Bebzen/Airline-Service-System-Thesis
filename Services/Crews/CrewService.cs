using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Helpers;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Crews;
using MediatR;
using System.Collections.Generic;

namespace AirlineServiceSoftware.Services.Crews
{
    public class CrewService : ICrewService
    {

        private readonly IMediator _mediator;
        public CrewService(IMediator mediator)
        {
            this._mediator = mediator;
        }
        public IEnumerable<User> GetAllPilots()
        {
            var pilots = _mediator.Send(new GetAllPilotsRequest()).Result;
            pilots = pilots.WithoutPasswords();
            return pilots;            
        }

        public IEnumerable<Crew> GetAllCrews()
        {
            var crews = _mediator.Send(new GetAllCrewsRequest()).Result;
            return crews;
        }

        public bool CreateCrew(Crew newCrew)
        {
            var result = _mediator.Send(new CreateCrewRequest()
            {
                CrewName = newCrew.CrewName,
                Captain = newCrew.Captain,
                FirstOfficer = newCrew.FirstOfficer,
                SecondOfficer = newCrew.SecondOfficer
            }).Result;

            return result;
        }

        public bool DeleteCrew(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool EditCrew(Crew editCrew)
        {
            throw new System.NotImplementedException();
        }
    }
}
