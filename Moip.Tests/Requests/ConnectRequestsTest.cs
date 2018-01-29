using Moip.Controllers;
using Moip.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Moip.Tests
{
    [TestFixture]
    public class ConnectRequestsTest : ControllerTestBase
    {

        private static ConnectController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Connect;
        }

        [Test]
        public void TestGetAuthURL()
        {
            string authURL = controller.GetAuthorizeUrl("APP-XT5FIAK2F8I7",
                "http://localhost/moip/callback.php",
                new ScopePermissionList(
                    ScopePermission.DEFINE_PREFERENCES,
                    ScopePermission.MANAGE_ACCOUNT_INFO,
                    ScopePermission.RECEIVE_FUNDS,
                    ScopePermission.REFUND,
                    ScopePermission.RETRIEVE_FINANCIAL_INFO,
                    ScopePermission.TRANSFER_FUNDS
                )
            );

            Assert.AreEqual("https://connect-sandbox.moip.com.br/oauth/authorize?response_type=code&client_id=APP-XT5FIAK2F8I7&redirect_uri=http%3A%2F%2Flocalhost%2Fmoip%2Fcallback.php&scope=DEFINE_PREFERENCES%2CMANAGE_ACCOUNT_INFO%2CRECEIVE_FUNDS%2CREFUND%2CRETRIEVE_FINANCIAL_INFO%2CTRANSFER_FUNDS", authURL);
        }


        [Test]
        public void TestCreateConnectRequest()
        {
            Moip.Models.ConnectRequest generatedConnectRequest = Helpers.RequestsCreator.CreateConnectRequest();

            string generatedConnectRequestJson = Newtonsoft.Json.JsonConvert.SerializeObject(generatedConnectRequest);

            string expectedConnectJson = Helpers.FileReader.readJsonFile(@"Connect\connect.json");

            Assert.AreEqual(expectedConnectJson, generatedConnectRequestJson,
                "Connect request body should match exactly (string literal match)");
        }

        [Test]
        public void TestCreateConnectRefreshRequest()
        {
            Moip.Models.ConnectRequest generatedConnectRequest = Helpers.RequestsCreator.CreateConnectRefreshRequest();

            string generatedConnectRequestJson = Moip.Utilities.APIHelper.JsonSerialize(generatedConnectRequest);

            string expectedConnectJson = Helpers.FileReader.readJsonFile(@"Connect\refresh.json");

            Assert.AreEqual(expectedConnectJson, generatedConnectRequestJson,
                "Connect request body should match exactly (string literal match)");
        }



    }
}
