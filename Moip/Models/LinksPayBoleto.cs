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
    public class LinksPayBoleto : BaseModel
    {
        // These fields hold the values for the public properties.
        private string printHref;
        private string redirectHref;

        [JsonProperty("printHref")]
        public string PrintHref
        {
            get
            {
                return this.printHref;
            }
            set
            {
                this.printHref = value;
                onPropertyChanged("PrintHref");
            }
        }

        [JsonProperty("redirectHref")]
        public string RedirectHref
        {
            get
            {
                return this.redirectHref;
            }
            set
            {
                this.redirectHref = value;
                onPropertyChanged("RedirectHref");
            }
        }
    }
}
