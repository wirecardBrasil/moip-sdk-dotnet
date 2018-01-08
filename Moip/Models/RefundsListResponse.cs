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
    public class RefundsListResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private List<Models.RefundCCResponse> refunds;

        [JsonProperty("refunds")]
        public List<Models.RefundCCResponse> Refunds
        {
            get
            {
                return this.refunds;
            }
            set
            {
                this.refunds = value;
                onPropertyChanged("Refunds");
            }
        }
    }
}
