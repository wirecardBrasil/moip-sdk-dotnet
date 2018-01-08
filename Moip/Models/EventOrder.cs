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
    public class EventOrder : BaseModel
    {
        // These fields hold the values for the public properties.
        private string type;
        private string createdAt;
        private string description;

        [JsonProperty("type")]
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
                onPropertyChanged("Type");
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
    }
}
