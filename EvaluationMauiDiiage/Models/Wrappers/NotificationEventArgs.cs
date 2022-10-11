using System;
namespace EvaluationMauiDiiage.Models.Wrappers;

public class NotificationEventArgs : EventArgs
{
    public string Title { get; set; }
    public string Message { get; set; }
}

