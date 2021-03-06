﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Flights;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Flights
{
    public class GetFlightByIdRequestHandler : IRequestHandler<GetFlightByIdRequest, Flight>
    {
        private readonly IFlightDataService _flightDataService;
        public GetFlightByIdRequestHandler(IFlightDataService dataAccessService)
        {
            _flightDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _flightDataService = dataAccessService;
        }
        public async Task<Flight> Handle(GetFlightByIdRequest request, CancellationToken cancellationToken)
        {
            return await _flightDataService.GetFlightById(request);
        }
    }
}
