using System;
using System.IO;
using Newtonsoft.Json;
using Moip.Http.Client;

namespace Moip.Exceptions
{
    [JsonObject]
    public class APIException : Exception
    {
        public int ResponseCode
        {
            get { return this.HttpContext != null ? HttpContext.Response.StatusCode : -1; }
        }

        public HttpContext HttpContext { get; set; }

        public APIException(string reason, HttpContext context)
            : base(reason)
        {
            this.HttpContext = context;

            if ((this.GetType().Name.Equals("APIException", StringComparison.OrdinalIgnoreCase))
                || (context == null) || (context.Response == null)
                || (context.Response.RawBody == null)
                || (!context.Response.RawBody.CanRead))
                return;

            using (StreamReader reader = new StreamReader(context.Response.RawBody))
            {
                var responseBody = reader.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(responseBody))
                {
                    try { JsonConvert.PopulateObject(responseBody, this); }
                    catch
                    {} 
                }
            }
        }
    }
}
