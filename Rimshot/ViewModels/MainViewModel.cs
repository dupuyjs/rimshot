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
using System.Diagnostics;
using Echonest.Models;
using Windows.Devices.Geolocation;
using Windows.ApplicationModel.Resources;
using Helpers.Extensions;
using Microsoft.Xbox.Music.Platform.Client;
using Microsoft.Xbox.Music.Platform.Contract.DataModel;

namespace Rimshot.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

        //private Geolocator _geoLocator;

        #region Properties

        private List<EventExt> _concerts;
        public List<EventExt> Concerts
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

        private List<ArtistExt> _artists;
        public List<ArtistExt> Artists
        {
            get
            {
                return _artists;
            }
            set
            {
                _artists = value;

                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    RaisePropertyChanged(() => Artists);
                });
            }
        }

        private List<VenueExt> _venues;
        public List<VenueExt> Venues
        {
            get
            {
                return _venues;
            }
            set
            {
                _venues = value;

                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    RaisePropertyChanged(() => Venues);
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

        public MainViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;

            Task.Run(() => Initialize());
        }

        #region Initialization

        public async Task Search(string query)
        {
            Songkick.Models.ContentResponse response = null;

            response = await _dataService.GetEvents(query);
            this.Concerts = response.ResultsPage.Results.Events;

            response = await _dataService.GetArtists(query);
            this.Artists = response.ResultsPage.Results.Artists;

            response = await _dataService.GetVenues(query);
            this.Venues = response.ResultsPage.Results.Venues;

            Task.Run(() => LoadArtistImages());
        }

        private async Task Initialize()
        {
            try
            {
                Songkick.Models.ContentResponse response = null;

                response = await _dataService.GetArtists("muse");
                this.Artists = response.ResultsPage.Results.Artists;

                response = await _dataService.GetEvents(null);
                this.Concerts = response.ResultsPage.Results.Events;

                //this.Artist = concerts.First().Performances.First().Artist;

                Task.Run(() => LoadArtistImages());
            }
            catch (Exception)
            {
                var loader = new ResourceLoader("Errors");
                DialogService.DisplayError(loader.GetString("Network/Caption"), loader.GetString("Network/Message"), "");
            }


            //DispatcherHelper.CheckBeginInvokeOnUI(async() =>
            //{
            //    try
            //    {
            //        //    var accessStatus = await Geolocator.RequestAccessAsync();

            //        //switch (accessStatus)
            //        //{
            //        //    case GeolocationAccessStatus.Allowed:

            //        //        DialogService.DisplayStatus("Waiting for update...", "Location", "");

            //        //        // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
            //        //        _geoLocator = new Geolocator();

            //        //        Geoposition pos = await _geoLocator.GetGeopositionAsync();

            //        //        var position = pos.Coordinate.Point.Position;
            //        //        var responseLocations = await _dataService.GetLocations((float)position.Latitude, (float)position.Longitude);

            //        //        var location = responseLocations.ResultsPage.Results.Locations.First();

            //        //        var responseEvents = await _dataService.GetUpcomingEvents(location.MetroArea.Id.Value);

            //        //        var concerts = responseEvents.ResultsPage.Results.Events;

            //        //        this.Concerts = concerts;

            //        //        DialogService.DisplayStatus("Location updated.", "Location", "");
            //        //        break;

            //        //    case GeolocationAccessStatus.Denied:

            //        //        DialogService.DisplayError("Access to location is denied.", "Location", "");
            //        //        break;

            //        //    case GeolocationAccessStatus.Unspecified:
            //        //        DialogService.DisplayError("Unspecified error.", "Location", "");
            //        //        break;
            //        //}

            //        var responseEvents = await _dataService.GetEvents();
            //        var concerts = responseEvents.ResultsPage.Results.Events;

            //        this.Concerts = concerts;

            //        //Task.Run(() => LoadArtistImages());

            //    }
            //    catch (Exception)
            //    {
            //        DialogService.DisplayError("Network Issue", "Network Issue", "");
            //    }
            //});
        }

        #endregion

        #region Load Images

        private async Task GetMappingAndImage(ArtistExt artist)
        {
            if (artist.IsDefaultImage)
            {
                try
                {
                    var artistId = artist.Id.Value;
                    var mapping = await _dataService.GetMapping(artistId.ToString());

                    if (mapping != null)
                    {
                        var groove = mapping.Groove;

                        DispatcherHelper.CheckBeginInvokeOnUI(() =>
                        {
                            artist.SetImageUrl($"http://musicimage.xboxlive.com/content/music.{groove}/image?locale=en-US");
                        });

                        Debug.WriteLine(string.Format("{0},{1}", artist.DisplayName, mapping.Groove));
                    }
                    else
                    {
                        Debug.WriteLine(string.Format("{0},{1}", artist.DisplayName, "NOT FOUND"));
                    }

                }
                catch (Exception)
                {
                    var loader = new ResourceLoader("Errors");
                    DialogService.DisplayError(loader.GetString("Network/Caption"), loader.GetString("Network/Message"), "");
                }
            }
        }

        private async Task LoadArtistImages()
        {
            if (this.Concerts.Count != 0)
            {
                foreach (var concert in this.Concerts)
                {
                    foreach (var performance in concert.Performances)
                    {
                        await GetMappingAndImage(performance.Artist);
                    }
                }
            }

            if (this.Artists.Count != 0)
            {
                foreach (var artist in this.Artists)
                {
                    await GetMappingAndImage(artist);
                }
            }
        }

        #endregion

        #region Load Details

        public async Task LoadConcertDetails(EventExt concert)
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

                    if (artist.PastEvents == null)
                    {
                        var past = await _dataService.GetArtistPastEvents(performance.Artist);
                        artist.PastEvents = past;

                        GetArtistHistory(past);
                    }
                }
            }
            catch (Exception ex)
            {
                var loader = new ResourceLoader("Errors");
                DialogService.DisplayError(loader.GetString("Network/Caption"), loader.GetString("Network/Message"), "");
            }
        }

        internal class ArtistHistory
        {
            public Dictionary<int, int> Touring { get; set; }
            public Dictionary<string, int> MostPlayed { get; set; }
            public Dictionary<string, int> AppearsWith { get; set; }

            public ArtistHistory()
            {
                this.Touring = new Dictionary<int, int>();
                this.MostPlayed = new Dictionary<string, int>();
                this.AppearsWith = new Dictionary<string, int>();
            }
        }

        private ArtistHistory GetArtistHistory(List<EventExt> past)
        {
            ArtistHistory history = new ArtistHistory();

            foreach (var concert in past)
            {
                var year = concert.Start.Date.ConvertDate().Year;

                if (history.Touring.ContainsKey(year)) 
                {
                    history.Touring[year]++;
                }
                else
                {
                    history.Touring.Add(year, 1);
                }

                var city = concert.Location.City;

                if (history.MostPlayed.ContainsKey(city))
                {
                    history.MostPlayed[city]++;
                }
                else
                {
                    history.MostPlayed.Add(city, 1);
                }

                foreach (var performance in concert.Performances)
                {
                    var artist = performance.Artist.DisplayName;
                    if (history.AppearsWith.ContainsKey(artist))
                    {
                        history.AppearsWith[artist]++;
                    }
                    else
                    {
                        history.AppearsWith.Add(artist, 1);
                    }
                }
            }

            return history;
        }

        //public async Task LoadArtistDetails(EventExt concert)
        //{

        //}
        #endregion
    }
}
