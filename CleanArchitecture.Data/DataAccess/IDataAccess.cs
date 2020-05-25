namespace CleanArchitecture.Data.DataAccess
{
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using CleanArchitecture.Data.Models.Responses;

    public interface IDataAccess
    {
        Task<DataAccessResponse> ExecuteReader(SqlCommand sqlCommand);

        Task<DataAccessResponse> ExecuteNonQuery(SqlCommand sqlCommand);
    }
}
