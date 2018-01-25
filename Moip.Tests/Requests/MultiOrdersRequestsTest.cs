using Moip.Controllers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Moip.Tests
{
    [TestFixture]
    public class MultiOrdersRequestsTest : ControllerTestBase
    {

        private static MultiOrdersController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().MultiOrders;
        }

        [Test]
        public void TestMultiOrderRequest()
        {

            Moip.Models.MultiorderRequest multiorderRequest = Helpers.RequestsCreator.CreateMultiorderRequest();

            string multiorderRequestJson = Moip.Utilities.APIHelper.JsonSerialize(multiorderRequest);

            string expectedMultiorderRequestJson = Helpers.FileReader.readJsonFile(@"Multiorder\multiorder.json");

            Assert.AreEqual(expectedMultiorderRequestJson, multiorderRequestJson,
                "Order request body should match exactly (string literal match)");
        }
    }
}
