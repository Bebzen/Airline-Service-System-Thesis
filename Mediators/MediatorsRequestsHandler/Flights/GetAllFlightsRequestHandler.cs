using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Flights;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Flights
{
    public class GetAllFlightsRequestHandler : IRequestHandler<GetAllFlightsRequest, IEnumerable<Flight>>
    {
        private readonly IFlightDataService _flightDataService;
        public GetAllFlightsRequestHandler(IFlightDataService dataAccessService)
        {
            _flightDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _flightDataService = dataAccessService;
        }

        public async Task<IEnumerable<Flight>> Handle(GetAllFlightsRequest request, CancellationToken cancellationToken)
        {
            return await _flightDataService.GetAllFlights(request);
        }
    }
}
