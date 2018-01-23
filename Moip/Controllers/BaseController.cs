using System;
using Moip;
using Moip.Utilities;
using Moip.Http.Client;
using Moip.Http.Response;
using Moip.Exceptions;

namespace Moip.Controllers
{
    public partial class BaseController
    {
        #region shared http client instance
        private static object syncObject = new object();
        private static IHttpClient clientInstance = null;

        public static IHttpClient ClientInstance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == clientInstance)
                    {
                        clientInstance = new HTTPClient();
                    }
                    return clientInstance;
                }
            }
            set
            {
                lock (syncObject)
                {
                    if (value is IHttpClient)
                    {
                        clientInstance = value;
                    }
                }
            }
        }
        #endregion shared http client instance

        internal ArrayDeserialization ArrayDeserializationFormat = ArrayDeserialization.Indexed;
        internal static char ParameterSeparator = '&';

        internal void ValidateResponse(HttpResponse _response, HttpContext _context)
        {
            if (((_response.StatusCode < 200) || (_response.StatusCode > 208)) && _response.StatusCode != 404) //[200,208] = HTTP OK
                throw new APIException(@"HTTP Response Not OK", _context);
        }
    }
}
