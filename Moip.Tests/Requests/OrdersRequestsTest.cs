using Moip.Controllers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Moip.Tests
{
    [TestFixture]
    public class OrdersRequestsTest : ControllerTestBase
    {

        private static OrdersController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Orders;
        }

        [Test]
        public void TestOrderRequest()
        {

            Moip.Models.OrderRequest orderRequest = Helpers.RequestsCreator.createOrderRequest();

            string orderRequestJson = Newtonsoft.Json.JsonConvert.SerializeObject(orderRequest);

            string expectedOrderRequestJson = Helpers.FileReader.readJsonFile(@"Order\order.json");

            Assert.AreEqual(expectedOrderRequestJson, orderRequestJson,
                "Order request body should match exactly (string literal match)");
        }

        [Test]
        public void TestOrderWithReceiversRequest()
        {

            Moip.Models.OrderRequest orderRequest = Helpers.RequestsCreator.createOrderWithReceiversRequest();

            string orderRequestJson = Newtonsoft.Json.JsonConvert.SerializeObject(orderRequest);

            string expectedOrderRequestJson = Helpers.FileReader.readJsonFile(@"Order\order_with_receivers.json");

            Assert.AreEqual(expectedOrderRequestJson, orderRequestJson,
                "Order request body should match exactly (string literal match)");
        }

    }
}
