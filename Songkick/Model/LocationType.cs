using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songkick.Model
{
    public class LocationType
    {
        public LocationTypeEnum Type { get; set; }
        public int? MetroAreaId { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string Ip { get; set; }

        public static LocationType GeoLocation(float latitude, float longitude)
        {
            return new LocationType()
            {
                Type = LocationTypeEnum.Geo,
                Latitude = latitude,
                Longitude = longitude
            };
        }

        public static LocationType SongkickLocation(int metroAreaId)
        {
            return new LocationType()
            {
                Type = LocationTypeEnum.Songkick,
                MetroAreaId = metroAreaId
            };
        }

        public static LocationType IpLocation(string ip)
        {
            return new LocationType()
            {
                Type = LocationTypeEnum.Ip,
                Ip = ip
            };
        }

        public static LocationType ClientIpLocation(string clientIp)
        {
            return new LocationType()
            {
                Type = LocationTypeEnum.ClientIp
            };
        }

        public override string ToString()
        {
            switch (this.Type)
            {
                case LocationTypeEnum.Songkick:
                    return string.Format("sk:{0}", this.MetroAreaId);
                case LocationTypeEnum.Geo:
                    return string.Format(CultureInfo.InvariantCulture, "geo:{0},{1}", this.Latitude, this.Longitude);
                case LocationTypeEnum.Ip:
                    return string.Format("ip:{0}", this.Ip);
                case LocationTypeEnum.ClientIp:
                    return string.Format("clientip");
            }

            return null;
        }
    }

    public enum LocationTypeEnum
    {
        Songkick,
        Geo,
        Ip,
        ClientIp
    }
}
