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
    public class MoipAccountReceiverResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private string id;
        private string login;
        private string fullname;

        [JsonProperty("id")]
        public string Id
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

        [JsonProperty("login")]
        public string Login
        {
            get
            {
                return this.login;
            }
            set
            {
                this.login = value;
                onPropertyChanged("Login");
            }
        }

        [JsonProperty("fullname")]
        public string Fullname
        {
            get
            {
                return this.fullname;
            }
            set
            {
                this.fullname = value;
                onPropertyChanged("Fullname");
            }
        }
    }
}
