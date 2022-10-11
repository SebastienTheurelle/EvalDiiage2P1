using System;
using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.Services;
using Newtonsoft.Json;

namespace EvaluationMauiDiiage.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region CTOR

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoToRDVPageCommand = new DelegateCommand(async () => await DoRDVPageCommand());
        }

        #endregion

        #region Lifecycle


        #endregion

        #region Properties
        public DelegateCommand GoToRDVPageCommand { get; }

        #endregion

        #region Commands
        public async Task DoRDVPageCommand()
        {
            await NavigationService.NavigateAsync(Constants.RDVPageNavigationKey);
        }

        
        #endregion
    }
}

