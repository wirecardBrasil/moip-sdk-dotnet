using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Moip.Utilities
{
    public static class APIHelper
    {
        public static string DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        public static string JsonSerialize(object obj, JsonSerializerSettings settings = null)
        {
            if (null == obj)
                return null;
            if (settings == null)
            {
                settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                return JsonConvert.SerializeObject(obj, Formatting.None, settings);
            }
            else
                return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        public static string JsonSerialize(object obj, JsonConverter converter)
        {
            if (null == obj)
                return null;

            return JsonConvert.SerializeObject(obj, Formatting.None, converter);
        }

        public static T JsonDeserialize<T>(string json, JsonConverter converter = null)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);
            if (converter == null)
                return JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter());
            else
                return JsonConvert.DeserializeObject<T>(json, converter);
        }

        public static void AppendUrlWithTemplateParameters
            (StringBuilder queryBuilder, IEnumerable<KeyValuePair<string, object>> parameters)
        {

            if (null == queryBuilder)
                throw new ArgumentNullException("queryBuilder");

            if (null == parameters)
                return;

            foreach (KeyValuePair<string, object> pair in parameters)
            {
                string replaceValue = string.Empty;

                if (null == pair.Value)
                    replaceValue = "";
                else if (pair.Value is ICollection)
                    replaceValue = flattenCollection(pair.Value as ICollection, ArrayDeserialization.None, '/', false);
                else if (pair.Value is DateTime)
                    replaceValue = ((DateTime)pair.Value).ToString(DateTimeFormat);
                else if (pair.Value is DateTimeOffset)
                    replaceValue = ((DateTimeOffset)pair.Value).ToString(DateTimeFormat);
                else
                    replaceValue = pair.Value.ToString();

                replaceValue = Uri.EscapeUriString(replaceValue);

                queryBuilder.Replace(string.Format("{{{0}}}", pair.Key), replaceValue);
            }
        }

        public static void AppendUrlWithQueryParameters
            (StringBuilder queryBuilder, IEnumerable<KeyValuePair<string, object>> parameters, ArrayDeserialization arrayDeserializationFormat = ArrayDeserialization.UnIndexed, char separator = '&')
        {

            if (null == queryBuilder)
                throw new ArgumentNullException("queryBuilder");

            if (null == parameters)
                return;

            bool hasParams = (indexOf(queryBuilder, "?") > 0);

            foreach (KeyValuePair<string, object> pair in parameters)
            {

                if (pair.Value == null)
                    continue;

                queryBuilder.Append((hasParams) ? '&' : '?');

                hasParams = true;

                string paramKeyValPair;

                if (pair.Value is ICollection)
                    paramKeyValPair = flattenCollection(pair.Value as ICollection, arrayDeserializationFormat, separator, true, pair.Key);
                else if (pair.Value is DateTime)
                    paramKeyValPair = string.Format("{0}={1}", Uri.EscapeDataString(pair.Key), ((DateTime)pair.Value).ToString(DateTimeFormat));
                else if (pair.Value is DateTimeOffset)
                    paramKeyValPair = string.Format("{0}={1}", Uri.EscapeDataString(pair.Key), ((DateTimeOffset)pair.Value).ToString(DateTimeFormat));
                else
                    paramKeyValPair = string.Format("{0}={1}", Uri.EscapeDataString(pair.Key), Uri.EscapeDataString(pair.Value.ToString()));

                queryBuilder.Append(paramKeyValPair);
            }
        }

        private static int indexOf(StringBuilder stringBuilder, string strCheck)
        {
            if (stringBuilder == null)
                throw new ArgumentNullException("stringBuilder");

            if (strCheck == null)
                return 0;

            for (int inputCounter = 0; inputCounter < stringBuilder.Length; inputCounter++)
            {
                int matchCounter;

                for (matchCounter = 0;
                        (matchCounter < strCheck.Length)
                        && (inputCounter + matchCounter < stringBuilder.Length)
                        && (stringBuilder[inputCounter + matchCounter] == strCheck[matchCounter]);
                    matchCounter++) ;

                if (matchCounter == strCheck.Length)
                    return inputCounter;
            }

            return -1;
        }

        public static string CleanUrl(StringBuilder queryBuilder)
        {

            string url = queryBuilder.ToString();

            Match match = Regex.Match(url, "^https?://[^/]+");
            if (!match.Success)
                throw new ArgumentException("Invalid Url format.");

            int index = url.IndexOf('?');
            string protocol = match.Value;
            string query = url.Substring(protocol.Length, (index == -1 ? url.Length : index) - protocol.Length);
            query = Regex.Replace(query, "//+", "/");
            string parameters = index == -1 ? "" : url.Substring(index);

            return string.Concat(protocol, query, parameters); ;
        }

        private static string flattenCollection(ICollection array, ArrayDeserialization fmt, char separator,
            bool urlEncode, string key = "")
        {
            StringBuilder builder = new StringBuilder();

            string format = string.Empty;
            if (fmt == ArrayDeserialization.UnIndexed)
                format = String.Format("{0}[]={{0}}{{1}}", key);
            else if (fmt == ArrayDeserialization.Indexed)
                format = String.Format("{0}[{{2}}]={{0}}{{1}}", key);
            else if (fmt == ArrayDeserialization.Plain)
                format = String.Format("{0}={{0}}{{1}}", key);
            else if (fmt == ArrayDeserialization.Csv || fmt == ArrayDeserialization.Psv ||
                     fmt == ArrayDeserialization.Tsv)
            {
                builder.Append(String.Format("{0}=", key));
                format = "{0}{1}";
            }
            else
                format = "{0}{1}";

            int index = 0;
            foreach (object element in array)
                builder.AppendFormat(format, getElementValue(element, urlEncode), separator, index++);

            if ((builder.Length > 1) && (builder[builder.Length - 1] == separator))
                builder.Length -= 1;

            return builder.ToString();
        }

        private static string getElementValue(object element, bool urlEncode)
        {
            string elemValue = null;

            if (null == element)
                elemValue = string.Empty;
            else if (element is DateTime)
                elemValue = ((DateTime)element).ToString(DateTimeFormat);
            else if (element is DateTimeOffset)
                elemValue = ((DateTimeOffset)element).ToString(DateTimeFormat);
            else
                elemValue = element.ToString();

            if (urlEncode)
                elemValue = Uri.EscapeDataString(elemValue);
            return elemValue;
        }

        public static List<KeyValuePair<string, object>> PrepareFormFieldsFromObject(
            string name, object value, List<KeyValuePair<string, object>> keys = null, PropertyInfo propInfo = null, ArrayDeserialization arrayDeserializationFormat = ArrayDeserialization.UnIndexed)
        {
            keys = keys ?? new List<KeyValuePair<string, object>>();

            if (value == null)
            {
                return keys;
            }
            else if (value is Stream)
            {
                keys.Add(new KeyValuePair<string, object>(name, value));
                return keys;
            }
            else if (value is JObject)
            {
                var valueAccept = (value as JObject);
                foreach (var property in valueAccept.Properties())
                {
                    string pKey = property.Name;
                    object pValue = property.Value;
                    var fullSubName = name + '[' + pKey + ']';
                    PrepareFormFieldsFromObject(fullSubName, pValue, keys, propInfo, arrayDeserializationFormat);
                }
            }
            else if (value is IList)
            {
                int i = 0;
                var enumerator = ((IEnumerable)value).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var subValue = enumerator.Current;
                    if (subValue == null) continue;
                    var fullSubName = name + '[' + i + ']';
                    if (arrayDeserializationFormat == ArrayDeserialization.UnIndexed)
                        fullSubName = name + "[]";
                    else if (arrayDeserializationFormat == ArrayDeserialization.Plain)
                        fullSubName = name;
                    PrepareFormFieldsFromObject(fullSubName, subValue, keys, propInfo, arrayDeserializationFormat);
                    i++;
                }
            }
            else if (value is JToken)
            {
                keys.Add(new KeyValuePair<string, object>(name, value.ToString()));
            }
            else if (value is Enum)
            {
#if WINDOWS_UWP || NETSTANDARD1_3
                Assembly thisAssembly = typeof(APIHelper).GetTypeInfo().Assembly;
#else
                Assembly thisAssembly = Assembly.GetExecutingAssembly();
#endif
                string enumTypeName = value.GetType().FullName;
                Type enumHelperType = thisAssembly.GetType(string.Format("{0}Helper", enumTypeName));
                object enumValue = (int)value;

                if (enumHelperType != null)
                {

#if NETSTANDARD1_3
                    MethodInfo enumHelperMethod = enumHelperType.GetRuntimeMethod("ToValue", new[] { value.GetType() });
#else
                    MethodInfo enumHelperMethod = enumHelperType.GetMethod("ToValue", new[] { value.GetType() });
#endif
                    if (enumHelperMethod != null)
                        enumValue = enumHelperMethod.Invoke(null, new object[] { value });
                }

                keys.Add(new KeyValuePair<string, object>(name, enumValue));
            }
            else if (value is IDictionary)
            {
                var obj = (IDictionary)value;
                foreach (var sName in obj.Keys)
                {
                    var subName = sName.ToString();
                    var subValue = obj[subName];
                    string fullSubName = string.IsNullOrWhiteSpace(name) ? subName : name + '[' + subName + ']';
                    PrepareFormFieldsFromObject(fullSubName, subValue, keys, propInfo, arrayDeserializationFormat);
                }
            }
            else if (!(value.GetType().Namespace.StartsWith("System")))
            {

#if NETSTANDARD1_3
                var enumerator = value.GetType().GetRuntimeProperties().GetEnumerator();
#else
                var enumerator = value.GetType().GetProperties().GetEnumerator(); ;
#endif
                PropertyInfo pInfo = null;
                var t = new JsonPropertyAttribute().GetType();
                while (enumerator.MoveNext())
                {
                    pInfo = enumerator.Current as PropertyInfo;

                    var jsonProperty = (JsonPropertyAttribute)pInfo.GetCustomAttributes(t, true).FirstOrDefault();
                    var subName = (jsonProperty != null) ? jsonProperty.PropertyName : pInfo.Name;
                    string fullSubName = string.IsNullOrWhiteSpace(name) ? subName : name + '[' + subName + ']';
                    var subValue = pInfo.GetValue(value, null);
                    PrepareFormFieldsFromObject(fullSubName, subValue, keys, pInfo, arrayDeserializationFormat);
                }
            }
            else if (value is DateTime)
            {
                string convertedValue = null;
#if NETSTANDARD1_3
                IEnumerable<Attribute> pInfo = null;
#else
                object[] pInfo = null;
#endif
                if (propInfo != null)
                    pInfo = propInfo.GetCustomAttributes(true);
                if (pInfo != null)
                {
                    foreach (object attr in pInfo)
                    {
                        JsonConverterAttribute converterAttr = attr as JsonConverterAttribute;
                        if (converterAttr != null)
                            convertedValue =
                                JsonSerialize(value,
                                    (JsonConverter)
                                        Activator.CreateInstance(converterAttr.ConverterType,
                                            converterAttr.ConverterParameters)).Replace("\"", "");
                    }
                }
                keys.Add(new KeyValuePair<string, object>(name, (convertedValue) ?? ((DateTime)value).ToString(DateTimeFormat)));
            }
            else
            {
                keys.Add(new KeyValuePair<string, object>(name, value));
            }
            return keys;
        }

        public static void Add(this Dictionary<string, object> dictionary, Dictionary<string, object> dictionary2)
        {
            foreach (var kvp in dictionary2)
            {
                dictionary[kvp.Key] = kvp.Value;
            }
        }

        public static void RunTaskSynchronously(Task t)
        {
            try
            {
                Task.WaitAll(t);
            }
            catch (AggregateException e)
            {
                if (e.InnerExceptions.Count > 0)
                    throw e.InnerExceptions[0];
                else
                    throw;
            }
        }

        public static Dictionary<string, string> GetHeader()
        {
            var _headers = new Dictionary<string, string>();
            _headers.Add("user-agent", "Moip.NETSDK");
            _headers.Add("accept", "application/json");
            _headers.Add("Authorization", string.Format("Bearer {0}", Configuration.OAuthAccessToken));
            _headers.Add("content-type", "application/json; charset=utf-8");

            return _headers;
        }

        public static string GetBuiltUrl(string resource, string resourceId = null)
        {

            string _baseUri = Configuration.GetBaseURI();

            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.AppendFormat("/{0}s", resource);

            if (resourceId != null)
                _queryBuilder.AppendFormat("/{0}", resourceId);

            if (resourceId != null)
            {

                APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { resource + "-id", resourceId }
            });

            }

            return APIHelper.CleanUrl(_queryBuilder);

        }
    }
}
