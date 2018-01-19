using System;
using Newtonsoft.Json;

namespace Moip.Models
{
    public class IdentityDocumentRequest : BaseModel
    {
        private string type;
        private string number;
        private string issuer;
        private string issueDate;


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


        [JsonProperty("number")]
        public string Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
                onPropertyChanged("Number");
            }
        }


        [JsonProperty("issuer")]
        public string Issuer
        {
            get
            {
                return this.issuer;
            }
            set
            {
                this.issuer = value;
                onPropertyChanged("Issuer");
            }
        }


        [JsonProperty("issueDate")]
        public string IssueDate
        {
            get
            {
                return this.issueDate;
            }
            set
            {
                this.issueDate = value;
                onPropertyChanged("IssueDate");
            }
        }
    }


}