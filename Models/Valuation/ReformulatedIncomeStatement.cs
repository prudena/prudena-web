namespace Prudena.Web.Models.Valuation
{
    public class ReformulatedIncomeStatement
    {
        public int ID { get; set; }
        public decimal OperatingExpense { get; set; }
        public decimal OperatingIncome { get; set; }
        public decimal NetOperatingIncome { get; set; }
        public decimal FinancialIncome { get; set; }
        public decimal FinancialExpense { get; set; }
        public decimal NetFinancialExpense { get; set; }
        public decimal ComprehensiveIncome { get; set; }

        public ReformulatedIncomeStatement()
        {

            OperatingExpense = 0;
            OperatingIncome = 0;
            NetOperatingIncome = 0;
            FinancialIncome = 0;
            FinancialExpense = 0;
            NetFinancialExpense = 0;
            ComprehensiveIncome = 0;


        }
        
        
    }
}