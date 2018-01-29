using Moip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Tests.Helpers
{
    class RequestsCreator
    {
        public static OrderRequest createOrderRequest()
        {
            TaxDocument taxDocument = new TaxDocument
            {
                Type = "CPF",
                Number = "22222222222"
            };

            Phone phone = new Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "66778899"
            };

            ShippingAddress shippingAddress = new ShippingAddress
            {
                Street = "Rua test",
                StreetNumber = "123",
                Complement = "Ap test",
                District = "Bairro test",
                City = "TestCity",
                State = "SP",
                Country = "BRA",
                ZipCode = "01234000"
            };

            CustomerRequest customerRequest = new CustomerRequest
            {
                Fullname = "Fulano de Tal",
                OwnId = "OFulanoDeTal",
                BirthDate = "1990-01-01",
                Email = "fulano@detal.com.br",
                Phone = phone,
                ShippingAddress = shippingAddress,
                TaxDocument = taxDocument
            };

            Moip.Models.SubtotalsRequest subtotalsRequest = new Moip.Models.SubtotalsRequest
            {
                Shipping = 1500,
                Addition = 20,
                Discount = 10
            };


            Moip.Models.AmountOrderRequest amountRequest = new Moip.Models.AmountOrderRequest
            {
                Currency = "BRL",
                Subtotals = subtotalsRequest
            };

            Item itemsRequest = new Item
            {
                Product = "Bicicleta Specialized Tarmac 26 Shimano Alivio",
                Quantity = 1,
                Detail = "uma linda bicicleta",
                Price = 2000
            };

            List<Item> itemsRequestList = new List<Item>
            {
                itemsRequest
            };

            OrderRequest orderRequest = new OrderRequest
            {
                OwnId = "my_own_id",
                Amount = amountRequest,
                Items = itemsRequestList,
                Customer = customerRequest,
            };

            return orderRequest;
        }

        public static OrderRequest createOrderWithReceiversRequest()
        {
            TaxDocument taxDocument = new TaxDocument
            {
                Type = "CPF",
                Number = "22222222222"
            };

            Phone phone = new Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "66778899"
            };

            ShippingAddress shippingAddress = new ShippingAddress
            {
                Street = "Rua test",
                StreetNumber = "123",
                Complement = "Ap test",
                District = "Bairro test",
                City = "TestCity",
                State = "SP",
                Country = "BRA",
                ZipCode = "01234000"
            };

            CustomerRequest customerRequest = new CustomerRequest
            {
                Fullname = "Fulano de Tal",
                OwnId = "OFulanoDeTal",
                BirthDate = "1990-01-01",
                Email = "fulano@detal.com.br",
                Phone = phone,
                ShippingAddress = shippingAddress,
                TaxDocument = taxDocument
            };

            Moip.Models.SubtotalsRequest subtotalsRequest = new Moip.Models.SubtotalsRequest
            {
                Shipping = 1500,
                Addition = 20,
                Discount = 10
            };

            AmountOrderRequest amountRequest = new AmountOrderRequest
            {
                Currency = "BRL",
                Subtotals = subtotalsRequest
            };

            Item itemsRequest = new Item
            {
                Product = "Bicicleta Specialized Tarmac 26 Shimano Alivio",
                Quantity = 1,
                Detail = "uma linda bicicleta",
                Price = 2000
            };

            List<Item> itemsRequestList = new List<Item>
            {
                itemsRequest
            };

            MoipAccountReceiverRequest moipAccountReceiver1 = new MoipAccountReceiverRequest
            {
                Id = "MPA-14AC21F09CAE"
            };

            AmountReceiverRequest amountReceiver1 = new AmountReceiverRequest
            {
                Percentual = 50
            };

            ReceiverRequest receiver1 = new ReceiverRequest
            {
                MoipAccount = moipAccountReceiver1,
                Type = "SECONDARY",
                Amount = amountReceiver1
            };

            MoipAccountReceiverRequest moipAccountReceiver2 = new MoipAccountReceiverRequest
            {
                Id = "MPA-B0D880F21EF1"
            };

            AmountReceiverRequest amountReceiver2 = new AmountReceiverRequest
            {
                Percentual = 50
            };

            ReceiverRequest receiver2 = new ReceiverRequest
            {
                MoipAccount = moipAccountReceiver2,
                Type = "SECONDARY",
                Amount = amountReceiver2
            };

            List<ReceiverRequest> receiverList = new List<ReceiverRequest>
            {
                receiver1,
                receiver2
            };

            OrderRequest orderRequest = new OrderRequest
            {
                OwnId = "my_own_id",
                Amount = amountRequest,
                Items = itemsRequestList,
                Customer = customerRequest,
                Receivers = receiverList
            };

            return orderRequest;
        }

        public static PaymentRequest CreatePaymentWithCCRequest()
        {

            TaxDocument taxDocumentRequest = new TaxDocument
            {
                Type = "CPF",
                Number = "33333333333"
            };

            Phone phoneRequest = new Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "66778899"
            };

            HolderRequest holderRequest = new HolderRequest
            {
                Fullname = "Jose Goku da Silva",
                Birthdate = "1988-12-30",
                TaxDocument = taxDocumentRequest,
                Phone = phoneRequest
            };

            CreditCardRequest creditCardRequest = new CreditCardRequest
            {
                ExpirationMonth = "02",
                ExpirationYear = "20",
                Number = "5555666677778884",
                Cvc = "123",
                Holder = holderRequest
            };

            FundingInstrumentRequest fundingInstrumentRequest = new FundingInstrumentRequest
            {
                Method = "CREDIT_CARD",
                CreditCard = creditCardRequest
            };

            PaymentRequest paymentRequest = new PaymentRequest
            {
                InstallmentCount = 1,
                StatementDescriptor = "MyStore",
                FundingInstrument = fundingInstrumentRequest
            };

            return paymentRequest;

        }

        public static PaymentRequest CreatePaymentWithPreAuthorizationRequest()
        {

            TaxDocument taxDocumentRequest = new TaxDocument
            {
                Type = "CPF",
                Number = "33333333333"
            };

            Phone phoneRequest = new Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "66778899"
            };

            HolderRequest holderRequest = new HolderRequest
            {
                Fullname = "Jose Goku da Silva",
                Birthdate = "1988-12-30",
                TaxDocument = taxDocumentRequest,
                Phone = phoneRequest
            };

            CreditCardRequest creditCardRequest = new CreditCardRequest
            {
                ExpirationMonth = "02",
                ExpirationYear = "20",
                Number = "5555666677778884",
                Cvc = "123",
                Holder = holderRequest
            };

            FundingInstrumentRequest fundingInstrumentRequest = new FundingInstrumentRequest
            {
                Method = "CREDIT_CARD",
                CreditCard = creditCardRequest
            };

            PaymentRequest paymentRequest = new PaymentRequest
            {
                InstallmentCount = 1,
                StatementDescriptor = "MyStore",
                FundingInstrument = fundingInstrumentRequest,
                DelayCapture = true
            };

            return paymentRequest;

        }

        public static PaymentBoletoOrDebitRequest CreatePaymentWithBoletoRequest()
        {

            BoletoInstructionLines boletoInstructionLines = new BoletoInstructionLines()
            {
                First = "TESTETETSTTTST",
                Second = "tfcsddlksjsd",
                Third = "lkshglashiuahgha"
            };

            BoletoRequest boletoRequest = new BoletoRequest()
            {
                ExpirationDate = "2020-09-30",
                InstructionLines = boletoInstructionLines,
                LogoUri = "http://"
            };

            FundingInstrumentRequest fundingInstrumentRequest = new FundingInstrumentRequest
            {
                Method = "BOLETO",
                Boleto = boletoRequest
            };

            PaymentBoletoOrDebitRequest paymentRequest = new PaymentBoletoOrDebitRequest
            {
                FundingInstrument = fundingInstrumentRequest
            };

            return paymentRequest;

        }

        public static PaymentBoletoOrDebitRequest CreatePaymentWithOnlineDebitRequest()
        {
            OnlineBankDebitRequest onlineBankDebitRequest = new OnlineBankDebitRequest()
            {
                BankNumber = 341,
                ExpirationDate = "2020-09-30"
            };

            FundingInstrumentRequest fundingInstrumentRequest = new FundingInstrumentRequest
            {
                Method = "ONLINE_BANK_DEBIT",
                OnlineBankDebit = onlineBankDebitRequest
            };

            PaymentBoletoOrDebitRequest paymentRequest = new PaymentBoletoOrDebitRequest
            {
                FundingInstrument = fundingInstrumentRequest
            };

            return paymentRequest;

        }

        public static NotificationPreferenceRequest CreateNotificationRequest()
        {
            List<string> eventsList = new List<string>();
            eventsList.Add("ORDER.*");
            eventsList.Add("PAYMENT.AUTHORIZED");
            eventsList.Add("PAYMENT.CANCELLED");

            NotificationPreferenceRequest notificationPreferenceRequest = new NotificationPreferenceRequest()
            {
                Events = eventsList,
                Target = "http://requestb.in/1dhjesw1",
                Media = "WEBHOOK"
            };
            return notificationPreferenceRequest;

        }

        public static PaymentRequest CreatePaymentWithEscrowRequest()
        {

            TaxDocument taxDocumentRequest = new TaxDocument
            {
                Type = "CPF",
                Number = "33333333333"
            };

            Phone phoneRequest = new Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "66778899"
            };

            HolderRequest holderRequest = new HolderRequest
            {
                Fullname = "Jose Goku da Silva",
                Birthdate = "1988-12-30",
                TaxDocument = taxDocumentRequest,
                Phone = phoneRequest
            };

            CreditCardRequest creditCardRequest = new CreditCardRequest
            {
                ExpirationMonth = "02",
                ExpirationYear = "20",
                Number = "5555666677778884",
                Cvc = "123",
                Holder = holderRequest
            };

            FundingInstrumentRequest fundingInstrumentRequest = new FundingInstrumentRequest
            {
                Method = "CREDIT_CARD",
                CreditCard = creditCardRequest
            };

            Escrow escrow = new Escrow
            {
                Description = "Escrow test"
            };

            PaymentRequest paymentRequest = new PaymentRequest
            {
                InstallmentCount = 1,
                StatementDescriptor = "MyStore",
                FundingInstrument = fundingInstrumentRequest,
                Escrow = escrow
            };

            return paymentRequest;

        }

        public static RefundCCRequest CreateFullCCRefundRequest()
        {
            Phone phoneRequest = new Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "66778899"
            };

            TaxDocument taxDocumentRequest = new TaxDocument
            {
                Type = "CPF",
                Number = "33333333333"
            };

            HolderRequest holderRequest = new HolderRequest
            {
                Fullname = "Jose Goku da Silva",
                Birthdate = "1988-12-30",
                TaxDocument = taxDocumentRequest,
                Phone = phoneRequest,

            };

            CreditCardRequest creditCardRequest = new CreditCardRequest
            {
                Number = "5555666677778884",
                ExpirationMonth = "02",
                ExpirationYear = "20",
                Cvc = "123",
                Holder = holderRequest
            };

            RefundingInstrumentCCRequest refundingInstrumentRequest = new RefundingInstrumentCCRequest
            {
                Method = "CREDIT_CARD",
                CreditCard = creditCardRequest
            };

            RefundCCRequest refundRequest = new RefundCCRequest
            {
                RefundingInstrument = refundingInstrumentRequest,
            };

            return refundRequest;

        }

        public static RefundCCRequest CreatePartialCCRefundRequest()
        {
            Phone phoneRequest = new Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "66778899"
            };

            TaxDocument taxDocumentRequest = new TaxDocument
            {
                Type = "CPF",
                Number = "33333333333"
            };

            HolderRequest holderRequest = new HolderRequest
            {
                Fullname = "Jose Goku da Silva",
                Birthdate = "1988-12-30",
                TaxDocument = taxDocumentRequest,
                Phone = phoneRequest,

            };

            CreditCardRequest creditCardRequest = new CreditCardRequest
            {
                Number = "5555666677778884",
                ExpirationMonth = "02",
                ExpirationYear = "20",
                Cvc = "123",
                Holder = holderRequest
            };

            RefundingInstrumentCCRequest refundingInstrumentRequest = new RefundingInstrumentCCRequest
            {
                Method = "CREDIT_CARD",
                CreditCard = creditCardRequest
            };

            RefundCCRequest refundRequest = new RefundCCRequest
            {
                RefundingInstrument = refundingInstrumentRequest,
                Amount = 100
            };

            return refundRequest;

        }

        public static RefundBankAccountRequest CreateFullBankAccountRefundRequest()
        {
            TaxDocument taxDocumentRequest = new TaxDocument
            {
                Type = "CPF",
                Number = "22222222222"
            };

            HolderRequest holderRequest = new HolderRequest
            {
                Fullname = "Fulano de Tal",
                Birthdate = "1990-01-01",
                TaxDocument = taxDocumentRequest,

            };

            BankAccountRefundingInstrumentRequest bankAccountRefundRequest = new BankAccountRefundingInstrumentRequest
            {
                BankNumber = "341",
                AgencyNumber = "4444444",
                AgencyCheckNumber = "2",
                AccountNumber = "1234",
                AccountCheckNumber = "1",
                Type = "CHECKING",
                Holder = holderRequest
            };

            RefundingInstrumentBankAccountRequest refundingInstrumentRequest = new RefundingInstrumentBankAccountRequest
            {
                Method = "BANK_ACCOUNT",
                BankAccount = bankAccountRefundRequest
            };

            RefundBankAccountRequest refundRequest = new RefundBankAccountRequest
            {
                RefundingInstrument = refundingInstrumentRequest,
            };

            return refundRequest;

        }

        public static RefundBankAccountRequest CreatePartialBankAccountRefundRequest()
        {

            TaxDocument taxDocumentRequest = new TaxDocument
            {
                Type = "CPF",
                Number = "22222222222"
            };

            HolderRequest holderRequest = new HolderRequest
            {
                Fullname = "Fulano de Tal",
                Birthdate = "1990-01-01",
                TaxDocument = taxDocumentRequest,

            };

            BankAccountRefundingInstrumentRequest bankAccountRefundRequest = new BankAccountRefundingInstrumentRequest
            {
                BankNumber = "341",
                AgencyNumber = "4444444",
                AgencyCheckNumber = "2",
                AccountNumber = "1234",
                AccountCheckNumber = "1",
                Type = "CHECKING",
                Holder = holderRequest
            };

            RefundingInstrumentBankAccountRequest refundingInstrumentRequest = new RefundingInstrumentBankAccountRequest
            {
                Method = "BANK_ACCOUNT",
                BankAccount = bankAccountRefundRequest
            };

            RefundBankAccountRequest refundRequest = new RefundBankAccountRequest
            {
                RefundingInstrument = refundingInstrumentRequest,
                Amount = 100
            };

            return refundRequest;

        }

        public static CustomerRequest CreateCustomerRequest(string date)
        {
            ShippingAddress shippingAddressRequest = new ShippingAddress
            {
                Street = "Rua test",
                StreetNumber = "123",
                Complement = "Ap test",
                District = "Bairro test",
                City = "TestCity",
                State = "SP",
                Country = "BRA",
                ZipCode = "01234000"
            };

            TaxDocument taxDocumentRequest = new TaxDocument
            {
                Type = "CPF",
                Number = "33333333333"
            };

            Phone phoneRequest = new Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "66778899"
            };

            CustomerRequest customerRequest = new CustomerRequest
            {
                Fullname = "Fulano de Tal",
                OwnId = "OFulanoDeTal" + date,
                BirthDate = "1990-01-01",
                Email = "fulano@detal.com.br",
                Phone = phoneRequest,
                ShippingAddress = shippingAddressRequest,
                TaxDocument = taxDocumentRequest
            };

            return customerRequest;
        }

        public static CustomerRequest CreateCustomerWithFundingInstrumentRequest(string date)
        {
            ShippingAddress shippingAddressRequest = new ShippingAddress
            {
                Street = "Rua test",
                StreetNumber = "123",
                Complement = "Ap test",
                District = "Bairro test",
                City = "TestCity",
                State = "SP",
                Country = "BRA",
                ZipCode = "01234000"
            };

            TaxDocument taxDocumentRequest = new TaxDocument
            {
                Type = "CPF",
                Number = "33333333333"
            };

            Phone phoneRequest = new Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "66778899"
            };

            HolderRequest holderRequest = new HolderRequest
            {
                Fullname = "Jose Goku da Silva",
                Birthdate = "1988-12-30",
                TaxDocument = taxDocumentRequest,
                Phone = phoneRequest
            };

            CreditCardRequest creditCardRequest = new CreditCardRequest
            {
                ExpirationMonth = "02",
                ExpirationYear = "20",
                Number = "5555666677778884",
                Cvc = "123",
                Holder = holderRequest
            };

            FundingInstrumentRequest fundingInstrumentRequest = new FundingInstrumentRequest
            {
                Method = "CREDIT_CARD",
                CreditCard = creditCardRequest
            };

            CustomerRequest customerRequest = new CustomerRequest
            {
                Fullname = "Fulano de Tal",
                OwnId = "OFulanoDeTal" + date,
                BirthDate = "1990-01-01",
                Email = "fulano@detal.com.br",
                Phone = phoneRequest,
                ShippingAddress = shippingAddressRequest,
                TaxDocument = taxDocumentRequest,
                FundingInstrument = fundingInstrumentRequest
            };

            return customerRequest;
        }

        public static CustomerCreditCardRequest CreateCustomerCreditCardRequest()
        {
            ShippingAddress shippingAddressRequest = new ShippingAddress
            {
                Street = "Rua test",
                StreetNumber = "123",
                Complement = "Ap test",
                District = "Bairro test",
                City = "TestCity",
                State = "SP",
                Country = "BRA",
                ZipCode = "01234000"
            };

            TaxDocument taxDocumentRequest = new TaxDocument
            {
                Type = "CPF",
                Number = "33333333333"
            };

            Phone phoneRequest = new Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "66778899"
            };

            HolderRequest holderRequest = new HolderRequest
            {
                Fullname = "Jose Goku da Silva",
                Birthdate = "1988-12-30",
                TaxDocument = taxDocumentRequest,
                Phone = phoneRequest
            };

            CreditCardRequest creditCardRequest = new CreditCardRequest
            {
                ExpirationMonth = "02",
                ExpirationYear = "20",
                Number = "5555666677778884",
                Cvc = "123",
                Holder = holderRequest
            };

            CustomerCreditCardRequest customerCreditCardRequest = new CustomerCreditCardRequest
            {
                Method = "CREDIT_CARD",
                CreditCard = creditCardRequest
            };

            return customerCreditCardRequest;
        }

        public static Moip.Models.AccountRequest CreateAccountPersonRequest()
        {

            Moip.Models.EmailRequest emailRequest = new Models.EmailRequest
            {
                Address = "testingarandomemail10@labs.moip.com.br"
            };

            Moip.Models.TaxDocument taxDocumentRequest = new Models.TaxDocument
            {
                Type = "CPF",
                Number = "736.141.550-48"
            };

            Moip.Models.IdentityDocumentRequest identityDocumentRequest = new Models.IdentityDocumentRequest
            {
                Type = "RG",
                Number = "434322344",
                Issuer = "SSP",
                IssueDate = "2000-12-12"
            };

            Moip.Models.Phone phoneRequest = new Models.Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "712341234"
            };

            Moip.Models.ShippingAddress shippingAddressRequest = new Models.ShippingAddress
            {
                Street = "Av. Brigadeiro Faria Lima",
                StreetNumber = "2927",
                District = "Itaim",
                ZipCode = "01234-000",
                City = "São Paulo",
                State = "SP",
                Country = "BRA"
            };

            Moip.Models.Person personRequest = new Models.Person
            {
                Name = "Runscope",
                LastName = "Goku",
                TaxDocument = taxDocumentRequest,
                IdentityDocument = identityDocumentRequest,
                BirthDate = "1990-01-01",
                Phone = phoneRequest,
                Address = shippingAddressRequest,
            };

            Moip.Models.AccountRequest accountRequest = new Moip.Models.AccountRequest
            {
                Email = emailRequest,
                Person = personRequest,
                Type = "MERCHANT"
            };

            return accountRequest;
        }

        public static Moip.Models.AccountRequest CreateAccountCompanyRequest()
        {
            Moip.Models.EmailRequest emailRequest = new Models.EmailRequest
            {
                Address = "dev.moip@labs.moip.com.br"
            };

            Moip.Models.TaxDocument personTaxDocumentRequest = new Models.TaxDocument
            {
                Type = "CPF",
                Number = "123.456.798-91"
            };

            Moip.Models.IdentityDocumentRequest identityDocumentRequest = new Models.IdentityDocumentRequest
            {
                Type = "RG",
                Number = "434322344",
                Issuer = "SSP",
                IssueDate = "2000-12-12"
            };

            Moip.Models.Phone personPhoneRequest = new Models.Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "712341234"
            };

            Moip.Models.ShippingAddress shippingAddressRequest = new Models.ShippingAddress
            {
                Street = "Av. Brigadeiro Faria Lima",
                StreetNumber = "2927",
                District = "Itaim",
                ZipCode = "01234-000",
                City = "São Paulo",
                State = "SP",
                Country = "BRA"
            };

            Moip.Models.Person personRequest = new Models.Person
            {
                Name = "Runscope",
                LastName = "Goku",
                TaxDocument = personTaxDocumentRequest,
                IdentityDocument = identityDocumentRequest,
                BirthDate = "1990-01-01",
                Phone = personPhoneRequest,
                Address = shippingAddressRequest,
            };

            Moip.Models.TaxDocument companyTaxDocumentRequest = new Models.TaxDocument
            {
                Type = "CNPJ",
                Number = "11.698.147/0001-13"
            };

            Moip.Models.MainActivityRequest mainActivityRequest = new Models.MainActivityRequest
            {
                Cnae = "82.91-1/00",
                Description = "Atividades de cobranças e informações cadastrais"
            };

            Moip.Models.Phone companyPhoneRequest = new Models.Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "32234455"
            };

            Moip.Models.ShippingAddress companyAddressRequest = new Models.ShippingAddress
            {
                Street = "Av. Brigadeiro Faria Lima",
                StreetNumber = "2927",
                District = "Itaim",
                ZipCode = "01234-000",
                City = "São Paulo",
                State = "SP",
                Country = "BRA"
            };

            Moip.Models.CompanyRequest companyRequest = new Models.CompanyRequest
            {
                Name = "Empresa Moip",
                BusinessName = "Moip Pagamentos",
                OpeningDate = "2011-01-01",
                TaxDocument = companyTaxDocumentRequest,
                MainActivity = mainActivityRequest,
                Phone = companyPhoneRequest,
                Address = companyAddressRequest

            };

            Moip.Models.BusinessSegmentRequest businessSegmentRequest = new Moip.Models.BusinessSegmentRequest
            {
                Id = 3
            };

            Moip.Models.AccountRequest accountRequest = new Moip.Models.AccountRequest
            {
                Email = emailRequest,
                Person = personRequest,
                Company = companyRequest,
                BusinessSegment = businessSegmentRequest,
                Type = "MERCHANT"
            };

            return accountRequest;
        }

        public static Moip.Models.AccountRequest CreateAccountTransparentRequest()
        {

            Moip.Models.EmailRequest emailRequest = new Models.EmailRequest
            {
                Address = "testingarandomemail10@labs.moip.com.br"
            };

            Moip.Models.TaxDocument taxDocumentRequest = new Models.TaxDocument
            {
                Type = "CPF",
                Number = "736.141.550-48"
            };

            Moip.Models.IdentityDocumentRequest identityDocumentRequest = new Models.IdentityDocumentRequest
            {
                Type = "RG",
                Number = "434322344",
                Issuer = "SSP",
                IssueDate = "2000-12-12"
            };

            Moip.Models.Phone phoneRequest = new Models.Phone
            {
                CountryCode = "55",
                AreaCode = "11",
                Number = "712341234"
            };

            Moip.Models.ShippingAddress shippingAddressRequest = new Models.ShippingAddress
            {
                Street = "Av. Brigadeiro Faria Lima",
                StreetNumber = "2927",
                District = "Itaim",
                ZipCode = "01234-000",
                City = "São Paulo",
                State = "SP",
                Country = "BRA"
            };

            Moip.Models.Person personRequest = new Models.Person
            {
                Name = "Runscope",
                LastName = "Goku",
                TaxDocument = taxDocumentRequest,
                IdentityDocument = identityDocumentRequest,
                BirthDate = "1990-01-01",
                Phone = phoneRequest,
                Address = shippingAddressRequest,
            };

            Moip.Models.AccountRequest accountRequest = new Moip.Models.AccountRequest
            {
                Email = emailRequest,
                Person = personRequest,
                Type = "MERCHANT",
                TransparentAccount = true
            };

            return accountRequest;
        }
        public static ConnectRequest CreateConnectRequest()
        {
            ConnectRequest connectRequest = new ConnectRequest
            {
                ClientId = "APP-XT5FIAK2F8I7",
                ClientSecret = "e2bd3951b87e469eb0f2c2b781a753d5",
                Code = "8870af1372ada7a18fdff4fa4ca1a60f4d542272",
                RedirectUri = "https://www.google.com.br",
                GrantType = GrantType.AUTHORIZATION_CODE
            };

            return connectRequest;
        }

        public static ConnectRequest CreateConnectRefreshRequest()
        {
            ConnectRequest connectRequest = new ConnectRequest
            {
                RefreshToken = "80ca5fb244674117be068d2535ecbe2f_v2",
                GrantType = GrantType.REFRESH_TOKEN
            };

            return connectRequest;
        }

    }
}
