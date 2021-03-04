using System;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Flights;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Flights
{
    public class EditFlightStatusRequestHandler : IRequestHandler<EditFlightStatusRequest, bool>
    {
        private readonly IFlightDataService _flightDataService;
        public EditFlightStatusRequestHandler(IFlightDataService dataAccessService)
        {
            _flightDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _flightDataService = dataAccessService;
        }

        public async Task<bool> Handle(EditFlightStatusRequest request, CancellationToken cancellationToken)
        {
            return await _flightDataService.EditFlightStatus(request);
        }
    }
}
