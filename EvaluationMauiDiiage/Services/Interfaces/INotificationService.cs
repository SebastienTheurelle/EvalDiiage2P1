namespace EvaluationMauiDiiage.Services.Interfaces
{
    public interface INotificationService
    {
        void Initialize();
        void SendNotification(string title, string message, DateTime dateTime);
        void ShowNotification(string title, string message);
    }
}
