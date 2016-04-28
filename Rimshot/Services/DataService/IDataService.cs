using Echonest.Models;
using Songkick.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rimshot.Services
{
    public interface IDataService
    {
        //Task<ContentResponse> GetArtist(string query);
        //Task<ContentResponse> GetLocations(float latitude, float longitude);
        //Task<ContentResponse> GetUpcomingEvents(int metroAreaId);
        Task<ContentResponse> GetEvents(string query);
        Task<ContentResponse> GetArtists(string query);
        Task<ContentResponse> GetVenues(string query);
        Task<VenueExt> GetVenueDetails(EventExt concert);
        Task<List<EventExt>> GetArtistUpcomingEvents(ArtistExt artist);
        Task<List<EventExt>> GetArtistPastEvents(ArtistExt artist);
        Task<ArtistItem> GetMapping(string id);
    }
}
