using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.ViewModels;
using EvaluationMauiDiiage.Views;
using CommunityToolkit.Maui;
using EvaluationMauiDiiage.Services;
using EvaluationMauiDiiage.Services.Interfaces;
using EvaluationMauiDiiage.Helpers.Interfaces;
using EvaluationMauiDiiage.Platforms.Android.Helpers;

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
            containerRegistry.RegisterHelpers();

        }).OnAppStart(navigation =>
        {
            navigation.NavigateAsync($"{Constants.NavigationPageNavigationKey}/{Constants.RendezVousListPageNavigationKey}");

        })).ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        return builder.Build();
    }

    private static void RegisterServices(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IServiceSource, ServiceSource>();
        containerRegistry.RegisterSingleton<INotificationService, NotificationService>();
    }

    private static void RegisterHelpers(this IContainerRegistry containerRegistry)
    {
        // Utilisation d'un pré processeur pour register le helper uniquement sous Android
#if ANDROID
        containerRegistry.RegisterSingleton<INotificationHelper, AndroidNotificationHelper>();
#endif
    }


    private static void RegisterForNavigation(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainPage, MainViewModel>(Constants.MainPageNavigationKey);
        containerRegistry.RegisterForNavigation<RendezVousListPage, RendezVousListPageViewModel>(Constants.RendezVousListPageNavigationKey);
        containerRegistry.RegisterForNavigation<RendezVousNotificationPage, RendezVousNotificationPageViewModel>(Constants.RendezVousNotificationPageListPageNavigationKey);
    }

}