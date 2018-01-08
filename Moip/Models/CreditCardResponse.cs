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
    public class CreditCardResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private string id;
        private string brand;
        private string first6;
        private string last4;
        private bool store;
        private Models.HolderRequest holder;

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

        [JsonProperty("brand")]
        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                this.brand = value;
                onPropertyChanged("Brand");
            }
        }

        [JsonProperty("first6")]
        public string First6
        {
            get
            {
                return this.first6;
            }
            set
            {
                this.first6 = value;
                onPropertyChanged("First6");
            }
        }

        [JsonProperty("last4")]
        public string Last4
        {
            get
            {
                return this.last4;
            }
            set
            {
                this.last4 = value;
                onPropertyChanged("Last4");
            }
        }

        [JsonProperty("store")]
        public bool Store
        {
            get
            {
                return this.store;
            }
            set
            {
                this.store = value;
                onPropertyChanged("Store");
            }
        }

        [JsonProperty("holder")]
        public Models.HolderRequest Holder
        {
            get
            {
                return this.holder;
            }
            set
            {
                this.holder = value;
                onPropertyChanged("Holder");
            }
        }

    }
}

