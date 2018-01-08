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
    public class BoletoRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private string expirationDate;
        private Models.BoletoInstructionLines instructionLines;
        private string logoUri;

        [JsonProperty("expirationDate")]
        public string ExpirationDate
        {
            get
            {
                return this.expirationDate;
            }
            set
            {
                this.expirationDate = value;
                onPropertyChanged("ExpirationDate");
            }
        }

        [JsonProperty("instructionLines")]
        public Models.BoletoInstructionLines InstructionLines
        {
            get
            {
                return this.instructionLines;
            }
            set
            {
                this.instructionLines = value;
                onPropertyChanged("InstructionLines");
            }
        }

        [JsonProperty("logoUri")]
        public string LogoUri
        {
            get
            {
                return this.logoUri;
            }
            set
            {
                this.logoUri = value;
                onPropertyChanged("LogoUri");
            }
        }
    }
}
