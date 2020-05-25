using CleanArchitecture.Infrastructure.Models.Requests.Users;
using CleanArchitecture.Infrastructure.Models.Responses.Users;

namespace CleanArchitecture.Infrastructure.Extensions.Users
{
    public static class AuthenticateUserExtension
    {
        public static AuthenticateUserRequest ToRequest(this AuthenticateUserWebRequest webRequest) 
        {
            var request = new AuthenticateUserRequest()
            {
                Username = webRequest.Username,
                Password = webRequest.Password
            };

            return request;
        }

        public static AuthenticateUserWebResponse ToWebResponse(this AuthenticateUserResponse response)
        {
            var webResponse = new AuthenticateUserWebResponse()
            {
                Success = response.Success,
                Errors = response.Errors,
                Message = response.Message,
                Data = response.Data
            };

            return webResponse;
        }
    }
}
