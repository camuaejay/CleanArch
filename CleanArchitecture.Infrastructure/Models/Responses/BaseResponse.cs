namespace CleanArchitecture.Infrastructure.Models.Responses
{
    using System.Collections.Generic;

    public class BaseResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
    }
}
