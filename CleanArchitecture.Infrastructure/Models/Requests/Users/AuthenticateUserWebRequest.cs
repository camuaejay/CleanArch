namespace CleanArchitecture.Infrastructure.Models.Requests.Users
{
    public class AuthenticateUserWebRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
