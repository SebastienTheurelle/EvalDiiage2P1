using System;
using System.Collections.ObjectModel;
using EvaluationMauiDiiage.Models.DTOs.Down;
using EvaluationMauiDiiage.Services;
using EvaluationMauiDiiage.Services.Interface;
using Newtonsoft.Json;
using ReactiveUI;

namespace EvaluationMauiDiiage.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region CTOR

        public MainViewModel(INavigationService navigationService, IServiceSource sourceService) : base(navigationService)
        {
            _serviceSource = sourceService;

            GetSources();

            DetailCommand = new DelegateCommand<SourceDtoDown>((SourceDtoDown source) => OnDetail(source));
        }

        #endregion

        #region Lifecycle

        #endregion

        #region Properties

        private readonly IServiceSource _serviceSource;

        private List<SourceDtoDown> _lstSource;

        public List<SourceDtoDown> LstSource
        {
            get => _lstSource;
            set => this.RaiseAndSetIfChanged(ref _lstSource, value);
        }

        #endregion

        #region Commands

        public DelegateCommand<SourceDtoDown> DetailCommand { get; set; }
        async void OnDetail(SourceDtoDown source)
        {
            var parameters = new NavigationParameters { { "source", source } };
            await NavigationService.NavigateAsync($"{Commons.Constants.DetailPageNavigationKey}", parameters);
        }

        #endregion

        #region Methodes

        private async void GetSources() 
        {
            string json = await _serviceSource.GetSourceFileContent();

            LstSource = JsonConvert.DeserializeObject<List<SourceDtoDown>>(json).OrderBy(l => l.ScheduledDate).ToList();
        }

        #endregion
    }
}

