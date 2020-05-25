namespace CleanArchitecture.Data.Gateways.Users
{
    using System.Threading.Tasks;
    using CleanArchitecture.Infrastructure.Models.Requests.Users;
    using CleanArchitecture.Infrastructure.Models.Responses.Users;

    public interface IUserDataGateway
    {
        Task<SaveUserResponse> SaveUser(SaveUserRequest request);

        Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserRequest request);
    }
}
