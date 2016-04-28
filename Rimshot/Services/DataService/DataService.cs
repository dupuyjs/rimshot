using Rimshot.Commons;
using Songkick;
using Songkick.Models;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using Echonest;
using Echonest.Models;

namespace Rimshot.Services
{
    class DataService : IDataService
    {
        private ISongkickClient _songkickClient = null;
        private MappingClient _mappingClient = null;

        public DataService()
        {
            this._songkickClient = SongkickClientFactory.CreateSongkickClient(Keys.Songkick);
            this._mappingClient = new MappingClient();
        }

        public async Task<ContentResponse> GetEvents(string query = null)
        {
            ContentResponse response = await _songkickClient.UpcomingEventSearch(query, LocationType.GeoLocation(49.7592f, 2.3025f), null, null, 1, 50);
            return response;
        }

        public async Task<ContentResponse> GetArtists(string query)
        {
            ContentResponse response = await _songkickClient.ArtistSearch(query);
            return response;
        }

        public async Task<ContentResponse> GetVenues(string query)
        {
            ContentResponse response = await _songkickClient.VenueSearch(query);
            return response;
        }

        public async Task<ArtistItem> GetMapping(string id)
        {
            ArtistItem mapping = await _mappingClient.ArtistItems.GetArtistItemByIdAsync(id);
            return mapping;
        }

        public async Task<VenueExt> GetVenueDetails(EventExt concert)
        {
            ContentResponse response = await _songkickClient.VenueDetails(concert.Venue.Id.Value);
            return response.ResultsPage.Results.Venues.First();
        }

        public async Task<List<EventExt>> GetArtistUpcomingEvents(ArtistExt artist)
        {
            int perPage = 50;

            ArtistType artistType = new ArtistType();
            artistType.Type = ArtistTypeEnum.Songkick;
            artistType.ArtistId = artist.Id.Value;

            var upcomingEvents = new List<EventExt>();

            var response = await _songkickClient.ArtistUpcomingEvents(artistType, 1, perPage);
            upcomingEvents.AddRange(response.ResultsPage.Results.Events);

            var max = Math.Ceiling(double.Parse(response.ResultsPage.TotalEntries) / perPage);

            for (int page = 2; page <= max; page++)
            {
                response = await _songkickClient.ArtistUpcomingEvents(artistType, 1, perPage);
                upcomingEvents.AddRange(response.ResultsPage.Results.Events);
            }

            return upcomingEvents;
        }

        public async Task<List<EventExt>> GetArtistPastEvents(ArtistExt artist)
        {
            int perPage = 50;

            ArtistType artistType = new ArtistType();
            artistType.Type = ArtistTypeEnum.Songkick;
            artistType.ArtistId = artist.Id.Value;

            var pastEvents = new List<EventExt>();
            var response = await _songkickClient.ArtistPastEvents(artistType, 1, perPage);

            if (int.Parse(response.ResultsPage.TotalEntries) != 0)
            {
                pastEvents.AddRange(response.ResultsPage.Results.Events);

                var max = Math.Ceiling(double.Parse(response.ResultsPage.TotalEntries) / perPage);

                for (int page = 2; page <= max; page++)
                {
                    response = await _songkickClient.ArtistPastEvents(artistType, 1, perPage);
                    pastEvents.AddRange(response.ResultsPage.Results.Events);
                }
            }

            return pastEvents;
        }

        //public async Task<ContentResponse> GetLocations(float latitude, float longitude)
        //{
        //    ContentResponse response = await _songkickClient.LocationSearch(LocationType.GeoLocation(latitude, longitude));
        //    return response;
        //}

        //public async Task<ContentResponse> GetUpcomingEvents(int metroAreaId)
        //{
        //    ContentResponse response = await _songkickClient.UpcomingEventSearch(metroAreaId, 1, 50);
        //    return response;
        //}

 

        //public async Task<ContentResponse> GetEvents(float latitude, float longitude)
        //{
        //    ContentResponse response = await _songkickClient.LocationSearch(LocationType.GeoLocation(latitude, longitude));
        //    //response.ResultsPage.Results.    
        //        //UpcomingEventSearch(null, LocationType.GeoLocation(49.7592f, 2.3025f), null, null, 1, 50);
        //    return response;
        //}


    }
}
