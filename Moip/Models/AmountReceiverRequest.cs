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
    public class AmountReceiverRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private int percentual;

        [JsonProperty("percentual")]
        public int Percentual
        {
            get
            {
                return this.percentual;
            }
            set
            {
                this.percentual = value;
                onPropertyChanged("Percentual");
            }
        }
    }
}
