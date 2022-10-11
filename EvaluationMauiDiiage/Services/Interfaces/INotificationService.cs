namespace EvaluationMauiDiiage.Services.Interfaces
{
    public interface INotificationService
    {
        void ShowNotification(string title, string message);
        void Initialize();
        void SendNotification(string title, string message);
        void ScheduleNotification(string title, string message, DateTime dateTime);
    }
}
