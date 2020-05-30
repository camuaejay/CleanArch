namespace CleanArchitecture.Data.Gateways.Users
{
    using System;
    using System.Data;
    using System.Threading.Tasks;
    using CleanArchitecture.Data.DataAccess;
    using CleanArchitecture.Data.SqlCommandFactories.Users;
    using CleanArchitecture.Infrastructure.Models.Requests.Users;
    using CleanArchitecture.Infrastructure.Models.Responses.Users;
    using CleanArchitecture.Infrastructure.Models.Users;
    using Microsoft.IdentityModel.Logging;

    public class UserDataGateway : IUserDataGateway
    {
        private IDataAccess dataAccess;
        private IUserSqlCommandFactory userSqlCommandFactory;

        public UserDataGateway(IDataAccess dataAccess, IUserSqlCommandFactory userSqlCommandFactory)
        {
            this.dataAccess = dataAccess;
            this.userSqlCommandFactory = userSqlCommandFactory;
        }

        public async Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserRequest request)
        {
            var response = new AuthenticateUserResponse();

            try
            {
                var command = this.userSqlCommandFactory.AuthenticateUser(request);
                var result = await this.dataAccess.ExecuteReader(command);

                if (result.DataTable.Rows.Count == 1)
                {
                    response.Message = "Successfully authenticated user.";
                    response.Success = true;

                    response.Data = new UserAuthenticationModel();

                    response.Data.User = BuildUserFromDataRow(result.DataTable.Rows[0]);
                }
                else 
                {
                    response.Message = "Incorrect authentication details.";
                    response.Success = false;
                }
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
                var command = this.userSqlCommandFactory.GetUserByUsername(username);
                var result = await this.dataAccess.ExecuteReader(command);

                if (result.DataTable.Rows.Count == 1)
                {
                    response = BuildUserFromDataRow(result.DataTable.Rows[0]);
                }
                
            }
            catch (Exception ex)
            {
                LogHelper.LogWarning(ex.Message);
            }

            return response;
        }

        public async Task<SaveUserResponse> SaveUser(SaveUserRequest request)
        {
            var response = new SaveUserResponse();

            try
            {
                var command = this.userSqlCommandFactory.SaveUser(request);
                var result = await this.dataAccess.ExecuteNonQuery(command);

                response.Message = "Successfully registered user.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.Message = "Failed to register user.";
            }

            return response;
        }

        private UserModel BuildUserFromDataRow(DataRow row)
        {
            var user = new UserModel();

          
            user.Id = Guid.Parse(row["Id"].ToString());
            user.FirstName = row["FirstName"].ToString();
            user.MiddleName = row["MiddleName"].ToString();
            user.LastName = row["LastName"].ToString();
            user.Username = row["Username"].ToString();
            user.EmailAddress = row["EmailAddress"].ToString();
            user.BirthDate = (DateTime) row["BirthDate"];

            return user;
        }
    }
}
