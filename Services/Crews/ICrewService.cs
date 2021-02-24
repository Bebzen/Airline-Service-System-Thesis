using AirlineServiceSoftware.Entities;
using System.Collections.Generic;

namespace AirlineServiceSoftware.Services.Crews
{
    public interface ICrewService
    {
        IEnumerable<User> GetAllPilots();
        IEnumerable<Crew> GetAllCrews();
        bool DeleteCrew(int Id);
        bool EditCrew(Crew editCrew);
        bool CreateCrew(Crew newCrew);
    }
}
