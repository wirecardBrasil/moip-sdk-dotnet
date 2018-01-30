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
    public partial class MultiOrdersController : BaseController
    {
        #region Singleton Pattern

        private static object syncObject = new object();
        private static MultiOrdersController instance = null;

        internal static MultiOrdersController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new MultiOrdersController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        public Models.MultiorderResponse CreateMultiorder(Models.MultiorderRequest body)
        {
            Task<Models.MultiorderResponse> t = CreateMultiorderAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.MultiorderResponse> CreateMultiorderAsync(Models.MultiorderRequest body)
        {
            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/multiorders");

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            var _body = APIHelper.JsonSerialize(body);

            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.MultiorderResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public dynamic GetMultiorder(string multiOrderId)
        {
            Task<Models.MultiorderResponse> t = GetMultiorderAsync(multiOrderId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.MultiorderResponse> GetMultiorderAsync(string multiOrderId)
        {

            string _queryUrl = Utilities.APIHelper.GetBuiltUrl("multiorder", multiOrderId);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.MultiorderResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }
    }
}
