using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Moip.Models
{
    public class Person : BaseModel
    {
        private string name;
        private string lastName;
        private TaxDocument taxDocument;
        private IdentityDocumentRequest identityDocument;
        private string birthDate;
        private string nationality;
        private string birthPlace;
        private ParentsNameRequest parentsName;
        private Phone phone;
        private List<Phone> alternativePhones = new List<Phone>();
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

        [JsonProperty("lastName")]
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
                onPropertyChanged("LastName");
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

        [JsonProperty("identityDocument")]
        public IdentityDocumentRequest IdentityDocument
        {
            get
            {
                return this.identityDocument;
            }
            set
            {
                this.identityDocument = value;
                onPropertyChanged("IdentityDocument");
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

        [JsonProperty("nationality")]
        public string Nationality
        {
            get
            {
                return this.nationality;
            }
            set
            {
                this.nationality = value;
                onPropertyChanged("Nationality");
            }
        }

        [JsonProperty("birthPlace")]
        public string BirthPlace
        {
            get
            {
                return this.birthPlace;
            }
            set
            {
                this.birthPlace = value;
                onPropertyChanged("BirthPlace");
            }
        }

        [JsonProperty("parentsName")]
        public ParentsNameRequest ParentsName
        {
            get
            {
                return this.parentsName;
            }
            set
            {
                this.parentsName = value;
                onPropertyChanged("ParentsName");
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

        [JsonProperty("alternativePhones")]
        public List<Phone> AlternativePhones
        {
            get
            {
                return this.alternativePhones;
            }
            set
            {
                this.alternativePhones = value;
                onPropertyChanged("AlternativePhones");
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

    public class ParentsNameRequest : BaseModel
    {
        private string mother;
        private string father;

        [JsonProperty("mother")]
        public string Mother
        {
            get
            {
                return this.mother;
            }
            set
            {
                this.mother = value;
                onPropertyChanged("Mother");
            }
        }

        [JsonProperty("father")]
        public string Father
        {
            get
            {
                return this.father;
            }
            set
            {
                this.father = value;
                onPropertyChanged("Father");
            }
        }

    }
}