using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Rimshot.Models;
using Rimshot.Services;
using Songkick.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls;

namespace Rimshot.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

        private IOrderedEnumerable<IGrouping<string, EventExt>> _concerts;
        public IOrderedEnumerable<IGrouping<string, EventExt>> Concerts
        {
            get
            {
                return _concerts;
            }
            set
            {
                _concerts = value;

                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    RaisePropertyChanged(() => Concerts);
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

        //public string MapServiceToken
        //{
        //    get
        //    {
        //        return Keys.Bingmaps;
        //    }
        //}

        public MainViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;

            Task.Run(() => Initialize());
        }

        public async Task LoadDetails(EventExt concert)
        {
            try
            {
                if (!concert.Venue.IsVenueDetailsLoaded && concert.Venue.Id.HasValue)
                {
                    var venue = await _dataService.GetVenueDetails(concert);
                    concert.Venue.IsVenueDetailsLoaded = true;
                    concert.Venue = venue;
                }

                foreach (var performance in concert.Performances)
                {
                    var artist = performance.Artist;
                    if (artist.UpcomingEvents == null)
                    {
                        var upcoming = await _dataService.GetArtistUpcomingEvents(performance.Artist);
                        artist.UpcomingEvents = upcoming;
                    }
                }
            }
            catch (Exception)
            {
                DialogService.ShowError("Network Issue", "Network Issue", "");
            }
        }

        private async Task Initialize()
        {
            try
            {
                var response = await _dataService.GetEvents();
                var concerts = response.ResultsPage.Results.Events;

                var query = from concert in concerts
                            group concert by concert.FullDisplayDate
                            into grp orderby grp.Key select grp;

                this.Concerts = query;
            }
            catch (Exception)
            {
                DialogService.ShowError("Network Issue", "Network Issue", "");
            }
        }
    }
}
