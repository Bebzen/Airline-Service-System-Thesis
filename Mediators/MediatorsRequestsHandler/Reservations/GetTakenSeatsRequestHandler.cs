using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Reservations;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Reservations
{
    public class GetTakenSeatsRequestHandler : IRequestHandler<GetTakenSeatsRequest, IEnumerable<string>>
    {
        private readonly IReservationDataService _reservationDataService;

        public GetTakenSeatsRequestHandler(IReservationDataService dataAccessService)
        {
            _reservationDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _reservationDataService = dataAccessService;
        }

        public async Task<IEnumerable<string>> Handle(GetTakenSeatsRequest request, CancellationToken cancellationToken)
        {
            return await _reservationDataService.GetTakenSeats(request);
        }
    }
}
