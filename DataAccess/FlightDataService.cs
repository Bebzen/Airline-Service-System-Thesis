using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Flights;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineServiceSoftware.DataAccess
{
    public class FlightDataService : IFlightDataService
    {
        private readonly string _connectionString;
        public FlightDataService(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("message", nameof(connectionString));
            }

            _connectionString = connectionString;
        }
        public async Task<bool> CreateFlight(CreateFlightRequest request)
        {
            try
            {
                await using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@CrewId", request.Crew.Id);
                    parameters.Add("@FlightNumber", request.FlightNumber);
                    parameters.Add("@StartingAirportName", request.StartingAirportName);
                    parameters.Add("@DestinationAirportName", request.DestinationAirportName);
                    parameters.Add("@FlightDate", request.FlightDate);
                    parameters.Add("@TakeoffHour", request.TakeoffHour);
                    parameters.Add("@LandingHour", request.LandingHour);
                    parameters.Add("@PlaneType", request.PlaneType);
                    parameters.Add("@TotalSeats", request.TotalSeats);
                    parameters.Add("@RemainingSeats", request.TotalSeats);
                    parameters.Add("@IsApproved", request.IsApproved);
                    parameters.Add("@IsCompleted", request.IsCompleted);

                    conn.Query<bool>("CreateFlight", parameters, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> DeleteFlight(DeleteFlightRequest request)
        {
            try
            {
                await using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", request.Id);
                    var result = conn.Query("DeleteFlight", parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> EditFlight(EditFlightRequest request)
        {
            try
            {
                await using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", request.Id);
                    parameters.Add("@CrewId", request.Crew.Id);
                    parameters.Add("@FlightNumber", request.FlightNumber);
                    parameters.Add("@StartingAirportName", request.StartingAirportName);
                    parameters.Add("@DestinationAirportName", request.DestinationAirportName);
                    parameters.Add("@FlightDate", request.FlightDate);
                    parameters.Add("@TakeoffHour", request.TakeoffHour);
                    parameters.Add("@LandingHour", request.LandingHour);
                    parameters.Add("@PlaneType", request.PlaneType);
                    parameters.Add("@TotalSeats", request.TotalSeats);
                    parameters.Add("@RemainingSeats", request.TotalSeats);
                    parameters.Add("@IsApproved", request.IsApproved);
                    parameters.Add("@IsCompleted", request.IsCompleted);

                    conn.Query("EditFlight", parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<IEnumerable<Flight>> GetAllFlights(GetAllFlightsRequest request)
        {
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                
                var result = conn.Query<FlightResponse>("GetAllFlights", commandType: CommandType.StoredProcedure);
                List<Flight> list = new List<Flight>();

                foreach (var flight in result)
                {

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", flight.CrewId);
                    var crews = conn.Query<CrewResponse>("GetCrewById", parameters, commandType: CommandType.StoredProcedure);
                    Crew newCrew = new Crew();
                    var crew = crews.FirstOrDefault();
                    newCrew.Id = crew.Id;
                    newCrew.CrewName = crew.CrewName;
                    parameters = new DynamicParameters();
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

                    var newFlight = new Flight
                    {
                        Id = flight.Id,
                        Crew = newCrew,
                        FlightNumber = flight.FlightNumber,
                        StartingAirportName = flight.StartingAirportName,
                        DestinationAirportName = flight.DestinationAirportName,
                        FlightDate = flight.FlightDate,
                        TakeoffHour = flight.TakeoffHour,
                        LandingHour = flight.LandingHour,
                        PlaneType = flight.PlaneType,
                        TotalSeats = flight.TotalSeats,
                        RemainingSeats = flight.RemainingSeats,
                        IsApproved = flight.IsApproved,
                        IsCompleted = flight.IsCompleted
                    };
                    newFlight.TakeoffHour = newFlight.TakeoffHour.Substring(0, 5);
                    newFlight.LandingHour = newFlight.LandingHour.Substring(0, 5);
                    list.Add(newFlight);
                }

                IEnumerable<Flight> flights = list;
                return flights;
            }
        }

        public async Task<IEnumerable<Flight>> GetPilotFlights(GetPilotFlightsRequest request)
        {
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Id", request.Id);

                var result = conn.Query<Flight>("GetFlightsByPilotId", parameters, commandType: CommandType.StoredProcedure);
                foreach (var flight in result)
                {
                    flight.LandingHour = flight.LandingHour.Substring(0, 5);
                    flight.TakeoffHour = flight.TakeoffHour.Substring(0, 5);
                }

                return result;
            }
        }

        public async Task<bool> EditFlightStatus(EditFlightStatusRequest request)
        {
            try
            {
                await using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", request.Id);
                    parameters.Add("@DestinationAirportName", request.DestinationAirportName);
                    parameters.Add("@TakeoffHour", request.TakeoffHour);
                    parameters.Add("@LandingHour", request.LandingHour);
                    parameters.Add("@IsCompleted", request.IsCompleted);

                    conn.Query("EditFlightStatus", parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<IEnumerable<Flight>> SearchFlights(SearchFlightsRequest request)
        {
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@OriginAirport", request.OriginAirport);
                parameters.Add("@DestinationAirport", request.DestinationAirport);
                parameters.Add("@DepartureDate", request.DepartureDate);

                var result = conn.Query<Flight>("SearchFlights", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<Flight> GetFlight(GetFlightRequest request)
        {
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", request.Id);

                var result = conn.Query<Flight>("GetFlight", parameters, commandType: CommandType.StoredProcedure);
                return result.SingleOrDefault();
            }
        }
    }
}
