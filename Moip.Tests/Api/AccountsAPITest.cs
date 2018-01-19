using Moip.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;

namespace Moip.Tests
{
    [TestFixture]
    public class AccountsAPITest : ControllerTestBase
    {

        private static AccountsController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Accounts;
        }


        [Test]
        public void TestCreateAccountPerson()
        {
            Moip.Models.AccountRequest accountRequest = Helpers.RequestsCreator.CreateAccountPersonRequest();

            Moip.Models.AccountResponse accountResponse = controller.CreateAccount(accountRequest);

            Assert.NotNull(accountResponse.Id, "Id should not be null");
            Assert.IsFalse(accountResponse.TransparentAccount, "Transparent should be false");
        }

        [Test]
        public void TestCreateAccountCompany()
        {
            Moip.Models.AccountRequest accountRequest = Helpers.RequestsCreator.CreateAccountCompanyRequest();

            Moip.Models.AccountResponse accountResponse = controller.CreateAccount(accountRequest);

            Assert.NotNull(accountResponse.Id, "Id should not be null");
            Assert.IsFalse(accountResponse.TransparentAccount, "Transparent should be false");
        }

        [Test]
        public void TestCreateAccountTransparent()
        {
            Moip.Models.AccountRequest accountRequest = Helpers.RequestsCreator.CreateAccountTransparentRequest();
//
            Moip.Models.AccountResponse accountResponse = controller.CreateAccount(accountRequest);

            Assert.NotNull(accountResponse.Id, "Id should not be null");
            Assert.IsTrue(accountResponse.TransparentAccount, "Transparent should be true");
        }

        [Test]
        public void TestGetAccountPerson()
        {
            Moip.Models.AccountResponse accountResponse = controller.GetAccount("MPA-2958D38FCE22");

            Assert.NotNull(accountResponse.Id, "Id should not be null");
            Assert.AreEqual("MPA-2958D38FCE22", accountResponse.Id, "Should match exactly (string literal match)");
            Assert.AreEqual("Goku", accountResponse.Person.LastName, "Should match exactly (string literal match)");
            Assert.AreEqual("712341234", accountResponse.Person.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("", accountResponse.Person.ParentsName.Mother, "Should match exactly (string literal match)");
            Assert.AreEqual("01234-000", accountResponse.Person.Address.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("736.141.550-48", accountResponse.Person.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("Runscope", accountResponse.Person.Name, "Should match exactly (string literal match)");
            Assert.AreEqual("1990-01-01", accountResponse.Person.BirthDate, "Should match exactly (string literal match)");
            Assert.IsFalse(accountResponse.TransparentAccount, "Should be false");
            Assert.AreEqual("testingarandomemail10@labs.moip.com.br", accountResponse.Email.Address, "Should match exactly (string literal match)");
            Assert.AreEqual("2018-01-18T18:03:50.000-02:00", accountResponse.CreatedAt, "Should match exactly (string literal match)");
            Assert.AreEqual("https://sandbox.moip.com.br/accounts/MPA-2958D38FCE22", accountResponse.Links.Self.Href, "Should match exactly (string literal match)");
            Assert.AreEqual(0, accountResponse.MonthlyRevenueId, "Should match exactly (string literal match)");
            Assert.AreEqual("testingarand", accountResponse.SoftDescriptor, "Should match exactly (string literal match)");
            Assert.AreEqual("testingarandomemail10@labs.moip.com.br", accountResponse.Login, "Should match exactly (string literal match)");
            Assert.AreEqual("MERCHANT", accountResponse.Type, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestGetAccountCompany()
        {
            Moip.Models.AccountResponse accountResponse = controller.GetAccount("MPA-189BA48DD0AF");

            Assert.NotNull(accountResponse.Id, "Id should not be null");
            Assert.AreEqual("MPA-189BA48DD0AF", accountResponse.Id, "Should match exactly (string literal match)");
            Assert.AreEqual("Goku", accountResponse.Person.LastName, "Should match exactly (string literal match)");
            Assert.AreEqual("712341234", accountResponse.Person.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("", accountResponse.Person.ParentsName.Mother, "Should match exactly (string literal match)");
            Assert.AreEqual("01234-000", accountResponse.Person.Address.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("870.092.800-37", accountResponse.Person.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("Runscope", accountResponse.Person.Name, "Should match exactly (string literal match)");
            Assert.AreEqual("1990-01-01", accountResponse.Person.BirthDate, "Should match exactly (string literal match)");
            Assert.IsFalse(accountResponse.TransparentAccount, "Should be false");
            Assert.AreEqual("dev.moip@labs.moip.com", accountResponse.Email.Address, "Should match exactly (string literal match)");
            Assert.AreEqual("2018-01-19T14:44:05.000-02:00", accountResponse.CreatedAt, "Should match exactly (string literal match)");
            Assert.AreEqual(3, accountResponse.BusinessSegment.Id, "Should match exactly (string literal match)");
            Assert.AreEqual("", accountResponse.Company.MonthlyRevenue, "Should match exactly (string literal match)");
            Assert.AreEqual("Empresa Alguma", accountResponse.Company.BusinessName, "Should match exactly (string literal match)");
            Assert.AreEqual("32234455", accountResponse.Company.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("2011-01-01", accountResponse.Company.OpeningDate, "Should match exactly (string literal match)");
            Assert.AreEqual("01234-000", accountResponse.Company.Address.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("47.675.779/0001-09", accountResponse.Company.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("Alguma Empresa", accountResponse.Company.Name, "Should match exactly (string literal match)");
            Assert.AreEqual("", accountResponse.Company.ConstitutionType, "Should match exactly (string literal match)");
            Assert.AreEqual("https://sandbox.moip.com.br/accounts/MPA-189BA48DD0AF", accountResponse.Links.Self.Href, "Should match exactly (string literal match)");
            Assert.AreEqual(0, accountResponse.MonthlyRevenueId, "Should match exactly (string literal match)");
            Assert.AreEqual("Alguma Empre", accountResponse.SoftDescriptor, "Should match exactly (string literal match)");
            Assert.AreEqual("dev.moip@labs.moip.com", accountResponse.Login, "Should match exactly (string literal match)");
            Assert.AreEqual("MERCHANT", accountResponse.Type, "Should match exactly (string literal match)");

        }

        [Test]
        public void TestCheckIfAccountExists()
        {
            bool response = controller.CheckAccountExists("736.141.550-48");

            Assert.IsTrue(response, "Account should exists");
        }

        [Test]
        public void TestCheckIfAccountDoesnotExists()
        {
            bool response = controller.CheckAccountExists("310.659.870-05");

            Assert.IsFalse(response, "Account should not exists");
        }

    }
}
