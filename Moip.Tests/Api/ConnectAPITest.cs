using Moip.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Moip.Tests
{
    [TestFixture]
    public class ConnectAPITest : ControllerTestBase
    {

        private static ConnectController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Connect;
        }

        [Test]
        public void GenerateTokenOAuth()
        {
            Moip.Models.ConnectRequest connectRequest = Helpers.RequestsCreator.CreateConnectRequest();

            Moip.Models.ConnectResponse connectResponse = controller.Authorize(connectRequest);

            Assert.NotNull(connectResponse.AccessToken, "Id should not be null");
            Assert.NotNull(connectResponse.ExpiresIn, "Id should not be null");
            Assert.NotNull(connectResponse.RefreshToken, "Id should not be null");
            Assert.NotNull(connectResponse.Scope, "Id should not be null");
            Assert.NotNull(connectResponse.MoipAccount.Id, "Id should not be null");
        }

        [Test]
        public void RefreshTokenOAuth()
        {
            Moip.Models.ConnectRequest connectRequest = Helpers.RequestsCreator.CreateConnectRefreshRequest();

            Moip.Models.ConnectResponse connectResponse = controller.Authorize(connectRequest);

            Assert.NotNull(connectResponse.AccessToken, "Id should not be null");
            Assert.NotNull(connectResponse.ExpiresIn, "Id should not be null");
            Assert.NotNull(connectResponse.RefreshToken, "Id should not be null");
            Assert.NotNull(connectResponse.Scope, "Id should not be null");
            Assert.NotNull(connectResponse.MoipAccount.Id, "Id should not be null");
        }
    }
}
