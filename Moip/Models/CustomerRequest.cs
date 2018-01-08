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
    public class CustomerRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private string ownId;
        private string fullname;
        private string email;
        private string birthDate;
        private Models.TaxDocument taxDocument;
        private Models.Phone phone;
        private Models.ShippingAddress shippingAddress;
        private Models.FundingInstrumentRequest fundingInstrument;
        private string id;

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

        [JsonProperty("fundingInstrument")]
        public Models.FundingInstrumentRequest FundingInstrument
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
    }
}
