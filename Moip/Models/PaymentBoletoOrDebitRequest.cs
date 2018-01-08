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
    public class PaymentBoletoOrDebitRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private Models.FundingInstrumentRequest fundingInstrument;

        [JsonProperty("fundingInstrument")]
        public Models.FundingInstrumentRequest FundingInstrument
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
    }
}
