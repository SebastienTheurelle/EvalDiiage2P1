namespace EvaluationMauiDiiage.Services.Interface
{
    public interface INotificationService
    {
        void ShowNotification(string title, string message);
        void Initialize();
        void SendNotification(string title, string message);
    }
}
