using CleanArchitecture.Infrastructure.Models.Requests.Users;
using CleanArchitecture.Infrastructure.Models.Responses.Users;

namespace CleanArchitecture.Infrastructure.Extensions.Users
{
    public static class SaveUserExtension
    {
        public static SaveUserRequest ToRequest(this SaveUserWebRequest webRequest) 
        {
            var request = new SaveUserRequest()
            {
                Id = webRequest.Id,
                BirthDate = webRequest.BirthDate,
                Username = webRequest.Username,
                FirstName = webRequest.FirstName,
                EmailAddress = webRequest.EmailAddress,
                LastName = webRequest.LastName,
                Password = webRequest.Password,
                MiddleName = webRequest.MiddleName,
            };

            return request;
        }

        public static SaveUserWebResponse ToWebResponse(this SaveUserResponse response) 
        {
            var webResponse = new SaveUserWebResponse()
            {
                Errors = response.Errors,
                Message = response.Message,
                Success = response.Success
            };

            return webResponse;
        }
    }
}
