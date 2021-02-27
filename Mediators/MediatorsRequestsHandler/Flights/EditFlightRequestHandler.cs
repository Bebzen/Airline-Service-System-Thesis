using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Flights;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Flights
{
    public class EditFlightRequestHandler : IRequestHandler<EditFlightRequest, bool>
    {
        private readonly IFlightDataService _flightDataService;
        public EditFlightRequestHandler(IFlightDataService dataAccessService)
        {
            _flightDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _flightDataService = dataAccessService;
        }

        public async Task<bool> Handle(EditFlightRequest request, CancellationToken cancellationToken)
        {
            return await _flightDataService.EditFlight(request);
        }
    }
}
