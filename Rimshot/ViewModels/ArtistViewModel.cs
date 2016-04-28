using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Rimshot.Services;
using Songkick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rimshot.ViewModels
{
    public class ArtistViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

        #region Properties

        private ArtistExt _artist;
        public ArtistExt Artist
        {
            get
            {
                return _artist;
            }
            set
            {
                _artist = value;

                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    RaisePropertyChanged(() => Artist);
                });
            }
        }

        public Services.IDialogService DialogService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Services.IDialogService>();
            }
        }

        #endregion

        public ArtistViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;

            Task.Run(() => Initialize());
        }

        private async Task Initialize()
        {
            var responseEvents = await _dataService.GetEvents(null);
            var concerts = responseEvents.ResultsPage.Results.Events;

            this.Artist = concerts.First().Performances.First().Artist;
        }
    }
}
