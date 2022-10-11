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
    protected override void OnCreate(Bundle savedInstanceState)
    {
        try
        {
            base.OnCreate(savedInstanceState);
            CreateNotificationFromIntent(Intent);
            HandleIntent(Intent);
            CreateNotificationChannelIfNeeded();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    protected override void OnNewIntent(Intent intent)
    {
        base.OnNewIntent(intent);
        HandleIntent(intent);
        CreateNotificationFromIntent(intent);
    }

    private static void HandleIntent(Intent intent)
    {
        //FirebaseCloudMessagingImplementation.OnNewIntent(intent);
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
        //FirebaseCloudMessagingImplementation.ChannelId = channelId;
        //FirebaseCloudMessagingImplementation.SmallIconRef = Resource.Drawable.ic_push_small;
    }

    void CreateNotificationFromIntent(Intent intent)
    {
        if (intent?.Extras != null)
        {
            string title = intent.GetStringExtra(AndroidNotificationHelper.TitleKey);
            string message = intent.GetStringExtra(AndroidNotificationHelper.MessageKey);
            DependencyService.Get<INotificationHelper>().ReceiveNotification(title, message);
        }
    }
}

