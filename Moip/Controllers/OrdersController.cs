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
    public partial class OrdersController : BaseController
    {
        #region Singleton Pattern

        private static object syncObject = new object();
        private static OrdersController instance = null;

        internal static OrdersController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new OrdersController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        public Models.OrderResponse CreateOrder(Models.OrderRequest bodyy)
        {
            Task<Models.OrderResponse> t = CreateOrderAsync(bodyy);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.OrderResponse> CreateOrderAsync(Models.OrderRequest bodyy)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/orders");

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            var _body = APIHelper.JsonSerialize(bodyy);

            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.OrderResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public dynamic GetOrder(string orderId)
        {
            Task<Models.OrderResponse> t = GetOrderAsync(orderId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.OrderResponse> GetOrderAsync(string orderId)
        {

            string _queryUrl = Utilities.APIHelper.GetBuiltUrl("order", orderId);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.OrderResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.OrderListResponse ListOrders()
        {
            Task<Models.OrderListResponse> t = ListOrdersAsync();
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.OrderListResponse> ListOrdersAsync()
        {

            string _queryUrl = Utilities.APIHelper.GetBuiltUrl("order");

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.OrderListResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
}
