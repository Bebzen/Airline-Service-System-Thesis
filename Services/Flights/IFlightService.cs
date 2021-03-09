using AirlineServiceSoftware.Entities;
using System.Collections.Generic;

namespace AirlineServiceSoftware.Services.Flights
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetAllFlights();
        bool DeleteFlight(int Id);
        bool EditFlight(Flight editFlight);
        bool CreateFlight(Flight newFlight);
        IEnumerable<Flight> GetPilotFlights(int Id);
        bool EditFlightStatus(Flight editFlight);
        IEnumerable<Flight> SearchFlights(SearchParameters searchParameters);
    }
}
