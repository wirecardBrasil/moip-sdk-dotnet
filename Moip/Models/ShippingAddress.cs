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
    public class ShippingAddress : BaseModel
    {
        // These fields hold the values for the public properties.
        private string street;
        private string streetNumber;
        private string complement;
        private string district;
        private string city;
        private string state;
        private string country;
        private string zipCode;

        [JsonProperty("street")]
        public string Street
        {
            get
            {
                return this.street;
            }
            set
            {
                this.street = value;
                onPropertyChanged("Street");
            }
        }

        [JsonProperty("streetNumber")]
        public string StreetNumber
        {
            get
            {
                return this.streetNumber;
            }
            set
            {
                this.streetNumber = value;
                onPropertyChanged("StreetNumber");
            }
        }

        [JsonProperty("complement")]
        public string Complement
        {
            get
            {
                return this.complement;
            }
            set
            {
                this.complement = value;
                onPropertyChanged("Complement");
            }
        }

        [JsonProperty("district")]
        public string District
        {
            get
            {
                return this.district;
            }
            set
            {
                this.district = value;
                onPropertyChanged("District");
            }
        }

        [JsonProperty("city")]
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
                onPropertyChanged("City");
            }
        }

        [JsonProperty("state")]
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
                onPropertyChanged("State");
            }
        }

        [JsonProperty("country")]
        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
                onPropertyChanged("Country");
            }
        }

        [JsonProperty("zipCode")]
        public string ZipCode
        {
            get
            {
                return this.zipCode;
            }
            set
            {
                this.zipCode = value;
                onPropertyChanged("ZipCode");
            }
        }
    }
}
