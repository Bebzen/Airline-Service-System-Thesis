using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Reservations;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Reservations
{
    public class GetUserReservationsRequestHandler : IRequestHandler<GetUserReservationsRequest, IEnumerable<Reservation>>
    {
        private readonly IReservationDataService _reservationDataService;

        public GetUserReservationsRequestHandler(IReservationDataService dataAccessService)
        {
            _reservationDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _reservationDataService = dataAccessService;
        }

        public async Task<IEnumerable<Reservation>> Handle(GetUserReservationsRequest request, CancellationToken cancellationToken)
        {
            return await _reservationDataService.GetUserReservations(request);
        }
    }
}
