using Helpers;
using Songkick.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Songkick
{
    public sealed class SongkickClient : SimpleServiceClient, ISongkickClient
    {
        private Uri baseUri = new Uri("http://api.songkick.com/api/3.0/");
        private string _apikey;

        internal SongkickClient(string apiKey)
        {
            this._apikey = apiKey;
        }

        public async Task<ContentResponse> LocationSearch(string query, int? page = 1, int? perPage = 20)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("apikey", _apikey);
            parameters.Add("query", Uri.EscapeDataString(query));

            if (page.HasValue)
            {
                parameters.Add("page", page.Value.ToString());
            }
            if (perPage.HasValue)
            {
                parameters.Add("perpage", perPage.Value.ToString());
            }

            var template = new UriTemplate("search/locations.json?apikey={apikey}&query={query}&page={page}&per_page={perpage}");

            return await GetWithRetryAsync(baseUri, template, parameters);
        }

        public async Task<ContentResponse> LocationSearch(LocationType location, int? page = 1, int? perPage = 20)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("apikey", _apikey);
            parameters.Add("location", location.ToString());

            if (page.HasValue)
            {
                parameters.Add("page", page.Value.ToString());
            }
            if (perPage.HasValue)
            {
                parameters.Add("perpage", perPage.Value.ToString());
            }

            var template = new UriTemplate("search/locations.json?apikey={apikey}&location={location}&page={page}&per_page={perpage}");

            return await GetWithRetryAsync(baseUri, template, parameters);
        }

        public async Task<ContentResponse> UpcomingEventSearch(string artistName, LocationType location = null, DateTime? minDate = null, DateTime? maxDate = null, int? page = 1, int? perPage = 20)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("apikey", _apikey);

            if (artistName != null)
            {
                parameters.Add("artistname", Uri.EscapeDataString(artistName));
            }
            if (location != null)
            {
                parameters.Add("location", location.ToString());
            }
            if (minDate.HasValue)
            {
                parameters.Add("mindate", minDate.Value.ToString("yyyy-MM-dd"));
            }
            if (maxDate.HasValue)
            {
                parameters.Add("maxdate", maxDate.Value.ToString("yyyy-MM-dd"));
            }
            if (page.HasValue)
            {
                parameters.Add("page", page.Value.ToString());
            }
            if (perPage.HasValue)
            {
                parameters.Add("perpage", perPage.Value.ToString());
            }

            var template = new UriTemplate("events.json?apikey={apikey}&artist_name={artistname}&location={location}&min_date={mindate}&max_date={maxdate}&page={page}&per_page={perpage}");

            return await GetWithRetryAsync(baseUri, template, parameters);
        }

        public async Task<ContentResponse> ArtistSearch(string query, int? page = 1, int? perPage = 20)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("apikey", _apikey);
            parameters.Add("query", Uri.EscapeDataString(query));

            if (page.HasValue)
            {
                parameters.Add("page", page.Value.ToString());
            }
            if (perPage.HasValue)
            {
                parameters.Add("perpage", perPage.Value.ToString());
            }

            var template = new UriTemplate("search/artists.json?apikey={apikey}&query={query}&page={page}&per_page={perpage}");

            return await GetWithRetryAsync(baseUri, template, parameters);
        }

        public async Task<ContentResponse> VenueSearch(string query, int? page = 1, int? perPage = 20)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("apikey", _apikey);
            parameters.Add("query", Uri.EscapeDataString(query));

            if (page.HasValue)
            {
                parameters.Add("page", page.Value.ToString());
            }
            if (perPage.HasValue)
            {
                parameters.Add("perpage", perPage.Value.ToString());
            }

            var template = new UriTemplate("search/venues.json?apikey={apikey}&query={query}&page={page}&per_page={perpage}");

            return await GetWithRetryAsync(baseUri, template, parameters);
        }

        public async Task<ContentResponse> ArtistUpcomingEvents(ArtistType artist, int? page = 1, int? perPage = 20, OrderTypeEnum order = OrderTypeEnum.Ascending)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("apikey", _apikey);
            parameters.Add("artistid", artist.ToString());

            if (page.HasValue)
            {
                parameters.Add("page", page.Value.ToString());
            }
            if (perPage.HasValue)
            {
                parameters.Add("perpage", perPage.Value.ToString());
            }

            switch (order)
            {
                case OrderTypeEnum.Ascending:
                    parameters.Add("order", "asc");
                    break;
                case OrderTypeEnum.Descending:
                    parameters.Add("order", "desc");
                    break;
            }

            var template = new UriTemplate("artists/{artistid}/calendar.json?apikey={apikey}&page={page}&per_page={perpage}&order={order}");

            return await GetWithRetryAsync(baseUri, template, parameters);
        }

        public async Task<ContentResponse> VenueUpcomingEvents(int venueId, int? page = 1, int? perPage = 20)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("apikey", _apikey);
            parameters.Add("venueid", venueId.ToString());

            if (page.HasValue)
            {
                parameters.Add("page", page.Value.ToString());
            }
            if (perPage.HasValue)
            {
                parameters.Add("perpage", perPage.Value.ToString());
            }

            var template = new UriTemplate("venues/{venueid}/calendar.json?apikey={apikey}&page={page}&per_page={perpage}");

            return await GetWithRetryAsync(baseUri, template, parameters);
        }

        public async Task<ContentResponse> VenueDetails(int venueId)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("apikey", _apikey);
            parameters.Add("venueid", venueId.ToString());

            var template = new UriTemplate("venues/{venueid}.json?apikey={apikey}");

            return await GetWithRetryAsync(baseUri, template, parameters);
        }
    }
}
