using Moip.Http.Client;
using Moip.Http.Request;
using Moip.Http.Response;
using Moip.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace Moip.Tests.Helpers
{
    static class TestHelper
    {
        internal static string ConvertStreamToString(Stream inStream)
        {
            using (StreamReader reader = new StreamReader(inStream))
            {
                var str = reader.ReadToEnd();
                return str;
            }
        }

        private static bool IsProperSubsetOf(
            JObject leftTree,
            JObject rightTree,
            bool checkValues, bool allowExtra, bool isOrdered)
        {
            foreach (var property in leftTree.Properties())
            {

                if (rightTree.Property(property.Name) == null)
                    return false;

                object leftVal = property.Value;
                object rightVal = rightTree.Property(property.Name).Value;

                if (leftVal is JObject)
                {
                    // If left value is tree, right value should be be tree too
                    if (rightVal is JObject)
                    {
                        if (!IsProperSubsetOf(
                                (JObject)leftVal,
                                (JObject)rightVal,
                                checkValues, allowExtra, isOrdered))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    if (checkValues)
                    {
                        // If left value is a primitive, check if it equals right value
                        if (leftVal == null)
                        {
                            if (rightVal != null)
                            {
                                return false;
                            }
                        }
                        else if (leftVal is JArray)
                        {
                            if (!(rightVal is JArray))
                                return false;

                            if (((JArray)leftVal).First is JObject)
                            {
                                if (!IsArrayOfJsonObjectsProperSubsetOf(
                                        (JArray)leftVal,
                                        (JArray)rightVal,
                                        checkValues, allowExtra, isOrdered))
                                    return false;
                            }
                            else
                            {
                                if (!IsListProperSubsetOf(
                                        (JArray)leftVal,
                                        (JArray)rightVal,
                                        allowExtra, isOrdered))
                                    return false;
                            }
                        }
                        else if (!leftVal.Equals(rightVal))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static bool IsArrayOfJsonObjectsProperSubsetOf(
            string leftObject, string rightObject,
            bool checkValues, bool allowExtra, bool isOrdered)
        {

            JArray left = APIHelper.JsonDeserialize<dynamic>(leftObject);
            JArray right = APIHelper.JsonDeserialize<dynamic>(rightObject);

            return IsArrayOfJsonObjectsProperSubsetOf(left, right, checkValues, allowExtra, isOrdered);
        }

        public static bool IsArrayOfJsonObjectsProperSubsetOf(
                JArray leftList,
                JArray rightList,
                bool checkValues, bool allowExtra, bool isOrdered)
        {

            if ((!allowExtra) && (rightList.Count != leftList.Count))
                return false;

            var leftIter = leftList.GetEnumerator();
            var rightIter = rightList.GetEnumerator();

            while (leftIter.MoveNext())
            {
                var leftTree = leftIter.Current;
                bool found = false;

                if (!isOrdered)
                    rightIter = rightList.GetEnumerator();

                while (rightIter.MoveNext())
                {
                    if (IsProperSubsetOf((JObject)leftTree, (JObject)rightIter.Current, checkValues, allowExtra, isOrdered))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    return false;
            }

            return true;
        }

        public static bool IsListProperSubsetOf(string leftListJson, string rightListJson,
                bool allowExtra, bool isOrdered)
        {

            JArray left = APIHelper.JsonDeserialize<dynamic>(leftListJson);
            JArray right = APIHelper.JsonDeserialize<dynamic>(rightListJson);

            return IsListProperSubsetOf(left, right, allowExtra, isOrdered);
        }

        public static bool IsListProperSubsetOf(JArray leftList, JArray rightList,
                bool allowExtra, bool isOrdered)
        {
            if (isOrdered)
            {
                if ((!allowExtra) && (rightList.Count != leftList.Count))
                    return false;

                else if (rightList.Count < leftList.Count)
                    return false;

                int rIndex = 0, lIndex = 0;
                while (rIndex < rightList.Count)
                {
                    if(rightList[rIndex].ToString() == leftList[lIndex].ToString())
                    {
                        lIndex++;
                    }
                    rIndex++;
                }

                return (lIndex == leftList.Count);
            }
            else
            {
                if ((!allowExtra) && (rightList.Count != leftList.Count))
                    return false;

                HashSet<object> rHashSet = new HashSet<object>(rightList);
                return rHashSet.IsSupersetOf(leftList);
            }
        }

        internal static bool IsJsonObjectProperSubsetOf(string leftObject, string rightObject,
                bool checkValues, bool allowExtra, bool isOrdered)
        {
            return IsProperSubsetOf(
                APIHelper.JsonDeserialize<dynamic>(leftObject),
                APIHelper.JsonDeserialize<dynamic>(rightObject),
                checkValues, allowExtra, isOrdered);
        }

        public static bool AreHeadersProperSubsetOf(
            Dictionary<string, string> leftDict, Dictionary<string, string> rightDict)
        {
            Dictionary<string, string> leftDictInv = new Dictionary<string, string>(leftDict, StringComparer.CurrentCultureIgnoreCase);
            Dictionary<string, string> rightDictInv = new Dictionary<string, string>(rightDict, StringComparer.CurrentCultureIgnoreCase);
            foreach (var leftKey in leftDictInv.Keys)
            {
                if (!leftDictInv.ContainsKey(leftKey))
                    return false;

                if (null == leftDictInv[leftKey])
                    continue;

                if (!leftDictInv[leftKey].Equals(rightDictInv[leftKey]))
                    return false;
            }
            return true;
        }

        public static bool IsSameAsFile(string file, Stream input)
        {
            return IsSameInputStream(GetFile(file).FileStream, input);
        }

        public static bool IsSameInputStream(Stream input1, Stream input2)
        {
            if (input1 == input2)
            {
                return true;
            }

            int ch = input1.ReadByte();
            while (ch != -1)
            {
                int ch2 = input2.ReadByte();
                if (ch != ch2)
                {
                    return false;
                }
                ch = input1.ReadByte();
            }

            bool input2Finished = (input2.ReadByte() == -1);

            try { input1.Dispose(); } catch { }
            try { input2.Dispose(); } catch { }

            return input2Finished;
        }

        public static FileStreamInfo GetFile(string url)
        {
            string originalFileName = Path.GetFileName(url);
            string filename = "sdk_tests" + toSHA1(url) + ".tmp";
            string tmpPath = Path.GetTempPath();
            string filePath = Path.Combine(tmpPath, filename);
            FileInfo fileInfo = new FileInfo(filePath);
            FileStream fileStream = null;

            // if file does not exist locally, download it
            if (!fileInfo.Exists)
            {
                IHttpClient client = ControllerTestBase.GetClient().SharedHttpClient;
                HttpRequest req = client.Get(url, null, null);
                req.Headers = new Dictionary<string, string>
                {
                    {"user-agent", "Moip.NETSDK" }
                };

                HttpResponse resp = client.ExecuteAsBinary(req);
                fileStream = System.IO.File.Create(filePath);
                byte[] buffer = new byte[2048];
                int len = resp.RawBody.Read(buffer, 0, 2048);

                while (len > 0)
                {
                    fileStream.Write(buffer, 0, len);
                    len = resp.RawBody.Read(buffer, 0, 2048);
                }
                fileStream.Position = 0;
            }
            else
            {
                fileStream = System.IO.File.OpenRead(filePath);
            }

            return new FileStreamInfo(fileStream, originalFileName);
        }

        public static string toSHA1(string convertme)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(convertme);
            using (var sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(bytes);
                return ByteArrayToHexString(hashBytes);
            }
        }

        public static string ByteArrayToHexString(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

        public static bool IsSuperSetOf<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            HashSet<T> lHashSet = new HashSet<T>(left);
            return lHashSet.IsSupersetOf(right);
        }

        public static bool IsOrderedSupersetOf<T>(this IEnumerable<T> left, IEnumerable<T> right, bool checkSize = false)
        {
            var lItr = left.GetEnumerator();
            var rItr = right.GetEnumerator();

            while(lItr.MoveNext())
            {
                T lCurrent = lItr.Current;

                if (!rItr.MoveNext())
                    return false;

                T rCurrent = rItr.Current;

                if (!lCurrent.Equals(rCurrent))
                    return false;
            }

            if(checkSize)
            {
                //right items should have been exhaustively read?
                if (rItr.MoveNext())
                    return false;
            }

            return true;
        }

        public static void AuthorizePayment(string paymentId, int amount)
        {
            HttpClient client = new HttpClient();
            string uri = "https://sandbox.moip.com.br/simulador/authorize?payment_id=" + paymentId + "&amount=" + amount;

            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "Moip.NETSDK" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };
            _headers.Add("Authorization", string.Format("Bearer {0}", ControllerTestBase.oauth));

            var responseString = client.GetAsync(uri);

        }
    }
}
