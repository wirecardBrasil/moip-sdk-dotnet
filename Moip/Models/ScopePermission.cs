using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Models
{
    public enum ScopePermission
    {
        RECEIVE_FUNDS, REFUND, MANAGE_ACCOUNT_INFO,
        RETRIEVE_FINANCIAL_INFO, TRANSFER_FUNDS, DEFINE_PREFERENCES
    }
}
