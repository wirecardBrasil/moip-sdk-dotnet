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
    public class CustomerResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private string id;
        private string ownId;
        private string fullname;
        private string createdAt;
        private string birthDate;
        private string email;
        private Models.FundingInstrumentResponse fundingInstrument;
        private Models.Phone phone;
        private Models.TaxDocument taxDocument;
        private Models.ShippingAddress shippingAddress;
        private object links;

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

        [JsonProperty("ownId")]
        public string OwnId
        {
            get
            {
                return this.ownId;
            }
            set
            {
                this.ownId = value;
                onPropertyChanged("OwnId");
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

        [JsonProperty("createdAt")]
        public string CreatedAt
        {
            get
            {
                return this.createdAt;
            }
            set
            {
                this.createdAt = value;
                onPropertyChanged("CreatedAt");
            }
        }

        [JsonProperty("birthDate")]
        public string BirthDate
        {
            get
            {
                return this.birthDate;
            }
            set
            {
                this.birthDate = value;
                onPropertyChanged("BirthDate");
            }
        }

        [JsonProperty("email")]
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
                onPropertyChanged("Email");
            }
        }

        [JsonProperty("fundingInstrument")]
        public Models.FundingInstrumentResponse FundingInstrument
        {
            get
            {
                return this.fundingInstrument;
            }
            set
            {
                this.fundingInstrument = value;
                onPropertyChanged("FundingInstrument");
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

        [JsonProperty("shippingAddress")]
        public Models.ShippingAddress ShippingAddress
        {
            get
            {
                return this.shippingAddress;
            }
            set
            {
                this.shippingAddress = value;
                onPropertyChanged("ShippingAddress");
            }
        }

        [JsonProperty("_links")]
        public object Links
        {
            get
            {
                return this.links;
            }
            set
            {
                this.links = value;
                onPropertyChanged("Links");
            }
        }
    }
}
