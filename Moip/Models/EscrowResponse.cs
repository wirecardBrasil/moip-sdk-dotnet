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
    public class EscrowResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private string id;
        private string status;
        private string description;
        private int amount;
        private string createdAt;
        private string updatedAt;
        private Models.Links links;

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

        [JsonProperty("description")]
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                onPropertyChanged("Description");
            }
        }

        [JsonProperty("amount")]
        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
                onPropertyChanged("Amount");
            }
        }

        [JsonProperty("createdAt")]
        public string CreatedAt
        {
            get
            {
                return this.createdAt;
            }
            set
            {
                this.createdAt = value;
                onPropertyChanged("CreatedAt");
            }
        }

        [JsonProperty("updatedAt")]
        public string UpdatedAt
        {
            get
            {
                return this.updatedAt;
            }
            set
            {
                this.updatedAt = value;
                onPropertyChanged("UpdatedAt");
            }
        }

        [JsonProperty("_links")]
        public Models.Links Links
        {
            get
            {
                return this.links;
            }
            set
            {
                this.links = value;
                onPropertyChanged("Links");
            }
        }
    }
}
