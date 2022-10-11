using EvaluationMauiDiiage.Models.Entity;
using EvaluationMauiDiiage.Services.Interfaces;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationMauiDiiage.ViewModels
{
    public class DetailRdvViewModel : BaseViewModel
    {

        #region CTOR
        public DetailRdvViewModel(INavigationService navigationService,IServiceSource serviceSource, INotificationService notificationService) : base(navigationService)
        {
            _serviceSource = serviceSource;
            CreationNotifCommand = new DelegateCommand(async () => await OnCreationNotif());
            _notificationService = notificationService;
        }
        #endregion

        #region Lifecycle

        public override async Task<Task> OnNavigatedToAsync(INavigationParameters parameters)
        {

            parameters.TryGetValue("idRdv", out _idRdv);

            Rdv = await _serviceSource.GetById(_idRdv);

            SelectedDate = DateTime.Now;

            return base.OnNavigatedToAsync(parameters);
        }


        #endregion

        #region Properties
        private readonly IServiceSource _serviceSource;
        private readonly INotificationService _notificationService;

        private RdvEntity _rdv;

        public RdvEntity Rdv
        {
            get { return _rdv; }
            set { this.RaiseAndSetIfChanged(ref _rdv, value); }
        }

        private long _idRdv;

        private string _titreNotif;

        public string TitreNotif
        {
            get { return _titreNotif; }
            set { this.RaiseAndSetIfChanged(ref _titreNotif, value); }
        }

        private string _messageNotif;

        public string MessageNotif
        {
            get { return _messageNotif; }
            set { this.RaiseAndSetIfChanged(ref _messageNotif, value); }
        }

        private DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { this.RaiseAndSetIfChanged(ref _selectedDate, value); }
        }

        private TimeSpan _selectedTime;
        public TimeSpan SelectedTime
        {
            get { return _selectedTime; }
            set { this.RaiseAndSetIfChanged(ref _selectedTime, value); }
        }
        #endregion

        #region Commands
        public DelegateCommand CreationNotifCommand { get; set; }
        public async Task OnCreationNotif()
        {
            SelectedDate = SelectedDate.AddHours(SelectedTime.Hours);
            SelectedDate = SelectedDate.AddMinutes(SelectedTime.Minutes);
            _notificationService.ScheduleNotification(TitreNotif, MessageNotif, SelectedDate);
            _notificationService.SendNotification(TitreNotif, MessageNotif);
            //await NavigationService.NavigateAsync($"{Commons.Constants.NavigationPageNavigationKey}/{Commons.Constants.MainPageNavigationKey}");
        }

        #endregion

    }
}
