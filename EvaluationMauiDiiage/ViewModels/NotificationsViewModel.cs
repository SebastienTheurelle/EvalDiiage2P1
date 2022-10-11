using System;
using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.Services.Interfaces;
using ReactiveUI;

namespace EvaluationMauiDiiage.ViewModels
{
    public class NotificationsViewModel : BaseViewModel
    {
        #region privates
        private INavigationService _navigationService;
        private INotificationsService _notificationsService;
        #endregion

        #region publics
        private int _time;
        public int Time
        {
            get { return _time; }
            set { this.RaiseAndSetIfChanged(ref _time, value); }
        }
        #endregion

        #region CTOR
        public NotificationsViewModel(INavigationService navigationService, INotificationsService notificationsService) : base(navigationService)
        {
            _navigationService = navigationService;
            _notificationsService = notificationsService;
            ValidateNotifCommand = new DelegateCommand(async () => await OnValidate());
        }
        #endregion

        #region Lifecycle
        public override Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("spaceId"))
            {
                var spaceId = parameters.GetValue<int>("spaceId");
            }
            return base.OnNavigatedToAsync(parameters);
        }
        #endregion

        #region Commands
        private DelegateCommand ValidateNotifCommand { get; }
        public async Task OnValidate()
        {
            await _navigationService.NavigateAsync($"{Constants.NavigationPageNavigationKey}/{Constants.MeetingsPage}");
        }
        #endregion
    }
}

