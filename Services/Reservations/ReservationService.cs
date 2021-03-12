using MediatR;
using System.Collections.Generic;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Reservations;

namespace AirlineServiceSoftware.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IMediator _mediator;

        public ReservationService(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public bool CreateReservation(Reservation reservationData)
        {
            var result = _mediator.Send(new CreateReservationRequest()
            {
                FlightId = reservationData.Flight.Id,
                Price = reservationData.Price,
                SeatNumber = reservationData.SeatNumber,
                TransactionId = reservationData.TransactionId,
                UserId = reservationData.UserId,
                IsValid = reservationData.IsValid
            }).Result;

            return result;
        }

        public IEnumerable<ReservationUserResponse> GetFlightReservations(int id)
        {
            var reservations = _mediator.Send(new GetFlightReservationsRequest()
            {
                Id = id
            }).Result;

            return reservations;
        }

        public IEnumerable<Reservation> GetUserReservations(int id)
        {
            var reservations = _mediator.Send(new GetUserReservationsRequest()
            {
                Id = id
            }).Result;

            return reservations;
        }

        public IEnumerable<string> GetTakenSeats(int id)
        {
            var seats = _mediator.Send(new GetTakenSeatsRequest()
            {
                Id = id
            }).Result;

            return seats;
        }
    }
}
