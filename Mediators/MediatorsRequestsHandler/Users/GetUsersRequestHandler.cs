using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Users;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Users
{
    public class GetUsersRequestHandler : IRequestHandler<GetAllUsersRequest, IEnumerable<User>>
    {
        private readonly IUserDataService _userDataService;

        public GetUsersRequestHandler(IUserDataService dataAccessService)
        {
            _userDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _userDataService = dataAccessService;
        }

        public Task<IEnumerable<User>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            return _userDataService.GetAllUsers(request);
        }
    }
}
