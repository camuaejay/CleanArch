namespace CleanArchitecture.Data.Tests.DataAccess
{
    using CleanArchitecture.Data.DataAccess;
    using CleanArchitecture.Data.Models.Responses;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

    public class StubUserDataAccess : IDataAccess
    {
        private DataAccessResponse response;

        public StubUserDataAccess(DataAccessResponse response)
        {
            this.response = new DataAccessResponse
            {
                Success = true,
                Message = "Successful Execution of query"
            };
        }

        public async Task<DataAccessResponse> ExecuteNonQuery(SqlCommand sqlCommand)
        {
            await Task.Yield();

            return this.response;
        }

        public Task<DataAccessResponse> ExecuteReader(SqlCommand sqlCommand)
        {
            DataTable dataTable = new DataTable();

            if (sqlCommand.CommandText == "[dbo].[GetUserByUsername]") 
            {
                dataTable = this.BuildUserDataTable();
            }

            this.response.DataTable = dataTable;
            return Task.FromResult(this.response);
        }

        private DataTable BuildUserDataTable()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Id", typeof(Guid));
            dataTable.Columns.Add("Username", typeof(string));
            dataTable.Columns.Add("EmailAddress", typeof(string));
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("MiddleName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Password", typeof(string));
            dataTable.Columns.Add("BirthDate", typeof(DateTime));

            object[] row = {
               new Guid("3BFBE4A0-E80E-4AE7-897D-2EFB617F0005"),
               "JoeDoe",
               "JoeDoe@Test.com",
               "Joe",
               "Smith",
               "Doe",
               "Password",
               "BirthDate"
            };

            return dataTable;
        }
    }
}
