using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.ViewModels;
using EvaluationMauiDiiage.Views;
using CommunityToolkit.Maui;
using EvaluationMauiDiiage.Services;

using EvaluationMauiDiiage.Services.Interfaces;
using EvaluationMauiDiiage.Helper.Interfaces;
using EvaluationMauiDiiage.Helper;

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
                containerRegistry.RegisterServices();
                containerRegistry.RegisterHelpers();

            }).OnAppStart(navigation =>
            {
                navigation.NavigateAsync($"{Constants.MainPageNavigationKey}");

            })
        ).ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();

        return builder.Build();
    }

    private static void RegisterForNavigation(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
    }

    public static void RegisterServices(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IAppointmentService, AppointmentService>();
    }

    public static void RegisterHelpers(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<ISerializationHelper, SerializationHelper>();
    }

}