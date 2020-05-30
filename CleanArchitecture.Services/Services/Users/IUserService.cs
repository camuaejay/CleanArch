namespace CleanArchitecture.Services.Services.Users
{
    using System.Threading.Tasks;
    using CleanArchitecture.Infrastructure.Models.Requests.Users;
    using CleanArchitecture.Infrastructure.Models.Responses.Users;
    using CleanArchitecture.Infrastructure.Models.Users;

    public interface IUserService
    {
        Task<AuthenticateUserWebResponse> AuthenticateUser(AuthenticateUserWebRequest request);
        Task<SaveUserWebResponse> SaveUser(SaveUserWebRequest request);

        Task<UserModel> GetUserByUsername(string username);

    }
}
