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
    public class ReceiverRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private Models.MoipAccountReceiverRequest moipAccount;
        private string type;
        private Models.AmountReceiverRequest amount;
        private bool feePayor;

        [JsonProperty("moipAccount")]
        public Models.MoipAccountReceiverRequest MoipAccount
        {
            get
            {
                return this.moipAccount;
            }
            set
            {
                this.moipAccount = value;
                onPropertyChanged("MoipAccount");
            }
        }

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

        [JsonProperty("amount")]
        public Models.AmountReceiverRequest Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
                onPropertyChanged("Amount");
            }
        }

        [JsonProperty("feePayor")]
        public bool FeePayor
        {
            get
            {
                return this.feePayor;
            }
            set
            {
                this.feePayor = value;
                onPropertyChanged("FeePayor");
            }
        }
    }
}
