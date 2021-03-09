using System;
using System.Collections.Generic;
using AirlineServiceSoftware.Entities;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Flights
{
    public class SearchFlightsRequest : IRequest<IEnumerable<Flight>>
    {
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
