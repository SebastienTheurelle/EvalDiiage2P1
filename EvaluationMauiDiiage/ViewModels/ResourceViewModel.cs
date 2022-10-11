using System;
using System.Reactive;
using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.Models.Entities;
using EvaluationMauiDiiage.Services.Interfaces;
using ReactiveUI;

namespace EvaluationMauiDiiage.ViewModels;

public class ResourceViewModel : BaseViewModel
{
    private readonly IResourceService _resourceService;
    private readonly INotificationService _notificationService;

    #region CTOR

    public ResourceViewModel(INavigationService navigationService, IResourceService resourceService, INotificationService notificationService) : base(navigationService)
    {
        _resourceService = resourceService;
        _notificationService = notificationService;

        CreateNotificationCommand = ReactiveCommand.CreateFromTask(OnCreateNotificationCommand);
        NotificationDate = DateTime.Now.AddSeconds(10);
    }

    #endregion

    #region Life cycle

    public override async Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        await base.OnNavigatedToAsync(parameters);


        if (parameters.TryGetValue<long>(Constants.ResourceIdNavigationParameterKey, out long resourceId))
        {
            var resource = await _resourceService.GetResourceAsync(resourceId);
            if (resource != null)
                Resource = new ResourceEntity(resource);
        }
        else
            await NavigationService.GoBackAsync();
    }

    #endregion

    #region Properties

    #region NotificationTitle

    private string _notificationTitle;
    public string NotificationTitle
    {
        get => _notificationTitle;
        set => this.RaiseAndSetIfChanged(ref _notificationTitle, value);
    }

    #endregion

    #region NotificationContent

    private string _notificationContent;
    public string NotificationContent
    {
        get => _notificationContent;
        set => this.RaiseAndSetIfChanged(ref _notificationContent, value);
    }

    #endregion

    #region NotificationDate

    private DateTime _notificationDate;
    public DateTime NotificationDate
    {
        get => _notificationDate;
        set => this.RaiseAndSetIfChanged(ref _notificationDate, value);
    }

    #endregion

    #region Resource

    private ResourceEntity _resource;
    public ResourceEntity Resource
    {
        get => _resource;
        set => this.RaiseAndSetIfChanged(ref _resource, value);
    }

    #endregion

    #endregion

    #region Methods & Commands

    #region OnCreateNotificationCommand

    public ReactiveCommand<Unit, Unit> CreateNotificationCommand { get; private set; }
    private async Task OnCreateNotificationCommand()
    {
        _notificationService.SendNotification("Sucess", $"Notification programmed the {NotificationDate}");
        _notificationService.SendNotification(NotificationTitle, NotificationContent, NotificationDate);
    }

    #endregion


    #endregion
}

