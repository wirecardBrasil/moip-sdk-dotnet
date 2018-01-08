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
    public class RefundingInstrumentCCResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private Models.CreditCardResponse creditCard;
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
}
