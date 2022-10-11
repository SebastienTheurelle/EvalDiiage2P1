using System;
using System.Collections.ObjectModel;
using System.Reactive;
using DynamicData;
using EvaluationMauiDiiage.Models.Entities;
using EvaluationMauiDiiage.Services;
using EvaluationMauiDiiage.Services.Interfaces;
using Newtonsoft.Json;
using ReactiveUI;
using EvaluationMauiDiiage.Commons;

namespace EvaluationMauiDiiage.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly IResourceService _resourceService;

    #region CTOR

    public MainViewModel(INavigationService navigationService, IResourceService resourceService) : base(navigationService)
    {
        _resourceService = resourceService;

        _resourcesCache
            .Connect()
            .SortBy(x => x.ScheduledDate)
            .Bind(out _resources)
            .Subscribe();

        ResourceTappedCommand = ReactiveCommand.CreateFromTask<ResourceEntity>(OnResourceTappedCommand);
    }

    #endregion

    #region Lifecycle

    public override async Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        await base.OnNavigatedToAsync(parameters);

        var resources = await _resourceService.GetResourcesAsync();
        _resourcesCache.AddOrUpdate(resources.Select(x => new ResourceEntity(x)));
    }

    #endregion

    #region Properties

    #region Dynamic list Resources
    private SourceCache<ResourceEntity, long> _resourcesCache = new SourceCache<ResourceEntity, long>(r => r.Id);
    private readonly ReadOnlyObservableCollection<ResourceEntity> _resources;
    public ReadOnlyObservableCollection<ResourceEntity> Resources => _resources;
    #endregion

    #endregion

    #region Commands

    #region OnResourceTappedCommand

    public ReactiveCommand<ResourceEntity, Unit> ResourceTappedCommand { get; private set; }
    private async Task OnResourceTappedCommand(ResourceEntity resource)
    {
        if (resource?.Id != null)
        {
            var parameters = new NavigationParameters { { Constants.ResourceIdNavigationParameterKey, resource.Id } };
            await NavigationService.NavigateAsync(Constants.ResourcePageNavigationKey, parameters);
        }
    }

    #endregion


    #endregion
}

