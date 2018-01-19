using Moip.Controllers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Moip.Tests
{
    [TestFixture]
    public class AccountsRequestsTest : ControllerTestBase
    {

        private static AccountsController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Accounts;
        }

        [Test]
        public void TestCreateAccountPersonRequest()
        {
            Moip.Models.AccountRequest accountRequest = Helpers.RequestsCreator.CreateAccountPersonRequest();

            string accountRequestJson = Moip.Utilities.APIHelper.JsonSerialize(accountRequest);

            string expectedAccountRequestJson = Helpers.FileReader.readJsonFile(@"Account\account_person.json");

            Assert.AreEqual(expectedAccountRequestJson, accountRequestJson,
                "Account request body should match exactly (string literal match)");
        }

        [Test]
        public void TestCreateAccountCompanyRequest()
        {
            Moip.Models.AccountRequest accountRequest = Helpers.RequestsCreator.CreateAccountCompanyRequest();

            string accountRequestJson = Moip.Utilities.APIHelper.JsonSerialize(accountRequest);

            string expectedAccountRequestJson = Helpers.FileReader.readJsonFile(@"Account\account_company.json");

            Assert.AreEqual(expectedAccountRequestJson, accountRequestJson,
                "Account request body should match exactly (string literal match)");
        }

        [Test]
        public void TestCreateAccountTransparentRequest()
        {
            Moip.Models.AccountRequest accountRequest = Helpers.RequestsCreator.CreateAccountTransparentRequest();

            string accountRequestJson = Moip.Utilities.APIHelper.JsonSerialize(accountRequest);

            string expectedAccountRequestJson = Helpers.FileReader.readJsonFile(@"Account\account_transparent.json");

            Assert.AreEqual(expectedAccountRequestJson, accountRequestJson,
                "Account request body should match exactly (string literal match)");
        }

    }
}
