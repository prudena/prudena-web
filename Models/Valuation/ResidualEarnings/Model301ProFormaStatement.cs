using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models.Valuation.ResidualEarnings
{
    public class Model301ProFormaStatement
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        #region Statement Descriptions

        public int FiscalYear { get; set; }
        public DateTime FiscalYearEndDate { get; set; }
        public ProFormaStatementType ProFormaStatementType { get; set; }

        #endregion

        #region Assumptions

        [Display(Name = "Sales Growth Rate")]
        public double SalesGrowthRate { get; set; }
        public string SalesGrowthRateText { get; set; }

        [Display(Name = "Net operating profits after tax/sales")]
        public double NetOperatingProfitsAfterTaxDividedBySales { get; set; }

        [Display(Name = "Beginning Net operating working capital/sales")]
        public double BeginningNetOperatingWorkingCapitalDividedBySales { get; set; }

        [Display(Name = "Beginning Net operating long-term assets / sales")]
        public double BeginningNetOperatingLongTermAssetsDividedBySales { get; set; }

        #endregion

        #region Cost of Capital Parameters

        [Display(Name = "Risk free rate")]
        public double RiskFreeRate { get; set; }

        [Display(Name = "Tax rate")]
        public double TaxRate { get; set; }

        [Display(Name = "Cost of Debt")]
        public double CostOfDebt { get; set; }

        [Display(Name = "Cost of Debt After Tax")]
        public double CostOfDebtAfterTax { get; set; }

        [Display(Name = "Common Equity Beta")]
        public double CommonEquityBeta { get; set; }

        [Display(Name = "Cost of Common Equity (e.g. required return)")]
        public double CostOfCommonEquity { get; set; }

        #endregion

        #region Ratios

        [Display(Name = "Net debt / End. book value of net capital")]
        public double NetDebtDividedByEndingBookValueOfNetCapital { get; set; }

        [Display(Name = "Preferred equity / book value of net capital")]
        public double PreferredEquityDividedByBookValueOfNetCapital { get; set; }

        [Display(Name = "Shareholders' equity /  book value of net capital")]
        public double ShareholdersEquityDividedByBookValueOfNetCapital { get; set; }

        #endregion

        #region Betas

        [Display(Name = "Implied asset beta")]
        public double ImpliedAssetBeta { get; set; }

        [Display(Name = "Cost of preferred equity, before tax  (if applicable)")]
        public double CostOfPreferredEquityBeforeTax { get; set; }

        [Display(Name = "Implied debt beta")]
        public double ImpliedDebtBeta { get; set; }

        [Display(Name = "Implied preferred equity beta")]
        public double ImpliedPreferredEquityBeta { get; set; }
        
        [Display(Name = "WACC (firm cost of capital)")]
        public double WACC { get; set; }

        [Display(Name = "Beg. Equity Market Value (from Valuation)")]
        public double BeginningEquityMarketValueFromValuation { get; set; }

        #endregion

        #region Balance Sheet ProFormas

        [Display(Name = "Ending Net Working Capital")]
        public double NetWorkingCapitial { get; set; }
        public string NetWorkingCapitialText { get; set; }

        [Display(Name = "Ending Net Long-term Assets")]
        public double NetLongTermAssets { get; set; }

        [Display(Name = "Net Operating Assets")]
        public double NetOperatingAssets { get; set; }

        [Display(Name = "Operating Assets")]
        public double OperatingAssets { get; set; }

        [Display(Name = "Net Debt")]
        public double NetDebt { get; set; }

        [Display(Name = "Net Assets")]
        public double NetAssets { get; set; }

        public string NetDebtText { get; set; }

        [Display(Name = "Preferred Stock")]
        public double PreferredStock { get; set; }

        [Display(Name = "Shareholder's Equity")]
        public double ShareholdersEquity { get; set; }

        [Display(Name = "Net Capital")]
        public double NetCapital { get; set; }
        
        #endregion

        #region Income Statement ProFormas

        [Display(Name = "Sales")]
        public double Sales { get; set; }

        [Display(Name = "Net Operating Profit Before Tax")]
        public double NetOperatingProfitBeforeTax { get; set; }

        [Display(Name = "Net Operating Profit After Tax")]
        public double NOPAT { get; set; }
        public string NOPATText { get; set; }
        [Display(Name = "Net interest expenses after tax")]
        public double NetInterestExpenseAfterTax { get; set; }

        public double InterestExpense { get; set; }

        public double InterestInvestmentIncome { get; set; }


        [Display(Name = "Net Income")]
        public double NetIncome { get; set; }

        [Display(Name = "Preferred Dividends")]
        public double PreferredDividends { get; set; }

        [Display(Name = "Net Income to Common")]
        public double NetIncomeToCommon { get; set; }

        #endregion

        #region Model Variables

        public double ChargeForCommonEquity { get; set; }
        public double ResidualOperatingIncome { get; set; }
        public double TerminalAbnormalEarnings { get; set; }
        
        public double PresentValueFactor { get; set; }
        public double PresentValueOfResidualOperatingIncome { get; set; }
        #endregion

    }

   
}