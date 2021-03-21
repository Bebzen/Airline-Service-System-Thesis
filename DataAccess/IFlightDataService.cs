using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Flights;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineServiceSoftware.DataAccess
{
    public interface IFlightDataService
    {
        Task<IEnumerable<Flight>> GetAllFlights(GetAllFlightsRequest request);
        Task<bool> CreateFlight(CreateFlightRequest request);
        Task<bool> EditFlight(EditFlightRequest request);
        Task<bool> DeleteFlight(DeleteFlightRequest request);
        Task<IEnumerable<Flight>> GetPilotFlights(GetPilotFlightsRequest request);
        Task<bool> EditFlightStatus(EditFlightStatusRequest request);
        Task<IEnumerable<Flight>> SearchFlights(SearchFlightsRequest request);
        Task<Flight> GetFlightById(GetFlightByIdRequest request);
    }
}
