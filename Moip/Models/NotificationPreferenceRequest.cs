using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Moip;
using Moip.Utilities;

namespace Moip.Models
{
    public class NotificationPreferenceRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private List<string> events;
        private string target;
        private string media;

        [JsonProperty("events")]
        public List<string> Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
                onPropertyChanged("Events");
            }
        }

        [JsonProperty("target")]
        public string Target
        {
            get
            {
                return this.target;
            }
            set
            {
                this.target = value;
                onPropertyChanged("Target");
            }
        }

        [JsonProperty("media")]
        public string Media
        {
            get
            {
                return this.media;
            }
            set
            {
                this.media = value;
                onPropertyChanged("Media");
            }
        }
    }
}
