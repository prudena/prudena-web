using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Prudena.Web.Models.Market
{
    public class MarketStripeCharge
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]

        public string Name { get; set; }

        public SystemUser Purchaser { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("amount_refunded")]
        public int AmountRefunded { get; set; }

        public string BalanceTransactionId { get; set; }

        [JsonProperty("captured")]
        public bool? Captured { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
        public string CustomerId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        public string FailureCode { get; set; }
        [JsonProperty("failure_message")]
        public string FailureMessage { get; set; }
        public string InvoiceId { get; set; }
        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        [JsonProperty("paid")]
        public bool Paid { get; set; }
        [JsonProperty("receipt_email")]
        public string ReceiptEmail { get; set; }
        [JsonProperty("receipt_number")]
        public string ReceiptNumber { get; set; }
        [JsonProperty("refunded")]
        public bool Refunded { get; set; }

        [JsonProperty("statement_descriptor")]
        public string StatementDescriptor { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        
    }
}