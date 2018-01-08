using Moip.Http.Request;
using Moip.Http.Response;

namespace Moip.Http.Client
{
    public class HttpContext
    {
        public HttpRequest Request { get; set; }

        public HttpResponse Response { get; set; }

        public HttpContext(HttpRequest request, HttpResponse response)
        {
            Request = request;
            Response = response;
        }
    }
}
