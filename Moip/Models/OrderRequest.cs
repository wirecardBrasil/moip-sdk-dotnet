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
    public class OrderRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private string ownId;
        private Models.AmountOrderRequest amount;
        private List<Models.Item> items;
        private Models.CustomerRequest customer;
        private List<Models.ReceiverRequest> receivers;
        private Models.CheckoutPreferences checkoutPreferences;

        [JsonProperty("ownId")]
        public string OwnId
        {
            get
            {
                return this.ownId;
            }
            set
            {
                this.ownId = value;
                onPropertyChanged("OwnId");
            }
        }

        [JsonProperty("amount")]
        public Models.AmountOrderRequest Amount
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

        [JsonProperty("items")]
        public List<Models.Item> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
                onPropertyChanged("Items");
            }
        }

        [JsonProperty("customer")]
        public Models.CustomerRequest Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
                onPropertyChanged("Customer");
            }
        }

        [JsonProperty("receivers")]
        public List<Models.ReceiverRequest> Receivers
        {
            get
            {
                return this.receivers;
            }
            set
            {
                this.receivers = value;
                onPropertyChanged("Receivers");
            }
        }

        [JsonProperty("checkoutPreferences")]
        public Models.CheckoutPreferences CheckoutPreferences
        {
            get
            {
                return this.checkoutPreferences;
            }
            set
            {
                this.checkoutPreferences = value;
                onPropertyChanged("CheckoutPreferences");
            }
        }
    }
}
