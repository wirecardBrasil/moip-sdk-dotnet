using Moip.Controllers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Moip.Tests
{
    [TestFixture]
    public class MultiOrdersAPITest : ControllerTestBase
    {

        private static MultiOrdersController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().MultiOrders;
        }

        [Test]
        public void TestCreateMultiOrder()
        {
            Moip.Models.MultiorderRequest multiorderRequest = Helpers.RequestsCreator.CreateMultiorderRequest();

            Moip.Models.MultiorderResponse multiorderResponse = controller.CreateMultiorder(multiorderRequest);

            Assert.NotNull(multiorderResponse.Orders[0].Id, "Id should not be null");
            Assert.AreEqual("my_own_id", multiorderResponse.Orders[0].OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("Bicicleta Specialized Tarmac 26 Shimano Alivio", multiorderResponse.Orders[0].Items[0].Product, "Should match exactly (string literal match)");
            Assert.AreEqual(1, multiorderResponse.Orders[0].Items[0].Quantity, "Should match exactly (string literal match)");
            Assert.AreEqual("uma linda bicicleta", multiorderResponse.Orders[0].Items[0].Detail, "Should match exactly (string literal match)");
            Assert.AreEqual(2000, multiorderResponse.Orders[0].Items[0].Price, "Should match exactly (string literal match)");
            Assert.AreEqual("BRL", multiorderResponse.Orders[0].Amount.Currency, "Should match exactly (string literal match)");
            Assert.AreEqual("Fulano de Tal", multiorderResponse.Orders[0].Customer.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("OFulanoDeTal", multiorderResponse.Orders[0].Customer.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("1990-01-01", multiorderResponse.Orders[0].Customer.BirthDate, "Should match exactly (string literal match)");
            Assert.AreEqual("fulano@detal.com.br", multiorderResponse.Orders[0].Customer.Email, "Should match exactly (string literal match)");
            Assert.AreEqual("Rua test", multiorderResponse.Orders[0].ShippingAddress.Street, "Should match exactly (string literal match)");
            Assert.AreEqual("123", multiorderResponse.Orders[0].ShippingAddress.StreetNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("Ap test", multiorderResponse.Orders[0].ShippingAddress.Complement, "Should match exactly (string literal match)");
            Assert.AreEqual("Bairro test", multiorderResponse.Orders[0].ShippingAddress.District, "Should match exactly (string literal match)");
            Assert.AreEqual("TestCity", multiorderResponse.Orders[0].ShippingAddress.City, "Should match exactly (string literal match)");
            Assert.AreEqual("SP", multiorderResponse.Orders[0].ShippingAddress.State, "Should match exactly (string literal match)");
            Assert.AreEqual("BRA", multiorderResponse.Orders[0].ShippingAddress.Country, "Should match exactly (string literal match)");
            Assert.AreEqual("01234000", multiorderResponse.Orders[0].ShippingAddress.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("55", multiorderResponse.Orders[0].Customer.Phone.CountryCode, "Should match exactly (string literal match)");
            Assert.AreEqual("11", multiorderResponse.Orders[0].Customer.Phone.AreaCode, "Should match exactly (string literal match)");
            Assert.AreEqual("66778899", multiorderResponse.Orders[0].Customer.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", multiorderResponse.Orders[0].Customer.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("22222222222", multiorderResponse.Orders[0].Customer.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual(1500, multiorderResponse.Orders[0].Amount.Subtotals.Shipping, "Should match exactly (string literal match)");
            Assert.AreEqual(20, multiorderResponse.Orders[0].Amount.Subtotals.Addition, "Should match exactly (string literal match)");
            Assert.AreEqual(10, multiorderResponse.Orders[0].Amount.Subtotals.Discount, "Should match exactly (string literal match)");

            Assert.NotNull(multiorderResponse.Orders[1].Id, "Id should not be null");
            Assert.AreEqual("my_own_id2", multiorderResponse.Orders[1].OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("Bicicleta Specialized Tarmac 26 Shimano Alivio", multiorderResponse.Orders[1].Items[0].Product, "Should match exactly (string literal match)");
            Assert.AreEqual(1, multiorderResponse.Orders[1].Items[0].Quantity, "Should match exactly (string literal match)");
            Assert.AreEqual("uma linda bicicleta", multiorderResponse.Orders[1].Items[0].Detail, "Should match exactly (string literal match)");
            Assert.AreEqual(2000, multiorderResponse.Orders[1].Items[0].Price, "Should match exactly (string literal match)");
            Assert.AreEqual("BRL", multiorderResponse.Orders[1].Amount.Currency, "Should match exactly (string literal match)");
            Assert.AreEqual("Outro Nome Teste", multiorderResponse.Orders[1].Customer.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("OFulanoDeTal", multiorderResponse.Orders[1].Customer.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("1990-01-01", multiorderResponse.Orders[1].Customer.BirthDate, "Should match exactly (string literal match)");
            Assert.AreEqual("fulano@detal.com.br", multiorderResponse.Orders[1].Customer.Email, "Should match exactly (string literal match)");
            Assert.AreEqual("Rua test", multiorderResponse.Orders[1].ShippingAddress.Street, "Should match exactly (string literal match)");
            Assert.AreEqual("123", multiorderResponse.Orders[1].ShippingAddress.StreetNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("Ap test", multiorderResponse.Orders[1].ShippingAddress.Complement, "Should match exactly (string literal match)");
            Assert.AreEqual("Bairro test", multiorderResponse.Orders[1].ShippingAddress.District, "Should match exactly (string literal match)");
            Assert.AreEqual("TestCity", multiorderResponse.Orders[1].ShippingAddress.City, "Should match exactly (string literal match)");
            Assert.AreEqual("SP", multiorderResponse.Orders[1].ShippingAddress.State, "Should match exactly (string literal match)");
            Assert.AreEqual("BRA", multiorderResponse.Orders[1].ShippingAddress.Country, "Should match exactly (string literal match)");
            Assert.AreEqual("01234000", multiorderResponse.Orders[1].ShippingAddress.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("55", multiorderResponse.Orders[1].Customer.Phone.CountryCode, "Should match exactly (string literal match)");
            Assert.AreEqual("11", multiorderResponse.Orders[1].Customer.Phone.AreaCode, "Should match exactly (string literal match)");
            Assert.AreEqual("66778899", multiorderResponse.Orders[1].Customer.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", multiorderResponse.Orders[1].Customer.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("22222222222", multiorderResponse.Orders[1].Customer.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual(1500, multiorderResponse.Orders[1].Amount.Subtotals.Shipping, "Should match exactly (string literal match)");
            Assert.AreEqual(20, multiorderResponse.Orders[1].Amount.Subtotals.Addition, "Should match exactly (string literal match)");
            Assert.AreEqual(10, multiorderResponse.Orders[1].Amount.Subtotals.Discount, "Should match exactly (string literal match)");
        }

        [Test]
        public void TestGetMultiOrder()
        {
            Moip.Models.MultiorderRequest multiorderRequest = Helpers.RequestsCreator.CreateMultiorderRequest();

            string multiorderId = controller.CreateMultiorder(multiorderRequest).Id;

            Moip.Models.MultiorderResponse multiorderResponse = controller.GetMultiorder(multiorderId);

            Assert.NotNull(multiorderResponse.Orders[0].Id, "Id should not be null");
            Assert.AreEqual("my_own_id", multiorderResponse.Orders[0].OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("Bicicleta Specialized Tarmac 26 Shimano Alivio", multiorderResponse.Orders[0].Items[0].Product, "Should match exactly (string literal match)");
            Assert.AreEqual(1, multiorderResponse.Orders[0].Items[0].Quantity, "Should match exactly (string literal match)");
            Assert.AreEqual("uma linda bicicleta", multiorderResponse.Orders[0].Items[0].Detail, "Should match exactly (string literal match)");
            Assert.AreEqual(2000, multiorderResponse.Orders[0].Items[0].Price, "Should match exactly (string literal match)");
            Assert.AreEqual("BRL", multiorderResponse.Orders[0].Amount.Currency, "Should match exactly (string literal match)");
            Assert.AreEqual("Fulano de Tal", multiorderResponse.Orders[0].Customer.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("OFulanoDeTal", multiorderResponse.Orders[0].Customer.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("1990-01-01", multiorderResponse.Orders[0].Customer.BirthDate, "Should match exactly (string literal match)");
            Assert.AreEqual("fulano@detal.com.br", multiorderResponse.Orders[0].Customer.Email, "Should match exactly (string literal match)");
            Assert.AreEqual("Rua test", multiorderResponse.Orders[0].ShippingAddress.Street, "Should match exactly (string literal match)");
            Assert.AreEqual("123", multiorderResponse.Orders[0].ShippingAddress.StreetNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("Ap test", multiorderResponse.Orders[0].ShippingAddress.Complement, "Should match exactly (string literal match)");
            Assert.AreEqual("Bairro test", multiorderResponse.Orders[0].ShippingAddress.District, "Should match exactly (string literal match)");
            Assert.AreEqual("TestCity", multiorderResponse.Orders[0].ShippingAddress.City, "Should match exactly (string literal match)");
            Assert.AreEqual("SP", multiorderResponse.Orders[0].ShippingAddress.State, "Should match exactly (string literal match)");
            Assert.AreEqual("BRA", multiorderResponse.Orders[0].ShippingAddress.Country, "Should match exactly (string literal match)");
            Assert.AreEqual("01234000", multiorderResponse.Orders[0].ShippingAddress.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("55", multiorderResponse.Orders[0].Customer.Phone.CountryCode, "Should match exactly (string literal match)");
            Assert.AreEqual("11", multiorderResponse.Orders[0].Customer.Phone.AreaCode, "Should match exactly (string literal match)");
            Assert.AreEqual("66778899", multiorderResponse.Orders[0].Customer.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", multiorderResponse.Orders[0].Customer.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("22222222222", multiorderResponse.Orders[0].Customer.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual(1500, multiorderResponse.Orders[0].Amount.Subtotals.Shipping, "Should match exactly (string literal match)");
            Assert.AreEqual(20, multiorderResponse.Orders[0].Amount.Subtotals.Addition, "Should match exactly (string literal match)");
            Assert.AreEqual(10, multiorderResponse.Orders[0].Amount.Subtotals.Discount, "Should match exactly (string literal match)");

            Assert.NotNull(multiorderResponse.Orders[1].Id, "Id should not be null");
            Assert.AreEqual("my_own_id2", multiorderResponse.Orders[1].OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("Bicicleta Specialized Tarmac 26 Shimano Alivio", multiorderResponse.Orders[1].Items[0].Product, "Should match exactly (string literal match)");
            Assert.AreEqual(1, multiorderResponse.Orders[1].Items[0].Quantity, "Should match exactly (string literal match)");
            Assert.AreEqual("uma linda bicicleta", multiorderResponse.Orders[1].Items[0].Detail, "Should match exactly (string literal match)");
            Assert.AreEqual(2000, multiorderResponse.Orders[1].Items[0].Price, "Should match exactly (string literal match)");
            Assert.AreEqual("BRL", multiorderResponse.Orders[1].Amount.Currency, "Should match exactly (string literal match)");
            Assert.AreEqual("Outro Nome Teste", multiorderResponse.Orders[1].Customer.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("OFulanoDeTal", multiorderResponse.Orders[1].Customer.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("1990-01-01", multiorderResponse.Orders[1].Customer.BirthDate, "Should match exactly (string literal match)");
            Assert.AreEqual("fulano@detal.com.br", multiorderResponse.Orders[1].Customer.Email, "Should match exactly (string literal match)");
            Assert.AreEqual("Rua test", multiorderResponse.Orders[1].ShippingAddress.Street, "Should match exactly (string literal match)");
            Assert.AreEqual("123", multiorderResponse.Orders[1].ShippingAddress.StreetNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("Ap test", multiorderResponse.Orders[1].ShippingAddress.Complement, "Should match exactly (string literal match)");
            Assert.AreEqual("Bairro test", multiorderResponse.Orders[1].ShippingAddress.District, "Should match exactly (string literal match)");
            Assert.AreEqual("TestCity", multiorderResponse.Orders[1].ShippingAddress.City, "Should match exactly (string literal match)");
            Assert.AreEqual("SP", multiorderResponse.Orders[1].ShippingAddress.State, "Should match exactly (string literal match)");
            Assert.AreEqual("BRA", multiorderResponse.Orders[1].ShippingAddress.Country, "Should match exactly (string literal match)");
            Assert.AreEqual("01234000", multiorderResponse.Orders[1].ShippingAddress.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("55", multiorderResponse.Orders[1].Customer.Phone.CountryCode, "Should match exactly (string literal match)");
            Assert.AreEqual("11", multiorderResponse.Orders[1].Customer.Phone.AreaCode, "Should match exactly (string literal match)");
            Assert.AreEqual("66778899", multiorderResponse.Orders[1].Customer.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", multiorderResponse.Orders[1].Customer.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("22222222222", multiorderResponse.Orders[1].Customer.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual(1500, multiorderResponse.Orders[1].Amount.Subtotals.Shipping, "Should match exactly (string literal match)");
            Assert.AreEqual(20, multiorderResponse.Orders[1].Amount.Subtotals.Addition, "Should match exactly (string literal match)");
            Assert.AreEqual(10, multiorderResponse.Orders[1].Amount.Subtotals.Discount, "Should match exactly (string literal match)");
        }
    }
}
