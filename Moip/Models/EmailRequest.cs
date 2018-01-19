using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Models
{
    public class EmailRequest : BaseModel
    {
        private string address;

        [JsonProperty("address")]
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
                onPropertyChanged("address");
            }
        }
    }

}
