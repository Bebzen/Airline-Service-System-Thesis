
using System.Collections.Generic;
using AirlineServiceSoftware.Entities;

namespace AirlineServiceSoftware.Services.Reservations
{
    public interface IReservationService
    {
        bool CreateReservation(Reservation transactionData);
        IEnumerable<Reservation> GetUserReservations(int id);
        IEnumerable<ReservationUserResponse> GetFlightReservations(int id);
        IEnumerable<string> GetTakenSeats(int id);
    }
}
