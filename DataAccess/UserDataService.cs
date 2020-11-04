using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Users;
using Dapper;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace AirlineServiceSoftware.DataAccess
{
    public class UserDataService :IUserDataService
    {
        private readonly string _connectionString;

        public UserDataService(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("message", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public async Task<IEnumerable<User>> GetUserByUsername(GetUserByUsernameRequest request)
        {
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@username", request.Username);

                return conn.Query<User>("GetUserByUsername", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<User>> GetUserById(GetUserByIdRequest request)
        {
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Id", request.Id);

                return conn.Query<User>("GetUserById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<User>> GetUsers(GetUsersRequest request)
        {
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                return conn.Query<User>("GetAllUsers", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
