using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prudena.Web.Models.Valuation.ResidualEarnings
{
    public class Model301
    {
        public const int MAX_LONG_TERM_YEARS = 300;
        public const int DEFAULT_YEARS_IN_SHORT_TERM = 3;
        public const int DEFAULT_YEARS_IN_MIDDLE_TERM = 0;
        public const double DEFAULT_LONG_TERM_EARNING_GROWTH_RATE = .04;

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public bool IsPublished { get; set; }

        public bool ShareWithStockTwits { get; set; }

        public string StockTwitsText { get; set; }
        public DateTime? PublishDate { get; set; }

        public bool IsFlagged { get; set; }
        public string Notes { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime DateModified { get; set; }
        public Ticker Ticker { get; set; }

        //[Index("IX_Model201_TickerSymbol", 1, IsUnique = false)]
        [StringLength(100)]
        public string TickerSymbol { get; set; }
        public double LastPrice { get; set; }
        public double CostOfCapital { get; set; }
        
        public bool IncludesUncertainty { get; set; }
        
        public DateTime DateCreated { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }

        public SystemUser Owner { get; set; }


        public int HistoricalYears { get; set; }

        public int BaseFiscalYear { get; set; }
        public int YearsToForecast { get; set; }
        public int SubmittedHistoricalYears { get; set; }
        public double SalesGrowthRate { get; set; }
        public double LongTermSalesGrowthRate { get; set; }
        public double NopatDividedBySales { get; set; }
        public double BeginningNetOperatingWorkingCapitalDividedBySales { get; set; }
        public double BeginningNetOperatingLongTermCapitalDividedBySales { get; set; }
        public double TaxRate { get; set; }
        public double RiskFreeRate { get; set; }
        public double MarketRiskPremium { get; set; }
        public double CostOfDebt { get; set; }
        public double CostOfCommonEquity { get; set; }
        public double CommonEquityBeta { get; set; }
        public double NetDebtDividedByEndingBookValueOfNetCapital { get; set; }
        public double CostOfPreferredEquityBeforeTax { get; set; }
        public double PreferredEquityDividedByBookValueOfNetCapital { get; set; }
        public int MaxYearsToForecast { get; set; }

        public double NumberOfSharesOutstanding { get; set; }

        public double BeginningBookValueOfEquity { get; set; }

        [NotMapped]
        public List<Model301ProFormaStatement> ProFormaStatements { get; set; }

        [NotMapped]
        public List<Model301ProFormaStatement> ProFormaStatementsOptimistic { get; set; }

        [NotMapped]
        public List<Model301ProFormaStatement> ProFormaStatementsPessimistic { get; set; }


    }
}