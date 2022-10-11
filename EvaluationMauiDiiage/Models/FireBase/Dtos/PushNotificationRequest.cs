namespace EvaluationMauiDiiage.Models.FireBase.Dtos
{
    public class PushNotificationRequest
    {
        public List<string> registration_ids { get; set; } = new List<string>();
        public NotificationMessageBody notification { get; set; }
        public object data { get; set; }
    }
}
