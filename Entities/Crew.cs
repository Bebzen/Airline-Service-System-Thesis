namespace AirlineServiceSoftware.Entities
{
    public class Crew
    {
        public int Id { get; set; }
        public string CrewName { get; set; }
        public User Captain { get; set; }
        public User FirstOfficer { get; set; }
        public User SecondOfficer { get; set; }
    }
}
