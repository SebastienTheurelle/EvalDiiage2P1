namespace EvaluationMauiDiiage.Helpers.Interfaces
{
    public interface INotificationHelper
    {
        event EventHandler NotificationReceived;
        void Initialize();
        void SendNotification(string title, string notificationMessage, DateTime? notifyTime = null);
        void ReceiveNotification(string title, string notificationMessage);
    }
}
