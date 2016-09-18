using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Prudena.Web.Models.Valuation
{
    public enum FinancialStatementTagCategory
    {
        [DescriptionAttribute("Not Set")]
        [Display(Name = "Not Set")]
        PfacNotSet = 0,

        [DescriptionAttribute("Current Asset")]
        [Display(Name = "Current Asset")]
        PfacCurrentAsset = 1,

        [DescriptionAttribute("Total Current Assets")]
        [Display(Name = "Total Current Assets")]
        PfacTotalCurrentAssets = 3,

        [DescriptionAttribute("Non-Current Asset")]
        [Display(Name = "Non-Current Asset")]
        PfacNonCurrentAsset = 4,

        [DescriptionAttribute("Total Assets")]
        [Display(Name = "Total Assets")]
        PfacTotalAssets = 5,

        [DescriptionAttribute("Current Liability")]
        [Display(Name = "Current Liability")]
        PfacCurrentLiability = 6,

        [DescriptionAttribute("Total Current Liabilities")]
        [Display(Name = "Total Current Liabilities")]
        PfacTotalCurrentLiabilities = 7,

        [DescriptionAttribute("Non-Current Liability")]
        [Display(Name = "Non-Current Liability")]
        PfacNonCurrentLiability = 8,

        [DescriptionAttribute("Total Liabilities")]
        [Display(Name = "Total Liabilities")]
        PfacTotalLiabilities = 9,

        [DescriptionAttribute("Equity Item")]
        [Display(Name = "Equity Item")]
        PfacEquityItem = 10,

        [DescriptionAttribute("Total Equity")]
        [Display(Name = "Total Equity")]
        PfacTotalEquity = 11,

        [DescriptionAttribute("Liabilities and Equity")]
        [Display(Name = "Liabilities and Equity")]
        PfacTotalLiabilitiesAndEquity = 12,

        [DescriptionAttribute("Total Revenue")]
        [Display(Name = "Total Revenue")]
        PfacTotalRevenue = 13,

        [DescriptionAttribute("Cost of Revenue")]
        [Display(Name = "Cost of Revenue")]
        PfacCostOfRevenue = 14,

        [DescriptionAttribute("Gross Profit")]
        [Display(Name = "Gross Profit")]
        PfacGrossProfit = 15,

        [DescriptionAttribute("Costs and expenses")]
        [Display(Name = "Costs and Expenses")]
        PfacCostsAndExpenses = 16,

        [DescriptionAttribute("Reported Operating Income")]
        [Display(Name = "Reported Operating Income")]
        PfacReportedOperatingIncome = 17,

        [DescriptionAttribute("Reported Non-Operating Income")]
        [Display(Name = "Reported Non-Operating Income")]
        PfacReportedNonOperatingIncome = 18,

        [DescriptionAttribute("Income from Cont. Ops.")]
        [Display(Name = "Income from Cont. Ops.")]
        PfacIncomeFromContinuingOperations = 19,

        [DescriptionAttribute("Tax Expense")]
        [Display(Name = "Tax Expense")]
        PfacTaxExpense = 20,

        [DescriptionAttribute("Reported Net Income")]
        [Display(Name = "Reported Net Income")]
        PfacReportedNetIncome = 21,

        [DescriptionAttribute("EPS Basic")]
        [Display(Name = "EPS Basic")]
        PfacEpsBasic = 22,

        [DescriptionAttribute("EPS Diluted")]
        [Display(Name = "EPS Diluted")]
        PfacEpsDiluted = 23,

        [DescriptionAttribute("W. Ave. Shares Basic")]
        [Display(Name = "W. Ave. Shares Basic")]
        PfacWeightedAverageSharesOutstandingBasic = 24,

        [DescriptionAttribute("W. Ave. Shares Diluted")]
        [Display(Name = "W. Ave. Shares Diluted")]
        PfacWeightedAverageSharesOutstandingDiluted = 25,

        [DescriptionAttribute("DividendsPerCommonShare")]
        [Display(Name = "DividendsPerCommonShare")]
        PfacDividendsPerCommonShare = 26,

    }

    public enum FinancialStatementTagDefinitionType
    {
        [DescriptionAttribute("Balance Sheet Statement")]
        [Display(Name = "Balance Sheet Statement")]
        BalanceSheetStatement = 0,

        [DescriptionAttribute("Income Statement")]
        [Display(Name = "Income Statement")]
        IncomeStatement = 1,

        [DescriptionAttribute("Cash Flow Statement")]
        [Display(Name = "Cash Flow Statement")]
        CashFlowStatement = 2,

        [DescriptionAttribute("Not Set")]
        [Display(Name = "Not Set")]
        NotSet = 3,

    }

    public enum AccountingTreatment
    {
        [DescriptionAttribute("Operating")]
        Operating = 0,

        [DescriptionAttribute("Financial")]
        Financial = 1,

        [DescriptionAttribute("Split")]
        Split = 2,

        [DescriptionAttribute("Not Applicable")]
        NotApplicable = 3,

    }

    public class FinancialStatementTagDefinition : BurnuliBaseModel
    {
        public int ID { get; set; }
        public string TagName { get; set; }
        public string Name { get; set; }
        public FinancialStatementTagDefinitionType Type { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Ordinal { get; set; }
        public AccountingTreatment AccountingTreatment { get; set; }
    }
}