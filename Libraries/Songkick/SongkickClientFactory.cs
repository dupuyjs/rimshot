namespace Songkick
{
    public static class SongkickClientFactory
    {
        /// <summary>
        /// Create a Songkick Platform client
        /// </summary>
        /// <param name="apiKey">Songkick API Key</param>
        /// <returns></returns>
        public static ISongkickClient CreateSongkickClient(string apiKey)
        {
            return new SongkickClient(apiKey);
        }
    }
}
