namespace CleanArchitecture.Data.DataAccess
{
    using CleanArchitecture.Data.Models.Responses;
    using CleanArchitecture.Infrastructure.Providers;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class DataAccess : IDataAccess
    {
        private ConnectionProvider connectionProvider;
        private SqlTransaction transaction;

        public DataAccess(ConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public async Task<DataAccessResponse> ExecuteNonQuery(SqlCommand sqlCommand)
        {
            var response = new DataAccessResponse();

            try
            {
                using (var connection = new SqlConnection(this.connectionProvider.DBConnection))
                {
                    connection.Open();

                    using (this.transaction = connection.BeginTransaction())
                    {
                        sqlCommand.Connection = connection;
                        sqlCommand.Transaction = this.transaction;
                        var result = await sqlCommand.ExecuteNonQueryAsync();

                        this.transaction.Commit();
                        response.Message = $"Succesfully executed {sqlCommand.CommandText}";
                        response.Success = true;
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                this.transaction.Rollback();
                response.Errors.Add(ex.Message);
                response.Message = $"Failed to Execute Non Query Command : {sqlCommand.CommandText}.";
            }

            return response;
        }

        public async Task<DataAccessResponse> ExecuteReader(SqlCommand sqlCommand)
        {
            var response = new DataAccessResponse();

            try
            {
                using (var connection = new SqlConnection(this.connectionProvider.DBConnection))
                {
                    connection.Open();

                    using (this.transaction = connection.BeginTransaction())
                    {
                        sqlCommand.Connection = connection;
                        sqlCommand.Transaction = this.transaction;
                        var result = await sqlCommand.ExecuteReaderAsync();


                        var dataTable = new DataTable();
                        dataTable.Load(result);

                        response.DataTable = dataTable;
                        response.Message = $"Succesfully executed {sqlCommand.CommandText}";
                        response.Success = true;

                        this.transaction.Commit();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                this.transaction.Rollback();
                response.Errors.Add(ex.Message);
                response.Message = $"Failed to Execute Reader Command : {sqlCommand.CommandText}.";
            }

            return response;
        }
    }
}
