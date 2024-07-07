using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorAsaas.Dominio.AsaasCobrancas
{
    public class Cobranca
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("dateCreated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DateCreated { get; set; }

        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
        public string Customer { get; set; }

        [JsonProperty("paymentLink", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentLink { get; set; }

        [JsonProperty("dueDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DueDate { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Value { get; set; }

        [JsonProperty("netValue", NullValueHandling = NullValueHandling.Ignore)]
        public decimal NetValue { get; set; }

        [JsonProperty("billingType", NullValueHandling = NullValueHandling.Ignore)]
        public string BillingType { get; set; }

        [JsonProperty("canBePaidAfterDueDate", NullValueHandling = NullValueHandling.Ignore)]
        public bool CanBePaidAfterDueDate { get; set; }

        [JsonProperty("pixTransaction", NullValueHandling = NullValueHandling.Ignore)]
        public object PixTransaction { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("daysAfterDueDateToRegistrationCancellation", NullValueHandling = NullValueHandling.Ignore)]
        public int? DaysAfterDueDateToRegistrationCancellation { get; set; }

        [JsonProperty("externalReference", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalReference { get; set; }

        [JsonProperty("originalValue", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? OriginalValue { get; set; }

        [JsonProperty("interestValue", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? InterestValue { get; set; }

        [JsonProperty("originalDueDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime OriginalDueDate { get; set; }

        [JsonProperty("paymentDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PaymentDate { get; set; }

        [JsonProperty("clientPaymentDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ClientPaymentDate { get; set; }

        [JsonProperty("installmentCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? InstallmentCount { get; set; }

        [JsonProperty("totalValue", NullValueHandling = NullValueHandling.Ignore)]
        public float? TotalValue { get; set; }

        [JsonProperty("installmentNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int? InstallmentNumber { get; set; }

        [JsonProperty("installmentValue", NullValueHandling = NullValueHandling.Ignore)]
        public int? InstallmentValue { get; set; }

        [JsonProperty("transactionReceiptUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionReceiptUrl { get; set; }

        [JsonProperty("nossoNumero", NullValueHandling = NullValueHandling.Ignore)]
        public string NossoNumero { get; set; }

        [JsonProperty("invoiceUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string InvoiceUrl { get; set; }

        [JsonProperty("bankSlipUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string BankSlipUrl { get; set; }

        [JsonProperty("invoiceNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string InvoiceNumber { get; set; }

        [JsonProperty("discount", NullValueHandling = NullValueHandling.Ignore)]
        public Discount Discount { get; set; }

        [JsonProperty("fine", NullValueHandling = NullValueHandling.Ignore)]
        public Fine Fine { get; set; }

        [JsonProperty("interest", NullValueHandling = NullValueHandling.Ignore)]
        public Interest Interest { get; set; }

        [JsonProperty("split", NullValueHandling = NullValueHandling.Ignore)]
        public Split Split { get; set; }

        [JsonProperty("callback", NullValueHandling = NullValueHandling.Ignore)]
        public Callback Callback { get; set; }

        [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool Deleted { get; set; }

        [JsonProperty("postalService", NullValueHandling = NullValueHandling.Ignore)]
        public bool PostalService { get; set; }

        [JsonProperty("anticipated", NullValueHandling = NullValueHandling.Ignore)]
        public bool Anticipated { get; set; }

        [JsonProperty("anticipable", NullValueHandling = NullValueHandling.Ignore)]
        public bool Anticipable { get; set; }

        [JsonProperty("refunds", NullValueHandling = NullValueHandling.Ignore)]
        public object Refunds { get; set; }

        // Propriedades auxiliares para evitar valores nulos

        [JsonIgnore]
        public bool PaymentDateSpecified => PaymentDate.HasValue;

        [JsonIgnore]
        public bool ClientPaymentDateSpecified => ClientPaymentDate.HasValue;

        [JsonIgnore]
        public bool OriginalValueSpecified => OriginalValue.HasValue;

        [JsonIgnore]
        public bool InterestValueSpecified => InterestValue.HasValue;

        [JsonIgnore]
        public bool InstallmentNumberSpecified => InstallmentNumber.HasValue;

        [JsonIgnore]
        public bool PixTransactionSpecified => PixTransaction != null;

        [JsonIgnore]
        public bool RefundsSpecified => Refunds != null;

        [JsonIgnore]
        public bool DaysAfterDueDateToRegistrationCancellationSpecified => DaysAfterDueDateToRegistrationCancellation.HasValue;

        [JsonIgnore]
        public bool InstallmentCountSpecified => InstallmentCount.HasValue;

        [JsonIgnore]
        public bool TotalValueSpecified => TotalValue.HasValue;

        [JsonIgnore]
        public bool InstallmentValueSpecified => InstallmentValue.HasValue;

    }

    public class Discount
    {
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Value { get; set; }

        [JsonProperty("dueDateLimitDays", NullValueHandling = NullValueHandling.Ignore)]
        public int DueDateLimitDays { get; set; }
    }

    public class Fine
    {
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Value { get; set; }
    }

    public class Interest
    {
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Value { get; set; }
    }

    public class Split
    {
        [JsonProperty("walletId", NullValueHandling = NullValueHandling.Ignore)]
        public string WalletId { get; set; }

        [JsonProperty("fixedValue", NullValueHandling = NullValueHandling.Ignore)]
        public float FixedValue { get; set; }

        [JsonProperty("percentualValue", NullValueHandling = NullValueHandling.Ignore)]
        public float PercentualValue { get; set; }

        [JsonProperty("totalFixedValue", NullValueHandling = NullValueHandling.Ignore)]
        public float TotalFixedValue { get; set; }
    }

    public class Callback
    {
        [JsonProperty("successUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string SuccessUrl { get; set; }

        [JsonProperty("autoRedirect", NullValueHandling = NullValueHandling.Ignore)]
        public bool AutoRedirect { get; set; }

    }

}
