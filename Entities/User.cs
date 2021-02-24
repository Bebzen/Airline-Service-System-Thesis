using System.ComponentModel.DataAnnotations;

namespace AirlineServiceSoftware.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string Pesel { get; set; }
        public string DocumentId { get; set; }
        public string Token { get; set; }
    }
}
