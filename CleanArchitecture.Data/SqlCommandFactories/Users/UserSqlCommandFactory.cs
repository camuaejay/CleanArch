namespace CleanArchitecture.Data.SqlCommandFactories.Users
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using CleanArchitecture.Infrastructure.Models.Requests.Users;

    public class UserSqlCommandFactory : IUserSqlCommandFactory
    {
        public SqlCommand AuthenticateUser(AuthenticateUserRequest request)
        {
            var command = new SqlCommand();

            command.CommandText = "[dbo].[AuthenticateUser]";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@UserName", request.Username);
            command.Parameters.AddWithValue("@Password", request.Password);

            return command;
        }

        public SqlCommand GetUserByUsername(string username)
        {
            var command = new SqlCommand();

            command.CommandText = "[dbo].[GetUserByUsername]";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@UserName", username);

            return command;
        }

        public SqlCommand SaveUser(SaveUserRequest request)
        {
            var command = new SqlCommand();

            command.CommandText = "[dbo].[SaveUser]";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", request.Id);
            command.Parameters.AddWithValue("@EmailAddress", request.EmailAddress);
            command.Parameters.AddWithValue("@Password", request.Password);
            command.Parameters.AddWithValue("@FirstName", request.FirstName);
            command.Parameters.AddWithValue("@MiddleName", request.MiddleName);
            command.Parameters.AddWithValue("@LastName", request.LastName);
            command.Parameters.AddWithValue("@UserName", request.Username);
            command.Parameters.AddWithValue("@BirthDate", request.BirthDate);

            return command;
        }
    }
}
