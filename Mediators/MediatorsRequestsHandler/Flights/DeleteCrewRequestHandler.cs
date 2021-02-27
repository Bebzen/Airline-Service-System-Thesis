using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Flights;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Flights
{
    public class DeleteCrewRequestHandler : IRequestHandler<DeleteFlightRequest, bool>
    {
        private readonly IFlightDataService _flightDataService;
        public DeleteCrewRequestHandler(IFlightDataService dataAccessService)
        {
            _flightDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _flightDataService = dataAccessService;
        }

        public async Task<bool> Handle(DeleteFlightRequest request, CancellationToken cancellationToken)
        {
            return await _flightDataService.DeleteFlight(request);
        }
    }
}
