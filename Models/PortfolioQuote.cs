using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public class PortfolioQuote
    {

        public void LoadPortfolioQuote(PortfolioSummary summary, Portfolio portfolio)
        {
            this.TotalValue = summary.TotalValue;
            this.Shares = summary.Shares;
            this.CashHoldings = summary.CashHoldings;
            this.Portfolio = portfolio;
            decimal totalLast = 0;
            decimal totalOpen = 0;
            decimal totalHigh = 0;
            decimal totalLow = 0;
            this.Name = portfolio.Name + " " + DateTime.UtcNow;
            string holdingsString = string.Empty;

            if (summary.PortfolioHoldings == null)
                summary.PortfolioHoldings = new List<PortfolioHoldingSummary>();

            foreach (PortfolioHoldingSummary holding in summary.PortfolioHoldings.Where(h => h.TotalShares > 0))
            {
                totalLast += holding.LastPrice * (decimal)holding.TotalShares;
                totalOpen += holding.OpenPrice * (decimal)holding.TotalShares;
                totalHigh += holding.DaysHigh * (decimal)holding.TotalShares;
                totalLow += holding.DaysLow * (decimal)holding.TotalShares;

                holdingsString += holding.Symbol + ":" + holding.TotalShares + ";";
                this.LastTradeDate = holding.LastTradeDate; // holding.LastTradeDate;
                this.LastTradeTime = holding.LastTradeDate; // holding.LastTradeTime;
                this.TradeDate = holding.LastTradeDate;    
            
            }

            Holdings = holdingsString;

            if (Shares == 0)
            {
                this.LastTradePriceOnly = 0;
                
            }
            else
            {
                this.LastTradePriceOnly = totalLast / Shares;
                this.Close = totalLast / Shares;
                this.DaysHigh = totalHigh / (decimal)Shares;
                this.DaysLow = totalLow / Shares;
                this.Open = totalOpen / Shares;
            }
               
        }
        
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Portfolio Portfolio { get; set; }

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