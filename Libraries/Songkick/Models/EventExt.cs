using Helpers.Extensions;
using Songkick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songkick.Models
{
    public class EventExt : Event
    {
        public string FullDisplayName
        {
            get
            {
                if (this.Type.Equals("Festival"))
                {
                    return this.DisplayName;
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    int maxArtists = this.Performances.Count;

                    if (maxArtists == 1)
                    {
                        return this.Performances.First().Artist.DisplayName;
                    }

                    foreach (var item in this.Performances)
                    {
                        maxArtists--;

                        switch (maxArtists)
                        {
                            case 0:
                                sb.AppendFormat("et {0}", item.Artist.DisplayName);
                                break;
                            case 1:
                                sb.AppendFormat("{0} ", item.Artist.DisplayName);
                                break;
                            default:
                                sb.AppendFormat("{0}, ", item.Artist.DisplayName);
                                break;
                        }
                    }

                    return sb.ToString();
                }
            }
        }

        public string FullDisplayVenue
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (base.Start != null)
                {
                    sb.AppendFormat("{0}, ", base.Start.Date.ConvertDate().ToString("m"));
                }

                if (!base.Venue.DisplayName.Equals("Unknown venue"))
                {
                    sb.AppendFormat("{0}, ", base.Venue.DisplayName);
                }

                sb.Append(base.Location.City.Split(',').First());

                return sb.ToString();
            }
        }

        public string FullDisplayDate
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (base.Start != null)
                {
                    sb.Append(base.Start.Date);
                }

                if (base.End != null)
                {
                    sb.AppendFormat(",{0}", base.End.Date);
                }

                return sb.ToString();
            }
        }

        public string Title
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (!this.Venue.DisplayName.Equals("Unknown venue"))
                {
                    sb.AppendFormat("{0} - ", this.Venue.DisplayName);
                }

                sb.AppendFormat("{0}", this.Start.Date.ConvertDate().ToString("D"));

                if (this.Start.DateTime.HasValue)
                {
                    sb.AppendFormat(" - {0}h{1:00}", this.Start.DateTime.Value.Hour, this.Start.DateTime.Value.Minute);
                }

                return sb.ToString();
            }
        }

        public string SubTitle
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (!this.Venue.DisplayName.Equals("Unknown venue"))
                {
                    if (!string.IsNullOrEmpty(this.Venue.Street)) sb.AppendFormat("{0}", this.Venue.Street.ToTitleCase());
                    if (!string.IsNullOrEmpty(this.Venue.Zip)) sb.AppendFormat(" {0} ", this.Venue.Zip);
                    if (this.Venue.City != null)
                    {
                        sb.AppendFormat("{0} ", this.Venue.City.DisplayName);
                        sb.AppendFormat("{0}", this.Venue.City.Country.DisplayName);
                    }
                }

                return sb.ToString();
            }
        }
    }
}
