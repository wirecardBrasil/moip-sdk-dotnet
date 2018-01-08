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
    public class OrderPaymentResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private string id;
        private int installmentCount;
        private Models.FundingInstrumentResponse fundingInstrument;

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

    }
}
