using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.Models.Dtos.Down;
using EvaluationMauiDiiage.Services.Interfaces;
using ReactiveUI;

namespace EvaluationMauiDiiage.ViewModels
{
    public class RendezVousNotificationPageViewModel : BaseViewModel
    {
        #region CTOR

        public RendezVousNotificationPageViewModel(INavigationService navigationService, INotificationService notificationService) : base(navigationService)
        {
            _notificationService = notificationService;
            _notificationService.Initialize();
            RendezVousNotificationCommand = new DelegateCommand(async () => await OnRendezVousNotificationCommand());
        }

        #endregion

        #region Lifecycle


        #endregion

        #region Properties

        private INotificationService _notificationService;

        private string _titleNotification;
        public string TitleNotification
        {
            get { return _titleNotification; }
            set { this.RaiseAndSetIfChanged(ref _titleNotification, value); }
        }

        private string _messageNotification;
        public string MessageNotification
        {
            get { return _messageNotification; }
            set { this.RaiseAndSetIfChanged(ref _messageNotification, value); }
        }

        private DateTime _dateNotification;
        public DateTime DateNotification
        {
            get { return _dateNotification; }
            set { this.RaiseAndSetIfChanged(ref _dateNotification, value); }
        }

        #endregion

        #region Commands

        public DelegateCommand RendezVousNotificationCommand { get; }
        private async Task OnRendezVousNotificationCommand()
        {
            _notificationService.SendNotification(TitleNotification, MessageNotification, DateNotification);
        }

        #endregion
        
        public async override Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            await base.OnNavigatedToAsync(parameters);
            var param = parameters.GetValue<RendezVousDtoDown>(Constants.RendezVousIdNavigationParameter);

            this.TitleNotification = param.Name;
            this.MessageNotification = param.Note;
            this.DateNotification = param.ScheduledDate;
        }

        
    }
}
