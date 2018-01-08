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
    public class Installments : BaseModel
    {
        // These fields hold the values for the public properties.
        private List<int> quantity;
        private int addition;

        [JsonProperty("quantity")]
        public List<int> Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
                onPropertyChanged("Quantity");
            }
        }

        [JsonProperty("addition")]
        public int Addition
        {
            get
            {
                return this.addition;
            }
            set
            {
                this.addition = value;
                onPropertyChanged("Addition");
            }
        }
    }
}
