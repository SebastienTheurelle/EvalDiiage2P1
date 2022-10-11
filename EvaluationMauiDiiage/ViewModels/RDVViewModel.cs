using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using DynamicData;
using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.Models;
using EvaluationMauiDiiage.Services;
using Newtonsoft.Json;
using ReactiveUI;

namespace EvaluationMauiDiiage.ViewModels
{
    public class RDVViewModel : BaseViewModel
    {
        #region CTOR

        public RDVViewModel(INavigationService navigationService, ServiceSource serviceSource) : base(navigationService)
        {
            this.ServiceSource = serviceSource;

            GoToNotifPageCommand = new DelegateCommand(async () => await DoNotifPageCommand(RDVSelected));

            GetRDVs();
        }

        #endregion

        #region Lifecycle

        #endregion

        #region Properties

        ServiceSource ServiceSource { get; }

        public ObservableCollection<RDVEntity> RDVs { get; } = new();

        public DelegateCommand GoToNotifPageCommand { get; }

        private RDVEntity _rDVSelected;

        public RDVEntity RDVSelected
        {
            get => _rDVSelected;
            set => this.RaiseAndSetIfChanged(ref _rDVSelected, value);
        }
        public bool IsBusy { get; private set; }

        #endregion

        #region Commands
        public async Task DoNotifPageCommand(RDVEntity rDVEntity)
        {
            var parameter = new NavigationParameters {
                {"Id", rDVEntity.Id}
            };
            await NavigationService.NavigateAsync(Constants.NotifPageNavigationKey, parameter);
        }
        #endregion

        #region Methods
        public async void GetRDVs()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                var rdvs = await ServiceSource.GetSourceFileContent();

                if (RDVs.Count != 0)
                    RDVs.Clear();

                foreach (var rdv in rdvs)
                    RDVs.Add(rdv);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get rdvs: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}

