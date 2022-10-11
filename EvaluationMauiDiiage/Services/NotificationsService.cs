using System;
using EvaluationMauiDiiage.Helpers.Interfaces;
using EvaluationMauiDiiage.Services.Interfaces;
using static EvaluationMauiDiiage.Helpers.Interfaces.INotificationsHelper;

namespace EvaluationMauiDiiage.Services
{
    public class NotificationsService : INotificationsService
    {
        INotificationsHelper _notificationHelper;

        public void Initialize()
        {
            _notificationHelper = ContainerLocator.Container.Resolve<INotificationsHelper>();
            _notificationHelper.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
            };
        }

        public void SendNotification(string title, string message, DateTime? notifyTime = null)
        {
            _notificationHelper.SendNotification(title, message, DateTime.Now);
        }

        public void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"
                };
            });
        }
    }
}

