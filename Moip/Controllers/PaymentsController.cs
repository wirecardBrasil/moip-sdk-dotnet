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
    public partial class PaymentsController : BaseController
    {
        #region Singleton Pattern

        private static object syncObject = new object();
        private static PaymentsController instance = null;

        internal static PaymentsController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new PaymentsController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        public dynamic GetPayment(string paymentId)
        {
            Task<Models.PaymentResponse> t = GetPaymentAsync(paymentId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.PaymentResponse> GetPaymentAsync(string paymentId)
        {

            string _queryUrl = Utilities.APIHelper.GetBuiltUrl("payment", paymentId);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.PaymentResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.PaymentResponse CreateCreditCard(string orderId, Models.PaymentRequest body = null)
        {
            Task<Models.PaymentResponse> t = CreateCreditCardAsync(orderId, body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.PaymentResponse> CreateCreditCardAsync(string orderId, Models.PaymentRequest body = null)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/orders/{order-id}/payments");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "order-id", orderId }
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
                return APIHelper.JsonDeserialize<Models.PaymentResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.PaymentResponse CreateBoletoOrDebit(string orderId, Models.PaymentBoletoOrDebitRequest body)
        {
            Task<Models.PaymentResponse> t = CreateBoletoOrDebitAsync(body, orderId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.PaymentResponse> CreateBoletoOrDebitAsync(Models.PaymentBoletoOrDebitRequest body, string orderId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/orders/{order-id}/payments");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "order-id", orderId }
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
                return APIHelper.JsonDeserialize<Models.PaymentResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.PaymentResponse CapturePreAuthorized(string paymentId)
        {
            Task<Models.PaymentResponse> t = CapturePreAuthorizedAsync(paymentId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.PaymentResponse> CapturePreAuthorizedAsync(string paymentId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/payments/{payment-id}/capture");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "payment-id", paymentId }
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
                return APIHelper.JsonDeserialize<Models.PaymentResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.PaymentResponse CancelPreAuthorized(string paymentId)
        {
            Task<Models.PaymentResponse> t = CancelPreAuthorizedAsync(paymentId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.PaymentResponse> CancelPreAuthorizedAsync(string paymentId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/payments/{payment-id}/void");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "payment-id", paymentId }
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
                return APIHelper.JsonDeserialize<Models.PaymentResponse>(_response.Body);
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
