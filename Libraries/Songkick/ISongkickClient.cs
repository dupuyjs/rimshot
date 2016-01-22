using Songkick.Model;
using System;
using System.Threading.Tasks;

namespace Songkick
{
    public interface ISongkickClient
    {
        Task<ContentResponse> LocationSearch(string query, int? page = 1, int? perPage = 20);

        Task<ContentResponse> LocationSearch(LocationType location, int? page = 1, int? perPage = 20);

        Task<ContentResponse> UpcomingEventSearch(string artistName, LocationType location = null, DateTime? minDate = null, DateTime? maxDate = null, int? page = 1, int? perPage = 20);

        Task<ContentResponse> ArtistSearch(string query, int? page = 1, int? perPage = 20);

        Task<ContentResponse> VenueSearch(string query, int? page = 1, int? perPage = 20);

        Task<ContentResponse> ArtistUpcomingEvents(ArtistType artist, int? page = 1, int? perPage = 20, OrderTypeEnum order = OrderTypeEnum.Ascending);

        Task<ContentResponse> VenueUpcomingEvents(int venueId, int? page = 1, int? perPage = 20);

        Task<ContentResponse> VenueDetails(int venueId);
    }
}
