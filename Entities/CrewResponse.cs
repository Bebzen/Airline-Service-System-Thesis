namespace AirlineServiceSoftware.Entities
{
    public class CrewResponse
    {
        public int Id { get; set; }
        public string CrewName { get; set; }
        public int CaptainID { get; set; }
        public int FirstOfficerID { get; set; }
        public int SecondOfficerID { get; set; }
    }
}
