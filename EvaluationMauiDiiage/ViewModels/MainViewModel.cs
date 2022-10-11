using EvaluationMauiDiiage.Models;
using EvaluationMauiDiiage.Services;
using Newtonsoft.Json;

namespace EvaluationMauiDiiage.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region CTOR
        public MainViewModel(INavigationService navigationService, ServiceSource serviceSource) : base(navigationService)
        {
            this.ServiceSource = serviceSource;
            GetMeetsCommand = new DelegateCommand(async () => await doGetMeetsCommand());
            GetMeetsCommand.Execute();
        }
        #endregion

        #region Lifecycle
        #endregion

        #region Properties
        public List<MeetEntity> Meets { get; } = new();
        ServiceSource ServiceSource { get; }
        #endregion

        #region Commands
        public DelegateCommand GetMeetsCommand { get; }
        public async Task doGetMeetsCommand()
        {
            try
            {
                var content = await ServiceSource.GetSourceFileContent();
                var meets = JsonConvert.DeserializeObject<List<MeetEntity>>(content);

                foreach (MeetEntity meet in meets.OrderBy(rdv => rdv.ScheduledDate.Date).ToList())
                    Meets.Add(meet);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }
        #endregion
    }
}

