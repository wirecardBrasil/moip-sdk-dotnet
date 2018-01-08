using Moip.Controllers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Moip.Tests
{
    [TestFixture]
    public class PaymentsRequestsTest : ControllerTestBase
    {

        private static PaymentsController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Payments;
        }

        [Test]
        public void TestPaymentWithCreditCardRequest()
        {

            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithCCRequest();

            string paymentRequestJson = Newtonsoft.Json.JsonConvert.SerializeObject(paymentRequest);

            string expectedPaymentRequestJson = Helpers.FileReader.readJsonFile(@"Payment\payment_with_credit_card.json");

            Assert.AreEqual(expectedPaymentRequestJson, paymentRequestJson,
                "Payment request body should match exactly (string literal match)");
        }

        [Test]
        public void TestPaymentWithBoletoRequest()
        {

            Moip.Models.PaymentBoletoOrDebitRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithBoletoRequest();

            string paymentRequestJson = Newtonsoft.Json.JsonConvert.SerializeObject(paymentRequest);

            string expectedPaymentRequestJson = Helpers.FileReader.readJsonFile(@"Payment\payment_with_boleto.json");

            Assert.AreEqual(expectedPaymentRequestJson, paymentRequestJson,
                "Payment request body should match exactly (string literal match)");
        }

        [Test]
        public void TestPaymentWithOnlineDebitRequest()
        {

            Moip.Models.PaymentBoletoOrDebitRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithOnlineDebitRequest();

            string paymentRequestJson = Newtonsoft.Json.JsonConvert.SerializeObject(paymentRequest);

            string expectedPaymentRequestJson = Helpers.FileReader.readJsonFile(@"Payment\payment_with_online_debit.json");

            Assert.AreEqual(expectedPaymentRequestJson, paymentRequestJson,
                "Payment request body should match exactly (string literal match)");
        }

        [Test]
        public void TestPaymentWithPreAuthorizationRequest()
        {

            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithPreAuthorizationRequest();

            string paymentRequestJson = Newtonsoft.Json.JsonConvert.SerializeObject(paymentRequest);

            string expectedPaymentRequestJson = Helpers.FileReader.readJsonFile(@"Payment\payment_with_pre_authorization.json");

            Assert.AreEqual(expectedPaymentRequestJson, paymentRequestJson,
                "Payment request body should match exactly (string literal match)");
        }

    }
}
