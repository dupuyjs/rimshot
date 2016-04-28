﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Echonest.Models
{
    public partial class ArtistItem
    {
        private string _displayName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string DisplayName
        {
            get { return this._displayName; }
            set { this._displayName = value; }
        }
        
        private string _groove;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Groove
        {
            get { return this._groove; }
            set { this._groove = value; }
        }
        
        private int? _id;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private bool? _isDirty;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsDirty
        {
            get { return this._isDirty; }
            set { this._isDirty = value; }
        }
        
        private string _songkick;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Songkick
        {
            get { return this._songkick; }
            set { this._songkick = value; }
        }
        
        private string _spotify;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Spotify
        {
            get { return this._spotify; }
            set { this._spotify = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ArtistItem class.
        /// </summary>
        public ArtistItem()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken displayNameValue = inputObject["DisplayName"];
                if (displayNameValue != null && displayNameValue.Type != JTokenType.Null)
                {
                    this.DisplayName = ((string)displayNameValue);
                }
                JToken grooveValue = inputObject["Groove"];
                if (grooveValue != null && grooveValue.Type != JTokenType.Null)
                {
                    this.Groove = ((string)grooveValue);
                }
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((int)idValue);
                }
                JToken isDirtyValue = inputObject["IsDirty"];
                if (isDirtyValue != null && isDirtyValue.Type != JTokenType.Null)
                {
                    this.IsDirty = ((bool)isDirtyValue);
                }
                JToken songkickValue = inputObject["Songkick"];
                if (songkickValue != null && songkickValue.Type != JTokenType.Null)
                {
                    this.Songkick = ((string)songkickValue);
                }
                JToken spotifyValue = inputObject["Spotify"];
                if (spotifyValue != null && spotifyValue.Type != JTokenType.Null)
                {
                    this.Spotify = ((string)spotifyValue);
                }
            }
        }
    }
}