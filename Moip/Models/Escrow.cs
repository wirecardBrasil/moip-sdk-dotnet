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
    public class Escrow : BaseModel
    {
        // These fields hold the values for the public properties.
        private string description;

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
