using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Models
{
    public class TosAcceptanceRequest : BaseModel
    {
        private DateTime acceptedAt;
        private string ip;
        private string userAgent;

        [JsonProperty("acceptedAt")]
        public DateTime AcceptedAt
        {
            get
            {
                return this.acceptedAt;
            }
            set
            {
                this.acceptedAt = value;
                onPropertyChanged("AcceptedAt");
            }
        }

        [JsonProperty("ip")]
        public string Ip
        {
            get
            {
                return this.ip;
            }
            set
            {
                this.ip = value;
                onPropertyChanged("Ip");
            }
        }

        [JsonProperty("userAgent")]
        public string UserAgent
        {
            get
            {
                return this.userAgent;
            }
            set
            {
                this.userAgent = value;
                onPropertyChanged("UserAgent");
            }
        }
    }
}
