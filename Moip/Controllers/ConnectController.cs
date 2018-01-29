using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Moip;
using Moip.Utilities;
using Moip.Http.Request;
using Moip.Http.Response;
using Moip.Http.Client;
using Moip.Exceptions;
using Moip.Models;
using System.Web;
using System.Net.Http;

namespace Moip.Controllers
{
    public partial class ConnectController : BaseController
    {
        #region Singleton Pattern

        private static object syncObject = new object();
        private static ConnectController instance = null;

        internal static ConnectController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new ConnectController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        public Models.ConnectResponse Authorize(ConnectRequest body)
        {
            Task<Models.ConnectResponse> t = AuthorizeAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<ConnectResponse> AuthorizeAsync(ConnectRequest body)
        {
            string _baseUri = "";
            if (Configuration.Environment == Configuration.Environments.SANDBOX)
                _baseUri = "https://connect-sandbox.moip.com.br";
            else
                _baseUri = "https://connect.moip.com.br";

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/oauth/token");

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = new Dictionary<string, string>();
            _headers.Add("user-agent", "Moip.NETSDK");
            _headers.Add("Authorization", string.Format("Bearer {0}", Configuration.OAuthAccessToken));
            _headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");

            var _body = APIHelper.JsonSerialize(body);

            HttpRequest _request = ClientInstance.PostFormUrl(_queryUrl, _headers, _body);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.ConnectResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public string GetAuthorizeUrl(String clientId, String redirectUri, ScopePermissionList scope)
        {

            string query;
            using (
                var content = new FormUrlEncodedContent(
                    new KeyValuePair<string, string>[]{
                        new KeyValuePair<string, string>("response_type", "code"),
                        new KeyValuePair<string, string>("client_id", clientId),
                        new KeyValuePair<string, string>("redirect_uri", redirectUri),
                        new KeyValuePair<string, string>("scope", scope.ToString()),
                    }
                )
            )
            {
                query = content.ReadAsStringAsync().Result;
            }

            return "https://connect-sandbox.moip.com.br/oauth/authorize?" + query;
        }

    }
}
