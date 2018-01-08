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
    public class PaymentResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private string id;
        private string status;
        private bool delayCapture;
        private Models.AmountPaymentOrRefundResponse amount;
        private int installmentCount;
        private string statementDescriptor;
        private Models.FundingInstrumentResponse fundingInstrument;
        private List<Models.Fee> fees;
        private List<Models.EscrowResponse> escrows;
        private List<Models.EventOrder> events;
        private List<Models.ReceiverResponse> receivers;
        private Models.Links links;
        private string createdAt;
        private string updatedAt;

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

        [JsonProperty("delayCapture")]
        public bool DelayCapture
        {
            get
            {
                return this.delayCapture;
            }
            set
            {
                this.delayCapture = value;
                onPropertyChanged("DelayCapture");
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

        [JsonProperty("installmentCount")]
        public int InstallmentCount
        {
            get
            {
                return this.installmentCount;
            }
            set
            {
                this.installmentCount = value;
                onPropertyChanged("InstallmentCount");
            }
        }

        [JsonProperty("statementDescriptor")]
        public string StatementDescriptor
        {
            get
            {
                return this.statementDescriptor;
            }
            set
            {
                this.statementDescriptor = value;
                onPropertyChanged("StatementDescriptor");
            }
        }

        [JsonProperty("fundingInstrument")]
        public Models.FundingInstrumentResponse FundingInstrument
        {
            get
            {
                return this.fundingInstrument;
            }
            set
            {
                this.fundingInstrument = value;
                onPropertyChanged("FundingInstrument");
            }
        }

        [JsonProperty("fees")]
        public List<Models.Fee> Fees
        {
            get
            {
                return this.fees;
            }
            set
            {
                this.fees = value;
                onPropertyChanged("Fees");
            }
        }

        [JsonProperty("escrows")]
        public List<Models.EscrowResponse> Escrows
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
    }
}
