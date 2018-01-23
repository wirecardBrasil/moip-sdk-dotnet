using System;
using Newtonsoft.Json;

namespace Moip.Models
{
    public class CompanyRequest : BaseModel
    {
        private string name;
        private string businessName;
        private string openingDate;
        private TaxDocument taxDocument;
        private MainActivityRequest mainActivity;
        private Phone phone;
        private ShippingAddress address;

        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                onPropertyChanged("Name");
            }
        }

        [JsonProperty("businessName")]
        public string BusinessName
        {
            get
            {
                return this.businessName;
            }
            set
            {
                this.businessName = value;
                onPropertyChanged("BusinessName");
            }
        }



        [JsonProperty("openingDate")]
        public string OpeningDate
        {
            get
            {
                return this.openingDate;
            }
            set
            {
                this.openingDate = value;
                onPropertyChanged("OpeningDate");
            }
        }


        [JsonProperty("taxDocument")]
        public TaxDocument TaxDocument
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

        [JsonProperty("mainActivity")]
        public MainActivityRequest MainActivity
        {
            get
            {
                return this.mainActivity;
            }
            set
            {
                this.mainActivity = value;
                onPropertyChanged("MainActivity");
            }
        }

        [JsonProperty("phone")]
        public Phone Phone
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

        [JsonProperty("address")]
        public ShippingAddress Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
                onPropertyChanged("Address");
            }
        }
    }

    public class MainActivityRequest : BaseModel
    {
        private string cnae;
        private string description;

        [JsonProperty("cnae")]
        public string Cnae
        {
            get
            {
                return this.cnae;
            }
            set
            {
                this.cnae = value;
                onPropertyChanged("Cnae");
            }
        }

        [JsonProperty("description")]
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                onPropertyChanged("Description");
            }
        }
    }
}