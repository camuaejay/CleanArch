namespace CleanArchitecture.Infrastructure.Models.Responses.Users
{
    using System.Collections.Generic;
    using CleanArchitecture.Infrastructure.Models.Users;

    public class AuthenticateUserWebResponse : BaseWebResponse
    {
        public AuthenticateUserWebResponse()
        {
            this.Errors = new List<string>();
            this.Message = string.Empty;
            this.Success = false;
        }

        public UserAuthenticationModel Data { get; set; }
    }
}
