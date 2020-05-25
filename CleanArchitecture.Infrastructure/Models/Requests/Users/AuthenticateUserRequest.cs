namespace CleanArchitecture.Infrastructure.Models.Requests.Users
{
    public class AuthenticateUserRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
