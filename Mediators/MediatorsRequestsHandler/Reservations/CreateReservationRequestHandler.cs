using System;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Reservations;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Reservations
{
    public class CreateReservationRequestHandler : IRequestHandler<CreateReservationRequest, bool>
    {
        private readonly IReservationDataService _reservationDataService;
        public CreateReservationRequestHandler(IReservationDataService dataAccessService)
        {
            _reservationDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _reservationDataService = dataAccessService;
        }

        public async Task<bool> Handle(CreateReservationRequest request, CancellationToken cancellationToken)
        {
            return await _reservationDataService.CreateReservation(request);
        }
    }
}
