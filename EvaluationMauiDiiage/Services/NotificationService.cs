using EvaluationMauiDiiage.Helpers.Interfaces;
using EvaluationMauiDiiage.Services.Interfaces;
using static EvaluationMauiDiiage.Helpers.Interfaces.INotificationHelper;

namespace EvaluationMauiDiiage.Services
{
    public class NotificationService : INotificationService
    {
        INotificationHelper _notificationHelper;

        public void Initialize()
        {
            _notificationHelper = ContainerLocator.Container.Resolve<INotificationHelper>();
            _notificationHelper.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
            };
        }

        public void SendNotification(string title, string message)
        {
            _notificationHelper.SendNotification(title, message);
        }

        public void ScheduleNotification(string title, string message,DateTime dateTime)
        {
            _notificationHelper.SendNotification(title, message,dateTime);
        }

        public void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Title: {title}\n {message}"
                };
            });
        }
    }
}
