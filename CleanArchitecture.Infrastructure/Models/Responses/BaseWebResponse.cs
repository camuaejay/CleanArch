using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Models.Responses
{
    public class BaseWebResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
    }
}
