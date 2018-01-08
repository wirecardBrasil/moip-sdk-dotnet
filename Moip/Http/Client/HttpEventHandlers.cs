using Moip.Http.Request;
using Moip.Http.Response;

namespace Moip.Http.Client
{
    public delegate void OnBeforeHttpRequestEventHandler(IHttpClient source, HttpRequest request);

    public delegate void OnAfterHttpResponseEventHandler(IHttpClient source, HttpResponse response);
}
