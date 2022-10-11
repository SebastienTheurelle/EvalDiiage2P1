using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using EvaluationMauiDiiage.Helpers.Interfaces;
using EvaluationMauiDiiage.Platforms.Android.Helpers;

namespace EvaluationMauiDiiage;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public static readonly string Channel_ID = "TestChannel";
    public static readonly int NotificationID = 101;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        CreateNotificationChannel();
        CreateNotificationFromIntent(Intent);
    }

    private void CreateNotificationChannel()
    {
        if (OperatingSystem.IsOSPlatformVersionAtLeast("android", 26))
        {
            var channel = new NotificationChannel(Channel_ID, "Test Notfication Channel", NotificationImportance.Default);

            var notificaitonManager = (NotificationManager)GetSystemService(NotificationService);
            notificaitonManager.CreateNotificationChannel(channel);
        }
    }

    protected override void OnNewIntent(Intent intent)
    {
        CreateNotificationFromIntent(intent);
    }

    void CreateNotificationFromIntent(Intent intent)
    {
        if (intent?.Extras != null)
        {
            string title = intent.GetStringExtra(AndroidNotificationHelper.TitleKey);
            string message = intent.GetStringExtra(AndroidNotificationHelper.MessageKey);

            DependencyService.Get<INotificationsHelper>().ReceiveNotification(title, message);
        }
    }
}

