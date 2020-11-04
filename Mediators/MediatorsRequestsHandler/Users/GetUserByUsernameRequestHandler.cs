using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler
{
    public class GetUserByUsernameRequestHandler : IRequestHandler<GetUserByUsernameRequest, IEnumerable<User>>
    {
        private readonly IUserDataService _userDataService;

        public GetUserByUsernameRequestHandler(IUserDataService dataAccessService)
        {
            _userDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _userDataService = dataAccessService;
        }

        public Task<IEnumerable<User>> Handle(GetUserByUsernameRequest request, CancellationToken cancellationToken)
        {
            return _userDataService.GetUserByUsername(request);
        }
    }
}
