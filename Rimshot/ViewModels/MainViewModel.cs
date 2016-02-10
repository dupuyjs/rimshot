using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Rimshot.Models;
using Songkick.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rimshot.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

        private List<Event> _concerts;
        public List<Event> Concerts
        {
            get
            {
                return _concerts;
            }
            set
            {
                _concerts = value;

                DispatcherHelper.CheckBeginInvokeOnUI(() => {
                    RaisePropertyChanged(() => Concerts);
                });
            }
        }

        public MainViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;

            Task.Run(() => Initialize());
        }

        private async Task Initialize()
        {
            try
            {
                var response = await _dataService.GetEvents();
                this.Concerts = response.ResultsPage.Results.Events;
            }
            catch (Exception)
            {
                Messenger.Default.Send(new StatusMessage("Network Issue"));
            }
        }
    }
}
