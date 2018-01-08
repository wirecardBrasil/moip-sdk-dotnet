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
    public class HolderResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private string birthdate;
        private Models.TaxDocument taxDocument;
        private string fullname;

        [JsonProperty("birthdate")]
        public string Birthdate
        {
            get
            {
                return this.birthdate;
            }
            set
            {
                this.birthdate = value;
                onPropertyChanged("Birthdate");
            }
        }

        [JsonProperty("taxDocument")]
        public Models.TaxDocument TaxDocument
        {
            get
            {
                return this.taxDocument;
            }
            set
            {
                this.taxDocument = value;
                onPropertyChanged("TaxDocument");
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
