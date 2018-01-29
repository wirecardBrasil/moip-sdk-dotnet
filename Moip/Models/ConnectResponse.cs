using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Models
{
    public class ConnectResponse : BaseModel
    {
        private string accessToken;
        private string expires_in;
        private string scope;
        private MoipAccountCustomer moipAccount;
        private string refreshToken;

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("moipAccount")]
        public MoipAccountCustomer MoipAccount { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
