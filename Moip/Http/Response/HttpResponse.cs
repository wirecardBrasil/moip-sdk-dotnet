using System;
using System.Collections.Generic;
using System.IO;

namespace Moip.Http.Response
{
    public class HttpResponse
    {
        public int StatusCode { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public Stream RawBody { get; set; }
    }
}
