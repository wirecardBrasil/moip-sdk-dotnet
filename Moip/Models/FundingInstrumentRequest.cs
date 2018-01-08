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
    public class FundingInstrumentRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private string method;
        private Models.CreditCardRequest creditCard;
        private Models.BoletoRequest boleto;
        private Models.OnlineBankDebitRequest onlineBankDebit;

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

        [JsonProperty("creditCard")]
        public Models.CreditCardRequest CreditCard
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

        [JsonProperty("boleto")]
        public Models.BoletoRequest Boleto
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
        public Models.OnlineBankDebitRequest OnlineBankDebit
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
