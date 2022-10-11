using EvaluationMauiDiiage.Models.FireBase.Dtos;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace EvaluationMauiDiiage.Helper
{
    public static class FirebaseSendHelper
    {
        private static HttpClient _httpClient;
        private const string URL_SEND = "https://fcm.googleapis.com/fcm/send";
        static FirebaseSendHelper()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=" + "AAAAQWC9Rn8:APA91bGocqHWHC0CnOwpm3MOq9JQ1bfZSblVC9WCCsvmZrLX_2KdO7ZwOHfNd5sa_12HB3WnfL2P-2OtxGE2atH5Gj3WxlNaxu15LQbpPh7GlesrhIOoLi4A2NxLJd5QdP1eQ81zWO7i");
            }
        }

        public static async Task<HttpResponseMessage> SendSimpleNotification(string title, string body, string deviceToken)
        {

            var notificationMessageBody = new NotificationMessageBody
            {
                title = title,
                body = body
            };

            var pushNotificationRequest = new PushNotificationRequest
            {
                notification = notificationMessageBody,
                registration_ids = new List<string> { deviceToken },
            };

            string serializeRequest = JsonConvert.SerializeObject(pushNotificationRequest);
            var response = await _httpClient.PostAsync(URL_SEND, new StringContent(serializeRequest, Encoding.UTF8, "application/json"));
            return response;
        }
    }
}
