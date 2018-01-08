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
    public class HolderRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private string fullname;
        private string birthdate;
        private Models.TaxDocument taxDocument;
        private Models.Phone phone;

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

        [JsonProperty("phone")]
        public Models.Phone Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
                onPropertyChanged("Phone");
            }
        }
    }
}
