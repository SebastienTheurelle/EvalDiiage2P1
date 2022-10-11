using System;
namespace EvaluationMauiDiiage.Services.Interfaces
{
    public interface INotificationsService
    {
        void Initialize();
        void SendNotification(string title, string message, DateTime? notifyTime = null);
        void ShowNotification(string title, string message);
    }
}

