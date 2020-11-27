using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Users;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Users
{
    public class CreateUserRequestHandler: IRequestHandler<CreateUserRequest, Boolean>
    {
        private readonly IUserDataService _userDataService;

        public CreateUserRequestHandler(IUserDataService dataAccessService)
        {
            _userDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _userDataService = dataAccessService;
        }

        public Task<Boolean> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            return _userDataService.CreateUser(request);
        }
    }
}
