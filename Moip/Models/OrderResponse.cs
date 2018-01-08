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
    public class OrderResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private string id;
        private string ownId;
        private string status;
        private string platform;
        private string createdAt;
        private string updatedAt;
        private Models.AmountOrderResponse amount;
        private List<Models.Item> items;
        private Models.CustomerResponse customer;
        private List<Models.OrderPaymentResponse> payments;
        private List<string> escrows;
        private List<string> refunds;
        private List<string> entries;
        private List<Models.EventOrder> events;
        private List<Models.ReceiverResponse> receivers;
        private Models.ShippingAddress shippingAddress;
        private object links;

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

        [JsonProperty("status")]
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
                onPropertyChanged("Status");
            }
        }

        [JsonProperty("platform")]
        public string Platform
        {
            get
            {
                return this.platform;
            }
            set
            {
                this.platform = value;
                onPropertyChanged("Platform");
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

        [JsonProperty("updatedAt")]
        public string UpdatedAt
        {
            get
            {
                return this.updatedAt;
            }
            set
            {
                this.updatedAt = value;
                onPropertyChanged("UpdatedAt");
            }
        }

        [JsonProperty("amount")]
        public Models.AmountOrderResponse Amount
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
        public Models.CustomerResponse Customer
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

        [JsonProperty("payments")]
        public List<Models.OrderPaymentResponse> Payments
        {
            get
            {
                return this.payments;
            }
            set
            {
                this.payments = value;
                onPropertyChanged("Payments");
            }
        }

        [JsonProperty("escrows")]
        public List<string> Escrows
        {
            get
            {
                return this.escrows;
            }
            set
            {
                this.escrows = value;
                onPropertyChanged("Escrows");
            }
        }

        [JsonProperty("refunds")]
        public List<string> Refunds
        {
            get
            {
                return this.refunds;
            }
            set
            {
                this.refunds = value;
                onPropertyChanged("Refunds");
            }
        }

        [JsonProperty("entries")]
        public List<string> Entries
        {
            get
            {
                return this.entries;
            }
            set
            {
                this.entries = value;
                onPropertyChanged("Entries");
            }
        }

        [JsonProperty("events")]
        public List<Models.EventOrder> Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
                onPropertyChanged("Events");
            }
        }

        [JsonProperty("receivers")]
        public List<Models.ReceiverResponse> Receivers
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

        [JsonProperty("shippingAddress")]
        public Models.ShippingAddress ShippingAddress
        {
            get
            {
                return this.shippingAddress;
            }
            set
            {
                this.shippingAddress = value;
                onPropertyChanged("ShippingAddress");
            }
        }

        [JsonProperty("_links")]
        public object Links
        {
            get
            {
                return this.links;
            }
            set
            {
                this.links = value;
                onPropertyChanged("Links");
            }
        }
    }
}
