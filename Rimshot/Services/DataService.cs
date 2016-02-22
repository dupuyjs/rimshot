using Rimshot.Models;
using Songkick;
using Songkick.Models;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Rimshot.Services
{
    class DataService : IDataService
    {
        private ISongkickClient _songkickClient = null;

        public DataService()
        {
            this._songkickClient = SongkickClientFactory.CreateSongkickClient(Keys.Songkick);
        }

        public async Task<List<EventExt>> GetArtistUpcomingEvents(ArtistExt artist)
        {
            ArtistType artistType = new ArtistType();
            artistType.Type = ArtistTypeEnum.Songkick;
            artistType.ArtistId = artist.Id.Value;

            ContentResponse response = await _songkickClient.ArtistUpcomingEvents(artistType);
            return response.ResultsPage.Results.Events;
        }

        public async Task<ContentResponse> GetEvents()
        {
            ContentResponse response = await _songkickClient.UpcomingEventSearch(null, LocationType.GeoLocation(49.7592f, 2.3025f), null, null, 1, 50);
            return response;
        }

        public async Task<VenueExt> GetVenueDetails(EventExt concert)
        {
            ContentResponse response = await _songkickClient.VenueDetails(concert.Venue.Id.Value);
            return response.ResultsPage.Results.Venues.First();
        }
    }
}
