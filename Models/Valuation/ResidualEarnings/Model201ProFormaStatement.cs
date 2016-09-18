using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models.Valuation.ResidualEarnings
{
    public class Model201ProFormaStatement
    {
        public int ID { get; set; }

 
        #region Statement Descriptions

        public int FiscalYear { get; set; }
        public DateTime FiscalYearEndDate { get; set; }
        public ProFormaStatementType ProFormaStatementType { get; set; }

        #endregion

        #region Assumptions

        [Display(Name = "Sales Growth Rate")]
        public double SalesGrowthRate { get; set; }
        public string SalesGrowthRateText { get; set; }

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

       
        [Display(Name = "Shareholder's Equity")]
        public double ShareholdersEquity { get; set; }

        [Display(Name = "Shareholder's Equity")]
        public double ShareholdersEquityPerShare { get; set; }


        #endregion

        #region Income Statement ProFormas

        [Display(Name = "Sales")]
        public double Sales { get; set; }

        [Display(Name = "Net Income")]
        public double NetIncome { get; set; }

        [Display(Name = "Net Income Per Share")]
        public double NetIncomePerShare { get; set; }

        public double DividendPerShare { get; set; }

        #endregion

        #region Model Variables

        public double ChargeForCommonEquity { get; set; }
        public double ResidualOperatingIncome { get; set; }
        public double TerminalAbnormalEarnings { get; set; }
        
        public double PresentValueFactor { get; set; }
        public double PresentValueOfResidualOperatingIncome { get; set; }
        #endregion

    }

    public enum ProFormaStatementType
    { 
        Historical = 0,
        Forecast = 1,
        Terminal = 2
    }
}