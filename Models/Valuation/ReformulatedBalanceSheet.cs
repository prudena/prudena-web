namespace Prudena.Web.Models.Valuation
{
    public class ReformulatedBalanceSheet : BurnuliBaseModel
    {
        public int ID { get; set; }
        public Ticker Ticker { get; set; }
        public decimal OperatingAssets { get; set; }
        public decimal OperatingLiabilities { get; set; }
        public decimal NetOperatingAssets { get; set; }
        public decimal FinancialAssets { get; set; }
        public decimal FinancialObligations { get; set; }
        public decimal NetFinancialObligations { get; set; }
        public decimal CommonShareholderEquity { get; set; }

        public ReformulatedBalanceSheet()
        {
            OperatingAssets = 0;
            OperatingLiabilities = 0;
            NetOperatingAssets = 0;
            FinancialAssets = 0;
            FinancialObligations = 0;
            NetFinancialObligations = 0;
            CommonShareholderEquity = 0;



        }
    }
}