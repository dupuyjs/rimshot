using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Songkick.Models
{
    public class VenueExt : Venue
    {
        public bool IsVenueDetailsLoaded { get; set; }

        public bool IsMapVisible
        {
            get
            {
                if (base.Latitude.HasValue && base.Longitude.HasValue)
                {
                    return true;
                }

                return false;
            }
        }

        public Geopoint GeoLocation
        {
            get
            {
                if (base.Latitude.HasValue && base.Longitude.HasValue)
                {
                    return new Geopoint(new BasicGeoposition()
                    {
                        Latitude = base.Latitude.Value,
                        Longitude = base.Longitude.Value
                    });
                }

                return new Geopoint(new BasicGeoposition());
            }
        }

        public Geopoint GeoLocationCenter
        {
            get
            {
                if (base.Latitude.HasValue && base.Longitude.HasValue)
                {
                    return new Geopoint(new BasicGeoposition()
                    {
                        Latitude = base.Latitude.Value + 0.0055f,
                        Longitude = base.Longitude.Value - 0.03f
                    });
                }

                return new Geopoint(new BasicGeoposition());
            }
        }
    }
}
