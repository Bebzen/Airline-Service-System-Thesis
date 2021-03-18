using System.Collections.Generic;
using System.Threading.Tasks;
using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Reservations;

namespace AirlineServiceSoftware.DataAccess
{
    public interface IReservationDataService 
    {
        Task<bool> CreateReservation(CreateReservationRequest request);
        Task<IEnumerable<ReservationUserResponse>> GetFlightReservations(GetFlightReservationsRequest request);
        Task<IEnumerable<Reservation>> GetUserReservations(GetUserReservationsRequest request);
        Task<IEnumerable<string>> GetTakenSeats(GetTakenSeatsRequest request);
        Task<bool> EditReservation(EditReservationRequest request);
    }
}
