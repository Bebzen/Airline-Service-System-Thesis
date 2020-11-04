using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Users;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Users
{
    public class GetUserByIdRequestHandler: IRequestHandler<GetUserByIdRequest, IEnumerable<User>>
    {
        private readonly IUserDataService _userDataService;

        public GetUserByIdRequestHandler(IUserDataService dataAccessService)
        {
            _userDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _userDataService = dataAccessService;
        }

        public Task<IEnumerable<User>> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            return _userDataService.GetUserById(request);
        }
    }
}
