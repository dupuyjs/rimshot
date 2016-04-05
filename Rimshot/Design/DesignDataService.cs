using Rimshot.Services;
using Songkick;
using Songkick.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Rimshot.Models;
using Echonest.Models;
using Echonest;
using System;

namespace Rimshot.Design
{
    public class DesignDataService : IDataService
    {
        private ISongkickClient _songkickClient = null;
        private MappingClient _mappingClient = null;

        public DesignDataService()
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

        public async Task<VenueExt> GetVenueDetails(EventExt concert)
        {
            ContentResponse response = await _songkickClient.VenueDetails(concert.Venue.Id.Value);
            return response.ResultsPage.Results.Venues.First();
        }

        public Task<List<EventExt>> GetArtistUpcomingEvents(ArtistExt artist)
        {
            throw new NotImplementedException();
        }

        public Task<List<EventExt>> GetArtistPastEvents(ArtistExt artist)
        {
            throw new NotImplementedException();
        }

        public Task<ArtistItem> GetMapping(string id)
        {
            throw new NotImplementedException();
        }
    }
}
