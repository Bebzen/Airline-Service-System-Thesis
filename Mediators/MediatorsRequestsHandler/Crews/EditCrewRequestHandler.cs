using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Crews;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Crews
{
    public class EditCrewRequestHandler : IRequestHandler<EditCrewRequest, bool>
    {
        private readonly ICrewDataService _crewDataService;
        public EditCrewRequestHandler(ICrewDataService dataAccessService)
        {
            _crewDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _crewDataService = dataAccessService;
        }

        public Task<bool> Handle(EditCrewRequest request, CancellationToken cancellationToken)
        {
            return _crewDataService.EditCrew(request);
        }
    }
}
