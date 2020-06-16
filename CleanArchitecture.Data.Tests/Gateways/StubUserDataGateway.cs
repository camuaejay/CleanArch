namespace CleanArchitecture.Data.Tests.Gateways
{
    using CleanArchitecture.Data.Gateways.Users;
    using CleanArchitecture.Infrastructure.Models.Requests.Users;
    using CleanArchitecture.Infrastructure.Models.Responses.Users;
    using CleanArchitecture.Infrastructure.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StubUserDataGateway : IUserDataGateway
    {
        public Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetUserByUsername(string username)
        {
            await Task.Yield();
            var Users = this.BuildUsers();
            return Users.Where(user => user.Username == username).FirstOrDefault();
        }

        private List<UserModel> BuildUsers()
        {
            List<UserModel> users = new List<UserModel>();

            users.Add(new UserModel()
            {
                BirthDate = new DateTime(),
                EmailAddress = "Test",
                FirstName = "Test",
                MiddleName = "Test",
                LastName = "Test",
                Username = "Test",
                Id = new Guid("3BFBE4A0-E80E-4AE7-897D-2EFB617F0005")
            });

            users.Add(new UserModel()
            {
                BirthDate = new DateTime(),
                EmailAddress = "Test2",
                FirstName = "Test2",
                MiddleName = "Test2",
                LastName = "Test2",
                Username = "Test2",
                Id = new Guid("3BFBE4A0-E80E-4AE7-897D-2EFB617F0006")
            });

            return users;
        }

        public Task<SaveUserResponse> SaveUser(SaveUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
