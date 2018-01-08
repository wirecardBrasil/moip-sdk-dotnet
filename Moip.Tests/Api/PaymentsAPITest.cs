using Moip.Controllers;
using NUnit.Framework;
using System.Threading;

namespace Moip.Tests
{
    [TestFixture]
    public class PaymentsAPITest : ControllerTestBase
    {

        private static PaymentsController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Payments;
        }

        [Test]
        public void TestCreatePaymentWithCreditCard()
        {
            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithCCRequest();

            Moip.Models.PaymentResponse paymentResponse = controller.CreateCreditCard(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest);

            Assert.NotNull(paymentResponse.Id, "Id should not be null");
            Assert.AreEqual(1, paymentResponse.InstallmentCount, "Should match exactly (string literal match)");
            Assert.AreEqual("MyStore", paymentResponse.StatementDescriptor, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", paymentResponse.FundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("Jose Goku da Silva", paymentResponse.FundingInstrument.CreditCard.Holder.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("1988-12-30", paymentResponse.FundingInstrument.CreditCard.Holder.Birthdate, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", paymentResponse.FundingInstrument.CreditCard.Holder.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("33333333333", paymentResponse.FundingInstrument.CreditCard.Holder.TaxDocument.Number, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestCreatePaymentWithEscrow()
        {
            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithEscrowRequest();

            Moip.Models.PaymentResponse paymentResponse = controller.CreateCreditCard(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest);

            Assert.NotNull(paymentResponse.Id, "Id should not be null");
            Assert.NotNull(paymentResponse.Escrows[0].Id, "Escrow id should not be null");
            Assert.AreEqual("Escrow test", paymentResponse.Escrows[0].Description, "Should match exactly (string literal match)");
            Assert.AreEqual(1, paymentResponse.InstallmentCount, "Should match exactly (string literal match)");
            Assert.AreEqual("MyStore", paymentResponse.StatementDescriptor, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", paymentResponse.FundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("Jose Goku da Silva", paymentResponse.FundingInstrument.CreditCard.Holder.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("1988-12-30", paymentResponse.FundingInstrument.CreditCard.Holder.Birthdate, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", paymentResponse.FundingInstrument.CreditCard.Holder.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("33333333333", paymentResponse.FundingInstrument.CreditCard.Holder.TaxDocument.Number, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestCreatePaymentWithBoleto()
        {
            Moip.Models.PaymentBoletoOrDebitRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithBoletoRequest();

            Moip.Models.PaymentResponse paymentResponse = controller.CreateBoletoOrDebit(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest);

            Assert.NotNull(paymentResponse.Id, "Id should not be null");
            Assert.AreEqual("BOLETO", paymentResponse.FundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("2020-09-30", paymentResponse.FundingInstrument.Boleto.ExpirationDate, "Should match exactly (string literal match)");
            Assert.AreEqual("TESTETETSTTTST", paymentResponse.FundingInstrument.Boleto.InstructionLines.First, "Should match exactly (string literal match)");
            Assert.AreEqual("tfcsddlksjsd", paymentResponse.FundingInstrument.Boleto.InstructionLines.Second, "Should match exactly (string literal match)");
            Assert.AreEqual("lkshglashiuahgha", paymentResponse.FundingInstrument.Boleto.InstructionLines.Third, "Should match exactly (string literal match)");
            Assert.AreEqual("http://", paymentResponse.FundingInstrument.Boleto.LogoUri, "Should match exactly (string literal match)");
            Assert.AreEqual("https://checkout-sandbox.moip.com.br/boleto/" + paymentResponse.Id + "/print", paymentResponse.Links.PayBoleto.PrintHref, "Should match exactly (string literal match)");
            Assert.AreEqual("https://checkout-sandbox.moip.com.br/boleto/" + paymentResponse.Id, paymentResponse.Links.PayBoleto.RedirectHref, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestCreatePaymentWithOnlineDebit()
        {
            Moip.Models.PaymentBoletoOrDebitRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithOnlineDebitRequest();

            Moip.Models.PaymentResponse paymentResponse = controller.CreateBoletoOrDebit(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest);

            Assert.NotNull(paymentResponse.Id, "Id should not be null");
            Assert.AreEqual("ONLINE_BANK_DEBIT", paymentResponse.FundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("341", paymentResponse.FundingInstrument.OnlineBankDebit.BankNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("2020-09-30", paymentResponse.FundingInstrument.OnlineBankDebit.ExpirationDate, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestGetPayment()
        {
            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithCCRequest();

            string paymentId = controller.CreateCreditCard(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest).Id;

            Moip.Models.PaymentResponse paymentResponse = controller.GetPayment(paymentId);

            Assert.NotNull(paymentResponse.Id, "Id should not be null");
            Assert.AreEqual(1, paymentResponse.InstallmentCount, "Should match exactly (string literal match)");
            Assert.AreEqual("MyStore", paymentResponse.StatementDescriptor, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", paymentResponse.FundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("Jose Goku da Silva", paymentResponse.FundingInstrument.CreditCard.Holder.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("1988-12-30", paymentResponse.FundingInstrument.CreditCard.Holder.Birthdate, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", paymentResponse.FundingInstrument.CreditCard.Holder.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("33333333333", paymentResponse.FundingInstrument.CreditCard.Holder.TaxDocument.Number, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestCapturePayment()
        {
            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithPreAuthorizationRequest();

            string paymentId = controller.CreateCreditCard(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest).Id;

            Thread.Sleep(1000);

            Moip.Models.PaymentResponse paymentResponse = controller.CapturePreAuthorized(paymentId);

            Assert.NotNull(paymentResponse.Id, "Id should not be null");
            Assert.AreEqual(1, paymentResponse.InstallmentCount, "Should match exactly (string literal match)");
            Assert.AreEqual("MyStore", paymentResponse.StatementDescriptor, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", paymentResponse.FundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("Jose Goku da Silva", paymentResponse.FundingInstrument.CreditCard.Holder.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("1988-12-30", paymentResponse.FundingInstrument.CreditCard.Holder.Birthdate, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", paymentResponse.FundingInstrument.CreditCard.Holder.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("33333333333", paymentResponse.FundingInstrument.CreditCard.Holder.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("AUTHORIZED", paymentResponse.Status, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestCancelPayment()
        {
            Moip.Models.PaymentRequest paymentRequest = Helpers.RequestsCreator.CreatePaymentWithPreAuthorizationRequest();

            string paymentId = controller.CreateCreditCard(GetClient().Orders.CreateOrder(Helpers.RequestsCreator.createOrderRequest()).Id, paymentRequest).Id;

            Thread.Sleep(1000);

            Moip.Models.PaymentResponse paymentResponse = controller.CancelPreAuthorized(paymentId);

            Assert.NotNull(paymentResponse.Id, "Id should not be null");
            Assert.AreEqual(1, paymentResponse.InstallmentCount, "Should match exactly (string literal match)");
            Assert.AreEqual("MyStore", paymentResponse.StatementDescriptor, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", paymentResponse.FundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("Jose Goku da Silva", paymentResponse.FundingInstrument.CreditCard.Holder.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("1988-12-30", paymentResponse.FundingInstrument.CreditCard.Holder.Birthdate, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", paymentResponse.FundingInstrument.CreditCard.Holder.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("33333333333", paymentResponse.FundingInstrument.CreditCard.Holder.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("CANCELLED", paymentResponse.Status, "Should match exactly (string literal match)");

        }

    }
}
