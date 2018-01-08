using Moip.Controllers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Moip.Tests
{
    [TestFixture]
    public class NotificationsRequestsTest : ControllerTestBase
    {

        private static NotificationsController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Notifications;
        }

        [Test]
        public void TestCreateNotificationsPreferencesRequest()
        {

            Moip.Models.NotificationPreferenceRequest notificationRequest = Helpers.RequestsCreator.CreateNotificationRequest();

            string notificationRequestJson = Newtonsoft.Json.JsonConvert.SerializeObject(notificationRequest);

            string expectedNotificationRequestJson = Helpers.FileReader.readJsonFile(@"Notification\notification.json");

            Assert.AreEqual(expectedNotificationRequestJson, notificationRequestJson,
                "Notification request body should match exactly (string literal match)");

        }
    }
}
