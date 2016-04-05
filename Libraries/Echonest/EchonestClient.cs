using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echonest.Models;
using Helpers;

namespace Echonest
{
    public sealed class EchonestClient : SimpleServiceClient, IEchonestClient
    {
        private Uri baseUri = new Uri("http://developer.echonest.com/api/v4/");
        private string _apikey;

        internal EchonestClient(string apiKey)
        {
            this._apikey = apiKey;
        }

        public async Task<ContentResponse> GetBiographies(string artistId)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("apikey", _apikey);
            parameters.Add("artistid", artistId);

            var template = new UriTemplate("artist/biographies?api_key={apikey}&id=songkick:artist:{artistid}&format=json&results=20&start=0&license=cc-by-sa");

            return await GetWithRetryAsync(baseUri, template, parameters);
        }

        public async Task<ContentResponse> GetProfile(string artistId)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("apikey", _apikey);
            parameters.Add("artistid", artistId);

            var template = new UriTemplate("artist/profile?api_key={apikey}&id=songkick:artist:{artistid}&bucket=id:spotify&bucket=id:xboxmusic-ZZ&format=json");

            return await GetWithRetryAsync(baseUri, template, parameters);
        }
    }
}
