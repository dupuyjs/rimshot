using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songkick.Models
{
    public class ArtistExt : Artist
    {
        List<EventExt> upcoming = null;
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
    }
}
