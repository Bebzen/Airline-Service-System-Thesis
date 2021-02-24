using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Crews;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineServiceSoftware.DataAccess
{
    public class CrewDataService : ICrewDataService
    {
        private readonly string _connectionString;

        public CrewDataService(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("message", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public async Task<bool> CreateCrew(CreateCrewRequest request)
        {
            try
            {
                await using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@CrewName", request.CrewName);
                    parameters.Add("@CaptainID", request.Captain.Id);
                    parameters.Add("@FirstOfficerID", request.FirstOfficer.Id);
                    parameters.Add("@SecondOfficerID", request.SecondOfficer.Id);

                    conn.Query<bool>("CreateCrew", parameters, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            } 
        }

        public async Task<bool> DeleteCrew(DeleteCrewRequest request)
        {
            try
            {
                await using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", request.Id);
                    var result = conn.Query("DeleteCrew", parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> EditCrew(EditCrewRequest request)
        {
            try
            {
                await using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", request.Id);
                    parameters.Add("@CrewName", request.CrewName);
                    parameters.Add("@CaptainID", request.Captain.Id);
                    parameters.Add("@FirstOfficerID", request.FirstOfficer.Id);
                    parameters.Add("@SecondOfficerID", request.SecondOfficer.Id);
                    var result = conn.Query("EditCrew", parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<IEnumerable<Crew>> GetAllCrews(GetAllCrewsRequest request)
        {
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var result = conn.Query<CrewResponse>("GetAllCrews", commandType: CommandType.StoredProcedure);
                List<Crew> list = new List<Crew>();

                foreach(var crew in result)
                {
                    Crew newCrew = new Crew();
                    newCrew.Id = crew.Id;
                    newCrew.CrewName = crew.CrewName;
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", crew.CaptainID);
                    var pilot = conn.Query<User>("GetUserById", parameters, commandType: CommandType.StoredProcedure);
                    newCrew.Captain = pilot.FirstOrDefault();
                    newCrew.Captain.Password = "";
                    parameters = new DynamicParameters();
                    parameters.Add("@Id", crew.FirstOfficerID);
                    var pilot2 = conn.Query<User>("GetUserById", parameters, commandType: CommandType.StoredProcedure);
                    newCrew.FirstOfficer = pilot2.FirstOrDefault();
                    newCrew.FirstOfficer.Password = "";
                    parameters = new DynamicParameters();
                    parameters.Add("@Id", crew.SecondOfficerID);
                    var pilot3 = conn.Query<User>("GetUserById", parameters, commandType: CommandType.StoredProcedure);
                    newCrew.SecondOfficer = pilot3.FirstOrDefault();
                    newCrew.SecondOfficer.Password = "";
                    list.Add(newCrew);
                }

                IEnumerable<Crew> crews = list;

                return crews;
            }
        }

        public async Task<IEnumerable<User>> GetAllPilots(GetAllPilotsRequest request)
        {
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<User>("GetAllPilots", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
