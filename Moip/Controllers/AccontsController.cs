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

namespace Moip.Controllers
{
    public partial class AccountsController : BaseController
    {
        #region Singleton Pattern

        private static object syncObject = new object();
        private static AccountsController instance = null;

        internal static AccountsController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new AccountsController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        public Models.AccountResponse GetAccount(string accountId)
        {
            Task<Models.AccountResponse> t = GetAccountAsync(accountId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.AccountResponse> GetAccountAsync(string accountId)
        {

            string _queryUrl = Utilities.APIHelper.GetBuiltUrl("account", accountId);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.AccountResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }



        public Models.AccountResponse CreateAccount(Models.AccountRequest body)
        {
            Task<Models.AccountResponse> t = CreateAccountAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.AccountResponse> CreateAccountAsync(Models.AccountRequest body)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/accounts");

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            var _body = APIHelper.JsonSerialize(body);

            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.AccountResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }


        public bool CheckAccountExists(string taxDocument)
        {
            Task<bool> t = CheckAccountExistsAsync(taxDocument);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<bool> CheckAccountExistsAsync(string taxDocument)
        {
            string _queryUrl = Utilities.APIHelper.GetBuiltUrl("account");

            _queryUrl += "/exists?tax_document=" + taxDocument;

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            if (_response.StatusCode == 200)
                return true;
            else
                return false;

        }



    }
}
