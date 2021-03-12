using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Helpers;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Reservations;
using Dapper;

namespace AirlineServiceSoftware.DataAccess
{
    public class ReservationDataService : IReservationDataService
    {
        private readonly string _connectionString;

        public ReservationDataService(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("message", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public async Task<bool> CreateReservation(CreateReservationRequest request)
        {
            try
            {
                await using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@FlightId", request.FlightId);
                    parameters.Add("@UserId", request.UserId);
                    parameters.Add("@Price", request.Price);
                    parameters.Add("@SeatNumber", request.SeatNumber);
                    parameters.Add("@TransactionId", request.TransactionId);
                    parameters.Add("@IsValid", request.IsValid);

                    conn.Query<bool>("CreateReservation", parameters, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<IEnumerable<ReservationUserResponse>> GetFlightReservations(GetFlightReservationsRequest request)
        {
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                
                var parameters = new DynamicParameters();
                parameters.Add("@Id", request.Id);

                var results = conn.Query<ReservationResponse>("GetFlightReservations", parameters, commandType: CommandType.StoredProcedure);
                List<ReservationUserResponse> list = new List<ReservationUserResponse>();
                foreach (var result in results)
                {
                    User newUser = new User();
                    var newParameters = new DynamicParameters();
                    newParameters.Add("@Id", result.UserId);
                    newUser = conn.Query<User>("GetUserById", newParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    var newReservation = new ReservationUserResponse()
                    {
                        Id = result.Id,
                        FlightId = result.FlightId,
                        IsValid = result.IsValid,
                        Price = result.Price,
                        SeatNumber = result.SeatNumber,
                        TransactionId = result.TransactionId,
                        User = newUser.WithoutPassword()
                    };
                    list.Add(newReservation);
                    //Flight newFlight = new Flight();
                    //var newParameters = new DynamicParameters();
                    //newParameters.Add("@Id", result.FlightId);
                    //newFlight = conn.Query<Flight>("GetFlight", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    //var newReservation = new Reservation
                    //{
                    //    Id = result.Id,
                    //    Flight = newFlight,
                    //    IsValid = result.IsValid,
                    //    Price = result.Price,
                    //    SeatNumber = result.SeatNumber,
                    //    TransactionId = result.TransactionId,
                    //    UserId = result.UserId
                    //};

                    //list.Add(newReservation);
                }

                IEnumerable<ReservationUserResponse> reservations = list;
                return reservations;
            }
        }

        public async Task<IEnumerable<Reservation>> GetUserReservations(GetUserReservationsRequest request)
        {
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", request.Id);

                var results = conn.Query<ReservationResponse>("GetUserReservations", parameters, commandType: CommandType.StoredProcedure);
                List <Reservation>list = new List<Reservation>();
                
                foreach (var result in results)
                {
                    Flight newFlight = new Flight();
                    var newParameters = new DynamicParameters();
                    newParameters.Add("@Id", result.FlightId);
                    newFlight = conn.Query<Flight>("GetFlight", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    var newReservation = new Reservation
                    {
                        Id = result.Id,
                        Flight = newFlight,
                        IsValid = result.IsValid,
                        Price = result.Price,
                        SeatNumber = result.SeatNumber,
                        TransactionId = result.TransactionId,
                        UserId = result.UserId
                    };

                    list.Add(newReservation);
                }

                IEnumerable<Reservation> reservations = list;
                return reservations;
            }
        }

        public async Task<IEnumerable<string>> GetTakenSeats(GetTakenSeatsRequest request)
        {
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", request.Id);

                var results = conn.Query<string>("GetTakenSeats", parameters, commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        public async Task<bool> EditReservation()
        {
            try
            {
                await using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    //dodaj ID i isValid

                    var result = conn.Query<bool>("EditReservation", parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
