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
    public class RefundBankAccountResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private string id;
        private string status;
        private List<Models.EventPaymentOrRefund> events;
        private Models.AmountPaymentOrRefundResponse amount;
        private string type;
        private Models.RefundingInstrumentBankAccountResponse refundingInstrument;
        private string createdAt;
        private Models.Links links;

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

        [JsonProperty("events")]
        public List<Models.EventPaymentOrRefund> Events
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

        [JsonProperty("amount")]
        public Models.AmountPaymentOrRefundResponse Amount
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

        [JsonProperty("refundingInstrument")]
        public Models.RefundingInstrumentBankAccountResponse RefundingInstrument
        {
            get
            {
                return this.refundingInstrument;
            }
            set
            {
                this.refundingInstrument = value;
                onPropertyChanged("RefundingInstrument");
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

        [JsonProperty("_links")]
        public Models.Links Links
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
