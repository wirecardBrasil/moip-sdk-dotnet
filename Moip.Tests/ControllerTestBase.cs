using Moip;
using Moip.Tests.Helpers;
using NUnit.Framework;
using System;

namespace Moip.Tests
{

    [TestFixture]
    public class ControllerTestBase
    {
        public static string oauth = "d6bc80acbce6409b8b4cad5ceee62bc0_v2";

        public const int REQUEST_TIMEOUT = 60;
        protected const double ASSERT_PRECISION = 0.1;
        public TimeSpan globalTimeout = TimeSpan.FromSeconds(REQUEST_TIMEOUT);

        protected HttpCallBackEventsHandler httpCallBackHandler = new HttpCallBackEventsHandler();

        [SetUp]
        public void SetUp()
        {
            
            GetClient().SharedHttpClient.OnBeforeHttpRequestEvent += httpCallBackHandler.OnBeforeHttpRequestEventHandler;
            GetClient().SharedHttpClient.OnAfterHttpResponseEvent += httpCallBackHandler.OnAfterHttpResponseEventHandler;
        }

        private static Client client;
        private static object clientSync = new object();

        public static Client GetClient()
        {
            lock (clientSync)
            {
                if (client == null)
                {
                    client = new Client(oauth, Configuration.Environments.SANDBOX);
                }
                return client;
            }
        }
    }
}