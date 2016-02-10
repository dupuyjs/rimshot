using Songkick;
using Songkick.Models;
using System.Threading.Tasks;

namespace Rimshot.Models
{
    class DataService : IDataService
    {
        private ISongkickClient _songkickClient = null;

        public DataService()
        {
            this._songkickClient = SongkickClientFactory.CreateSongkickClient("OK5IjbPZxS0bfZOF");
        }

        public async Task<ContentResponse> GetEvents()
        {
            ContentResponse response = await _songkickClient.UpcomingEventSearch(null, LocationType.GeoLocation(49.7592f, 2.3025f), null, null, 1, 50);
            return response;
        }
    }
}
