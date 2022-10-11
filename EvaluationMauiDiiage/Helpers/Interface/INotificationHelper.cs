using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationMauiDiiage.Helpers.Interface
{
    public interface INotificationHelper
    {
        event EventHandler NotificationReceived;
        void Initialize();
        void SendNotification(string title, string notificationMessage, DateTime? notifyTime = null);
        void ReceiveNotification(string title, string notificationMessage);
    }
}
