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
    public class GrantType
    {
        public static string AUTHORIZATION_CODE = "authorization_code";
        public static string REFRESH_TOKEN = "refresh_token";

        private String description;

        private GrantType(String description)
        {
            this.description = description;
        }

        public String getDescription()
        {
            return description;
        }
    }
}
