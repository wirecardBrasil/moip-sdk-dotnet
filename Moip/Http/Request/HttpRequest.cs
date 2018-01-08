using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Moip.Http.Request
{
    public class HttpRequest
    {
        public HttpMethod HttpMethod { get; set; }

        public string QueryUrl { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public List<KeyValuePair<string, object>> FormParameters { get; set; }

        public object Body { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public HttpRequest(HttpMethod method, string queryUrl)
        {
            this.HttpMethod = method;
            this.QueryUrl = queryUrl;
        }

        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, string username, string password)
            : this(method, queryUrl)
        {
            this.Headers = headers;
            this.Username = username;
            this.Password = password;
        }

        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, object body, string username, string password)
            : this(method, queryUrl, headers, username, password)
        {
            this.Body = body;
        }

        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, Object>> formParameters, string username, string password)
            : this(method, queryUrl, headers, username, password)
        {
            this.FormParameters = formParameters;
        }
    }
}
