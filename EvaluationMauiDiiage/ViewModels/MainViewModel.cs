using EvaluationMauiDiiage.Commons;
using EvaluationMauiDiiage.Helper;

namespace EvaluationMauiDiiage.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region CTOR
 
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.navigationService = navigationService;
            NavigateToBookings = new DelegateCommand(async () => await NavigatetoBookingsCommand());
            NavigateToLocalNotificationSettings = new DelegateCommand(async () => await NavigateToNotificationSettingsCommand());
            SendFireBaseNotification = new DelegateCommand(async () => await SendFireBaseNotificationCommand());
        }

        #endregion

        #region Lifecycle


        #endregion

        #region Properties
        private INavigationService navigationService;
        #endregion

        #region Commands
        public DelegateCommand NavigateToLocalNotificationSettings { get; }
        public DelegateCommand NavigateToBookings { get; }

        public DelegateCommand SendFireBaseNotification { get; }

        public async Task NavigatetoBookingsCommand()
        {
            await navigationService.NavigateAsync(Constants.BookingsPageNavigationKey);
        }

        public async Task NavigateToNotificationSettingsCommand()
        {
            await navigationService.NavigateAsync(Constants.LocalNotificationSettingsPageNavigationKey);
        }

        public async Task SendFireBaseNotificationCommand()
        {

            var deviceToken = string.Empty;
            if (Preferences.ContainsKey("DeviceToken"))
            {
                deviceToken = Preferences.Get("DeviceToken", "");
            }

            await FirebaseSendHelper.SendSimpleNotification("Firebase", "Ici l'assitant FireBase", deviceToken);

        }

        #endregion
    }
}

