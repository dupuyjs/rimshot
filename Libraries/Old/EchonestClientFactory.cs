using System;

namespace Echonest
{
    public static class EchonestClientFactory
    {
        /// <summary>
        /// Create The Echonest Platform client
        /// </summary>
        /// <param name="apiKey">Echnoest API Key</param>
        /// <returns></returns>
        public static IEchonestClient CreateEchonestClient(string apiKey)
        {
            return new EchonestClient(apiKey);
        }
    }
}
