using EvaluationMauiDiiage.Models;
using EvaluationMauiDiiage.Services.Interface;
using System;



namespace EvaluationMauiDiiage.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region CTOR


        public MainViewModel(INavigationService navigationService, INotificationService notificationService, IServiceSource serviceSource) : base(navigationService)
        {
            _notificationService = notificationService;
            _serviceSource = serviceSource;
            _notificationService.Initialize();
            SourceCommand = new DelegateCommand(async () => await GetSource());
        }

        #endregion

        #region Lifecycle
        public virtual async void OnAppearing()
        {
            base.OnAppearing(); 
            _notificationService.SendNotification("Main Page", "Bienvenue sur la mainpage");
           
        }

        #endregion

        #region Properties
        private readonly INotificationService _notificationService;
        private readonly IServiceSource _serviceSource;
        public RdvEntity rdv;

        #endregion

        #region Publics
        //private int _id;
        //public int Id
        //{
        //    get { return _id; }
        //    set { SetProperty(ref _id, value); }
        //}

        //private string _name;
        //public string Name
        //{
        //    get { return _name; }
        //    set { SetProperty(ref _name, value); }
        //}

        //private DateTime _date;
        //public DateTime Date
        //{
        //    get { return _date; }
        //    set { SetProperty(ref _date, value); }
        //}



        #endregion

        #region Commands
        public DelegateCommand SourceCommand { get;}
        private async Task GetSource()
        {
            var sources = await _serviceSource.GetSourceFileContent();
            
        }
        #endregion
    }
}

