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
    public class CreditCardRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private string expirationMonth;
        private string expirationYear;
        private string number;
        private string cvc;
        private Models.HolderRequest holder;
        private string hash;
        private bool? store;

        [JsonProperty("expirationMonth")]
        public string ExpirationMonth
        {
            get
            {
                return this.expirationMonth;
            }
            set
            {
                this.expirationMonth = value;
                onPropertyChanged("ExpirationMonth");
            }
        }

        [JsonProperty("expirationYear")]
        public string ExpirationYear
        {
            get
            {
                return this.expirationYear;
            }
            set
            {
                this.expirationYear = value;
                onPropertyChanged("ExpirationYear");
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

        [JsonProperty("cvc")]
        public string Cvc
        {
            get
            {
                return this.cvc;
            }
            set
            {
                this.cvc = value;
                onPropertyChanged("Cvc");
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

        [JsonProperty("hash")]
        public string Hash
        {
            get
            {
                return this.hash;
            }
            set
            {
                this.hash = value;
                onPropertyChanged("Hash");
            }
        }

        [JsonProperty("store")]
        public bool? Store
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
    }
}
