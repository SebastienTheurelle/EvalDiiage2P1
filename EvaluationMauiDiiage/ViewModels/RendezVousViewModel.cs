using System;
using System.Collections.ObjectModel;
using EvaluationMauiDiiage.Models.Entities;
using EvaluationMauiDiiage.Services.Interfaces;
using Newtonsoft.Json;
using ReactiveUI;
using System.Linq;

namespace EvaluationMauiDiiage.ViewModels
{
    public class RendezVousViewModel : BaseViewModel
    {

        #region Properties
        private readonly IServiceSource _serviceSource;

        private List<RendezVousEntity> _rendezVous;
        public List<RendezVousEntity> RendezVous
        {
            get => _rendezVous;
            set => this.RaiseAndSetIfChanged(ref _rendezVous, value);
        }

        #endregion

        #region Ctor
        public RendezVousViewModel(INavigationService navigationService, IServiceSource serviceSource) : base(navigationService)
        {
            _serviceSource = serviceSource;
        }
        #endregion

        #region Lifecycle
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var jsonContent = await _serviceSource.GetSourceFileContent();
            var rendezVous = JsonConvert.DeserializeObject<List<RendezVousEntity>>(jsonContent);
            RendezVous = rendezVous.OrderBy(rdv => rdv.ScheduledDate.Date).ToList();
        }
        #endregion

    }
}
