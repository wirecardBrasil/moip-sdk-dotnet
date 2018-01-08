using System.Collections.Generic;
using System.Text;
using Moip.Utilities;
using Moip.Models;
namespace Moip
{
    public partial class Configuration
    {

        public enum Environments
        {
            SANDBOX,
            PRODUCTION,
        }
        public enum Servers
        {
            SANDBOX,
            PRODUCTION,
        }

        public static Environments Environment = Environments.SANDBOX;

        //OAuth 2.0 Access Token
        //TODO: Replace the OAuthAccessToken with an appropriate value
        public static string OAuthAccessToken = "TODO: Replace";

        //A map of environments and their corresponding servers/baseurls
        public static Dictionary<Environments, string> EnvironmentsMap =
            new Dictionary<Environments, string>()
            {
                { Environments.SANDBOX,"https://sandbox.moip.com.br/v2" },
                { Environments.PRODUCTION,"https://api.moip.com.br/v2" }
            };

        internal static List<KeyValuePair<string, object>> GetBaseURIParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList;
        }

        internal static string GetBaseURI()
        {
            StringBuilder Url = new StringBuilder(EnvironmentsMap[Environment]);
            APIHelper.AppendUrlWithTemplateParameters(Url, GetBaseURIParameters());
            return Url.ToString();
        }
    }
}