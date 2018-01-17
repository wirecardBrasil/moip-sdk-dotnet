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
    public class AmountOrderResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private int paid;
        private int total;
        private int fees;
        private int refunds;
        private int liquid;
        private int otherReceivers;
        private string currency;
        private Models.SubtotalsResponse subtotals;

        [JsonProperty("paid")]
        public int Paid
        {
            get
            {
                return this.paid;
            }
            set
            {
                this.paid = value;
                onPropertyChanged("Paid");
            }
        }

        [JsonProperty("total")]
        public int Total
        {
            get
            {
                return this.total;
            }
            set
            {
                this.total = value;
                onPropertyChanged("Total");
            }
        }

        [JsonProperty("fees")]
        public int Fees
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

        [JsonProperty("refunds")]
        public int Refunds
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

        [JsonProperty("liquid")]
        public int Liquid
        {
            get
            {
                return this.liquid;
            }
            set
            {
                this.liquid = value;
                onPropertyChanged("Liquid");
            }
        }

        [JsonProperty("otherReceivers")]
        public int OtherReceivers
        {
            get
            {
                return this.otherReceivers;
            }
            set
            {
                this.otherReceivers = value;
                onPropertyChanged("OtherReceivers");
            }
        }

        [JsonProperty("currency")]
        public string Currency
        {
            get
            {
                return this.currency;
            }
            set
            {
                this.currency = value;
                onPropertyChanged("Currency");
            }
        }

        [JsonProperty("subtotals")]
        public Models.SubtotalsResponse Subtotals
        {
            get
            {
                return this.subtotals;
            }
            set
            {
                this.subtotals = value;
                onPropertyChanged("Subtotals");
            }
        }
    }
}
