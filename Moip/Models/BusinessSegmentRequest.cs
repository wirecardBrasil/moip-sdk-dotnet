using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Models
{
    public class BusinessSegmentRequest : BaseModel
    {
        private int id;

        [JsonProperty("id")]
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                onPropertyChanged("Id");
            }
        }
    }
}
