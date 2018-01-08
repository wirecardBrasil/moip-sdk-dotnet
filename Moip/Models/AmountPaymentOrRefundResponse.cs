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
    public class AmountPaymentOrRefundResponse : BaseModel
    {
        
        private int total;
        private int gross;
        private int fees;
        private int refunds;
        private int liquid;
        private string currency;

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

        [JsonProperty("gross")]
        public int Gross
        {
            get
            {
                return this.gross;
            }
            set
            {
                this.gross = value;
                onPropertyChanged("Gross");
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
    }
}
