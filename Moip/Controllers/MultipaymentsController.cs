using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moip.Utilities;
using Moip.Http.Request;
using Moip.Http.Response;
using Moip.Http.Client;
using Moip.Exceptions;

namespace Moip.Controllers
{
    public partial class MultipaymentsController : BaseController
    {
        #region Singleton Pattern

        private static object syncObject = new object();
        private static MultipaymentsController instance = null;

        internal static MultipaymentsController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new MultipaymentsController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        public dynamic GetMultipayment(string multipaymentId)
        {
            Task<Models.MultipaymentResponse> t = GetMultipaymentAsync(multipaymentId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.MultipaymentResponse> GetMultipaymentAsync(string multipaymentId)
        {
            string _queryUrl = Utilities.APIHelper.GetBuiltUrl("multipayment", multipaymentId);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.MultipaymentResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.MultipaymentResponse CreateCreditCard(string multiorderId, Models.MultipaymentRequest body = null)
        {
            Task<Models.MultipaymentResponse> t = CreateCreditCardAsync(multiorderId, body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.MultipaymentResponse> CreateCreditCardAsync(string multiorderId, Models.MultipaymentRequest body = null)
        {
            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/multiorders/{multiorder-id}/multipayments");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "multiorder-id", multiorderId }
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
                return APIHelper.JsonDeserialize<Models.MultipaymentResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.MultipaymentResponse CreateBoletoOrDebit(string multiorderId, Models.MultipaymentBoletoOrDebitRequest body)
        {
            Task<Models.MultipaymentResponse> t = CreateBoletoOrDebitAsync(body, multiorderId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.MultipaymentResponse> CreateBoletoOrDebitAsync(Models.MultipaymentBoletoOrDebitRequest body, string multiorderId)
        {
            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/multiorders/{multiorder-id}/multipayments");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "multiorder-id", multiorderId }
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
                return APIHelper.JsonDeserialize<Models.MultipaymentResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }
        public Models.MultipaymentResponse CapturePreAuthorized(string multipaymentId)
        {
            Task<Models.MultipaymentResponse> t = CapturePreAuthorizedAsync(multipaymentId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.MultipaymentResponse> CapturePreAuthorizedAsync(string multipaymentId)
        {
            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/multiorders/{multiorder-id}/multipayments");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "multipayment-id", multipaymentId }
            });

            dynamic body = "";

            var _body = APIHelper.JsonSerialize(body);

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.MultipaymentResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.EscrowResponse ReleaseEscrow(string escrowId)
        {
            Task<Models.EscrowResponse> t = ReleaseEscrowAsync(escrowId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.EscrowResponse> ReleaseEscrowAsync(string escrowId)
        {
            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/escrows/{escrow-id}/release");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "escrow-id", escrowId }
            });

            dynamic body = "";

            var _body = APIHelper.JsonSerialize(body);

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.EscrowResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }
    }
}