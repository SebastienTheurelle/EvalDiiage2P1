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
            containerRegistry.RegisterForNavigation();

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

    private static void RegisterForNavigation(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainPage, MainViewModel>(Constants.MainPageNavigationKey);
        containerRegistry.RegisterForNavigation<NotifPage, NotifViewModel>(Constants.NotifPageNavigationKey);
        containerRegistry.RegisterForNavigation<RDVPage, RDVViewModel>(Constants.RDVPageNavigationKey);

        containerRegistry.RegisterSingleton<IServiceSource, ServiceSource>();

    }

}