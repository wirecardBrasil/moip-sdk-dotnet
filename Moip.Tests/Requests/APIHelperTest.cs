using Moip;
using NUnit.Framework;
using System.Collections.Generic;
using Moip;
using Moip.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Moip.Tests
{
    [TestFixture]
    public class APIHelperTest : ControllerTestBase
    {
        [Test]
        public void TestHeader()
        {
            Dictionary<string, string> expectedPostHeader = new Dictionary<string, string>()
            {
                { "user-agent", string.Format("MoipDotnetSDK/{0} (+https://github.com/moip/moip-sdk-dotnet)", Moip.Utilities.APIHelper.GetVersion()) },
                { "accept", "application/json" },
                { "Authorization", "Bearer " + "d6bc80acbce6409b8b4cad5ceee62bc0_v2" },
                { "content-type", "application/json; charset=utf-8" }
            };

            Dictionary<string, string> header = Moip.Utilities.APIHelper.GetHeader();

            Assert.AreEqual(expectedPostHeader, header, "Should match exactly header");

        }

        [Test]
        public void TestGetOrderListUrl()
        {
            string url = Moip.Utilities.APIHelper.GetBuiltUrl("order");

            string expectedUrl = "https://sandbox.moip.com.br/v2/orders";

            Assert.AreEqual(expectedUrl, url, "Should match exactly url");

        }

        [Test]
        public void TestGetPaymentUrl()
        {

            string paymentId = "PAY-Y2KHB8QWXW5J";

            string url = Moip.Utilities.APIHelper.GetBuiltUrl("payment", "PAY-Y2KHB8QWXW5J");

            string expectedUrl = "https://sandbox.moip.com.br/v2/payments/" + paymentId;

            Assert.AreEqual(expectedUrl, url, "Should match exactly url");

        }

    }
}
