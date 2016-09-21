using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public class MorningMonteRun : IBurnuliEntity
    {
        #region Properties
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        
        public DateTime DateCreated { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }

        public string TestSymbol { get; set; }
        public double TestSymbolLastPrice { get; set; }

        public DateTime LastTradeDate { get; set; }
        //
        // Summary:
        //     The price value of the QuoteBaseData
        [Display(Name = "Last Price")]
        public double LastTradePriceOnly { get; set; }
        //
        // Summary:
        //     The time value of the data
        public DateTime LastTradeTime { get; set; }

        public int UserCount { get; set; }
        public int PortfoliosUpdated { get; set; }
        public int TickersAdded { get; set; }
        public int HoldingsAdded { get; set; }
        public int HoldingsUpdated { get; set; }
        public int PortfolioQuotesCreated { get; set; }
        public int MorningMonteID { get; set; }


        #endregion
     

    }
}