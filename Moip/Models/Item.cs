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
    public class Item : BaseModel
    {
        // These fields hold the values for the public properties.
        private string product;
        private int quantity;
        private string detail;
        private int price;

        [JsonProperty("product")]
        public string Product
        {
            get
            {
                return this.product;
            }
            set
            {
                this.product = value;
                onPropertyChanged("Product");
            }
        }

        [JsonProperty("quantity")]
        public int Quantity
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

        [JsonProperty("detail")]
        public string Detail
        {
            get
            {
                return this.detail;
            }
            set
            {
                this.detail = value;
                onPropertyChanged("Detail");
            }
        }

        [JsonProperty("price")]
        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
                onPropertyChanged("Price");
            }
        }

    }
}
