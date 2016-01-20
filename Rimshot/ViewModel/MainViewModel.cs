using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Rimshot.Model;
using System;
using System.Threading.Tasks;

namespace Rimshot.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

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
                var item = await _dataService.GetData();
            }
            catch (Exception)
            {
                // Report error here
            }
        }
    }
}
