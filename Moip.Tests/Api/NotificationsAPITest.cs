using Moip.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;

namespace Moip.Tests
{
    [TestFixture]
    public class NotificationsAPITest : ControllerTestBase
    {

        private static NotificationsController controller;

        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Notifications;
        }

        [Test]
        public void TestCreateNotificationPreference()
        {
            Moip.Models.NotificationPreferenceRequest notificationPreferenceRequest = Helpers.RequestsCreator.CreateNotificationRequest();

            Moip.Models.NotificationPreferenceResponse notificationPreferenceResponse = controller.CreateNotificationPreference(notificationPreferenceRequest);

            Assert.NotNull(notificationPreferenceResponse.Id, "Id should not be null");
            Assert.AreEqual("WEBHOOK", notificationPreferenceResponse.Media, "Should match exactly (string literal match)");
            Assert.AreEqual("ORDER.*", notificationPreferenceResponse.Events[0], "Should match exactly (string literal match)");
            Assert.AreEqual("PAYMENT.AUTHORIZED", notificationPreferenceResponse.Events[1], "Should match exactly (string literal match)");
            Assert.AreEqual("PAYMENT.CANCELLED", notificationPreferenceResponse.Events[2], "Should match exactly (string literal match)");

        }

        [Test]
        public void TestGetNotificationPreference()
        {
            Moip.Models.NotificationPreferenceRequest notificationPreferenceRequest = Helpers.RequestsCreator.CreateNotificationRequest();

            string notificationPreferenceId = controller.CreateNotificationPreference(notificationPreferenceRequest).Id;

            Moip.Models.NotificationPreferenceResponse notificationPreferenceResponse = controller.GetNotificationPreference(notificationPreferenceId);

            Assert.NotNull(notificationPreferenceResponse.Id, "Id should not be null");
            Assert.AreEqual("WEBHOOK", notificationPreferenceResponse.Media, "Should match exactly (string literal match)");
            Assert.AreEqual("ORDER.*", notificationPreferenceResponse.Events[0], "Should match exactly (string literal match)");
            Assert.AreEqual("PAYMENT.AUTHORIZED", notificationPreferenceResponse.Events[1], "Should match exactly (string literal match)");
            Assert.AreEqual("PAYMENT.CANCELLED", notificationPreferenceResponse.Events[2], "Should match exactly (string literal match)");
        }

        [Test]
        public void TestDeleteNotificationPreference()
        {
            Moip.Models.NotificationPreferenceRequest notificationPreferenceRequest = Helpers.RequestsCreator.CreateNotificationRequest();

            string notificationPreferenceId = controller.CreateNotificationPreference(notificationPreferenceRequest).Id;

            bool notificationPreferenceResponse = controller.DeleteNotificationPreference(notificationPreferenceId);

            Assert.IsTrue(notificationPreferenceResponse, "Should be true when deleting a notification preference");
        }

        [Test]
        public void TestDeleteNotificationPreferenceDeleted()
        {
            bool notificationPreferenceResponse = controller.DeleteNotificationPreference("NPR-1CZBHDZY5WUO");

            Assert.IsFalse(notificationPreferenceResponse, "Should be false when deleting a notification preference that had already been deleted");
        }

        [Test]
        public void TestListNotificationPreferences()
        {
            List<Moip.Models.NotificationPreferenceResponse> notificationPreferenceResponseList = controller.ListNotificationsPreferences();

            Assert.NotNull(notificationPreferenceResponseList[0].Id, "Id should not be null");
            Assert.AreEqual("WEBHOOK", notificationPreferenceResponseList[0].Media, "Should match exactly (string literal match)");
            Assert.AreEqual("http://requestb.in/1dhjesw1", notificationPreferenceResponseList[0].Target, "Should match exactly (string literal match)");
            Assert.AreEqual("ORDER.*", notificationPreferenceResponseList[0].Events[0], "Should match exactly (string literal match)");
            Assert.AreEqual("PAYMENT.AUTHORIZED", notificationPreferenceResponseList[0].Events[1], "Should match exactly (string literal match)");
            Assert.AreEqual("PAYMENT.CANCELLED", notificationPreferenceResponseList[0].Events[2], "Should match exactly (string literal match)");
            Assert.True(notificationPreferenceResponseList.Count > 1, "Should have more than one notification preference");
        }

        [Test]
        public void TestListWebhooks()
        {
            Moip.Models.WebhooksResponse webhooksResponse = controller.ListWebhooks();

            Assert.NotNull(webhooksResponse.Webhooks[0].ResourceId);
            Assert.NotNull(webhooksResponse.Webhooks[0].Event);
            Assert.NotNull(webhooksResponse.Webhooks[0].Url);
            Assert.NotNull(webhooksResponse.Webhooks[0].Status);
            Assert.NotNull(webhooksResponse.Webhooks[0].Id);
            Assert.NotNull(webhooksResponse.Webhooks[0].SentAt);
            Assert.AreEqual("http://requestb.in/1dhjesw1", webhooksResponse.Webhooks[0].Url, "Should match exactly (string literal match)");
            Assert.True(webhooksResponse.Webhooks.Count > 1, "Should have more than one webhook");

        }

    }
}
