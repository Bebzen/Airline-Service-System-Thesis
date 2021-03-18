using System;
using System.Threading;
using System.Threading.Tasks;
using AirlineServiceSoftware.DataAccess;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Reservations;
using MediatR;

namespace AirlineServiceSoftware.Mediators.MediatorsRequestsHandler.Reservations
{
    public class EditReservationRequestHandler : IRequestHandler<EditReservationRequest, bool>
    {
        private readonly IReservationDataService _reservationDataService;
        public EditReservationRequestHandler(IReservationDataService dataAccessService)
        {
            _reservationDataService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _reservationDataService = dataAccessService;
        }

        public async Task<bool> Handle(EditReservationRequest request, CancellationToken cancellationToken)
        {
            return await _reservationDataService.EditReservation(request);
        }
    }
}
