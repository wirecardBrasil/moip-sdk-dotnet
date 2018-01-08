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
    public class Phone : BaseModel
    {
        // These fields hold the values for the public properties.
        private string countryCode;
        private string areaCode;
        private string number;

        [JsonProperty("countryCode")]
        public string CountryCode
        {
            get
            {
                return this.countryCode;
            }
            set
            {
                this.countryCode = value;
                onPropertyChanged("CountryCode");
            }
        }

        [JsonProperty("areaCode")]
        public string AreaCode
        {
            get
            {
                return this.areaCode;
            }
            set
            {
                this.areaCode = value;
                onPropertyChanged("AreaCode");
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
