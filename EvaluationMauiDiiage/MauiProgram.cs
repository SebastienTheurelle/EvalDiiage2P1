using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.ViewModels;
using EvaluationMauiDiiage.Views;
using CommunityToolkit.Maui;
using EvaluationMauiDiiage.Services;
using EvaluationMauiDiiage.Services.Interfaces;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Shared;

#if ANDROID
using Plugin.Firebase.Android;
#elif IOS
using Plugin.Firebase.iOS;
#endif

namespace EvaluationMauiDiiage;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UsePrism(prismAppBuilder => prismAppBuilder.RegisterTypes(containerRegistry =>
        {
            containerRegistry.RegisterForNavigation();
            containerRegistry.RegisterServices();

        }).OnAppStart(navigation =>
        {
            navigation.NavigateAsync($"{Constants.NavigationPageNavigationKey}/{Constants.ResourcesPageNavigationKey}");

        })).ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        return builder.Build();
    }

    private static void RegisterForNavigation(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ResourcesPage, ResourcesViewModel>(Constants.ResourcesPageNavigationKey);
        containerRegistry.RegisterForNavigation<ResourcePage, ResourceViewModel>(Constants.ResourcePageNavigationKey);
    }

    private static void RegisterServices(this IContainerRegistry containerRegistry)
    {
#if ANDROID
        containerRegistry.RegisterSingleton<INotificationService, EvaluationMauiDiiage.Platforms.Android.Services.AndroidNotificationService>();
#endif

        containerRegistry.RegisterSingleton<IResourceService, ResourceService>();
    }


    private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events => {
#if IOS
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                CrossFirebase.Initialize(app, launchOptions, CreateCrossFirebaseSettings());
                return false;
            }));
#elif ANDROID
            events.AddAndroid(android => android.OnCreate((activity, state) =>
                CrossFirebase.Initialize(activity, state, CreateCrossFirebaseSettings())));
#endif
        });

        builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
        return builder;
    }

    private static CrossFirebaseSettings CreateCrossFirebaseSettings()
    {
        return new CrossFirebaseSettings(isAuthEnabled: true);
    }

}