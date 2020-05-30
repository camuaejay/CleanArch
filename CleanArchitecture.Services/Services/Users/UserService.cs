using CleanArchitecture.Data.Gateways.Users;
using CleanArchitecture.Infrastructure.Extensions.Users;
using CleanArchitecture.Infrastructure.Helpers;
using CleanArchitecture.Infrastructure.Models.Requests.Users;
using CleanArchitecture.Infrastructure.Models.Responses.Users;
using CleanArchitecture.Infrastructure.Models.Users;
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
        private TokenHelper tokenHelper;

        public UserService(IUserDataGateway userDataGateway, EncryptionHelper encryptionHelper, TokenHelper tokenHelper)
        {
            this.userDataGateway = userDataGateway;
            this.encryptionHelper = encryptionHelper;
            this.tokenHelper = tokenHelper;
        }

        public async Task<AuthenticateUserWebResponse> AuthenticateUser(AuthenticateUserWebRequest request)
        {
            var response = new AuthenticateUserWebResponse();

            try
            {
                request.Password = this.encryptionHelper.EncryptPassword(request.Password);
                var result = await this.userDataGateway.AuthenticateUser(request.ToRequest());

                if (result.Success) 
                {
                    result.Data.Token = this.tokenHelper.GenerateToken(request.Username);
                }


                response = result.ToWebResponse();
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.Message = "Failed to authenticate user.";
            }

            return response;
        }

        public async Task<UserModel> GetUserByUsername(string username)
        {
            var response = new UserModel();

            try
            {
                var result = await this.userDataGateway.GetUserByUsername(username);
                response = result;
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        public async Task<SaveUserWebResponse> SaveUser(SaveUserWebRequest request)
        {
            var response = new SaveUserWebResponse();

            try
            {
                var user = await this.GetUserByUsername(request.Username);

                if (user.Id == new Guid())
                {
                    request.Id = Guid.NewGuid();
                    request.Password = this.encryptionHelper.EncryptPassword(request.Password);
                    var result = await this.userDataGateway.SaveUser(request.ToRequest());
                    response = result.ToWebResponse();
                }
                else 
                {
                    response.Message = "User already exists!";
                }

               
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
