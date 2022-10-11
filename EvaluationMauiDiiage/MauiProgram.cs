using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.ViewModels;
using EvaluationMauiDiiage.Views;
using CommunityToolkit.Maui;
using EvaluationMauiDiiage.Services;
using EvaluationMauiDiiage.Services.Interfaces;
using EvaluationMauiDiiage.Helpers.Interfaces;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Shared;
#if ANDROID
    using Plugin.Firebase.Android;
    using EvaluationMauiDiiage.Platforms.Android.Helpers;
#endif

namespace EvaluationMauiDiiage;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .RegisterFirebaseServices()
            .UsePrism(prismAppBuilder => prismAppBuilder.RegisterTypes(containerRegistry =>
        {
            containerRegistry.RegisterForNavigation();
            containerRegistry.RegisterServices();
            containerRegistry.RegisterHelpers();

        }).OnAppStart(navigation =>
        {
            navigation.NavigateAsync($"{Constants.NavigationPageNavigationKey}/{Constants.MainPageNavigationKey}");

        })).ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        return builder.Build();
    }

    private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events => {
            #if ANDROID
                events.AddAndroid(android => android.OnCreate((activity, state) =>
                    CrossFirebase.Initialize(activity, state, CreateCrossFirebaseSettings())));
            #endif
        });

        builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
        return builder;
    }

    private static CrossFirebaseSettings CreateCrossFirebaseSettings()
    {
        return new CrossFirebaseSettings(isAuthEnabled: true, isCloudMessagingEnabled: true);
    }

    private static void RegisterForNavigation(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainPage, MainViewModel>(Constants.MainPageNavigationKey);
        containerRegistry.RegisterForNavigation<DetailRdvPage, DetailRdvViewModel>(Constants.DetailRdvPageNavigationKey);
    }

    private static void RegisterServices(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IServiceSource,ServiceSource>();
        containerRegistry.RegisterSingleton<INotificationService,NotificationService>();
    }

    private static void RegisterHelpers(this IContainerRegistry containerRegistry)
    {
        #if ANDROID
                containerRegistry.RegisterSingleton<INotificationHelper, AndroidNotificationHelper>();
        #endif
    }

}