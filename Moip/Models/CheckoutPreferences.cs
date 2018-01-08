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
    public class CheckoutPreferences : BaseModel
    {
        // These fields hold the values for the public properties.
        private Models.RedirectUrls redirectUrls;
        private List<Models.Installments> installments;

        [JsonProperty("redirectUrls")]
        public Models.RedirectUrls RedirectUrls
        {
            get
            {
                return this.redirectUrls;
            }
            set
            {
                this.redirectUrls = value;
                onPropertyChanged("RedirectUrls");
            }
        }

        [JsonProperty("installments")]
        public List<Models.Installments> Installments
        {
            get
            {
                return this.installments;
            }
            set
            {
                this.installments = value;
                onPropertyChanged("Installments");
            }
        }
    }
}
