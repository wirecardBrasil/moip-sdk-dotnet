using System;
using Moip.Controllers;
using Moip.Http.Client;
using Moip.Utilities;
using static Moip.Configuration;

namespace Moip
{
    public partial class Client
    {
        public NotificationsController Notifications
        {
            get
            {
                return NotificationsController.Instance;
            }
        }

        public PaymentsController Payments
        {
            get
            {
                return PaymentsController.Instance;
            }
        }

        public RefundsController Refunds
        {
            get
            {
                return RefundsController.Instance;
            }
        }

        public CustomersController Customers
        {
            get
            {
                return CustomersController.Instance;
            }
        }

        public OrdersController Orders
        {
            get
            {
                return OrdersController.Instance;
            }
        }

        public AccountsController Accounts
        {
            get
            {
                return AccountsController.Instance;
            }
        }



        public IHttpClient SharedHttpClient
        {
            get
            {
                return BaseController.ClientInstance;
            }
            set
            {
                BaseController.ClientInstance = value;
            }
        }
        #region Constructors



        public Client() { }

        public Client(string oAuthAccessToken, Environments environment)
        {
            Configuration.OAuthAccessToken = oAuthAccessToken;
            Configuration.Environment = environment;
        }
        #endregion
    }
}
