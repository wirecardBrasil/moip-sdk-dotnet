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
    public class WebhooksResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private List<Webhooks> webhooks;

        [JsonProperty("webhooks")]
        public List<Webhooks> Webhooks
        {
            get
            {
                return this.webhooks;
            }
            set
            {
                this.webhooks = value;
                onPropertyChanged("Webhooks");
            }
        }
    }

    public class Webhooks : BaseModel
    {
        private string resourceId;
        private string _Event;
        private string url;
        private string status;
        private string id;
        private string sentAt;

        [JsonProperty("resourceId")]
        public string ResourceId
        {
            get
            {
                return this.resourceId;
            }
            set
            {
                this.resourceId = value;
                onPropertyChanged("ResourceId");
            }
        }

        [JsonProperty("event")]
        public string Event
        {
            get
            {
                return this._Event;
            }
            set
            {
                this._Event = value;
                onPropertyChanged("Event");
            }
        }

        [JsonProperty("url")]
        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                onPropertyChanged("Url");
            }
        }

        [JsonProperty("status")]
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
                onPropertyChanged("Status");
            }
        }

        [JsonProperty("id")]
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                onPropertyChanged("Id");
            }
        }

        [JsonProperty("sentAt")]
        public string SentAt
        {
            get
            {
                return this.sentAt;
            }
            set
            {
                this.sentAt = value;
                onPropertyChanged("SentAt");
            }
        }
    }
}
