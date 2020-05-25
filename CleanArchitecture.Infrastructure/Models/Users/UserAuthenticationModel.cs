namespace CleanArchitecture.Infrastructure.Models.Users
{
    public class UserAuthenticationModel
    {
        public UserModel User { get; set; }

        public string Token { get; set; }
    }
}
