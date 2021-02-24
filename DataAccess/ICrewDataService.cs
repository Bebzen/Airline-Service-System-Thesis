using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Crews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineServiceSoftware.DataAccess
{
    public interface ICrewDataService
    {
        Task<IEnumerable<User>> GetAllPilots(GetAllPilotsRequest request);
        Task<IEnumerable<Crew>> GetAllCrews(GetAllCrewsRequest request);
        Task<bool> CreateCrew(CreateCrewRequest request);
        Task<bool> EditCrew(EditCrewRequest request);
        Task<bool> DeleteCrew(DeleteCrewRequest request);
    }
}
