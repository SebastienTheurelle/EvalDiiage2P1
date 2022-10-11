namespace EvaluationMauiDiiage.Services.Interface
{
    public interface INotificationService
    {
        void Initialize();
        void SendNotification(string title, string message);
        void ShowNotification(string title, string message);
    }
}
