using MediatR;
#pragma warning disable 8632

namespace AirlineServiceSoftware.Mediators.MediatorsRequests.Users
{
    public class CreateUserRequest: IRequest<bool>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ?PhoneNumber { get; set; }
        public string ?Email { get; set; }
        public string ?Pesel { get; set; }
        public string ?DocumentID { get; set; }
    }
}
