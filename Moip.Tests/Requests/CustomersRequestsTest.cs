using Moip.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Moip.Tests
{
    [TestFixture]
    public class CustomersRequestsTest : ControllerTestBase
    {
        [Test]
        public void TestCreateCustomerRequest()
        {
            string date = DateTime.Now.ToString();

            Moip.Models.CustomerRequest generatedCustomerRequest = Helpers.RequestsCreator.CreateCustomerRequest(date);

            string generatedCustomerRequestJson = Moip.Utilities.APIHelper.JsonSerialize(generatedCustomerRequest);

            string expectedCustomerJson = Helpers.FileReader.readJsonFile(@"Customer\customer.json");

            Moip.Models.CustomerRequest expectedCustomerRequest = Moip.Utilities.APIHelper.JsonDeserialize<Moip.Models.CustomerRequest>(expectedCustomerJson);

            expectedCustomerRequest.OwnId += date;

            string expectedCustomerRequestJson = Moip.Utilities.APIHelper.JsonSerialize(expectedCustomerRequest);

            Assert.AreEqual(expectedCustomerRequestJson, generatedCustomerRequestJson,
                "Notification request body should match exactly (string literal match)");

        }

        [Test]
        public void TestCreateCustomerWithFundingInstrumentRequest()
        {
            string date = DateTime.Now.ToString();

            Moip.Models.CustomerRequest generatedCustomerRequest = Helpers.RequestsCreator.CreateCustomerWithFundingInstrumentRequest(date);

            string generatedCustomerRequestJson = Moip.Utilities.APIHelper.JsonSerialize(generatedCustomerRequest);

            string expectedCustomerJson = Helpers.FileReader.readJsonFile(@"Customer\customer_with_funding_instrument.json");

            Moip.Models.CustomerRequest expectedCustomerRequest = Moip.Utilities.APIHelper.JsonDeserialize<Moip.Models.CustomerRequest>(expectedCustomerJson);

            expectedCustomerRequest.OwnId += date;

            string expectedCustomerRequestJson = Moip.Utilities.APIHelper.JsonSerialize(expectedCustomerRequest);

            Assert.AreEqual(expectedCustomerRequestJson, generatedCustomerRequestJson,
                "Notification request body should match exactly (string literal match)");

        }

        [Test]
        public void TestAddCreditCardRequest()
        {
            Moip.Models.CustomerCreditCardRequest customerCreditCardRequest = Helpers.RequestsCreator.CreateCustomerCreditCardRequest();

            string customerCreditCardRequestJson = Moip.Utilities.APIHelper.JsonSerialize(customerCreditCardRequest);

            string expectedCustomerCreditCardRequestJson = Helpers.FileReader.readJsonFile(@"Customer\add_credit_card.json");

            Assert.AreEqual(expectedCustomerCreditCardRequestJson, customerCreditCardRequestJson,
                "Notification request body should match exactly (string literal match)");

        }
    }
}
