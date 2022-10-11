using EvaluationMauiDiiage.Helpers.Interface;
using EvaluationMauiDiiage.Models.Entities;
using EvaluationMauiDiiage.Services.Interface;
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
            _notificationHelper.NotificationReceived += (sender, eventArgs) =>
            {
                var data = (NotificationEventArgs)eventArgs;
                ShowNotification(data.Tittle, data.Message);
            };
        }

        public void SendNotification(string title, string message)
        {
            _notificationHelper.SendNotification(title, message, DateTime.Now);

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
