using Moip.Controllers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Moip.Tests
{
    [TestFixture]
    public class OrdersAPITest : ControllerTestBase
    {

        private static OrdersController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Orders;
        }

        [Test]
        public void TestCreateOrder()
        {
            Moip.Models.OrderRequest orderRequest = Helpers.RequestsCreator.createOrderRequest();

            Moip.Models.OrderResponse orderResponse = controller.CreateOrder(orderRequest);

            Assert.NotNull(orderResponse.Id, "Id should not be null");
            Assert.AreEqual("my_own_id", orderResponse.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("Bicicleta Specialized Tarmac 26 Shimano Alivio", orderResponse.Items[0].Product, "Should match exactly (string literal match)");
            Assert.AreEqual(1, orderResponse.Items[0].Quantity, "Should match exactly (string literal match)");
            Assert.AreEqual("uma linda bicicleta", orderResponse.Items[0].Detail, "Should match exactly (string literal match)");
            Assert.AreEqual(2000, orderResponse.Items[0].Price, "Should match exactly (string literal match)");
            Assert.AreEqual("BRL", orderResponse.Amount.Currency, "Should match exactly (string literal match)");
            Assert.AreEqual("Fulano de Tal", orderResponse.Customer.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("OFulanoDeTal", orderResponse.Customer.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("1990-01-01", orderResponse.Customer.BirthDate, "Should match exactly (string literal match)");
            Assert.AreEqual("fulano@detal.com.br", orderResponse.Customer.Email, "Should match exactly (string literal match)");
            Assert.AreEqual("Rua test", orderResponse.ShippingAddress.Street, "Should match exactly (string literal match)");
            Assert.AreEqual("123", orderResponse.ShippingAddress.StreetNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("Ap test", orderResponse.ShippingAddress.Complement, "Should match exactly (string literal match)");
            Assert.AreEqual("Bairro test", orderResponse.ShippingAddress.District, "Should match exactly (string literal match)");
            Assert.AreEqual("TestCity", orderResponse.ShippingAddress.City, "Should match exactly (string literal match)");
            Assert.AreEqual("SP", orderResponse.ShippingAddress.State, "Should match exactly (string literal match)");
            Assert.AreEqual("BRA", orderResponse.ShippingAddress.Country, "Should match exactly (string literal match)");
            Assert.AreEqual("01234000", orderResponse.ShippingAddress.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("55", orderResponse.Customer.Phone.CountryCode, "Should match exactly (string literal match)");
            Assert.AreEqual("11", orderResponse.Customer.Phone.AreaCode, "Should match exactly (string literal match)");
            Assert.AreEqual("66778899", orderResponse.Customer.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", orderResponse.Customer.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("22222222222", orderResponse.Customer.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual(1500, orderResponse.Amount.Subtotals.Shipping, "Should match exactly (string literal match)");
            Assert.AreEqual(20, orderResponse.Amount.Subtotals.Addition, "Should match exactly (string literal match)");
            Assert.AreEqual(10, orderResponse.Amount.Subtotals.Discount, "Should match exactly (string literal match)");
        }

        [Test]
        public void TestCreateOrderWithReceivers()
        {
            Moip.Models.OrderRequest orderRequest = Helpers.RequestsCreator.createOrderWithReceiversRequest();

            Moip.Models.OrderResponse orderResponse = controller.CreateOrder(orderRequest);

            Assert.NotNull(orderResponse.Id, "Id should not be null");
            Assert.AreEqual("my_own_id", orderResponse.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("Bicicleta Specialized Tarmac 26 Shimano Alivio", orderResponse.Items[0].Product, "Should match exactly (string literal match)");
            Assert.AreEqual(1, orderResponse.Items[0].Quantity, "Should match exactly (string literal match)");
            Assert.AreEqual("uma linda bicicleta", orderResponse.Items[0].Detail, "Should match exactly (string literal match)");
            Assert.AreEqual(2000, orderResponse.Items[0].Price, "Should match exactly (string literal match)");
            Assert.AreEqual("MPA-9C65D6964D21", orderResponse.Receivers[0].MoipAccount.Id, "Should match exactly (string literal match)");
            Assert.AreEqual("PRIMARY", orderResponse.Receivers[0].Type, "Should match exactly (string literal match)");
            Assert.AreEqual("MPA-14AC21F09CAE", orderResponse.Receivers[1].MoipAccount.Id, "Should match exactly (string literal match)");
            Assert.AreEqual("SECONDARY", orderResponse.Receivers[1].Type, "Should match exactly (string literal match)");
            Assert.AreEqual("MPA-B0D880F21EF1", orderResponse.Receivers[2].MoipAccount.Id, "Should match exactly (string literal match)");
            Assert.AreEqual("SECONDARY", orderResponse.Receivers[2].Type, "Should match exactly (string literal match)");
            Assert.AreEqual("BRL", orderResponse.Amount.Currency, "Should match exactly (string literal match)");
            Assert.AreEqual("Fulano de Tal", orderResponse.Customer.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("OFulanoDeTal", orderResponse.Customer.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("1990-01-01", orderResponse.Customer.BirthDate, "Should match exactly (string literal match)");
            Assert.AreEqual("fulano@detal.com.br", orderResponse.Customer.Email, "Should match exactly (string literal match)");
            Assert.AreEqual("Rua test", orderResponse.ShippingAddress.Street, "Should match exactly (string literal match)");
            Assert.AreEqual("123", orderResponse.ShippingAddress.StreetNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("Ap test", orderResponse.ShippingAddress.Complement, "Should match exactly (string literal match)");
            Assert.AreEqual("Bairro test", orderResponse.ShippingAddress.District, "Should match exactly (string literal match)");
            Assert.AreEqual("TestCity", orderResponse.ShippingAddress.City, "Should match exactly (string literal match)");
            Assert.AreEqual("SP", orderResponse.ShippingAddress.State, "Should match exactly (string literal match)");
            Assert.AreEqual("BRA", orderResponse.ShippingAddress.Country, "Should match exactly (string literal match)");
            Assert.AreEqual("01234000", orderResponse.ShippingAddress.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("55", orderResponse.Customer.Phone.CountryCode, "Should match exactly (string literal match)");
            Assert.AreEqual("11", orderResponse.Customer.Phone.AreaCode, "Should match exactly (string literal match)");
            Assert.AreEqual("66778899", orderResponse.Customer.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", orderResponse.Customer.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("22222222222", orderResponse.Customer.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual(1500, orderResponse.Amount.Subtotals.Shipping, "Should match exactly (string literal match)");
            Assert.AreEqual(20, orderResponse.Amount.Subtotals.Addition, "Should match exactly (string literal match)");
            Assert.AreEqual(10, orderResponse.Amount.Subtotals.Discount, "Should match exactly (string literal match)");
        }

        [Test]
        public void TestGetOrder()
        {
            Moip.Models.OrderRequest orderRequest = Helpers.RequestsCreator.createOrderWithReceiversRequest();

            string orderId = controller.CreateOrder(orderRequest).Id;

            Moip.Models.OrderResponse orderResponse = controller.GetOrder(orderId);

            Assert.AreEqual(orderId, orderResponse.Id, "Should match exactly (string literal match)");
            Assert.AreEqual("my_own_id", orderResponse.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("Bicicleta Specialized Tarmac 26 Shimano Alivio", orderResponse.Items[0].Product, "Should match exactly (string literal match)");
            Assert.AreEqual(1, orderResponse.Items[0].Quantity, "Should match exactly (string literal match)");
            Assert.AreEqual("uma linda bicicleta", orderResponse.Items[0].Detail, "Should match exactly (string literal match)");
            Assert.AreEqual(2000, orderResponse.Items[0].Price, "Should match exactly (string literal match)");
            Assert.AreEqual("MPA-9C65D6964D21", orderResponse.Receivers[0].MoipAccount.Id, "Should match exactly (string literal match)");
            Assert.AreEqual("PRIMARY", orderResponse.Receivers[0].Type, "Should match exactly (string literal match)");
            Assert.AreEqual("MPA-14AC21F09CAE", orderResponse.Receivers[1].MoipAccount.Id, "Should match exactly (string literal match)");
            Assert.AreEqual("SECONDARY", orderResponse.Receivers[1].Type, "Should match exactly (string literal match)");
            Assert.AreEqual("MPA-B0D880F21EF1", orderResponse.Receivers[2].MoipAccount.Id, "Should match exactly (string literal match)");
            Assert.AreEqual("SECONDARY", orderResponse.Receivers[2].Type, "Should match exactly (string literal match)");
            Assert.AreEqual("BRL", orderResponse.Amount.Currency, "Should match exactly (string literal match)");
            Assert.AreEqual("Fulano de Tal", orderResponse.Customer.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("OFulanoDeTal", orderResponse.Customer.OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("1990-01-01", orderResponse.Customer.BirthDate, "Should match exactly (string literal match)");
            Assert.AreEqual("fulano@detal.com.br", orderResponse.Customer.Email, "Should match exactly (string literal match)");
            Assert.AreEqual("Rua test", orderResponse.ShippingAddress.Street, "Should match exactly (string literal match)");
            Assert.AreEqual("123", orderResponse.ShippingAddress.StreetNumber, "Should match exactly (string literal match)");
            Assert.AreEqual("Ap test", orderResponse.ShippingAddress.Complement, "Should match exactly (string literal match)");
            Assert.AreEqual("Bairro test", orderResponse.ShippingAddress.District, "Should match exactly (string literal match)");
            Assert.AreEqual("TestCity", orderResponse.ShippingAddress.City, "Should match exactly (string literal match)");
            Assert.AreEqual("SP", orderResponse.ShippingAddress.State, "Should match exactly (string literal match)");
            Assert.AreEqual("BRA", orderResponse.ShippingAddress.Country, "Should match exactly (string literal match)");
            Assert.AreEqual("01234000", orderResponse.ShippingAddress.ZipCode, "Should match exactly (string literal match)");
            Assert.AreEqual("55", orderResponse.Customer.Phone.CountryCode, "Should match exactly (string literal match)");
            Assert.AreEqual("11", orderResponse.Customer.Phone.AreaCode, "Should match exactly (string literal match)");
            Assert.AreEqual("66778899", orderResponse.Customer.Phone.Number, "Should match exactly (string literal match)");
            Assert.AreEqual("CPF", orderResponse.Customer.TaxDocument.Type, "Should match exactly (string literal match)");
            Assert.AreEqual("22222222222", orderResponse.Customer.TaxDocument.Number, "Should match exactly (string literal match)");
            Assert.AreEqual(1500, orderResponse.Amount.Subtotals.Shipping, "Should match exactly (string literal match)");
            Assert.AreEqual(20, orderResponse.Amount.Subtotals.Addition, "Should match exactly (string literal match)");
            Assert.AreEqual(10, orderResponse.Amount.Subtotals.Discount, "Should match exactly (string literal match)");
        }

        [Test]
        public void TestListOrder()
        {

            Moip.Models.OrderListResponse orderResponseList = controller.ListOrders();

            List<Moip.Models.OrderResponse> orderList = orderResponseList.Orders;

            Assert.AreEqual("my_own_id", orderList[0].OwnId, "Should match exactly (string literal match)");
            Assert.AreEqual("MPA-9C65D6964D21", orderList[0].Receivers[0].MoipAccount.Id, "Should match exactly (string literal match)");
            Assert.AreEqual("PRIMARY", orderList[0].Receivers[0].Type, "Should match exactly (string literal match)");
            Assert.AreEqual("BRL", orderList[0].Amount.Currency, "Should match exactly (string literal match)");
            Assert.AreEqual("fulano de tal", orderList[0].Customer.Fullname, "Should match exactly (string literal match)");
            Assert.AreEqual("fulano@detal.com.br", orderList[0].Customer.Email, "Should match exactly (string literal match)");
            Assert.IsTrue(orderList.Count > 1, "OrderList should have more than one element");
        }

    }
}
