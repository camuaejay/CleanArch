using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Models.Responses.Users
{
    public class SaveUserWebResponse : BaseWebResponse
    {
        public SaveUserWebResponse()
        {
            this.Errors = new List<string>();
            this.Message = string.Empty;
            this.Success = false;
        }
    }
}
