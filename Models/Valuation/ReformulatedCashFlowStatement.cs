namespace Prudena.Web.Models.Valuation
{
    public class ReformulatedCashFlowStatement: BurnuliBaseModel
    {
        public int ID { get; set; }
        public decimal CashFromOperations { get; set; }
        public decimal CashInvestment { get; set; }
        public decimal FreeCashFlow { get; set; }
        public decimal CashToDebtholdersAndIssuers { get; set; }
        public decimal CashToShareholders{ get; set; }

        public ReformulatedCashFlowStatement()
        {
            CashFromOperations = 0;
            CashInvestment = 0;
            FreeCashFlow = 0;
            CashToDebtholdersAndIssuers = 0;
            CashToShareholders = 0;


        }
        
        
        
    }
}