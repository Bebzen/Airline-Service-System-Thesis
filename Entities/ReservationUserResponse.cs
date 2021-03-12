namespace AirlineServiceSoftware.Entities
{
    public class ReservationUserResponse
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public User User { get; set; }
        public float Price { get; set; }
        public string SeatNumber { get; set; }
        public string TransactionId { get; set; }
        public bool IsValid { get; set; }
    }
}
