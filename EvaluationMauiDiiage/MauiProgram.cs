using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.ViewModels;
using EvaluationMauiDiiage.Views;
using CommunityToolkit.Maui;
using EvaluationMauiDiiage.Services;
using EvaluationMauiDiiage.Services.Interface;
using EvaluationMauiDiiage.Helpers.Interface;
using EvaluationMauiDiiage.Platforms.Android.Helper;

namespace EvaluationMauiDiiage;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UsePrism(prismAppBuilder => 
        prismAppBuilder.RegisterTypes(containerRegistry =>
        {
            containerRegistry.RegisterForNavigation();
            RegisterServices(containerRegistry);
            RegisterHelpers(containerRegistry);


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
    private static void RegisterHelpers(IContainerRegistry containerRegistry)
    {
        // Utilisation d'un pré processeur pour register le helper uniquement sous Android
#if ANDROID
        containerRegistry.RegisterSingleton<INotificationHelper, AndroidNotificationHelper>();
#endif
    }

    private static void RegisterServices(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<INotificationService, NotificationService>();
        containerRegistry.RegisterSingleton<IServiceSource, ServiceSource>();
    }
    private static void RegisterForNavigation(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainPage, MainViewModel>(Constants.MainPageNavigationKey);
    }

}