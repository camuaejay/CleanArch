namespace CleanArchitecture.Data.Models.Responses
{
    using System.Collections.Generic;
    using System.Data;
    using CleanArchitecture.Infrastructure.Models.Responses;

    public class DataAccessResponse : BaseResponse
    {
        public DataAccessResponse()
        {
            this.Success = false;
            this.Errors = new List<string>();
            this.Message = string.Empty;
        }

        public DataTable DataTable { get; set; }
    }
}
