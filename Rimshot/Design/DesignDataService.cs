using Rimshot.Models;
using Songkick;
using Songkick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rimshot.Design
{
    public class DesignDataService : IDataService
    {
        private ISongkickClient _songkickClient = null;

        public DesignDataService()
        {
            this._songkickClient = SongkickClientFactory.CreateSongkickClient("OK5IjbPZxS0bfZOF");
        }

        public async Task<ContentResponse> GetEvents()
        {
            ContentResponse response = await _songkickClient.UpcomingEventSearch(null, LocationType.GeoLocation(48.7592f, 2.3025f), null, null, 1, 50);
            return response;
        }
    }
}
