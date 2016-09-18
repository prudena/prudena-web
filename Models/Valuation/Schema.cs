using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Prudena.Web.Models.Valuation
{
    public enum ValuationOpinion
    {
        [DescriptionAttribute("Overweight Short")]
        [Display(Name = "Overweight Short")]
        OverweightShort = 0,

        [Display(Name = "Short")]
        Short = 1,

        [DescriptionAttribute("No Opinion")]
        [Display(Name = "No Opinion")]
        NoOpinion = 2,

        [Display(Name = "Long")]
        Long = 3,

        [DescriptionAttribute("Overweight Long")]
        [Display(Name = "Overweight Long")]
        OverweightLong = 4,


    }

    public class Schema : BurnuliBaseModel
    {
        public int ID { get; set; }
        public Ticker Ticker { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public ReformulatedBalanceSheet BalanceSheetLastPeriod { get; set; }
        public ReformulatedBalanceSheet BalanceSheetCurrentPeriod { get; set; }
        public ReformulatedIncomeStatement IncomeStatement { get; set; }
        public ReformulatedEquityStatement EquityStatement { get; set; }
        public ReformulatedCashFlowStatement CashFlowStatement { get; set; }

        public Schema()
        {
            BalanceSheetLastPeriod = new ReformulatedBalanceSheet();
            BalanceSheetCurrentPeriod = new ReformulatedBalanceSheet();
            IncomeStatement = new ReformulatedIncomeStatement();
            EquityStatement = new ReformulatedEquityStatement();
            CashFlowStatement = new ReformulatedCashFlowStatement();


        }
        //checks
        public bool OperatingAssetsCheck
        {
            get
            {
                if (BalanceSheetLastPeriod.NetOperatingAssets + IncomeStatement.ComprehensiveIncome
                    - (CashFlowStatement.CashFromOperations - CashFlowStatement.CashInvestment)
                    == BalanceSheetCurrentPeriod.NetOperatingAssets)
                    return true;
                else
                    return false;
            }
        }
        public bool NetFinancialObligationsCheck
        {
            get
            {
                if (BalanceSheetLastPeriod.NetFinancialObligations * -1 - IncomeStatement.NetFinancialExpense
                    - (CashFlowStatement.CashFromOperations - CashFlowStatement.CashInvestment)
                    + CashFlowStatement.CashToShareholders
                    == BalanceSheetCurrentPeriod.NetFinancialObligations * -1)
                    return true;
                else
                    return false;
            }
        }
        public bool CommonShareholderEquityCheck
        {
            get
            {
                if (BalanceSheetLastPeriod.CommonShareholderEquity + IncomeStatement.ComprehensiveIncome
                    - CashFlowStatement.CashToShareholders
                    == BalanceSheetCurrentPeriod.CommonShareholderEquity)
                    return true;
                else
                    return false;
            }
        }

        public bool CashFlowStatementCheck
        {
            get
            {
                if (CashFlowStatement.CashFromOperations - CashFlowStatement.CashInvestment
                    == CashFlowStatement.CashToShareholders +CashFlowStatement.CashToDebtholdersAndIssuers)
                    return true;
                else
                    return false;
            }
        }
    }
}