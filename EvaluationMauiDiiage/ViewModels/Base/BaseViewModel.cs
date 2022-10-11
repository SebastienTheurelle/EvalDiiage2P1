using System;
using System.ComponentModel;
using ReactiveUI;
using Sharpnado.Tasks;

namespace EvaluationMauiDiiage.ViewModels.Base
{
    public abstract class BaseViewModel : BindableBase, INavigationAware, IPageLifecycleAware, INotifyPropertyChanged
    {
        #region Attributes Privates and Protected
        protected INavigationService NavigationService;
        private bool _isLoading;
        private string _loadingMessage;
        private string _title;
        #endregion


        #region Properties 
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public string LoadingMessage
        {
            get => _loadingMessage;
            set => SetProperty(ref _loadingMessage, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        #endregion

        #region CTOR
        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Title = "My Maui App";
        }
        #endregion
       
        #region INavigatedAware Implementation

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            TaskMonitor.Create(OnNavigatedFromAsync(parameters),
                          whenFaulted: t => {
                              t.Exception.Handle(ex => {
                                  Console.WriteLine($"Error in OnNavigatedFromAsync : {ex.Message}");
                                  return true;
                              });
                          });
        }

        public virtual Task OnNavigatedFromAsync(INavigationParameters parameters)
        {
            return Task.FromResult(0);
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            TaskMonitor.Create(OnNavigatedToAsync(parameters),
                          whenFaulted: t => {
                              t.Exception.Handle(ex => {
                                  Console.WriteLine($"Error in OnNavigatedTo : {ex.Message}");
                                  return true;
                              });
                          });
        }

        public virtual Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            return Task.FromResult(0);
        }

        #endregion

        #region IInitializeAsync Implementation

        public Task InitializeAsync(INavigationParameters parameters)
        {
            return Task.FromResult(0);
        }

        #endregion

        #region IPageLifecycleAware Implementation

        public virtual void OnAppearing()
        {
            TaskMonitor.Create(OnAppearingAsync(),
                          whenFaulted: t => {
                              t.Exception.Handle(ex => {
                                  Console.WriteLine($"Error in OnAppearingAsync : {ex.Message}");
                                  return true;
                              });
                          });
        }

        public virtual Task OnAppearingAsync()
        {
            return Task.FromResult(0);
        }

        public virtual void OnDisappearing()
        {
            TaskMonitor.Create(OnDisappearingAsync(),
                          whenFaulted: t => {
                              t.Exception.Handle(ex => {
                                  Console.WriteLine($"Error in OnDisappearingAsync : {ex.Message}");
                                  return true;
                              });
                          });
        }

        public virtual Task OnDisappearingAsync()
        {
            return Task.FromResult(0);
        }


        #endregion
    }
}

