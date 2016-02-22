using Newtonsoft.Json;
using System.ComponentModel;

namespace Songkick.Models
{
    public abstract class Content : INotifyPropertyChanged
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
