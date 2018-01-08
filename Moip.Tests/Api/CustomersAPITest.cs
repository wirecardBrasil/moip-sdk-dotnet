using Moip.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Moip.Tests
{
    [TestFixture]
    public class CustomersAPITest : ControllerTestBase
    {

        private static CustomersController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Customers;
        }

        [Test]
        public void TestCreateCustomer()
        {
            string date = DateTime.Now.ToString();

            Moip.Models.CustomerRequest customerRequest = Helpers.RequestsCreator.CreateCustomerRequest(date);

            Moip.Models.CustomerResponse customerResponse = controller.CreateCustomer(customerRequest);

            Assert.NotNull(customerResponse.Id, "Id should not be null");
            Assert.AreEqual("OFulanoDeTal" + date, customerResponse.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("Fulano de Tal", customerResponse.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("1990-01-01", customerResponse.BirthDate, "Should match exactly (string literal match)");
            Assert.AreEqual("fulano@detal.com.br", customerResponse.Email, "Should match exactly (string literal match)");
            Assert.AreEqual("Rua test", customerResponse.ShippingAddress.Street, "Should match exactly (string literal match)");
            Assert.AreEqual("123", customerResponse.ShippingAddress.StreetNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("Ap test", customerResponse.ShippingAddress.Complement, "Should match exactly (string literal match)");
            Assert.AreEqual("Bairro test", customerResponse.ShippingAddress.District, "Should match exactly (string literal match)");
            Assert.AreEqual("TestCity", customerResponse.ShippingAddress.City, "Should match exactly (string literal match)");
            Assert.AreEqual("SP", customerResponse.ShippingAddress.State, "Should match exactly (string literal match)");
            Assert.AreEqual("BRA", customerResponse.ShippingAddress.Country, "Should match exactly (string literal match)");
            Assert.AreEqual("01234000", customerResponse.ShippingAddress.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("55", customerResponse.Phone.CountryCode, "Should match exactly (string literal match)");
            Assert.AreEqual("11", customerResponse.Phone.AreaCode, "Should match exactly (string literal match)");
            Assert.AreEqual("66778899", customerResponse.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", customerResponse.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("33333333333", customerResponse.TaxDocument.Number, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestGetCustomer()
        {
            string date = DateTime.Now.ToString();

            Moip.Models.CustomerRequest customerRequest = Helpers.RequestsCreator.CreateCustomerRequest(date);

            string customerId = controller.CreateCustomer(customerRequest).Id;

            Moip.Models.CustomerResponse customerResponse = controller.GetCustomer(customerId);

            Assert.NotNull(customerResponse.Id, "Id should not be null");
            Assert.AreEqual("OFulanoDeTal" + date, customerResponse.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("Fulano de Tal", customerResponse.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("1990-01-01", customerResponse.BirthDate, "Should match exactly (string literal match)");
            Assert.AreEqual("fulano@detal.com.br", customerResponse.Email, "Should match exactly (string literal match)");
            Assert.AreEqual("Rua test", customerResponse.ShippingAddress.Street, "Should match exactly (string literal match)");
            Assert.AreEqual("123", customerResponse.ShippingAddress.StreetNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("Ap test", customerResponse.ShippingAddress.Complement, "Should match exactly (string literal match)");
            Assert.AreEqual("Bairro test", customerResponse.ShippingAddress.District, "Should match exactly (string literal match)");
            Assert.AreEqual("TestCity", customerResponse.ShippingAddress.City, "Should match exactly (string literal match)");
            Assert.AreEqual("SP", customerResponse.ShippingAddress.State, "Should match exactly (string literal match)");
            Assert.AreEqual("BRA", customerResponse.ShippingAddress.Country, "Should match exactly (string literal match)");
            Assert.AreEqual("01234000", customerResponse.ShippingAddress.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("55", customerResponse.Phone.CountryCode, "Should match exactly (string literal match)");
            Assert.AreEqual("11", customerResponse.Phone.AreaCode, "Should match exactly (string literal match)");
            Assert.AreEqual("66778899", customerResponse.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", customerResponse.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("33333333333", customerResponse.TaxDocument.Number, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestCreateCustomerWithFundingInstrument()
        {
            string date = DateTime.Now.ToString();

            Moip.Models.CustomerRequest customerRequest = Helpers.RequestsCreator.CreateCustomerWithFundingInstrumentRequest(date);

            Moip.Models.CustomerResponse customerResponse = controller.CreateCustomer(customerRequest);

            Assert.NotNull(customerResponse.Id, "Id should not be null");
            Assert.AreEqual("OFulanoDeTal" + date, customerResponse.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("Fulano de Tal", customerResponse.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("1990-01-01", customerResponse.BirthDate, "Should match exactly (string literal match)");
            Assert.AreEqual("fulano@detal.com.br", customerResponse.Email, "Should match exactly (string literal match)");
            Assert.AreEqual("Rua test", customerResponse.ShippingAddress.Street, "Should match exactly (string literal match)");
            Assert.AreEqual("123", customerResponse.ShippingAddress.StreetNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("Ap test", customerResponse.ShippingAddress.Complement, "Should match exactly (string literal match)");
            Assert.AreEqual("Bairro test", customerResponse.ShippingAddress.District, "Should match exactly (string literal match)");
            Assert.AreEqual("TestCity", customerResponse.ShippingAddress.City, "Should match exactly (string literal match)");
            Assert.AreEqual("SP", customerResponse.ShippingAddress.State, "Should match exactly (string literal match)");
            Assert.AreEqual("BRA", customerResponse.ShippingAddress.Country, "Should match exactly (string literal match)");
            Assert.AreEqual("01234000", customerResponse.ShippingAddress.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("55", customerResponse.Phone.CountryCode, "Should match exactly (string literal match)");
            Assert.AreEqual("11", customerResponse.Phone.AreaCode, "Should match exactly (string literal match)");
            Assert.AreEqual("66778899", customerResponse.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", customerResponse.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("33333333333", customerResponse.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("CREDIT_CARD", customerResponse.FundingInstrument.Method, "Should match exactly (string literal match)");
            Assert.AreEqual("555566", customerResponse.FundingInstrument.CreditCard.First6, "Should match exactly (string literal match)");
            Assert.AreEqual("8884", customerResponse.FundingInstrument.CreditCard.Last4, "Should match exactly (string literal match)");
            Assert.IsTrue(customerResponse.FundingInstrument.CreditCard.Store, "Store should be true");
            Assert.NotNull(customerResponse.FundingInstrument.CreditCard.Id, "Id should not be null");

        }

        [Test]
        public void TestAddCreditCardToCustomer()
        {
            string date = DateTime.Now.ToString();

            Moip.Models.CustomerRequest customerRequest = Helpers.RequestsCreator.CreateCustomerRequest(date);

            string customerId = controller.CreateCustomer(customerRequest).Id;

            Moip.Models.CustomerCreditCardRequest customerCreditCardRequest = Helpers.RequestsCreator.CreateCustomerCreditCardRequest();

            Moip.Models.CustomerCreditCardResponse customerCreditCardResponse = controller.CreateCreditCard(customerCreditCardRequest, customerId);

            Assert.NotNull(customerCreditCardResponse.CreditCard.Id, "Id should not be null");
            Assert.AreEqual("MASTERCARD", customerCreditCardResponse.CreditCard.Brand, "Should match exactly (string literal match)");
            Assert.AreEqual("555566", customerCreditCardResponse.CreditCard.First6, "Should match exactly (string literal match)");
            Assert.AreEqual("8884", customerCreditCardResponse.CreditCard.Last4, "Should match exactly (string literal match)");
            Assert.IsTrue(customerCreditCardResponse.CreditCard.Store, "Store should be true");
            Assert.AreEqual("MASTERCARD", customerCreditCardResponse.Card.Brand, "Should match exactly (string literal match)");
            Assert.IsTrue(customerCreditCardResponse.Card.Store, "Store should be true");
            Assert.AreEqual("CREDIT_CARD", customerCreditCardResponse.Method, "Should match exactly (string literal match)");
        }

        [Test]
        public void TestDeleteCreditCard()
        {
            string date = DateTime.Now.ToString();

            Moip.Models.CustomerRequest customerRequest = Helpers.RequestsCreator.CreateCustomerRequest(date);

            string customerId = controller.CreateCustomer(customerRequest).Id;

            Moip.Models.CustomerCreditCardRequest customerCreditCardRequest = Helpers.RequestsCreator.CreateCustomerCreditCardRequest();

            string customerCreditCardId = controller.CreateCreditCard(customerCreditCardRequest, customerId).CreditCard.Id;

            bool deleteCreditCardResponse = controller.DeleteCreditCard(customerCreditCardId);

            Assert.IsTrue(deleteCreditCardResponse, "Should be true");

        }

    }
}
