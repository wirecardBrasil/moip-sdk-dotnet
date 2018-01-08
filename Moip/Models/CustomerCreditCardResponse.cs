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
    public class CustomerCreditCardResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private Models.CreditCardResponse creditCard;
        private Card card;
        private string method;

        [JsonProperty("creditCard")]
        public Models.CreditCardResponse CreditCard
        {
            get
            {
                return this.creditCard;
            }
            set
            {
                this.creditCard = value;
                onPropertyChanged("CreditCard");
            }
        }

        [JsonProperty("card")]
        public Card Card
        {
            get
            {
                return this.card;
            }
            set
            {
                this.card = value;
                onPropertyChanged("Card");
            }
        }

        [JsonProperty("method")]
        public string Method
        {
            get
            {
                return this.method;
            }
            set
            {
                this.method = value;
                onPropertyChanged("Method");
            }
        }
    }

    public class Card : BaseModel
    {
        // These fields hold the values for the public properties.
        private string brand;
        private bool store;

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
    }
}
