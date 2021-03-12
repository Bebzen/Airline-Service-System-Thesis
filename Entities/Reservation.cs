namespace AirlineServiceSoftware.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public Flight Flight { get; set; }
        public int UserId { get; set; }
        public float Price { get; set; }
        public string SeatNumber { get; set; }
        public string TransactionId { get; set; }
        public bool IsValid { get; set; }
    }
}
