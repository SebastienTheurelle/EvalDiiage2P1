using EvaluationMauiDiiage.Helpers.Interfaces;
using EvaluationMauiDiiage.Models.Entities;
using EvaluationMauiDiiage.Services.Interfaces;

namespace EvaluationMauiDiiage.Services
{
    public class NotificationService : INotificationService
    {
        private INotificationHelper _notificationHelper;

        public NotificationService(INotificationHelper notificationHelper)
        {
            _notificationHelper = notificationHelper;
        }

        public void Initialize()
        {
            // _notificationHelper = ContainerLocator.Container.Resolve<INotificationHelper>();
            _notificationHelper.NotificationReceived += (sender, eventArgs) =>
            {
                var data = (NotificationEventArgs)eventArgs;
                ShowNotification(data.Title, data.Message);
            };
        }

        public void SendNotification(string title, string message, DateTime dateTime)
        {
            _notificationHelper.SendNotification(title, message, dateTime);
        }

        public void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"{title} : {message}"
                };
            });
        }
    }
}
