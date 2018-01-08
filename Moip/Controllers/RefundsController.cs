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
    public partial class RefundsController : BaseController
    {
        #region Singleton Pattern

        private static object syncObject = new object();
        private static RefundsController instance = null;

        internal static RefundsController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new RefundsController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        public Models.RefundCCResponse CreatePayment(string paymentId, Models.RefundCCRequest body)
        {
            Task<Models.RefundCCResponse> t = CreatePaymentAsync(paymentId, body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.RefundCCResponse> CreatePaymentAsync(string paymentId, Models.RefundCCRequest body)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/orders/{payment-id}/refunds");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "payment-id", paymentId }
            });

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = APIHelper.GetHeader();

            var _body = APIHelper.JsonSerialize(body);

            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.RefundCCResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.RefundBankAccountResponse CreatePaymentBankAccount(string paymentId, Models.RefundBankAccountRequest body)
        {
            Task<Models.RefundBankAccountResponse> t = CreatePaymentBankAccounttAsync(paymentId, body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.RefundBankAccountResponse> CreatePaymentBankAccounttAsync(string paymentId, Models.RefundBankAccountRequest body)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/orders/{payment-id}/refunds");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "payment-id", paymentId }
            });

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = APIHelper.GetHeader();

            var _body = APIHelper.JsonSerialize(body);

            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.RefundBankAccountResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.RefundBankAccountResponse CreateOrderBankAccount(string orderId, Models.RefundBankAccountRequest body)
        {
            Task<Models.RefundBankAccountResponse> t = CreateOrderBankAccounttAsync(orderId, body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.RefundBankAccountResponse> CreateOrderBankAccounttAsync(string orderId, Models.RefundBankAccountRequest body)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/orders/{order-id}/refunds");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "order-id", orderId }
            });

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = APIHelper.GetHeader();

            var _body = APIHelper.JsonSerialize(body);

            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.RefundBankAccountResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.RefundCCResponse GetCCRefund(string refundId)
        {
            Task<Models.RefundCCResponse> t = GetCCRefundAsync(refundId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.RefundCCResponse> GetCCRefundAsync(string refundId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/refunds/{refund-id}");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "refund-id", refundId }
            });

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.RefundCCResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.RefundBankAccountResponse GetBankAccountRefund(string refundId)
        {
            Task<Models.RefundBankAccountResponse> t = GetBankAccountRefundAsync(refundId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.RefundBankAccountResponse> GetBankAccountRefundAsync(string refundId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/refunds/{refund-id}");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "refund-id", refundId }
            });

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.RefundBankAccountResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.RefundCCResponse CreateOrder(string orderId, Models.RefundCCRequest body)
        {
            Task<Models.RefundCCResponse> t = CreateOrderAsync(orderId, body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.RefundCCResponse> CreateOrderAsync(string orderId, Models.RefundCCRequest body)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/orders/{order-id}/refunds");

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
                return APIHelper.JsonDeserialize<Models.RefundCCResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.RefundsListResponse ListPaymentRefunds(string paymentId)
        {
            Task<Models.RefundsListResponse> t = ListPaymentRefundsAsync(paymentId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.RefundsListResponse> ListPaymentRefundsAsync(string paymentId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/payments/{payment-id}/refunds");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "payment-id", paymentId }
            });

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.RefundsListResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.RefundsListResponse ListOrderRefunds(string orderId)
        {
            Task<Models.RefundsListResponse> t = ListOrderRefundsAsync(orderId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.RefundsListResponse> ListOrderRefundsAsync(string orderId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/orders/{order-id}/refunds");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "order-id", orderId }
            });

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.RefundsListResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
}
