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
    public class AccountRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private EmailRequest email;
        private Person person;
        private CompanyRequest company;
        private BusinessSegmentRequest businessSegment;
        private string site;
        private string type;
        private bool transparentAccount;
        private TosAcceptanceRequest tosAcceptance;

        [JsonProperty("email")]
        public EmailRequest Email
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

        [JsonProperty("person")]
        public Person Person
        {
            get
            {
                return this.person;
            }
            set
            {
                this.person = value;
                onPropertyChanged("Person");
            }
        }

        [JsonProperty("company")]
        public CompanyRequest Company
        {
            get
            {
                return this.company;
            }
            set
            {
                this.company = value;
                onPropertyChanged("Company");
            }
        }

        [JsonProperty("businessSegment")]
        public BusinessSegmentRequest BusinessSegment
        {
            get
            {
                return this.businessSegment;
            }
            set
            {
                this.businessSegment = value;
                onPropertyChanged("businessSegment");
            }
        }

        [JsonProperty("site")]
        public string Site
        {
            get
            {
                return this.site;
            }
            set
            {
                this.site = value;
                onPropertyChanged("Site");
            }
        }

        [JsonProperty("type")]
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
                onPropertyChanged("Type");
            }
        }

        [JsonProperty("transparentAccount")]
        public bool TransparentAccount
        {
            get
            {
                return this.transparentAccount;
            }
            set
            {
                this.transparentAccount = value;
                onPropertyChanged("TransparentAccount");
            }
        }

        [JsonProperty("tosAcceptance")]
        public TosAcceptanceRequest TosAcceptance
        {
            get
            {
                return this.tosAcceptance;
            }
            set
            {
                this.tosAcceptance = value;
                onPropertyChanged("TosAcceptance");
            }
        }
    }
}
