using System;
using System.Net;
using Newtonsoft.Json;

namespace VogCodeChallenge.BLL.Objects
{
    public class ErrorDetails
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public Exception InnerException { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}