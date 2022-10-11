using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using EvaluationMauiDiiage.Platforms.Android.Services;
using EvaluationMauiDiiage.Services.Interfaces;

namespace EvaluationMauiDiiage;

[Activity(Theme = "@style/Maui.SplashTheme", LaunchMode = LaunchMode.SingleTop, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        CreateNotificationFromIntent(Intent);
    }
    protected override void OnNewIntent(Intent intent)
    {
        CreateNotificationFromIntent(intent);
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

