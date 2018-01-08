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
    public class OrderListResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private List<Models.OrderResponse> orders;

        [JsonProperty("orders")]
        public List<Models.OrderResponse> Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders = value;
                onPropertyChanged("Orders");
            }
        }

    }
}
