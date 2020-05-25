namespace CleanArchitecture.Data.SqlCommandFactories.Users
{
    using CleanArchitecture.Infrastructure.Models.Requests.Users;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Text;

    public interface IUserSqlCommandFactory
    {
        SqlCommand SaveUser(SaveUserRequest request);

        SqlCommand AuthenticateUser(AuthenticateUserRequest request);
    }
}
