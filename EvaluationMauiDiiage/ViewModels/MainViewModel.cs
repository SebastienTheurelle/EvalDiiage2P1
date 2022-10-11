using System;
using EvaluationMauiDiiage.Models.Entity;
using EvaluationMauiDiiage.Services;
using EvaluationMauiDiiage.Services.Interfaces;
using Newtonsoft.Json;
using Plugin.Firebase.CloudMessaging;
using ReactiveUI;

namespace EvaluationMauiDiiage.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region CTOR

        public MainViewModel(INavigationService navigationService,IServiceSource serviceSource) : base(navigationService)
        {
            _serviceSource = serviceSource;
            DetailRdvCommand = new DelegateCommand<RdvEntity>(OnDetailClick);

        }

        #endregion

        #region Lifecycle

        public override async Task<Task> OnNavigatedToAsync(INavigationParameters parameters)
        {

            LstRdv = await _serviceSource.GetSourceFileContent();

            await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
            var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
            Console.WriteLine(token);

            return base.OnNavigatedToAsync(parameters);
        }


        #endregion

        #region Properties
        private readonly IServiceSource _serviceSource;

        private List<RdvEntity> _lstRdv;

        public List<RdvEntity> LstRdv
        {
            get { return _lstRdv; }
            set { this.RaiseAndSetIfChanged(ref _lstRdv, value); }
        }


        #endregion

        #region Commands
        public DelegateCommand<RdvEntity> DetailRdvCommand { get; set; }
        public async void OnDetailClick(RdvEntity rdv)
        {
            NavigationParameters parameters = new NavigationParameters { { "idRdv", rdv.Id } };
            await NavigationService.NavigateAsync($"{Commons.Constants.DetailRdvPageNavigationKey}",parameters);
        }

        #endregion
    }
}

