namespace CleanArchitecture.Infrastructure.Models.Responses.Users
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SaveUserResponse : BaseResponse
    {
        public SaveUserResponse()
        {
            this.Errors = new List<string>();
            this.Message = string.Empty;
            this.Success = false;
        }
    }
}
