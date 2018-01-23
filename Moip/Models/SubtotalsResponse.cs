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
    public class SubtotalsResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private int shipping;
        private int addition;
        private int discount;
        private int items;

        [JsonProperty("shipping")]
        public int Shipping
        {
            get
            {
                return this.shipping;
            }
            set
            {
                this.shipping = value;
                onPropertyChanged("Shipping");
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

        [JsonProperty("discount")]
        public int Discount
        {
            get
            {
                return this.discount;
            }
            set
            {
                this.discount = value;
                onPropertyChanged("Discount");
            }
        }

        [JsonProperty("items")]
        public int Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
                onPropertyChanged("Items");
            }
        }
    }
}
