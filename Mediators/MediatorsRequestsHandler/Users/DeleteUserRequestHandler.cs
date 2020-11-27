using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Users;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Users
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, Boolean>
    {
        private readonly IUserDataService _userDataService;

        public DeleteUserRequestHandler(IUserDataService dataAccessService)
        {
            _userDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _userDataService = dataAccessService;
        }

        public Task<Boolean> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            return _userDataService.DeleteUser(request);
        }
    }
}
