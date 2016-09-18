using System;
namespace Prudena.Web.Models.Valuation
{
    public class TickerAnnualHistoricalRatioSet : BurnuliBaseModel
    {
        public int ID { get; set; }
        public Ticker Ticker { get; set; }
        public string TickerSymbol { get; set; }
        public string IndustryName { get; set; }
        public string SicCode { get; set; }
        public string ExchangeCode { get; set; }
        public DateTime ReportingDate { get; set; }
        public int ReportingYear { get; set; }
        public int CashBin { get; set; }
        public int TaxBin { get; set; } 
        public int DepreciationBin { get; set; }
        public int SgqBin { get; set; }
        public int DividendBin { get; set; }
        public int DebtBin { get; set; }
        public int RoaBin { get; set; }
        public int RoeBin { get; set; }
        public int DividendYieldBin { get; set; }
        public int BookValueOfAssetsBin { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool SentToAgent { get; set; }
        public bool NeedToSendToAgent { get; set; }
    }
}