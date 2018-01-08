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
    public class BankAccountRefundingInstrumentRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private string type;
        private string bankNumber;
        private string agencyNumber;
        private string agencyCheckNumber;
        private string accountNumber;
        private string accountCheckNumber;
        private Models.HolderRequest holder;

        [JsonProperty("type")]
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
                onPropertyChanged("Type");
            }
        }

        [JsonProperty("bankNumber")]
        public string BankNumber
        {
            get
            {
                return this.bankNumber;
            }
            set
            {
                this.bankNumber = value;
                onPropertyChanged("BankNumber");
            }
        }

        [JsonProperty("agencyNumber")]
        public string AgencyNumber
        {
            get
            {
                return this.agencyNumber;
            }
            set
            {
                this.agencyNumber = value;
                onPropertyChanged("AgencyNumber");
            }
        }

        [JsonProperty("agencyCheckNumber")]
        public string AgencyCheckNumber
        {
            get
            {
                return this.agencyCheckNumber;
            }
            set
            {
                this.agencyCheckNumber = value;
                onPropertyChanged("AgencyCheckNumber");
            }
        }

        [JsonProperty("accountNumber")]
        public string AccountNumber
        {
            get
            {
                return this.accountNumber;
            }
            set
            {
                this.accountNumber = value;
                onPropertyChanged("AccountNumber");
            }
        }

        [JsonProperty("accountCheckNumber")]
        public string AccountCheckNumber
        {
            get
            {
                return this.accountCheckNumber;
            }
            set
            {
                this.accountCheckNumber = value;
                onPropertyChanged("AccountCheckNumber");
            }
        }

        [JsonProperty("holder")]
        public Models.HolderRequest Holder
        {
            get
            {
                return this.holder;
            }
            set
            {
                this.holder = value;
                onPropertyChanged("Holder");
            }
        }
    }
}
