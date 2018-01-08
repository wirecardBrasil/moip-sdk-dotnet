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
    public class OnlineBankDebitRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private int bankNumber;
        private string expirationDate;

        [JsonProperty("bankNumber")]
        public int BankNumber
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
