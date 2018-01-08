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
    public class TaxDocument : BaseModel
    {
        // These fields hold the values for the public properties.
        private string type;
        private string number;

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

        [JsonProperty("number")]
        public string Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
                onPropertyChanged("Number");
            }
        }
    }
}
