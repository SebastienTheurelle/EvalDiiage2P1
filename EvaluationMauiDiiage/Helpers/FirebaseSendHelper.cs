using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EvaluationMauiDiiage.Models.Firebase;
using Newtonsoft.Json;

namespace EvaluationMauiDiiage.Helpers
{
    public class FirebaseSendHelper
    {
        private static HttpClient _httpClient;
        private const string URL_SEND = "https://fcm.googleapis.com/fcm/send";
        static FirebaseSendHelper()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=" + "AAAASNV_gzM:APA91bENxI6s8rvtN7o8tWJFAv4z4HK6ZafRWEeOrA66MdSOL_CF5TldecwUu3hCaV7gdNUL-3IihocHtkJU2hIyiMJEr_Miqa9QcO450gATgeDNDy51ZbiE_glBo7-7fSZSpW3dxA86");
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

