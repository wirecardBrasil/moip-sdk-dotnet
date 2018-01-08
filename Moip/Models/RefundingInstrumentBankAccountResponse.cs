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
    public class RefundingInstrumentBankAccountResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private Models.BankAccountRefundingInstrumentResponse bankAccount;
        private string method;

        [JsonProperty("bankAccount")]
        public Models.BankAccountRefundingInstrumentResponse BankAccount
        {
            get
            {
                return this.bankAccount;
            }
            set
            {
                this.bankAccount = value;
                onPropertyChanged("BankAccount");
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
