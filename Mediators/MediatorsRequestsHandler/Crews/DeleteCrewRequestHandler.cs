using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Crews;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Crews
{
    public class DeleteCrewRequestHandler : IRequestHandler<DeleteCrewRequest, bool>
    {
        private readonly ICrewDataService _crewDataService;
        public DeleteCrewRequestHandler(ICrewDataService dataAccessService)
        {
            _crewDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _crewDataService = dataAccessService;

        }

        public Task<bool> Handle(DeleteCrewRequest request, CancellationToken cancellationToken)
        {
            return _crewDataService.DeleteCrew(request);
        }
    }
}
