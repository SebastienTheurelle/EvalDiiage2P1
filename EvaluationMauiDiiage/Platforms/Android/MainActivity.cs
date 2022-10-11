using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using EvaluationMauiDiiage.Platforms.Android.Services;
using EvaluationMauiDiiage.Services.Interfaces;
using Plugin.Firebase.CloudMessaging;

namespace EvaluationMauiDiiage;

[Activity(Theme = "@style/Maui.SplashTheme", LaunchMode = LaunchMode.SingleTop, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        CreateNotificationFromIntent(Intent);
        HandleIntent(Intent);
        CreateNotificationChannelIfNeeded();
    }
    protected override void OnNewIntent(Intent intent)
    {
        HandleIntent(intent);
        CreateNotificationFromIntent(intent);
    }

    private static void HandleIntent(Intent intent)
    {
        FirebaseCloudMessagingImplementation.OnNewIntent(intent);
    }

    private void CreateNotificationChannelIfNeeded()
    {
        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        {
            CreateNotificationChannel();
        }
    }

    private void CreateNotificationChannel()
    {
        var channelId = $"{PackageName}.general";
        var notificationManager = (NotificationManager)GetSystemService(NotificationService);
        var channel = new NotificationChannel(channelId, "General", NotificationImportance.Default);
        notificationManager.CreateNotificationChannel(channel);
        FirebaseCloudMessagingImplementation.ChannelId = channelId;
        //FirebaseCloudMessagingImplementation.SmallIconRef = Resource.Drawable.ic_push_small;
    }

    void CreateNotificationFromIntent(Intent intent)
    {
        if (intent?.Extras != null)
        {
            string title = intent.GetStringExtra(AndroidNotificationService.TitleKey);
            string message = intent.GetStringExtra(AndroidNotificationService.MessageKey);
            DependencyService.Get<INotificationService>().ReceiveNotification(title, message);
        }
    }
}

