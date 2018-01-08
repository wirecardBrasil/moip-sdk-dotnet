using Moip.Controllers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Moip.Tests
{
    [TestFixture]
    public class RefundsRequestsTest : ControllerTestBase
    {

        private static RefundsController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Refunds;
        }

        [Test]
        public void TestCreateCCFullRefundRequest()
        {

            Moip.Models.RefundCCRequest refundRequest = Helpers.RequestsCreator.CreateFullCCRefundRequest();

            string refundRequestJson = Newtonsoft.Json.JsonConvert.SerializeObject(refundRequest);

            string expectedRefundRequestJson = Helpers.FileReader.readJsonFile(@"Refund\payment_full_cc.json");

            Assert.AreEqual(expectedRefundRequestJson, refundRequestJson,
                "Refund request body should match exactly (string literal match)");

        }

        [Test]
        public void TestCreateCCPartialRefundRequest()
        {

            Moip.Models.RefundCCRequest refundRequest = Helpers.RequestsCreator.CreatePartialCCRefundRequest();

            string refundRequestJson = Newtonsoft.Json.JsonConvert.SerializeObject(refundRequest);

            string expectedRefundRequestJson = Helpers.FileReader.readJsonFile(@"Refund\payment_partial_cc.json");

            Assert.AreEqual(expectedRefundRequestJson, refundRequestJson,
                "Refund request body should match exactly (string literal match)");

        }

        [Test]
        public void TestCreateBankAccountFullRefundRequest()
        {

            Moip.Models.RefundBankAccountRequest refundRequest = Helpers.RequestsCreator.CreateFullBankAccountRefundRequest();

            string refundRequestJson = Newtonsoft.Json.JsonConvert.SerializeObject(refundRequest);

            string expectedRefundRequestJson = Helpers.FileReader.readJsonFile(@"Refund\payment_full_bankAccount.json");

            Assert.AreEqual(expectedRefundRequestJson, refundRequestJson,
                "Refund request body should match exactly (string literal match)");

        }

        [Test]
        public void TestCreateBankAccountPartialRefundRequest()
        {
            Moip.Models.RefundBankAccountRequest refundRequest = Helpers.RequestsCreator.CreatePartialBankAccountRefundRequest();

            string refundRequestJson = Newtonsoft.Json.JsonConvert.SerializeObject(refundRequest);

            string expectedRefundRequestJson = Helpers.FileReader.readJsonFile(@"Refund\payment_partial_bankAccount.json");

            Assert.AreEqual(expectedRefundRequestJson, refundRequestJson,
                "Refund request body should match exactly (string literal match)");

        }
    }
}
