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
            var result = _mediator.Send(new DeleteCrewRequest()
            {
                Id = Id
            }).Result;

            return result;
        }

        public bool EditCrew(Crew editCrew)
        {
            var result = _mediator.Send(new EditCrewRequest()
            {
                Id = editCrew.Id,
                CrewName = editCrew.CrewName,
                Captain = editCrew.Captain,
                FirstOfficer = editCrew.FirstOfficer,
                SecondOfficer = editCrew.SecondOfficer
            }).Result;

            return result;
        }
    }
}
