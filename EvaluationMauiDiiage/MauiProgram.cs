using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.ViewModels;
using EvaluationMauiDiiage.Views;
using CommunityToolkit.Maui;
using EvaluationMauiDiiage.Services;
using EvaluationMauiDiiage.Services.Interfaces;

namespace EvaluationMauiDiiage;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UsePrism(prismAppBuilder => prismAppBuilder.RegisterTypes(containerRegistry =>
        {
            RegisterViews(containerRegistry);
            RegisterServices(containerRegistry);

        }).OnAppStart(navigation =>
        {
            navigation.NavigateAsync($"{Constants.NavigationPageNavigationKey}/{Constants.NotificationsPage}");

        })).ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        return builder.Build();
    }

    private static void RegisterServices(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IMeetingsService, MeetingsService>();
        containerRegistry.RegisterSingleton<INotificationsService, NotificationsService>();
    }

    private static void RegisterViews(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MeetingsPage, MeetingsViewModel>(Constants.MeetingsPage);
        containerRegistry.RegisterForNavigation<NotificationsPage, NotificationsViewModel>(Constants.NotificationsPage);
    }
}