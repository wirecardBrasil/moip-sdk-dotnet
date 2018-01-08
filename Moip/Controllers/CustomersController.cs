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
    public partial class CustomersController : BaseController
    {
        #region Singleton Pattern

        private static object syncObject = new object();
        private static CustomersController instance = null;

        internal static CustomersController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new CustomersController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        public Models.CustomerResponse GetCustomer(string customerId)
        {
            Task<Models.CustomerResponse> t = GetCustomerAsync(customerId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.CustomerResponse> GetCustomerAsync(string customerId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/customers/{customer-id}");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "customer-id", customerId }
            });

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.CustomerResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public bool DeleteCreditCard(string creditCardId)
        {
            Task<bool> t = DeleteCreditCardAsync(creditCardId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<bool> DeleteCreditCardAsync(string creditCardId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/fundinginstruments/{creditCard-id}");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "creditCard-id", creditCardId }
            });

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Delete(_queryUrl, _headers, null);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            if (_response.StatusCode == 404)
            {
                return false;
            }
            else
            {

                base.ValidateResponse(_response, _context);
            }

            return true;
        }

        public Models.CustomerResponse CreateCustomer(Models.CustomerRequest body)
        {
            Task<Models.CustomerResponse> t = CreateCustomerAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.CustomerResponse> CreateCustomerAsync(Models.CustomerRequest body)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/customers");

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            var _body = APIHelper.JsonSerialize(body);

            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.CustomerResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public dynamic ListCustomers()
        {
            Task<dynamic> t = ListCustomersAsync();
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<dynamic> ListCustomersAsync()
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);

            _queryBuilder.Append("/customers/");

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);

            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }

            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.CustomerCreditCardResponse CreateCreditCard(Models.CustomerCreditCardRequest body, string customerId)
        {
            Task<Models.CustomerCreditCardResponse> t = CreateCreditCardAsync(body, customerId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.CustomerCreditCardResponse> CreateCreditCardAsync(Models.CustomerCreditCardRequest body, string customerId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/customers/{customer-id}/fundinginstruments");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "customer-id", customerId }
            });

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            var _body = APIHelper.JsonSerialize(body);

            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.CustomerCreditCardResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
}
