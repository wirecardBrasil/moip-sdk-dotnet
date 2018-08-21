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
        private int _percentual;
        private int _fixed;

        [JsonProperty("percentual")]
        public int Percentual
        {
            get
            {
                return this._percentual;
            }
            set
            {
                this._percentual = value;
                onPropertyChanged("Percentual");
            }
        }
        [JsonProperty("fixed")]
        public int Fixed
        {
            get
            {
                return this._fixed;
            }
            set
            {
                this._fixed = value;
                onPropertyChanged("Fixed");
            }
        }
    }
}
