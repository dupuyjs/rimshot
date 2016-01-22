namespace Songkick.Model
{
    public class ArtistType
    {
        public ArtistTypeEnum Type { get; set; }
        public int ArtistId { get; set; }

        public static ArtistType SongkickArtist(int artistId)
        {
            return new ArtistType()
            {
                Type = ArtistTypeEnum.Songkick,
                ArtistId = artistId
            };
        }

        public static ArtistType MusicBrainzArtist(int artistId)
        {
            return new ArtistType()
            {
                Type = ArtistTypeEnum.MusicBrainz,
                ArtistId = artistId
            };
        }

        public override string ToString()
        {
            switch (this.Type)
            {
                case ArtistTypeEnum.Songkick:
                    return ArtistId.ToString();
                case ArtistTypeEnum.MusicBrainz:
                    return string.Format("mbid:{0}", ArtistId.ToString());
            }

            return null;
        }
    }

    public enum ArtistTypeEnum
    {
        Songkick,
        MusicBrainz
    }
}
