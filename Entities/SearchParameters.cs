using System;

namespace AirlineServiceSoftware.Entities
{
    public class SearchParameters
    {
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
