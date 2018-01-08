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
    public class BoletoInstructionLines : BaseModel
    {
        // These fields hold the values for the public properties.
        private string first;
        private string second;
        private string third;

        [JsonProperty("first")]
        public string First
        {
            get
            {
                return this.first;
            }
            set
            {
                this.first = value;
                onPropertyChanged("First");
            }
        }

        [JsonProperty("second")]
        public string Second
        {
            get
            {
                return this.second;
            }
            set
            {
                this.second = value;
                onPropertyChanged("Second");
            }
        }

        [JsonProperty("third")]
        public string Third
        {
            get
            {
                return this.third;
            }
            set
            {
                this.third = value;
                onPropertyChanged("Third");
            }
        }
    }
}
