using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.Models.Dtos.Down;
using EvaluationMauiDiiage.Services.Interfaces;
using System.Collections.ObjectModel;

namespace EvaluationMauiDiiage.ViewModels
{
    public class RendezVousListPageViewModel : BaseViewModel
    {

        #region CTOR

        public RendezVousListPageViewModel(INavigationService navigationService, IServiceSource serviceSource) : base(navigationService)
        {
            _serviceSource = serviceSource;
            RendezVousTappedCommand = new DelegateCommand<RendezVousDtoDown>(async x => await OnRendezVousTappedCommand(x));
        }

        #endregion

        #region Lifecycle


        #endregion

        #region Properties
        private IServiceSource _serviceSource;

        public ObservableCollection<RendezVousDtoDown> RendezVous { get; set; } = new();

        #endregion

        #region Commands

        public DelegateCommand<RendezVousDtoDown> RendezVousTappedCommand { get; }
        private async Task OnRendezVousTappedCommand(RendezVousDtoDown rendezVous)
        {
            var parameters = new NavigationParameters { { Constants.RendezVousIdNavigationParameter, rendezVous } };
            await NavigationService.NavigateAsync(Constants.RendezVousNotificationPageListPageNavigationKey, parameters);
        }

        #endregion

        public async override Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            var data = await _serviceSource.GetRendezVousAsync();

            RendezVous.Clear();

            data.ForEach(rdv => RendezVous.Add(rdv));
        }
        
    }
}
