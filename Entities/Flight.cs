using System;

namespace AirlineServiceSoftware.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public Crew Crew { get; set; }
        public string FlightNumber { get; set; }
        public string StartingAirportName { get; set; }
        public string DestinationAirportName { get; set; }
        public DateTime FlightDate { get; set; }
        public string TakeoffHour { get; set; }
        public string LandingHour { get; set; }
        public string PlaneType { get; set; }
        public int TotalSeats { get; set; }
        public int RemainingSeats { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCompleted { get; set; }
    }
}
