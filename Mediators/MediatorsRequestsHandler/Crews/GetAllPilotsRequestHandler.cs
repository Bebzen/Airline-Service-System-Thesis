using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Crews;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Crews
{
    public class GetAllPilotsRequestHandler : IRequestHandler<GetAllPilotsRequest, IEnumerable<User>>
    {
        private readonly ICrewDataService _crewDataService;

        public GetAllPilotsRequestHandler(ICrewDataService dataAccessService)
        {
            _crewDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _crewDataService = dataAccessService;
        }
        public Task<IEnumerable<User>> Handle(GetAllPilotsRequest request, CancellationToken cancellationToken)
        {
            return _crewDataService.GetAllPilots(request);
        }
    }
}
