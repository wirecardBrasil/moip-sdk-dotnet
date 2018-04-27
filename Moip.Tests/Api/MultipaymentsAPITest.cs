using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moip.Controllers;
using NUnit.Framework;
using System.Threading;

namespace Moip.Tests.Api
{
    [TestFixture]
    class MultipaymentsAPITest : ControllerTestBase
    {
        private static MultipaymentsController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Multipayments;
        }

        [Test]
        public void TestCreateMultipaymentWithCreditCard()
        {
            Moip.Models.MultipaymentRequest multipaymentRequest = Helpers.RequestsCreator.CreateMultipaymetWithCCRequest();

            Moip.Models.MultipaymentResponse multipaymentResponse = controller.CreateCreditCard(GetClient().MultiOrders.CreateMultiorder(Helpers.RequestsCreator.CreateMultiorderRequest()).Id, multipaymentRequest);

            Assert.NotNull(multipaymentResponse.Id, "Id should not be null");
            Assert.AreEqual(1, multipaymentResponse.InstallmentCount, "Should match exactly (integer number match)");
            Assert.AreEqual("MyStore", multipaymentResponse.Payments[0].StatementDescriptor, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", multipaymentResponse.Payments[0].FundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("Jose Goku da Silva", multipaymentResponse.Payments[0].FundingInstrument.CreditCard.Holder.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("1988-12-30", multipaymentResponse.Payments[0].FundingInstrument.CreditCard.Holder.Birthdate, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", multipaymentResponse.Payments[0].FundingInstrument.CreditCard.Holder.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("33333333333", multipaymentResponse.Payments[0].FundingInstrument.CreditCard.Holder.TaxDocument.Number, "Should match exactly (string literal match)");
        }

        [Test]
        public void TestCreateMultipaymentWithBoleto()
        {
            Moip.Models.MultipaymentBoletoOrDebitRequest multipaymentRequest = Helpers.RequestsCreator.CreateMultipaymentWithBoletoRequest();

            Moip.Models.MultipaymentResponse multipaymentResponse = controller.CreateBoletoOrDebit(GetClient().MultiOrders.CreateMultiorder(Helpers.RequestsCreator.CreateMultiorderRequest()).Id, multipaymentRequest);

            Assert.NotNull(multipaymentResponse.Id, "Id should not be null");
            Assert.AreEqual("BOLETO", multipaymentResponse.Payments[0].FundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("2020-09-30", multipaymentResponse.Payments[0].FundingInstrument.Boleto.ExpirationDate, "Should match exactly (string literal match)");
            Assert.AreEqual("TESTETETSTTTST", multipaymentResponse.Payments[0].FundingInstrument.Boleto.InstructionLines.First, "Should match exactly (string literal match)");
            Assert.AreEqual("tfcsddlksjsd", multipaymentResponse.Payments[0].FundingInstrument.Boleto.InstructionLines.Second, "Should match exactly (string literal match)");
            Assert.AreEqual("lkshglashiuahgha", multipaymentResponse.Payments[0].FundingInstrument.Boleto.InstructionLines.Third, "Should match exactly (string literal match)");
            Assert.AreEqual("http://", multipaymentResponse.Payments[0].FundingInstrument.Boleto.LogoUri, "Should match exactly (string literal match)");
        }

        [Test]
        public void TestCreateMultipaymentWithOnlineDebit()
        {
            Moip.Models.MultipaymentBoletoOrDebitRequest multipaymentRequest = Helpers.RequestsCreator.CreateMultipaymentWithOnlineDebitRequest();

            Moip.Models.MultipaymentResponse multipaymentResponse = controller.CreateBoletoOrDebit(GetClient().MultiOrders.CreateMultiorder(Helpers.RequestsCreator.CreateMultiorderRequest()).Id, multipaymentRequest);

            Assert.NotNull(multipaymentResponse.Id, "Id should not be null");
            Assert.AreEqual("ONLINE_BANK_DEBIT", multipaymentResponse.Payments[0].FundingInstrument.Method, "Should match exactly(string literal match)");
            Assert.AreEqual("341", multipaymentResponse.Payments[0].FundingInstrument.OnlineBankDebit.BankNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("2020-09-30", multipaymentResponse.Payments[0].FundingInstrument.OnlineBankDebit.ExpirationDate, "Should match exactly (string literal match)");
        }
    }
}
