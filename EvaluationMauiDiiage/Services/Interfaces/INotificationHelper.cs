using System;
namespace EvaluationMauiDiiage.Services.Interfaces;

public interface INotificationService
{
    event EventHandler NotificationReceived;
    void Initialize();
    void SendNotification(string title, string message, DateTime? notifyTime = null);
    void ReceiveNotification(string title, string message);
}

