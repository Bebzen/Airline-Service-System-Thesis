using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Flights;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Flights
{
    public class GetPilotFlightsRequestHandler : IRequestHandler<GetPilotFlightsRequest, IEnumerable<Flight>>
    {
        private readonly IFlightDataService _flightDataService;

        public GetPilotFlightsRequestHandler(IFlightDataService dataAccessService)
        {
            _flightDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _flightDataService = dataAccessService;
        }
        public async Task<IEnumerable<Flight>> Handle(GetPilotFlightsRequest request, CancellationToken cancellationToken)
        {
            return await _flightDataService.GetPilotFlights(request);
        }
    }
}
