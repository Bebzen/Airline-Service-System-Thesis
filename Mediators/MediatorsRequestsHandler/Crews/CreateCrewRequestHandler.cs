using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Crews;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Crews
{
    public class CreateCrewRequestHandler : IRequestHandler<CreateCrewRequest, bool>
    {
        private readonly ICrewDataService _crewDataService;

        public CreateCrewRequestHandler(ICrewDataService dataAccessService)
        {
            _crewDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _crewDataService = dataAccessService;
        }
        public async Task<bool> Handle(CreateCrewRequest request, CancellationToken cancellationToken)
        {
            return await _crewDataService.CreateCrew(request);
        }
    }
}
