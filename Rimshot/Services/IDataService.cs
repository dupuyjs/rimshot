using Songkick.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rimshot.Services
{
    public interface IDataService
    {
        Task<ContentResponse> GetEvents();
        Task<VenueExt> GetVenueDetails(EventExt concert);
        Task<List<EventExt>> GetArtistUpcomingEvents(ArtistExt artist);
    }
}
