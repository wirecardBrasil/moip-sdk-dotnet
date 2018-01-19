using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Moip.Models
{
    public class AccountResponse : BaseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("transparentAccount")]
        public bool TransparentAccount { get; set; }

        [JsonProperty("createdAt")]
        public String CreatedAt { get; set; }

        [JsonProperty("businessSegment")]
        public BusinessSegment BusinessSegment { get; set; }

        [JsonProperty("person")]
        public Person Person { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("email")]
        public Email Email { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("monthlyRevenueId")]
        public int MonthlyRevenueId { get; set; }

        [JsonProperty("softDescriptor")]
        public string SoftDescriptor { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }
    }

    public class Email
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }
    }

    public class BusinessSegment
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class Company
    {
        [JsonProperty("monthlyRevenue")]
        public string MonthlyRevenue { get; set; }

        [JsonProperty("businessName")]
        public string BusinessName { get; set; }

        [JsonProperty("phone")]
        public Phone Phone { get; set; }

        [JsonProperty("openingDate")]
        public string OpeningDate { get; set; }

        [JsonProperty("address")]
        public ShippingAddress Address { get; set; }

        [JsonProperty("taxDocument")]
        public TaxDocument TaxDocument { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("constitutionType")]
        public string ConstitutionType { get; set; }
    }
    
}
