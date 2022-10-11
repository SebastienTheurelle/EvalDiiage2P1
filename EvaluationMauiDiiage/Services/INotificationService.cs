using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationMauiDiiage.Services.Interfaces
{
    public interface INotificationService
    {
        event EventHandler NotificationReceived;

        void Initialize();

        void SendNotification(string title, string message);

        void ReceiveNotification(string title, string message);
    }
}