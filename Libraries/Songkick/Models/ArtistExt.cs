using Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songkick.Models
{
    public class ArtistExt : Artist
    {
        List<EventExt> upcoming = default(List<EventExt>);
        public List<EventExt> UpcomingEvents
        {
            get
            {
                return upcoming;
            }
            set
            {
                this.upcoming = value;
                OnPropertyChanged("UpcomingEvents");
            }
        }

        List<EventExt> past = default(List<EventExt>);
        public List<EventExt> PastEvents
        {
            get
            {
                return past;
            }
            set
            {
                this.past = value;
                OnPropertyChanged("PastEvents");
            }
        }

        bool isDefaultImage = true;
        public bool IsDefaultImage
        {
            get
            {
                return isDefaultImage;
            }
        }

        const string defaultArtistImageUrl = ""; //"ms-appx:///Songkick/Assets/artist.jpg";
        const string defaultEventImageUrl = "ms-appx:///Songkick/Assets/event.jpg";
        private string imageUrl = default(string);

        public string ArtistImageUrl
        {
            get
            {
                return IsDefaultImage ? defaultArtistImageUrl : imageUrl.WithSize(200,200);
            }
        }

        public string HeaderImageUrl
        {
            get
            {
                return IsDefaultImage ? defaultArtistImageUrl : imageUrl.WithSize(1800, 200);
            }
        }

        public string EventImageUrl
        {
            get
            {
                return IsDefaultImage ? defaultEventImageUrl : imageUrl.WithSize(200, 200);
            }
        }

        public void SetImageUrl(string url)
        {
            this.imageUrl = url;
            this.isDefaultImage = false;

            OnPropertyChanged("ArtistImageUrl");
            OnPropertyChanged("EventImageUrl");
        }
    }
}
