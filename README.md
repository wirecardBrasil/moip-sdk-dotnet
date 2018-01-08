<img src="https://gist.githubusercontent.com/joaolucasl/00f53024cecf16410d5c3212aae92c17/raw/1789a2131ee389aeb44e3a9d5333f59cfeebc089/moip-icon.png" align="right" />

# Moip v2 .NET SDK
> O jeito mais simples e rápido de integrar o Moip a sua aplicação .NET

**Índice**
- [Instalação](#instalação)
- [Configurando a autenticação](#configurando-a-autenticação)
  - [Por OAuth](#autenticando)
- [Configurando o ambiente](#configurando-o-ambiente)
- [Exemplos de Uso](#clientes):
  - [Pedidos](#pedidos)
    - [Criação](#criação)
    - [Consulta](#consulta)
      - [Pedido Específico](#pedido-específico)
      - [Todos os Pedidos](#todos-os-pedidos)
        - [Sem Filtro](#sem-filtro)
        - [Com Filtros](#com-filtros)
        - [Com Paginação](#com-paginação)
        - [Consulta Valor Específico](#consulta-valor-específico)
  - [Pagamentos](#pagamentos)
    - [Criação](#criação-1)
      - [Cartão de Crédito](#cartão-de-crédito)
      - [Boleto](#boleto)
    - [Consulta](#consulta-1)
    - [Capturar pagamento pré-autorizado](#capturar-pagamento-pré-autorizado)
    - [Cancelar pagamento pré-autorizado](#cancelar-pagamento-pré-autorizado)
  - [Clientes](#clientes)
    - [Criação](#criação-2)
    - [Consulta](#consulta-2)
    - [Adicionar cartão de crédito](#adicionar-cartão-de-crédito)
  - [Preferências de Notificação](#preferências-de-notificação)
    -  [Criação](#criação-3)
    -  [Consulta](#consulta-3)
    -  [Exclusão](#exclusão)
    -  [Listagem](#listagem)
  - [Reembolsos](#reembolsos)
    - [Pedido](#pedido)
    - [Pagamento](#pagamento)
    - [Consulta](#consulta-4)
  - [Multipedidos](#multipedidos)
    - [Criação](#criação-4)
    - [Consulta](#consulta-5)
  - [Multipagamentos](#multipagamentos)
    - [Criação](#criação-5)
      - [Cartão de Crédito](#cartão-de-crédito-1)
      - [Boleto Bancário](#boleto-bancário)
    - [Consulta](#consulta-6)
    - [Capturar multipagamento pré-autorizado](#capturar-multipagamento-pré-autorizado)
    - [Cancelar multipagamento pré-autorizado](#cancelar-multipagamento-pré-autorizado)
  - [Conta Moip](#conta-moip)
    - [Criação](#criação-6)
    - [Consulta](#consulta-7)
    - [Verifica se usuário já possui Conta Moip](#verifica-se-usuário-já-possui-conta-moip)
  - [Contas Bancárias](#contas-bancárias)
    - [Criação](#criação-7)
    - [Consulta](#consulta-8)
    - [Exclusão](#exclusão-1)
    - [Atualização](#atualização)
    - [Listagem](#listagem-1)
  - [Transferência](#transferência)
    - [Criação](#criação-8)
      -[Conta Bancária](#conta-bancária)
      -[Conta Moip](#conta-moip-1)
    - [Consulta](#consulta-9)
    - [Listagem](#listagem-2)
    - [Reversão](#reversão)
  - [Custódia](#custódia)
    - [Pagamento com custódia](#pagamento-com-custódia)
    - [Liberação de custódia](#liberação-de-custódia)
  - [OAuth (Moip Connect)](#oauth-(moip-connect))
    - [Solicitar permissões de acesso ao usuário](#solicitar-permissões-de-acesso-ao-usuário)
    - [Gerar Token OAuth](#gerar-token-oauth)
    - [Atualizar Token OAuth](#atualizar-token-oauth)
- [Tratamento de Exceções](#tratamento-de-exceções)
- [Documentação](#documentação)
- [Licença](#licença)

## Instalação

Execute o comando para instalar via NuGet:

```xml
dotnet add package Moip --version 1.0.1
```

Package:

https://www.nuget.org/packages/Moip/

## Configurando a autenticação

### Autenticando
```C#
Client client = new Client("TOKEN_OAUTH");
```

## Configurando o ambiente
Após definir o tipo de autenticação, é necessário gerar o client, informando em qual environment você quer executar suas ações:
```C#
Client client = new Client("d6bc80acbce6409b8b4cad5ceee62bc0_v2", Configuration.Environments.SANDBOX);
```

## Pedidos
### Criação
```C#

Moip.Models.TaxDocument taxDocument = new Moip.Models.TaxDocument
{
    Type = "CPF",
    Number = "22222222222"
};

Moip.Models.Phone phone = new Moip.Models.Phone
{
    CountryCode = "55",
    AreaCode = "11",
    Number = "66778899"
};

Moip.Models.ShippingAddress shippingAddress = new Moip.Models.ShippingAddress
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

Moip.Models.CustomerRequest customerRequest = new Moip.Models.CustomerRequest
{
    Fullname = "Fulano de Tal",
    OwnId = "OFulanoDeTal",
    BirthDate = "1990-01-01",
    Email = "fulano@detal.com.br",
    Phone = phone,
    ShippingAddress = shippingAddress,
    TaxDocument = taxDocument
};

Moip.Models.AmountOrderRequest amountRequest = new Moip.Models.AmountOrderRequest
{
    Currency = "BRL"
};

Moip.Models.Item itemsRequest = new Moip.Models.Item
{
    Product = "Bicicleta Specialized Tarmac 26 Shimano Alivio",
    Quantity = 1,
    Detail = "uma linda bicicleta",
    Price = 2000
};

List<Moip.Models.Item> itemsRequestList = new List<Moip.Models.Item>
{
    itemsRequest
};

Moip.Models.OrderRequest orderRequest = new Moip.Models.OrderRequest
{
    OwnId = "my_own_id",
    Amount = amountRequest,
    Items = itemsRequestList,
    Customer = customerRequest,
};

OrderResponse createdOrder = client.Orders.CreateOrder(orderRequest);

```

### Consulta
#### Pedido Específico
```C#
string orderId = "ORD-HPMZSOM611M2";
Order order = client.Orders.GetOrder(orderId);
```

#### Todos os Pedidos
##### Sem Filtro
```C#
Moip.Models.OrderListResponse orderResponseList = client.Orders.ListOrders();

List<Moip.Models.OrderResponse> orderList = orderResponseList.Orders;
```

##### Com Filtros
```C#
TODO
```

##### Com Paginação
```C#
TODO
```

##### Consulta Valor Específico
```C#
TODO
```

> Também é possível usar paginação, filtros e consulta de valor específico juntos

```C#
TODO
```

## Pagamentos

### Criação
#### Cartão de crédito
```C#
Moip.Models.TaxDocument taxDocumentRequest = new Moip.Models.TaxDocument
{
    Type = "CPF",
    Number = "33333333333"
};

Moip.Models.Phone phoneRequest = new Moip.Models.Phone
{
    CountryCode = "55",
    AreaCode = "11",
    Number = "66778899"
};

Moip.Models.HolderRequest holderRequest = new Moip.Models.HolderRequest
{
    Fullname = "Jose Goku da Silva",
    Birthdate = "1988-12-30",
    TaxDocument = taxDocumentRequest,
    Phone = phoneRequest
};

Moip.Models.CreditCardRequest creditCardRequest = new Moip.Models.CreditCardRequest
{
    ExpirationMonth = "02",
    ExpirationYear = "20",
    Number = "5555666677778884",
    Cvc = "123",
    Holder = holderRequest
};


Moip.Models.FundingInstrumentRequest fundingInstrumentRequest = new Moip.Models.FundingInstrumentRequest
{
    Method = "CREDIT_CARD",
    CreditCard = creditCardRequest
};


Moip.Models.PaymentRequest paymentRequest = new Moip.Models.PaymentRequest
{
    InstallmentCount = 1,
    StatementDescriptor = "MyStore",
    FundingInstrument = fundingInstrumentRequest
};

Payment payment = client.Payments.CreateCreditCard("ORD-HPMZSOM611M2", paymentRequest);
```

#### Boleto
```C#

Moip.Models.BoletoInstructionLines boletoInstructionLines = new Moip.Models.BoletoInstructionLines()
{
    First("Primeira linha"),
    Second("Segunda linha"),
    Third("Terceira linha")
};

Moip.Models.BoletoRequest boletoRequest = new Moip.Models.BoletoRequest()
{
    ExpirationDate = "2020-09-30",
    InstructionLines = boletoInstructionLines,
    LogoUri = "http://"
};


Moip.Models.FundingInstrumentRequest fundingInstrumentRequest = new Moip.Models.FundingInstrumentRequest
{
    Method = "BOLETO",
    Boleto = boletoRequest
};


Moip.Models.PaymentBoletoOrDebitRequest paymentRequest = new Moip.Models.PaymentBoletoOrDebitRequest
{
    FundingInstrument = fundingInstrumentRequest
};

  Payment payment = client.Payments.CreateBoletoOrDebit("ORD-GOHHIF4Z6PLV", paymentRequest);

```

> Para capturar os links do boleto:

```C#
// Link do Boleto
payment.Links.PayBoleto.RedirectHref;
TODO

// Link para impressão do boleto
payment.Links.PayBoleto.PrintHref;
```

### Consulta
```C#
PaymentResponse paymentResponse = client.Payments.GetPayment("PAY-FRAAY8GN1HSB");
```

### Capturar pagamento pré-autorizado
```C#
PaymentResponse capturedPayment = client.Payments.CapturePreAuthorized("PAY-FRAAY8GN1HSB");
```

### Cancelar pagamento pré-autorizado
```C#
PaymentResponse capturedPayment = client.Payments.CancelPreAuthorized("PAY-FRAAY8GN1HSB");
```

## Clientes
### Criação
```C#
Moip.Models.ShippingAddress shippingAddressRequest = new Moip.Models.ShippingAddress
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

Moip.Models.TaxDocument taxDocumentRequest = new Moip.Models.TaxDocument
{
    Type = "CPF",
    Number = "33333333333"
};

Moip.Models.Phone phoneRequest = new Moip.Models.Phone
{
    CountryCode = "55",
    AreaCode = "11",
    Number = "66778899"
};

Moip.Models.CustomerRequest customerRequest = new Moip.Models.CustomerRequest
{
    Fullname = "Fulano de Tal",
    OwnId = "OFulanoDeTal" + date,
    BirthDate = "1990-01-01",
    Email = "fulano@detal.com.br",
    Phone = phoneRequest,
    ShippingAddress = shippingAddressRequest,
    TaxDocument = taxDocumentRequest
};

CustomerResponse customerResponse = client.Customers.CreateCustomer(customerRequest);
```

### Consulta
```C#
string customerId = "CUS-Q3BL0CAJ2G33";
Moip.Models.CustomerResponse customerResponse = client.Customers.GetCustomer(customerId);
```

### Adicionar cartão de crédito
```C#
Moip.Models.ShippingAddress shippingAddressRequest = new Moip.Models.ShippingAddress
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


Moip.Models.TaxDocument taxDocumentRequest = new Moip.Models.TaxDocument
{
    Type = "CPF",
    Number = "33333333333"
};

Moip.Models.Phone phoneRequest = new Moip.Models.Phone
{
    CountryCode = "55",
    AreaCode = "11",
    Number = "66778899"
};

Moip.Models.HolderRequest holderRequest = new Moip.Models.HolderRequest
{
    Fullname = "Jose Goku da Silva",
    Birthdate = "1988-12-30",
    TaxDocument = taxDocumentRequest,
    Phone = phoneRequest
};

Moip.Models.CreditCardRequest creditCardRequest = new Moip.Models.CreditCardRequest
{
    ExpirationMonth = "02",
    ExpirationYear = "20",
    Number = "5555666677778884",
    Cvc = "123",
    Holder = holderRequest
};


Moip.Models.CustomerCreditCardRequest customerCreditCardRequest = new Moip.Models.CustomerCreditCardRequest
{
    Method = "CREDIT_CARD",
    CreditCard = creditCardRequest
};

Moip.Models.CustomerCreditCardResponse customerCreditCardResponse = client.Customers.CreateCreditCard(customerCreditCardRequest, "CUS-1RM8JPVKWEVR");

```

## Preferências de notificação

### Criação
```C#
List<string> eventsList = new List<string>();
eventsList.Add("ORDER.*");
eventsList.Add("PAYMENT.AUTHORIZED");
eventsList.Add("PAYMENT.CANCELLED");

Moip.Models.NotificationPreferenceRequest notificationPreferenceRequest = new Moip.Models.NotificationPreferenceRequest()
{
    Events = eventsList,
    Target = "http://requestb.in/1dhjesw1",
    Media = "WEBHOOK"
};

Moip.Models.NotificationPreferenceResponse notificationPreferenceResponse = client.Notifications.CreateNotificationPreference(notificationPreferenceRequest);
```

### Consulta
```C#
Moip.Models.NotificationPreferenceResponse notificationPreferenceResponse = client.Notifications.GetNotificationPreference("NPR-NR0GR85KHL10");

```

### Exclusão
```C#
client.Notifications.DeleteNotificationPreference("NPR-NR0GR85KHL10");

```

### Listagem
```C#
List<Moip.Models.NotificationPreferenceResponse> notificationPreferenceResponseList = client.Notifications.ListNotificationsPreferences();

```

### Reembolsos

> Para fazer reembolsos totais basta remover o atributo ```Amount```.

### Pedido
#### Cartão de Crédito
```C#
tandard.Models.Phone phoneRequest = new Moip.Models.Phone
{
    CountryCode = "55",
    AreaCode = "11",
    Number = "66778899"
};

Moip.Models.TaxDocument taxDocumentRequest = new Moip.Models.TaxDocument
{
    Type = "CPF",
    Number = "33333333333"
};

Moip.Models.HolderRequest holderRequest = new Moip.Models.HolderRequest
{
    Fullname = "Jose Goku da Silva",
    Birthdate = "1988-12-30",
    TaxDocument = taxDocumentRequest,
    Phone = phoneRequest,

};

Moip.Models.CreditCardRequest creditCardRequest = new Moip.Models.CreditCardRequest
{
    Number = "5555666677778884",
    ExpirationMonth = "02",
    ExpirationYear = "20",
    Cvc = "123",
    Holder = holderRequest
};

Moip.Models.RefundingInstrumentCCRequest refundingInstrumentRequest = new Moip.Models.RefundingInstrumentCCRequest
{
    Method = "CREDIT_CARD",
    CreditCard = creditCardRequest
};

Moip.Models.RefundCCRequest refundRequest = new Moip.Models.RefundCCRequest
{
    RefundingInstrument = refundingInstrumentRequest,
    Amount = 2000
};   

Moip.Models.RefundCCResponse refundResponse = client.Refunds.CreateOrder("ORD-89SOQ6FMPJPX", refundRequest);

```

#### Conta Bancária
```C#
Moip.Models.TaxDocument taxDocumentRequest = new Moip.Models.TaxDocument
{
    Type = "CPF",
    Number = "22222222222"
};

Moip.Models.HolderRequest holderRequest = new Moip.Models.HolderRequest
{
    Fullname = "Fulano de Tal",
    Birthdate = "1990-01-01",
    TaxDocument = taxDocumentRequest,

};

Moip.Models.BankAccountRefundingInstrumentRequest bankAccountRefundRequest = new Moip.Models.BankAccountRefundingInstrumentRequest
{
    BankNumber = "341",
    AgencyNumber = "4444444",
    AgencyCheckNumber = "2",
    AccountNumber = "1234",
    AccountCheckNumber = "1",
    Type = "CHECKING",
    Holder = holderRequest
};

Moip.Models.RefundingInstrumentBankAccountRequest refundingInstrumentRequest = new Moip.Models.RefundingInstrumentBankAccountRequest
{
    Method = "BANK_ACCOUNT",
    BankAccount = bankAccountRefundRequest
};

Moip.Models.RefundBankAccountRequest refundRequest = new Moip.Models.RefundBankAccountRequest
{
    RefundingInstrument = refundingInstrumentRequest,
    Amount = 2000
};

Moip.Models.RefundBankAccountResponse refundResponse = client.Refunds.CreateOrderBankAccount("ORD-GS1FSQ3SO9SY", refundRequest);
```

### Pagamento
#### Cartão de Crédito

```C#
Moip.Models.Phone phoneRequest = new Moip.Models.Phone
{
    CountryCode = "55",
    AreaCode = "11",
    Number = "66778899"
};

Moip.Models.TaxDocument taxDocumentRequest = new Moip.Models.TaxDocument
{
    Type = "CPF",
    Number = "33333333333"
};

Moip.Models.HolderRequest holderRequest = new Moip.Models.HolderRequest
{
    Fullname = "Jose Goku da Silva",
    Birthdate = "1988-12-30",
    TaxDocument = taxDocumentRequest,
    Phone = phoneRequest,

};

Moip.Models.CreditCardRequest creditCardRequest = new Moip.Models.CreditCardRequest
{
    Number = "5555666677778884",
    ExpirationMonth = "02",
    ExpirationYear = "20",
    Cvc = "123",
    Holder = holderRequest
};

Moip.Models.RefundingInstrumentCCRequest refundingInstrumentRequest = new Moip.Models.RefundingInstrumentCCRequest
{
    Method = "CREDIT_CARD",
    CreditCard = creditCardRequest
};

Moip.Models.RefundCCRequest refundRequest = new Moip.Models.RefundCCRequest
{
    RefundingInstrument = refundingInstrumentRequest,
    Amount = 100
};
Moip.Models.RefundCCResponse refundResponse = client.Refunds.CreatePayment("PAY-70380H9B6L5R", refundRequest);

```

#### Conta Bancária
```C#
Moip.Models.TaxDocument taxDocumentRequest = new Moip.Models.TaxDocument
{
    Type = "CPF",
    Number = "22222222222"
};

Moip.Models.HolderRequest holderRequest = new Moip.Models.HolderRequest
{
    Fullname = "Fulano de Tal",
    Birthdate = "1990-01-01",
    TaxDocument = taxDocumentRequest,

};

Moip.Models.BankAccountRefundingInstrumentRequest bankAccountRefundRequest = new Moip.Models.BankAccountRefundingInstrumentRequest
{
    BankNumber = "341",
    AgencyNumber = "4444444",
    AgencyCheckNumber = "2",
    AccountNumber = "1234",
    AccountCheckNumber = "1",
    Type = "CHECKING",
    Holder = holderRequest
};

Moip.Models.RefundingInstrumentBankAccountRequest refundingInstrumentRequest = new Moip.Models.RefundingInstrumentBankAccountRequest
{
    Method = "BANK_ACCOUNT",
    BankAccount = bankAccountRefundRequest
};

Moip.Models.RefundBankAccountRequest refundRequest = new Moip.Models.RefundBankAccountRequest
{
    RefundingInstrument = refundingInstrumentRequest,
    Amount = 2000
};

Moip.Models.RefundBankAccountResponse refundResponse = client.Refunds.CreatePaymentBankAccount("PAY-E4Q0N9TK0BFW", refundRequest);
```

### Consulta
```C#
Moip.Models.RefundCCResponse refundResponse = client.Refunds.GetCCRefund("REF-JR4WALM894UJ");

```

## Multipedidos

### Criação
```C#
TODO
```

### Consulta
```C#
TODO
```

## Multipagamentos

### Criação
#### Cartão de Crédito
```C#
TODO
```

#### Boleto Bancário
```C#
TODO
```

> Para capturar os links do boleto:

```C#
// Link do Boleto
TODO

// Link para impressão do boleto
TODO
```

### Consulta
```C#
TODO
```

### Capturar multipagamento pré-autorizado
```C#
TODO
```

### Cancelar multipagamento pré-autorizado
```C#
TODO
```

## Conta Moip
### Criação
```C#
TODO
```

### Consulta
```C#
TODO
```

### Verifica se usuário já possui Conta Moip
```C#
TODO
```

## Contas Bancárias
### Criação
```C#
TODO
```
### Consulta
```C#
TODO
```
### Exclusão
```C#
TODO
```
### Atualização
```C#
TODO
```

### Listagem
```C#
List<BankAccount> createdBankAccounts = api.bankAccount().getList("MPA-E0BAC6D15696");
```

## Transferência
### Criação
#### Conta Bancária
```C#
TODO
```


#### Conta Moip
```C#
TODO
```

### Consulta
```C#
TODO
```

### Listagem
```C#
TODO
```

### Reversão
```C#
TODO
```

## Custódia
### Pagamento com custódia
```C#
Moip.Models.TaxDocument taxDocumentRequest = new Moip.Models.TaxDocument
{
    Type = "CPF",
    Number = "33333333333"
};

Moip.Models.Phone phoneRequest = new Moip.Models.Phone
{
    CountryCode = "55",
    AreaCode = "11",
    Number = "66778899"
};

Moip.Models.HolderRequest holderRequest = new Moip.Models.HolderRequest
{
    Fullname = "Jose Goku da Silva",
    Birthdate = "1988-12-30",
    TaxDocument = taxDocumentRequest,
    Phone = phoneRequest
};

Moip.Models.CreditCardRequest creditCardRequest = new Moip.Models.CreditCardRequest
{
    ExpirationMonth = "02",
    ExpirationYear = "20",
    Number = "5555666677778884",
    Cvc = "123",
    Holder = holderRequest
};

Moip.Models.FundingInstrumentRequest fundingInstrumentRequest = new Moip.Models.FundingInstrumentRequest
{
    Method = "CREDIT_CARD",
    CreditCard = creditCardRequest
};

Moip.Models.Escrow escrow = new Moip.Models.Escrow
{
    Description = "Escrow test"
};

Moip.Models.PaymentRequest paymentRequest = new Moip.Models.PaymentRequest
{
    InstallmentCount = 1,
    StatementDescriptor = "MyStore",
    FundingInstrument = fundingInstrumentRequest,
    Escrow = escrow
};

Moip.Models.PaymentResponse paymentResponse = client.Payments.CreateCreditCard("ORD-3435DIB58HYN", paymentRequest);

```

### Liberação de custódia
```C#
TODO
```

## OAuth (Moip Connect)
### Solicitar permissões de acesso ao usuário
```C#
TODO
```

### Gerar token OAuth
```C#
TODO
```

### Atualizar token OAuth
```C#
TODO
```

## Tratamento de Exceções

Quando ocorre algum erro na API, é lançada a exceção UnexpectedException para erros inesperados e ValidationException
para erros de validação.

```C#
TODO
```

## Documentação

[Documentação oficial](https://moip.com.br/referencia-api/)

## Licença

[The MIT License](https://github.com/moip/moip-sdk-dotnet/blob/master/LICENSE)
