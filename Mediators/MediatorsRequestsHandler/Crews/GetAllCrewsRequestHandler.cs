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
    public class GetAllCrewsRequestHandler : IRequestHandler<GetAllCrewsRequest, IEnumerable<Crew>>
    {
        private readonly ICrewDataService _crewDataService;
        public GetAllCrewsRequestHandler(ICrewDataService dataAccessService)
        {
            _crewDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _crewDataService = dataAccessService;
        }
        public Task<IEnumerable<Crew>> Handle(GetAllCrewsRequest request, CancellationToken cancellationToken)
        {
            return _crewDataService.GetAllCrews(request);
        }
    }
}
