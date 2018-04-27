using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Moip.Models
{
    public class MultipaymentResponse : BaseModel
    {
        private string id;
        private string status;
        private Models.AmountPaymentOrRefundResponse amount;
        private int installmentCount;
        private List<Models.PaymentResponse> payments;
        private Models.Links links;

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

        [JsonProperty("status")]
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
                onPropertyChanged("Status");
            }
        }

        [JsonProperty("amount")]
        public AmountPaymentOrRefundResponse Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
                onPropertyChanged("Amount");
            }
        }

        [JsonProperty("installmentCount")]
        public int InstallmentCount
        {
            get
            {
                return this.installmentCount;
            }
            set
            {
                this.installmentCount = value;
                onPropertyChanged("InstallmentCount");
            }
        }

        [JsonProperty("payments")]
        public List<PaymentResponse> Payments
        {
            get
            {
                return this.payments;
            }
            set
            {
                this.payments = value;
                onPropertyChanged("Payments");
            }
        }

        [JsonProperty("_links")]
        public Links Links
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
