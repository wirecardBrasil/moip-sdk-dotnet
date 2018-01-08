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
    public class AmountReceiverResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private int total;
        private string currency;
        private int fees;
        private int refunds;

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
    }
}
