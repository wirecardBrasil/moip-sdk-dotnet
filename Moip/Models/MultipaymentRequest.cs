using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Moip.Models
{
    public class MultipaymentRequest : BaseModel
    {

        // These fields hold the values for the public properties.
        private int? installmentCount;
        private string statementDescriptor;
        private Models.FundingInstrumentRequest fundingInstrument;
        private Models.Escrow escrow;
        private bool? delayCapture;

        [JsonProperty("installmentCount")]
        public int? InstallmentCount
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

        [JsonProperty("statementDescriptor")]
        public string StatementDescriptor
        {
            get
            {
                return this.statementDescriptor;
            }
            set
            {
                this.statementDescriptor = value;
                onPropertyChanged("StatementDescriptor");
            }
        }

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

        [JsonProperty("escrow")]
        public Models.Escrow Escrow
        {
            get
            {
                return this.escrow;
            }
            set
            {
                this.escrow = value;
                onPropertyChanged("Escrow");
            }
        }

        [JsonProperty("delayCapture")]
        public bool? DelayCapture
        {
            get
            {
                return this.delayCapture;
            }
            set
            {
                this.delayCapture = value;
                onPropertyChanged("DelayCapture");
            }
        }
    }
}
