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
    public class MultiorderResponse : BaseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ownId")]
        public string OwnId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("amount")]
        public AmountOrderResponse Amount { get; set; }

        [JsonProperty("orders")]
        public List<OrderResponse> Orders { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}
