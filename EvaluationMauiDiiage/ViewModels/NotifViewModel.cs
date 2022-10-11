using System;
using System.Collections.ObjectModel;
using DynamicData;
using EvaluationMauiDiiage.Models;
using EvaluationMauiDiiage.Services;
using EvaluationMauiDiiage.Services.Interfaces;
using Newtonsoft.Json;
using ReactiveUI;

namespace EvaluationMauiDiiage.ViewModels
{
    public class NotifViewModel : BaseViewModel
    {
        #region CTOR

        public NotifViewModel(INavigationService navigationService, INotificationService notificationService) : base(navigationService)
        {
            _notificationService = notificationService;
            if (Preferences.ContainsKey("DeviceToken"))
            {
                DeviceToken = Preferences.Get("DeviceToken", "");
            }
        }

        #endregion

        #region Lifecycle

        public new void OnNavigatedTo(INavigationParameters parameters)
        {
            IdRDV = parameters.GetValue<int>("Id");
        }

        #endregion

        #region Properties
        private int _idRDV;

        public int IdRDV
        {
            get => _idRDV;
            set => this.RaiseAndSetIfChanged(ref _idRDV, value);
        }

        private readonly INotificationService _notificationService;

        private string DeviceToken { get; }


        #endregion

        #region Commands

        #endregion
    }
}

