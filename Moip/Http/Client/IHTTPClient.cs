using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moip.Http.Request;
using Moip.Http.Response;

namespace Moip.Http.Client
{
    public interface IHttpClient
    {
        void setTimeout(TimeSpan Timeout);

        event OnBeforeHttpRequestEventHandler OnBeforeHttpRequestEvent;

        event OnAfterHttpResponseEventHandler OnAfterHttpResponseEvent;

        HttpResponse ExecuteAsString(HttpRequest request);

        HttpResponse ExecuteAsBinary(HttpRequest request);

        Task<HttpResponse> ExecuteAsStringAsync(HttpRequest request);

        Task<HttpResponse> ExecuteAsBinaryAsync(HttpRequest request);

        HttpRequest Get(string queryUrl);

        HttpRequest Post(string queryUrl);

        HttpRequest Put(string queryUrl);

        HttpRequest Delete(string queryUrl);

        HttpRequest Patch(string queryUrl);

        HttpRequest Get(string queryUrl, Dictionary<string, string> headers, string username = null, string password = null);

        HttpRequest Post(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, Object>> formParameters,
           string username = null, string password = null);

        HttpRequest PostBody(string queryUrl, Dictionary<string, string> headers, object body,
            string username = null, string password = null);

        HttpRequest PostFormUrl(string queryUrl, Dictionary<string, string> headers, 
            string formParameters, string username = null, string password = null);

        HttpRequest Put(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, Object>> formParameters,
            string username = null, string password = null);

        HttpRequest PutBody(string queryUrl, Dictionary<string, string> headers, object body,
            string username = null, string password = null);

        HttpRequest Patch(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, Object>> formParameters,
            string username = null, string password = null);

        HttpRequest PatchBody(string queryUrl, Dictionary<string, string> headers, object body,
            string username = null, string password = null);

        HttpRequest Delete(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, Object>> formParameters,
            string username = null, string password = null);

        HttpRequest DeleteBody(string queryUrl, Dictionary<string, string> headers, object body,
            string username = null, string password = null);
    }
}
