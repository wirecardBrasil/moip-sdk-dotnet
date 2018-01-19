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
    public class Links : BaseModel
    {
        // These fields hold the values for the public properties.
        private Models.Self self;
        private Models.LinksOrder order;
        private Models.LinksPayBoleto payBoleto;
        private Models.LinksPayOnlineBankDebitItau payOnlineBankDebitItau;
        private Models.LinksPayment payment;

        [JsonProperty("self")]
        public Models.Self Self
        {
            get
            {
                return this.self;
            }
            set
            {
                this.self = value;
                onPropertyChanged("Self");
            }
        }

        [JsonProperty("order")]
        public Models.LinksOrder Order
        {
            get
            {
                return this.order;
            }
            set
            {
                this.order = value;
                onPropertyChanged("Order");
            }
        }

        [JsonProperty("payBoleto")]
        public Models.LinksPayBoleto PayBoleto
        {
            get
            {
                return this.payBoleto;
            }
            set
            {
                this.payBoleto = value;
                onPropertyChanged("PayBoleto");
            }
        }

        [JsonProperty("payOnlineBankDebitItau")]
        public Models.LinksPayOnlineBankDebitItau PayOnlineBankDebitItau
        {
            get
            {
                return this.payOnlineBankDebitItau;
            }
            set
            {
                this.payOnlineBankDebitItau = value;
                onPropertyChanged("PayOnlineBankDebitItau");
            }
        }

        [JsonProperty("payment")]
        public Models.LinksPayment Payment
        {
            get
            {
                return this.payment;
            }
            set
            {
                this.payment = value;
                onPropertyChanged("Payment");
            }
        }

        [JsonProperty("setPassword")]
        public Self SetPassword { get; set; }

    }
}
