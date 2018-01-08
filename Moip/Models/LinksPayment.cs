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
    public class LinksPayment : BaseModel
    {
        // These fields hold the values for the public properties.
        private string href;
        private string title;

        [JsonProperty("href")]
        public string Href
        {
            get
            {
                return this.href;
            }
            set
            {
                this.href = value;
                onPropertyChanged("Href");
            }
        }

        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                onPropertyChanged("Title");
            }
        }
    }
}
