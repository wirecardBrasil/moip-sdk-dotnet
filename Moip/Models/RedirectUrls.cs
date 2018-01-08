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
    public class RedirectUrls : BaseModel
    {
        // These fields hold the values for the public properties.
        private string urlSuccess;
        private string urlFailure;

        [JsonProperty("urlSuccess")]
        public string UrlSuccess
        {
            get
            {
                return this.urlSuccess;
            }
            set
            {
                this.urlSuccess = value;
                onPropertyChanged("UrlSuccess");
            }
        }

        [JsonProperty("urlFailure")]
        public string UrlFailure
        {
            get
            {
                return this.urlFailure;
            }
            set
            {
                this.urlFailure = value;
                onPropertyChanged("UrlFailure");
            }
        }
    }
}
