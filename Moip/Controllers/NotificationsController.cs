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
    public partial class NotificationsController : BaseController
    {
        #region Singleton Pattern

        private static object syncObject = new object();
        private static NotificationsController instance = null;

        internal static NotificationsController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new NotificationsController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        public List<Models.NotificationPreferenceResponse> ListNotificationsPreferences()
        {
            Task<List<Models.NotificationPreferenceResponse>> t = ListNotificationsPreferencesAsync();
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<List<Models.NotificationPreferenceResponse>> ListNotificationsPreferencesAsync()
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/preferences/notifications");

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<List<Models.NotificationPreferenceResponse>>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public bool DeleteNotificationPreference(string notificationPreferenceId)
        {
            Task<bool> t = DeleteNotificationPreferenceAsync(notificationPreferenceId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<bool> DeleteNotificationPreferenceAsync(string notificationPreferenceId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/preferences/notifications/{notificationPreference-id}");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "notificationPreference-id", notificationPreferenceId }
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

        public Models.NotificationPreferenceResponse CreateNotificationPreference(Models.NotificationPreferenceRequest body)
        {
            Task<Models.NotificationPreferenceResponse> t = CreateNotificationPreferenceAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.NotificationPreferenceResponse> CreateNotificationPreferenceAsync(Models.NotificationPreferenceRequest body)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/preferences/notifications");

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            var _body = APIHelper.JsonSerialize(body);

            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.NotificationPreferenceResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.NotificationPreferenceResponse GetNotificationPreference(string notificationPreferenceId)
        {
            Task<Models.NotificationPreferenceResponse> t = GetNotificationPreferenceAsync(notificationPreferenceId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.NotificationPreferenceResponse> GetNotificationPreferenceAsync(string notificationPreferenceId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/preferences/notifications/{notificationPreference-id}");

            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "notificationPreference-id", notificationPreferenceId }
            });

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.NotificationPreferenceResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public Models.WebhooksResponse ListWebhooks()
        {
            Task<Models.WebhooksResponse> t = ListWebhooksAsync();
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<Models.WebhooksResponse> ListWebhooksAsync()
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/webhooks");

            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            var _headers = Utilities.APIHelper.GetHeader();

            HttpRequest _request = ClientInstance.Get(_queryUrl, _headers);

            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.WebhooksResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        public dynamic GetWebhooks(string resourceId)
        {
            Task<dynamic> t = GetWebhooksAsync(resourceId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        public async Task<dynamic> GetWebhooksAsync(string resourceId)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/webhooks");

            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "resourceId", resourceId }
            }, ArrayDeserializationFormat, ParameterSeparator);

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

    }
}
