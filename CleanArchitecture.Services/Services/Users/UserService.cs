using CleanArchitecture.Data.Gateways.Users;
using CleanArchitecture.Infrastructure.Extensions.Users;
using CleanArchitecture.Infrastructure.Helpers;
using CleanArchitecture.Infrastructure.Models.Requests.Users;
using CleanArchitecture.Infrastructure.Models.Responses.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Services.Services.Users
{
    public class UserService : IUserService
    {
        private IUserDataGateway userDataGateway;
        private EncryptionHelper encryptionHelper;

        public UserService(IUserDataGateway userDataGateway, EncryptionHelper encryptionHelper)
        {
            this.userDataGateway = userDataGateway;
            this.encryptionHelper = encryptionHelper;
        }

        public async Task<AuthenticateUserWebResponse> AuthenticateUser(AuthenticateUserWebRequest request)
        {
            var response = new AuthenticateUserWebResponse();

            try
            {
                request.Password = this.encryptionHelper.EncryptPassword(request.Password);
                var result = await this.userDataGateway.AuthenticateUser(request.ToRequest());
                response = result.ToWebResponse();
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.Message = "Failed to authenticate user.";
            }

            return response;
        }

        public async Task<SaveUserWebResponse> SaveUser(SaveUserWebRequest request)
        {
            var response = new SaveUserWebResponse();

            try
            {
                request.Id = Guid.NewGuid();
                request.Password = this.encryptionHelper.EncryptPassword(request.Password);
                var result = await this.userDataGateway.SaveUser(request.ToRequest());
                response = result.ToWebResponse();
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.Message = "Failed to register user.";
            }

            return response;
        }
    }
}
