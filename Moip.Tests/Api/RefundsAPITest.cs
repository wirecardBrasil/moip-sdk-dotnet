using Moip.Controllers;
using NUnit.Framework;
using System.Threading;

namespace Moip.Tests
{
    [TestFixture]
    public class RefundsAPITest : ControllerTestBase
    {

        private static RefundsController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Refunds;
        }

        [Test]
        public void TestCreateFullPaymentRefundCC()
        {

            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithCCRequest();

            string paymentId = GetClient().Payments.CreateCreditCard(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest).Id;

            Thread.Sleep(1000);

            Moip.Models.RefundCCRequest refundRequest = Helpers.RequestsCreator.CreateFullCCRefundRequest();

            Moip.Models.RefundCCResponse refundResponse = controller.CreatePayment(paymentId, refundRequest);

            Assert.NotNull(refundResponse.Id, "Id should not be null");
            Assert.AreEqual(2000, refundResponse.Amount.Total, "Should match exactly (string literal match)");
            Assert.AreEqual("FULL", refundResponse.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("COMPLETED", refundResponse.Status, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", refundResponse.RefundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("MASTERCARD", refundResponse.RefundingInstrument.CreditCard.Brand, "Should match exactly (string literal match)");
            Assert.AreEqual("555566", refundResponse.RefundingInstrument.CreditCard.First6, "Should match exactly (string literal match)");
            Assert.AreEqual("8884", refundResponse.RefundingInstrument.CreditCard.Last4, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestCreatePartialPaymentRefundCC()
        {
            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithCCRequest();

            string paymentId = GetClient().Payments.CreateCreditCard(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest).Id;

            Thread.Sleep(1000);

            Moip.Models.RefundCCRequest refundRequest = Helpers.RequestsCreator.CreatePartialCCRefundRequest();

            Moip.Models.RefundCCResponse refundResponse = controller.CreatePayment(paymentId, refundRequest);

            Assert.NotNull(refundResponse.Id, "Id should not be null");
            Assert.AreEqual(100, refundResponse.Amount.Total, "Should match exactly (string literal match)");
            Assert.AreEqual("PARTIAL", refundResponse.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("COMPLETED", refundResponse.Status, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", refundResponse.RefundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("MASTERCARD", refundResponse.RefundingInstrument.CreditCard.Brand, "Should match exactly (string literal match)");
            Assert.AreEqual("555566", refundResponse.RefundingInstrument.CreditCard.First6, "Should match exactly (string literal match)");
            Assert.AreEqual("8884", refundResponse.RefundingInstrument.CreditCard.Last4, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestCreateFullOrderRefundCC()
        {
            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithCCRequest();

            string orderId = GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id;

            string paymentId = GetClient().Payments.CreateCreditCard(orderId, paymentRequest).Id;

            Thread.Sleep(1000);

            Moip.Models.RefundCCRequest refundRequest = Helpers.RequestsCreator.CreateFullCCRefundRequest();

            Moip.Models.RefundCCResponse refundResponse = controller.CreateOrder(orderId, refundRequest);

            Assert.NotNull(refundResponse.Id, "Id should not be null");
            Assert.AreEqual(2000, refundResponse.Amount.Total, "Should match exactly (string literal match)");
            Assert.AreEqual("FULL", refundResponse.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("COMPLETED", refundResponse.Status, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", refundResponse.RefundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("MASTERCARD", refundResponse.RefundingInstrument.CreditCard.Brand, "Should match exactly (string literal match)");
            Assert.AreEqual("555566", refundResponse.RefundingInstrument.CreditCard.First6, "Should match exactly (string literal match)");
            Assert.AreEqual("8884", refundResponse.RefundingInstrument.CreditCard.Last4, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestCreatePartialOrderRefundCC()
        {
            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithCCRequest();

            string orderId = GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id;

            string paymentId = GetClient().Payments.CreateCreditCard(orderId, paymentRequest).Id;

            Thread.Sleep(1000);

            Moip.Models.RefundCCRequest refundRequest = Helpers.RequestsCreator.CreatePartialCCRefundRequest();

            Moip.Models.RefundCCResponse refundResponse = controller.CreateOrder(orderId, refundRequest);

            Assert.NotNull(refundResponse.Id, "Id should not be null");
            Assert.AreEqual(100, refundResponse.Amount.Total, "Should match exactly (string literal match)");
            Assert.AreEqual("PARTIAL", refundResponse.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("COMPLETED", refundResponse.Status, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", refundResponse.RefundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("MASTERCARD", refundResponse.RefundingInstrument.CreditCard.Brand, "Should match exactly (string literal match)");
            Assert.AreEqual("555566", refundResponse.RefundingInstrument.CreditCard.First6, "Should match exactly (string literal match)");
            Assert.AreEqual("8884", refundResponse.RefundingInstrument.CreditCard.Last4, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestCreateFullPaymentRefundBankAccount()
        {
            Moip.Models.PaymentBoletoOrDebitRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithOnlineDebitRequest();

            string paymentId = GetClient().Payments.CreateBoletoOrDebit(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest).Id;

            Helpers.TestHelper.AuthorizePayment(paymentId, 2000);

            Thread.Sleep(1000);

            Moip.Models.RefundBankAccountRequest refundRequest = Helpers.RequestsCreator.CreateFullBankAccountRefundRequest();

            Moip.Models.RefundBankAccountResponse refundResponse = controller.CreatePaymentBankAccount(paymentId, refundRequest);

            Assert.NotNull(refundResponse.Id, "Id should not be null");
            Assert.AreEqual(2000, refundResponse.Amount.Total, "Should match exactly (string literal match)");
            Assert.AreEqual("FULL", refundResponse.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("REQUESTED", refundResponse.Status, "Should match exactly (string literal match)");
            Assert.AreEqual("341", refundResponse.RefundingInstrument.BankAccount.BankNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("BANCO ITAÚ S.A.", refundResponse.RefundingInstrument.BankAccount.BankName, "Should match exactly (string literal match)");
            Assert.AreEqual("4444444", refundResponse.RefundingInstrument.BankAccount.AgencyNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("2", refundResponse.RefundingInstrument.BankAccount.AgencyCheckNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("1234", refundResponse.RefundingInstrument.BankAccount.AccountNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("1", refundResponse.RefundingInstrument.BankAccount.AccountCheckNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("BANK_ACCOUNT", refundResponse.RefundingInstrument.Method, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestCreatePartialPaymentRefundBankAccount()
        {
            Moip.Models.PaymentBoletoOrDebitRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithOnlineDebitRequest();

            string paymentId = GetClient().Payments.CreateBoletoOrDebit(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest).Id;

            Helpers.TestHelper.AuthorizePayment(paymentId, 2000);

            Thread.Sleep(1000);

            Moip.Models.RefundBankAccountRequest refundRequest = Helpers.RequestsCreator.CreatePartialBankAccountRefundRequest();

            Moip.Models.RefundBankAccountResponse refundResponse = controller.CreatePaymentBankAccount(paymentId, refundRequest);

            Assert.NotNull(refundResponse.Id, "Id should not be null");
            Assert.AreEqual(100, refundResponse.Amount.Total, "Should match exactly (string literal match)");
            Assert.AreEqual("PARTIAL", refundResponse.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("REQUESTED", refundResponse.Status, "Should match exactly (string literal match)");
            Assert.AreEqual("341", refundResponse.RefundingInstrument.BankAccount.BankNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("BANCO ITAÚ S.A.", refundResponse.RefundingInstrument.BankAccount.BankName, "Should match exactly (string literal match)");
            Assert.AreEqual("4444444", refundResponse.RefundingInstrument.BankAccount.AgencyNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("2", refundResponse.RefundingInstrument.BankAccount.AgencyCheckNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("1234", refundResponse.RefundingInstrument.BankAccount.AccountNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("1", refundResponse.RefundingInstrument.BankAccount.AccountCheckNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("BANK_ACCOUNT", refundResponse.RefundingInstrument.Method, "Should match exactly (string literal match)");
        }

        [Test]
        public void TestGetRefund()
        {

            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithCCRequest();

            string paymentId = GetClient().Payments.CreateCreditCard(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest).Id;

            Thread.Sleep(1000);

            Moip.Models.RefundCCRequest refundRequest = Helpers.RequestsCreator.CreateFullCCRefundRequest();

            string refundId = controller.CreatePayment(paymentId, refundRequest).Id;

            Moip.Models.RefundCCResponse refundResponse = controller.GetCCRefund(refundId);

            Assert.NotNull(refundResponse.Id, "Id should not be null");
            Assert.AreEqual(2000, refundResponse.Amount.Total, "Should match exactly (string literal match)");
            Assert.AreEqual("FULL", refundResponse.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("COMPLETED", refundResponse.Status, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", refundResponse.RefundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("MASTERCARD", refundResponse.RefundingInstrument.CreditCard.Brand, "Should match exactly (string literal match)");
            Assert.AreEqual("555566", refundResponse.RefundingInstrument.CreditCard.First6, "Should match exactly (string literal match)");
            Assert.AreEqual("8884", refundResponse.RefundingInstrument.CreditCard.Last4, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestListPaymentRefunds()
        {
            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithCCRequest();

            string paymentId = GetClient().Payments.CreateCreditCard(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest).Id;

            Thread.Sleep(1000);

            Moip.Models.RefundCCRequest refundRequest1 = Helpers.RequestsCreator.CreatePartialCCRefundRequest();
            Moip.Models.RefundCCRequest refundRequest2 = Helpers.RequestsCreator.CreatePartialCCRefundRequest();

            Moip.Models.RefundCCResponse refundResponse1 = controller.CreatePayment(paymentId, refundRequest1);
            Moip.Models.RefundCCResponse refundResponse2 = controller.CreatePayment(paymentId, refundRequest2);

            Moip.Models.RefundsListResponse refundListResponse = controller.ListPaymentRefunds(paymentId);

            Assert.NotNull(refundListResponse.Refunds[0].Id, "Id should not be null");
            Assert.AreEqual("COMPLETED", refundListResponse.Refunds[0].Status, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", refundListResponse.Refunds[0].RefundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("MASTERCARD", refundListResponse.Refunds[0].RefundingInstrument.CreditCard.Brand, "Should match exactly (string literal match)");
            Assert.AreEqual("555566", refundListResponse.Refunds[0].RefundingInstrument.CreditCard.First6, "Should match exactly (string literal match)");
            Assert.AreEqual("8884", refundListResponse.Refunds[0].RefundingInstrument.CreditCard.Last4, "Should match exactly (string literal match)");
            Assert.True(refundListResponse.Refunds.Count > 1, "Should have more than one refund");

        }

    }
}
