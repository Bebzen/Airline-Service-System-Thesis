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
    public class SearchFlightsRequestHandler : IRequestHandler<SearchFlightsRequest, IEnumerable<Flight>>
    {
        private readonly IFlightDataService _flightDataService;

        public SearchFlightsRequestHandler(IFlightDataService dataAccessService)
        {
            _flightDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _flightDataService = dataAccessService;
        }
        public async Task<IEnumerable<Flight>> Handle(SearchFlightsRequest request, CancellationToken cancellationToken)
        {
            return await _flightDataService.SearchFlights(request);
        }
    }
}
