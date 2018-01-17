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
    public class AmountOrderRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private string currency;
        private Models.SubtotalsRequest subtotals;

        [JsonProperty("currency")]
        public string Currency
        {
            get
            {
                return this.currency;
            }
            set
            {
                this.currency = value;
                onPropertyChanged("Currency");
            }
        }

        [JsonProperty("subtotals")]
        public Models.SubtotalsRequest Subtotals
        {
            get
            {
                return this.subtotals;
            }
            set
            {
                this.subtotals = value;
                onPropertyChanged("Subtotals");
            }
        }
    }
}
