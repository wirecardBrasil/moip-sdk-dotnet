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
    public class OnlineBankDebitResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private string bankName;
        private string bankNumber;
        private string expirationDate;

        [JsonProperty("bankName")]
        public string BankName
        {
            get
            {
                return this.bankName;
            }
            set
            {
                this.bankName = value;
                onPropertyChanged("BankName");
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

        [JsonProperty("expirationDate")]
        public string ExpirationDate
        {
            get
            {
                return this.expirationDate;
            }
            set
            {
                this.expirationDate = value;
                onPropertyChanged("ExpirationDate");
            }
        }
    }
}
