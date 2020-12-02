using System;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Users;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Users
{
    public class CreateUserRequestHandler: IRequestHandler<CreateUserRequest, bool>
    {
        private readonly IUserDataService _userDataService;

        public CreateUserRequestHandler(IUserDataService dataAccessService)
        {
            _userDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _userDataService = dataAccessService;
        }

        public async Task<bool> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            if (request.Password != null)
            {
                request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            }
            return await _userDataService.CreateUser(request);
        }
    }
}
