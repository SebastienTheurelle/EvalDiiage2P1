using System;
using System.Collections.ObjectModel;
using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.Models.Wrapper;
using EvaluationMauiDiiage.Services;
using EvaluationMauiDiiage.Services.Interfaces;
using EvaluationMauiDiiage.ViewModels.Base;
using Newtonsoft.Json;
using Prism.Navigation;
using ReactiveUI;

namespace EvaluationMauiDiiage.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Attributes Privates
        private INavigationService _navigationService;
        private IAppointmentService _appointmentService;
        private ObservableCollection<AppointmentWrapper> _appointments;
        private AppointmentWrapper _selectedAppointment;
        #endregion

        #region Properties Publics
        public ObservableCollection<AppointmentWrapper> Appointments
        {
            get => _appointments;
            set => SetProperty(ref (_appointments), value);
        }

        public object SelectedAppointment { get; set; }
        #endregion

        #region CTOR
        public MainPageViewModel(INavigationService navigationService, IAppointmentService appointmentService) : base(navigationService)
        {
            _navigationService = navigationService;
            _appointmentService = appointmentService;
        }
        #endregion

        #region Lifecycle
        public override void OnAppearing()
        {
            base.OnAppearing();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            IsLoading = true;
            try
            {
                LoadAppointments();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                IsLoading = false;
            }
            base.OnNavigatedTo(parameters);
        }

        #endregion

        #region Commands
        public DelegateCommand<AppointmentWrapper> OnOptionsSelectionChangedCommand { get; }
        #endregion

        #region Method
        private async void LoadAppointments()
        {
            Appointments = (ObservableCollection<AppointmentWrapper>)(await _appointmentService.GetAll());
        }

        public async Task OnSpaceClick(AppointmentWrapper appointment)
        {
            var parameters = new NavigationParameters
            {
                { "appointment", appointment?.Id }
            };

            await _navigationService.NavigateAsync(Constants.DetailsPageNavigationKey, parameters);
        }
        #endregion
    }
}

