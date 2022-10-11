﻿using System;
namespace EvaluationMauiDiiage.Helpers.Interfaces
{
    public interface INotificationsHelper
    {
        event EventHandler NotificationReceived;
        void Initialize();
        void SendNotification(string title, string message, DateTime? notifyTime = null);
        void ReceiveNotification(string title, string message);

        public class NotificationEventArgs : EventArgs
        {
            public string Title { get; set; }
            public string Message { get; set; }
        }
    }
}

