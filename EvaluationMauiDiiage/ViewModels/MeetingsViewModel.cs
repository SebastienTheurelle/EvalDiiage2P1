using System;
using EvaluationMauiDiiage.Models.Wrappers;
using EvaluationMauiDiiage.Services;
using EvaluationMauiDiiage.Services.Interfaces;
using Newtonsoft.Json;
using ReactiveUI;
using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.Helpers;

namespace EvaluationMauiDiiage.ViewModels
{
    public class MeetingsViewModel : BaseViewModel
    {
        #region CTOR

        public MeetingsViewModel(INavigationService navigationService, IMeetingsService meetingsService, INotificationsService notificationsService) : base(navigationService)
        {
            _navigationService = navigationService;
            _meetingsService = meetingsService;
            _notificationsService = notificationsService;
            MeetingsCommand = new DelegateCommand<MeetingsWrapper>(async (x) => await OnMeetingsClick(x));
        }

        #endregion

        #region Lifecycle
        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            var meetings = _meetingsService.GetSourceFileContent();

            var deviceToken = string.Empty;
            if (Preferences.ContainsKey("DeviceToken"))
            {
                deviceToken = Preferences.Get("DeviceToken", "");
            }

            await FirebaseSendHelper.SendSimpleNotification("Firebase", "Ici l'assitant FireBase", deviceToken);

            await base.OnNavigatedToAsync(parameters);
        }

        #endregion

        #region Properties
        private IMeetingsService _meetingsService;
        private INavigationService _navigationService;
        private INotificationsService _notificationsService;

        private MeetingsWrapper _meetings;
        public MeetingsWrapper Meetings {
            get => _meetings;
            set => this.RaiseAndSetIfChanged(ref _meetings, value);
        }
        #endregion

        #region Commands
        public DelegateCommand<MeetingsWrapper> MeetingsCommand { get; }
        public async Task OnMeetingsClick(MeetingsWrapper meeting)
        {
            var parameters = new NavigationParameters
            {
                { "meetingId", meeting?.Id }
            };

            await _navigationService.NavigateAsync($"{Constants.NavigationPageNavigationKey}/{Constants.NotificationsPage}");
        }
        #endregion
    }
}

