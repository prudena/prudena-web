using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public class DashboardQuote
    {
        
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Dashboard Dashboard { get; set; }

        public string Symbol { get; set; }

        // Summary:
        //     The change of the price in relation to close value of the previous day
        public decimal Change { get; set; }
        //
        // Summary:
        //     The calculated price change in percent
        //
        // Remarks:
        //     [Change] / [PreviewClose]
        public decimal ChangeInPercent { get; set; }
        //
        // Summary:
        //     The highest value of the day
        public decimal DaysHigh { get; set; }
        //
        // Summary:
        //     The lowest value of the day
        public decimal DaysLow { get; set; }
        //
        // Summary:
        //     The ID of the QuoteBaseData

        public DateTime LastTradeDate { get; set; }
        //
        // Summary:
        //     The price value of the QuoteBaseData
        [Display(Name = "Last Price")]
        public decimal LastTradePriceOnly { get; set; }
        //
        // Summary:
        //     The time value of the data
        public DateTime LastTradeTime { get; set; }
        //
        // Summary:
        //     The opening value of the day
        public decimal Open { get; set; }

        public decimal Close { get; set; }

        public DateTime TradeDate{ get; set; }
        
        //
        // Summary:
        //     The calculated close price of the last trading day
        //
        // Remarks:
        //     [LastTradePriceOnly] - [Change]
        public decimal PreviewClose { get; set; }
        //
        // Summary:
        //     The trade volume of the day


        [Required]
        public decimal Shares{ get; set; }


        [Required]
        public decimal CashHoldings { get; set; }

        public string Holdings { get; set; }

        [Required]
        public decimal TotalValue { get; set; }
        
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }

    }
}