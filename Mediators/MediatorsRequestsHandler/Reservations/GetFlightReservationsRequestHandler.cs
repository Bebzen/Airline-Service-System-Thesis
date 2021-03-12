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
    public class GetFlightReservationsRequestHandler : IRequestHandler<GetFlightReservationsRequest, IEnumerable<ReservationUserResponse>>
    {
        private readonly IReservationDataService _reservationDataService;

        public GetFlightReservationsRequestHandler(IReservationDataService dataAccessService)
        {
            _reservationDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _reservationDataService = dataAccessService;
        }

        public async Task<IEnumerable<ReservationUserResponse>> Handle(GetFlightReservationsRequest request, CancellationToken cancellationToken)
        {
            return await _reservationDataService.GetFlightReservations(request);
        }
    }
}
