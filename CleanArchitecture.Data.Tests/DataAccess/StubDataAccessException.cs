namespace CleanArchitecture.Data.Tests.DataAccess
{
    using CleanArchitecture.Data.DataAccess;
    using CleanArchitecture.Data.Models.Responses;
    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    class StubDataAccessException : IDataAccess
    {
        public async Task<DataAccessResponse> ExecuteNonQuery(SqlCommand sqlCommand)
        {
            await Task.Yield();
            throw new Exception();
        }

        public async Task<DataAccessResponse> ExecuteReader(SqlCommand sqlCommand)
        {
            await Task.Yield();
            throw new Exception();
        }
    }
}
