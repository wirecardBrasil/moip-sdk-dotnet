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
    public class MultiorderRequest : BaseModel
    {

        [JsonProperty("ownId")]
        public string OwnId { get; set; }

        [JsonProperty("orders")]
        public List<OrderRequest> Orders { get; set; }
    }
}
