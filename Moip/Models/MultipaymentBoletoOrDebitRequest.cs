using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Moip.Models
{
    public class MultipaymentBoletoOrDebitRequest : BaseModel
    {
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
