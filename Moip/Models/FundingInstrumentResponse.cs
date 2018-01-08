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
    public class FundingInstrumentResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private Models.CreditCardResponse creditCard;
        private string method;
        private Models.BoletoResponse boleto;
        private Models.OnlineBankDebitResponse onlineBankDebit;
        private string brand;

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

        [JsonProperty("boleto")]
        public Models.BoletoResponse Boleto
        {
            get
            {
                return this.boleto;
            }
            set
            {
                this.boleto = value;
                onPropertyChanged("Boleto");
            }
        }

        [JsonProperty("onlineBankDebit")]
        public Models.OnlineBankDebitResponse OnlineBankDebit
        {
            get
            {
                return this.onlineBankDebit;
            }
            set
            {
                this.onlineBankDebit = value;
                onPropertyChanged("OnlineBankDebit");
            }
        }
    }
}
