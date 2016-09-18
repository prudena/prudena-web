using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prudena.Web.Models.Valuation.ResidualEarnings
{
    public class Model201
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
        public string BsFiscalQuarter { get; set; }
        public DateTime BsLastReportDate { get; set; }
        public Ticker Ticker { get; set; }

        //[Index("IX_Model201_TickerSymbol", 1, IsUnique = false)]
        [StringLength(100)]
        public string TickerSymbol { get; set; }
        public double LastPrice { get; set; }
        public double CostOfCapital { get; set; }

        
        public bool IncludesUncertainty { get; set; }

        public DateTime BsFiscalYearEndDate { get; set; }

        public DateTime BsReportDate { get; set; }
        
        [Display(Name = "Shareholder Equity")]
        public double ShareholderEquity { get; set; }

        [Display(Name = "Common Shares Outstanding")]
        public double CommonSharesOutstanding { get; set; }

        public double MarketCap { get; set; }

        #region Estimates

        [Display(Name = "Estimate - Next Fiscal Year Current Mean")]
        public double EstimateNextFiscalYearCurrentMean { get; set; }
        [Display(Name = "Estimate - Next Fiscal Year Current High")]
        public double EstimateNextFiscalYearCurrentHigh { get; set; }
        [Display(Name = "Estimate - Next Fiscal Year Current Low")]
        public double EstimateNextFiscalYearCurrentLow { get; set; }

        public DateTime EstimateNextFiscalYearEndDate { get; set; }

        [Display(Name = "Estimate - Current Fiscal Year Current Mean")]
        public double EstimateCurrentFiscalYearCurrentMean { get; set; }
        [Display(Name = "Estimate - Current Fiscal Year Current High")]
        public double EstimateCurrentFiscalYearCurrentHigh { get; set; }
        [Display(Name = "Estimate - Current Fiscal Year Current Low")]
        public double EstimateCurrentFiscalYearCurrentLow { get; set; }

        public DateTime EstimateCurrentFiscalYearEndDate { get; set; }

        #endregion

        public double BookValuePerBasicShare { get; set; }

        public double LastPriceAndTotalValueDelta { get; set; }

        public double LastPriceAndTotalValueDeltaPercent { get; set; }

        public double ValueFromCurrentYear { get; set; }
        public double ValueFromCurrentYearOptimistic { get; set; }
        public double ValueFromCurrentYearPessimistic { get; set; }

        public double ValueFromNextYearOptimistic { get; set; }
        public double ValueFromNextYearPessimistic { get; set; }


        public double ValueFromNextYear { get; set; }

        public double ValueFromShortTerm { get; set; }
        public double ValueFromShortTermOptimistic { get; set; }
        public double ValueFromShortTermPessimistic { get; set; }

        public double ValueFromMiddleTerm { get; set; }
        public double ValueFromMiddleTermPessimistic { get; set; }
        public double ValueFromMiddleTermOptimistic { get; set; }

        public double ValueFromLongTerm { get; set; }
        public double ValueFromLongTermPessimistic { get; set; }
        public double ValueFromLongTermOptimistic { get; set; }

        public double TotalValuePerShare { get; set; }
        public double TotalValuePerSharePessimistic { get; set; }
        public double TotalValuePerShareOptimistic { get; set; }


        public double ResidualEarnings1 { get; set; }
        public double ResidualEarnings2 { get; set; }
        public double ShortTermValue1 { get; set; }
        public double ShortTermValue2 { get; set; }
        public double ValueOfSpeculativeGrowth { get; set; }
        public double ImpliedGrowthRate { get; set; }
        public double Dividend { get; set; }

        public double LastQuarterlyDividend { get; set; }

        public double NetIncome { get; set; }

        public double NoGrowthValuePerShare { get; set; }
        public double SpeculativeValuePercentage { get; set; }
       
        public DateTime DateCreated { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }

        public SystemUser Owner { get; set; }


        public DateTime LastUpdateOfEstimates { get; set; }
        public DateTime LastUpdateOfBalanceSheetData { get; set; }

        [Display(Name = "Excess Cash")]
        public double ExcessCash { get; set; }

        [Display(Name = "Net Income As Reported")]
        public double NetIncomeAsReported { get; set; }

        [Display(Name = "Net Income Per Share")]
        public double NetIncomePerShare { get; set; }

       
        public int YearsInForecast { get; set; }

        public int ShortTermYears { get; set; }

        public int ShortTermYearsOptimistic { get; set; }
        public int ShortTermYearsPessimistic { get; set; }

        public double ShortTermEarningsGrowthRate { get; set; }

        public double ShortTermEarningsGrowthRateOptimistic { get; set; }
        public double ShortTermEarningsGrowthRatePessimistic { get; set; }


        public double ShortTermPayoutRatio { get; set; }
        public double ShortTermPayoutRatioOptimistic { get; set; }
        public double ShortTermPayoutRatioPessimistic { get; set; }

        public int MiddleTermYears { get; set; }
        public int MiddleTermYearsOptimistic { get; set; }
        public int MiddleTermYearsPessimistic { get; set; }
        public double MiddleTermEarningsGrowthRate { get; set; }
        public double MiddleTermEarningsGrowthRateOptimistic { get; set; }
        public double MiddleTermEarningsGrowthRatePessimistic { get; set; }

        public double MiddleTermPayoutRatio { get; set; }
        public double MiddleTermPayoutRatioOptimistic { get; set; }
        public double MiddleTermPayoutRatioPessimistic { get; set; }
        public double LongTermEarningsGrowthRate { get; set; }
        public double LongTermEarningsGrowthRateOptimistic { get; set; }
        public double LongTermEarningsGrowthRatePessimistic { get; set; }
        public double LongTermPayoutRatio { get; set; }

        public double LongTermPayoutRatioOptimistic { get; set; }
        public double LongTermPayoutRatioPessimistic { get; set; }

        public List<double> EarningsPath { get; set; }
        public List<double> EarningsPathOptimistic { get; set; }
        public List<double> EarningsPathPessimistic { get; set; }

        public List<double> ResidualEarningsPath { get; set; }
        public List<double> ResidualEarningsPathOptimistic { get; set; }
        public List<double> ResidualEarningsPathPessimistic { get; set; }

        public List<double> DividensPath { get; set; }
        public List<double> DividensPathOptimistic { get; set; }
        public List<double> DividensPathPessimistic { get; set; }

        public List<int> YearsPath { get; set; }

        public List<int> YearsPathOptimistic { get; set; }
        public List<int> YearsPathPessimistic { get; set; }

        public int LongTermYears { get; set; }

        public int LongTermYearsOptimistic { get; set; }

        public int LongTermYearsPessimistic { get; set; }

        [NotMapped]
        public List<Model201ProFormaStatement> ProFormaStatements { get; set; }

        [NotMapped]
        public List<Model201ProFormaStatement> ProFormaStatementsOptimistic { get; set; }

        [NotMapped]
        public List<Model201ProFormaStatement> ProFormaStatementsPessimistic { get; set; }

        public void GenerateProformaStatements()
        {
            EarningsPath = new List<double>();
            EarningsPathOptimistic = new List<double>();
            EarningsPathPessimistic = new List<double>();

            ResidualEarningsPath = new List<double>();
            ResidualEarningsPathOptimistic = new List<double>();
            ResidualEarningsPathPessimistic = new List<double>();

            YearsPath = new List<int>();

            ProFormaStatements = new List<Model201ProFormaStatement>();
            ProFormaStatementsOptimistic = new List<Model201ProFormaStatement>();
            ProFormaStatementsPessimistic = new List<Model201ProFormaStatement>();

            // first year
            Model201ProFormaStatement lastYear = new Model201ProFormaStatement();
            lastYear.FiscalYear = BsFiscalYearEndDate.Year;
            
            lastYear.ProFormaStatementType = ProFormaStatementType.Historical;
            lastYear.NetIncome = NetIncome;
            lastYear.NetIncomePerShare = NetIncomePerShare;


            lastYear.ShareholdersEquity = ShareholderEquity;
            lastYear.ShareholdersEquityPerShare = BookValuePerBasicShare;
            lastYear.DividendPerShare = Dividend;

            //YearsPath.Add(lastYear.FiscalYear);
            //EarningsPath.Add(lastYear.NetIncomePerShare);
            //ResidualEarningsPath.Add(lastYear.ResidualOperatingIncome);
            ProFormaStatements.Add(lastYear);
            ProFormaStatementsOptimistic.Add(lastYear);
            ProFormaStatementsPessimistic.Add(lastYear);

            Model201ProFormaStatement previousYear = lastYear;
            Model201ProFormaStatement previousYearOptimistic = lastYear;
            Model201ProFormaStatement previousYearPessimistic = lastYear;


            #region Most-likely

            Model201ProFormaStatement firstYear = new Model201ProFormaStatement();
            firstYear.ProFormaStatementType = ProFormaStatementType.Forecast;
            firstYear.FiscalYear = BsFiscalYearEndDate.Year + 1;
            firstYear.NetIncomePerShare = EstimateCurrentFiscalYearCurrentMean;
            firstYear.DividendPerShare = firstYear.NetIncomePerShare * ShortTermPayoutRatio;
            firstYear.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + firstYear.NetIncomePerShare - firstYear.DividendPerShare;
            firstYear.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;
            firstYear.ResidualOperatingIncome = firstYear.NetIncomePerShare - firstYear.ChargeForCommonEquity;
            firstYear.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)1);
            firstYear.PresentValueOfResidualOperatingIncome = firstYear.ResidualOperatingIncome / firstYear.PresentValueFactor;
            
            this.ValueFromCurrentYear = firstYear.PresentValueOfResidualOperatingIncome;
            YearsPath.Add(firstYear.FiscalYear);
            EarningsPath.Add(firstYear.NetIncomePerShare);
            ResidualEarningsPath.Add(firstYear.ResidualOperatingIncome);
            ProFormaStatements.Add(firstYear);

            #endregion

            #region Optimistic

            Model201ProFormaStatement firstYearOptimistic = new Model201ProFormaStatement();
            firstYearOptimistic.ProFormaStatementType = ProFormaStatementType.Forecast;
            firstYearOptimistic.FiscalYear = BsFiscalYearEndDate.Year + 1;
            firstYearOptimistic.NetIncomePerShare = EstimateCurrentFiscalYearCurrentHigh;
            firstYearOptimistic.DividendPerShare = firstYearOptimistic.NetIncomePerShare * ShortTermPayoutRatio;
            firstYearOptimistic.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + firstYearOptimistic.NetIncomePerShare - firstYearOptimistic.DividendPerShare;
            firstYearOptimistic.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;
            firstYearOptimistic.ResidualOperatingIncome = firstYearOptimistic.NetIncomePerShare - firstYearOptimistic.ChargeForCommonEquity;
            firstYearOptimistic.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)1);
            firstYearOptimistic.PresentValueOfResidualOperatingIncome = firstYearOptimistic.ResidualOperatingIncome / firstYearOptimistic.PresentValueFactor;

            this.ValueFromCurrentYearOptimistic = firstYearOptimistic.PresentValueOfResidualOperatingIncome;
            EarningsPathOptimistic.Add(firstYearOptimistic.NetIncomePerShare);
            ResidualEarningsPathOptimistic.Add(firstYearOptimistic.ResidualOperatingIncome);
            ProFormaStatementsOptimistic.Add(firstYearOptimistic);

            #endregion

            #region Pesimistic

            Model201ProFormaStatement firstYearPessimistic = new Model201ProFormaStatement();
            firstYearPessimistic.ProFormaStatementType = ProFormaStatementType.Forecast;
            firstYearPessimistic.FiscalYear = BsFiscalYearEndDate.Year + 1;
            firstYearPessimistic.NetIncomePerShare = EstimateCurrentFiscalYearCurrentLow;
            firstYearPessimistic.DividendPerShare = firstYearPessimistic.NetIncomePerShare * ShortTermPayoutRatio;
            firstYearPessimistic.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + firstYearPessimistic.NetIncomePerShare - firstYearPessimistic.DividendPerShare;
            firstYearPessimistic.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;
            firstYearPessimistic.ResidualOperatingIncome = firstYearPessimistic.NetIncomePerShare - firstYearPessimistic.ChargeForCommonEquity;
            firstYearPessimistic.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)1);
            firstYearPessimistic.PresentValueOfResidualOperatingIncome = firstYearPessimistic.ResidualOperatingIncome / firstYearPessimistic.PresentValueFactor;

            this.ValueFromCurrentYearPessimistic = firstYearPessimistic.PresentValueOfResidualOperatingIncome;
            EarningsPathPessimistic.Add(firstYearPessimistic.NetIncomePerShare);
            ResidualEarningsPathPessimistic.Add(firstYearPessimistic.ResidualOperatingIncome);
            ProFormaStatementsPessimistic.Add(firstYearPessimistic);

            #endregion
             
            previousYear = firstYear;
            previousYearOptimistic = firstYearOptimistic;
            previousYearPessimistic = firstYearPessimistic;

            Model201ProFormaStatement secondYear = new Model201ProFormaStatement();
            secondYear.ProFormaStatementType = ProFormaStatementType.Forecast;
            secondYear.FiscalYear = BsFiscalYearEndDate.Year + 2;
            secondYear.NetIncomePerShare = EstimateNextFiscalYearCurrentMean;
            secondYear.DividendPerShare = ShortTermPayoutRatio * EstimateNextFiscalYearCurrentMean;
            secondYear.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + secondYear.NetIncomePerShare - secondYear.DividendPerShare;
            secondYear.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;
            secondYear.ResidualOperatingIncome = secondYear.NetIncomePerShare - secondYear.ChargeForCommonEquity;
            secondYear.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)2);
            secondYear.PresentValueOfResidualOperatingIncome = secondYear.ResidualOperatingIncome / secondYear.PresentValueFactor;
            this.ValueFromNextYear = secondYear.PresentValueOfResidualOperatingIncome;

            YearsPath.Add(secondYear.FiscalYear);
            EarningsPath.Add(secondYear.NetIncomePerShare);
            ResidualEarningsPath.Add(secondYear.ResidualOperatingIncome);

            Model201ProFormaStatement secondYearOptimistic = new Model201ProFormaStatement();
            secondYearOptimistic.ProFormaStatementType = ProFormaStatementType.Forecast;
            secondYearOptimistic.FiscalYear = BsFiscalYearEndDate.Year + 2;
            secondYearOptimistic.NetIncomePerShare = EstimateNextFiscalYearCurrentHigh;
            secondYearOptimistic.DividendPerShare = ShortTermPayoutRatio * EstimateNextFiscalYearCurrentHigh;
            secondYearOptimistic.ShareholdersEquityPerShare = previousYearOptimistic.ShareholdersEquityPerShare + secondYearOptimistic.NetIncomePerShare - secondYearOptimistic.DividendPerShare;
            secondYearOptimistic.ChargeForCommonEquity = previousYearOptimistic.ShareholdersEquityPerShare * this.CostOfCapital;
            secondYearOptimistic.ResidualOperatingIncome = secondYearOptimistic.NetIncomePerShare - secondYearOptimistic.ChargeForCommonEquity;
            secondYearOptimistic.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)2);
            secondYearOptimistic.PresentValueOfResidualOperatingIncome = secondYearOptimistic.ResidualOperatingIncome / secondYearOptimistic.PresentValueFactor;

            this.ValueFromNextYearOptimistic = secondYearOptimistic.PresentValueOfResidualOperatingIncome;
            EarningsPathOptimistic.Add(secondYearOptimistic.NetIncomePerShare);
            ResidualEarningsPathOptimistic.Add(secondYearOptimistic.ResidualOperatingIncome);
           
            Model201ProFormaStatement secondYearPessimistic = new Model201ProFormaStatement();
            secondYearPessimistic.ProFormaStatementType = ProFormaStatementType.Forecast;
            secondYearPessimistic.FiscalYear = BsFiscalYearEndDate.Year + 2;
            secondYearPessimistic.NetIncomePerShare = EstimateNextFiscalYearCurrentLow;
            secondYearPessimistic.DividendPerShare = ShortTermPayoutRatio * EstimateNextFiscalYearCurrentLow;
            secondYearPessimistic.ShareholdersEquityPerShare = previousYearPessimistic.ShareholdersEquityPerShare + secondYearPessimistic.NetIncomePerShare - secondYearOptimistic.DividendPerShare;
            secondYearPessimistic.ChargeForCommonEquity = previousYearPessimistic.ShareholdersEquityPerShare * this.CostOfCapital;
            secondYearPessimistic.ResidualOperatingIncome = secondYearPessimistic.NetIncomePerShare - secondYearPessimistic.ChargeForCommonEquity;
            secondYearPessimistic.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)2);
            secondYearPessimistic.PresentValueOfResidualOperatingIncome = secondYearPessimistic.ResidualOperatingIncome / secondYearPessimistic.PresentValueFactor;

            this.ValueFromNextYearPessimistic = secondYearPessimistic.PresentValueOfResidualOperatingIncome;
            EarningsPathPessimistic.Add(secondYearPessimistic.NetIncomePerShare);
            ResidualEarningsPathPessimistic.Add(secondYearPessimistic.ResidualOperatingIncome);

            ProFormaStatements.Add(secondYear);
            ProFormaStatementsOptimistic.Add(secondYearOptimistic);
            ProFormaStatementsPessimistic.Add(secondYearPessimistic);

            previousYear = secondYear;
            previousYearOptimistic = secondYearOptimistic;
            previousYearPessimistic = secondYearPessimistic;
            
            #region Most-likely

            this.ValueFromShortTerm = 0;
            for (int i = 0; i < ShortTermYears; i++)
            {
                Model201ProFormaStatement proforma = new Model201ProFormaStatement();
                proforma.ProFormaStatementType = ProFormaStatementType.Forecast;
                proforma.FiscalYear = BsFiscalYearEndDate.Year + i + 3;

                proforma.NetIncomePerShare = previousYear.NetIncomePerShare * (1 + ShortTermEarningsGrowthRate);

                proforma.DividendPerShare = proforma.NetIncomePerShare * ShortTermPayoutRatio;

                proforma.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + proforma.NetIncomePerShare - proforma.DividendPerShare;

                proforma.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;

                proforma.ResidualOperatingIncome = proforma.NetIncomePerShare - proforma.ChargeForCommonEquity;

                proforma.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)i + 3);

                proforma.PresentValueOfResidualOperatingIncome = proforma.ResidualOperatingIncome / proforma.PresentValueFactor;
                this.ValueFromShortTerm += proforma.PresentValueOfResidualOperatingIncome;
                YearsPath.Add(proforma.FiscalYear);
                EarningsPath.Add(proforma.NetIncomePerShare);
                ResidualEarningsPath.Add(proforma.ResidualOperatingIncome);
                ProFormaStatements.Add(proforma);
                previousYear = proforma;

            }

            this.ValueFromMiddleTerm = 0;
            for (int i = 0; i < MiddleTermYears; i++)
            {
                Model201ProFormaStatement proforma = new Model201ProFormaStatement();
                proforma.ProFormaStatementType = ProFormaStatementType.Forecast;
                proforma.FiscalYear = BsFiscalYearEndDate.Year + i + 3 + ShortTermYears;

                proforma.NetIncomePerShare = previousYear.NetIncomePerShare * (1 + MiddleTermEarningsGrowthRate);

                proforma.DividendPerShare = proforma.NetIncomePerShare * MiddleTermPayoutRatio;

                proforma.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + proforma.NetIncomePerShare - proforma.DividendPerShare;

                proforma.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;

                proforma.ResidualOperatingIncome = proforma.NetIncomePerShare - proforma.ChargeForCommonEquity;

                proforma.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)i + 3 + ShortTermYears);

                proforma.PresentValueOfResidualOperatingIncome = proforma.ResidualOperatingIncome / proforma.PresentValueFactor;
                this.ValueFromMiddleTerm += proforma.PresentValueOfResidualOperatingIncome;
                YearsPath.Add(proforma.FiscalYear);
                EarningsPath.Add(proforma.NetIncomePerShare);
                ResidualEarningsPath.Add(proforma.ResidualOperatingIncome);
                ProFormaStatements.Add(proforma);
                previousYear = proforma;

            }

            this.ValueFromLongTerm = 0;
            for (int i = 0; i < Model201.MAX_LONG_TERM_YEARS; i++)
            {
                Model201ProFormaStatement proforma = new Model201ProFormaStatement();
                proforma.ProFormaStatementType = ProFormaStatementType.Terminal;
                proforma.FiscalYear = BsFiscalYearEndDate.Year + i + 3 + ShortTermYears + MiddleTermYears;

                proforma.NetIncomePerShare = previousYear.NetIncomePerShare * (1 + LongTermEarningsGrowthRate);

                proforma.DividendPerShare = proforma.NetIncomePerShare * LongTermPayoutRatio;

                proforma.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + proforma.NetIncomePerShare - proforma.DividendPerShare;

                proforma.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;

                proforma.ResidualOperatingIncome = proforma.NetIncomePerShare - proforma.ChargeForCommonEquity;

                proforma.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)i + 3 + ShortTermYears + MiddleTermYears);

                proforma.PresentValueOfResidualOperatingIncome = proforma.ResidualOperatingIncome / proforma.PresentValueFactor;

                this.ValueFromLongTerm += proforma.PresentValueOfResidualOperatingIncome;

                this.LongTermYears = i + 1;

                if (i == 0)
                {
                    ProFormaStatements.Add(proforma);
                }
                else if (proforma.PresentValueOfResidualOperatingIncome < .01)
                {
                    ProFormaStatements.Add(proforma);
                    break;
                }
                //else
                //    Model201.ProFormaStatements.Add(proforma);

                if (i < 5)
                {
                    YearsPath.Add(proforma.FiscalYear);
                    EarningsPath.Add(proforma.NetIncomePerShare);
                    ResidualEarningsPath.Add(proforma.ResidualOperatingIncome);
                }
                previousYear = proforma;



            }

            TotalValuePerShare = BookValuePerBasicShare + ValueFromCurrentYear + ValueFromNextYear + ValueFromShortTerm
                + ValueFromMiddleTerm + ValueFromLongTerm;

            #endregion

            #region Pessimistic

            previousYear = secondYearPessimistic;
            this.ValueFromShortTermPessimistic = 0;

            for (int i = 0; i < ShortTermYearsPessimistic; i++)
            {
                Model201ProFormaStatement proforma = new Model201ProFormaStatement();
                proforma.ProFormaStatementType = ProFormaStatementType.Forecast;
                proforma.FiscalYear = BsFiscalYearEndDate.Year + i + 3;

                proforma.NetIncomePerShare = previousYear.NetIncomePerShare * (1 + ShortTermEarningsGrowthRatePessimistic);

                proforma.DividendPerShare = proforma.NetIncomePerShare * ShortTermPayoutRatioPessimistic;

                proforma.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + proforma.NetIncomePerShare - proforma.DividendPerShare;

                proforma.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;

                proforma.ResidualOperatingIncome = proforma.NetIncomePerShare - proforma.ChargeForCommonEquity;

                proforma.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)i + 3);

                proforma.PresentValueOfResidualOperatingIncome = proforma.ResidualOperatingIncome / proforma.PresentValueFactor;
                this.ValueFromShortTermPessimistic += proforma.PresentValueOfResidualOperatingIncome;
                EarningsPathPessimistic.Add(proforma.NetIncomePerShare);
                ResidualEarningsPathPessimistic.Add(proforma.ResidualOperatingIncome);
                ProFormaStatementsPessimistic.Add(proforma);
                previousYear = proforma;

            }

            this.ValueFromMiddleTermPessimistic = 0;
            for (int i = 0; i < MiddleTermYearsPessimistic; i++)
            {
                Model201ProFormaStatement proforma = new Model201ProFormaStatement();
                proforma.ProFormaStatementType = ProFormaStatementType.Forecast;
                proforma.FiscalYear = BsFiscalYearEndDate.Year + i + 3 + ShortTermYearsPessimistic;

                proforma.NetIncomePerShare = previousYear.NetIncomePerShare * (1 + MiddleTermEarningsGrowthRatePessimistic);

                proforma.DividendPerShare = proforma.NetIncomePerShare * MiddleTermPayoutRatioPessimistic;

                proforma.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + proforma.NetIncomePerShare - proforma.DividendPerShare;

                proforma.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;

                proforma.ResidualOperatingIncome = proforma.NetIncomePerShare - proforma.ChargeForCommonEquity;

                proforma.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)i + 3 + ShortTermYearsPessimistic);

                proforma.PresentValueOfResidualOperatingIncome = proforma.ResidualOperatingIncome / proforma.PresentValueFactor;
                this.ValueFromMiddleTermPessimistic += proforma.PresentValueOfResidualOperatingIncome;
                EarningsPathPessimistic.Add(proforma.NetIncomePerShare);
                ResidualEarningsPathPessimistic.Add(proforma.ResidualOperatingIncome);
                ProFormaStatementsPessimistic.Add(proforma);
                previousYear = proforma;

            }

            this.ValueFromLongTermPessimistic = 0;
            for (int i = 0; i < Model201.MAX_LONG_TERM_YEARS; i++)
            {
                Model201ProFormaStatement proforma = new Model201ProFormaStatement();
                proforma.ProFormaStatementType = ProFormaStatementType.Terminal;
                proforma.FiscalYear = BsFiscalYearEndDate.Year + i + 3 + ShortTermYearsPessimistic + MiddleTermYearsPessimistic;

                proforma.NetIncomePerShare = previousYear.NetIncomePerShare * (1 + LongTermEarningsGrowthRatePessimistic);

                proforma.DividendPerShare = proforma.NetIncomePerShare * LongTermPayoutRatioPessimistic;

                proforma.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + proforma.NetIncomePerShare - proforma.DividendPerShare;

                proforma.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;

                proforma.ResidualOperatingIncome = proforma.NetIncomePerShare - proforma.ChargeForCommonEquity;

                proforma.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)i + 3 + ShortTermYearsPessimistic + MiddleTermYearsPessimistic);

                proforma.PresentValueOfResidualOperatingIncome = proforma.ResidualOperatingIncome / proforma.PresentValueFactor;

                this.ValueFromLongTermPessimistic += proforma.PresentValueOfResidualOperatingIncome;

               
                if (i == 0)
                {
                    ProFormaStatementsPessimistic.Add(proforma);
                }
                else if (proforma.PresentValueOfResidualOperatingIncome < .01)
                {
                    ProFormaStatementsPessimistic.Add(proforma);
                    break;
                }
                //else
                //    Model201.ProFormaStatements.Add(proforma);

                if (i < 5)
                {
                    EarningsPathPessimistic.Add(proforma.NetIncomePerShare);
                    ResidualEarningsPathPessimistic.Add(proforma.ResidualOperatingIncome);
                }
                previousYear = proforma;



            }

            TotalValuePerSharePessimistic = BookValuePerBasicShare + ValueFromNextYearPessimistic + ValueFromNextYearPessimistic + ValueFromShortTermPessimistic
                + ValueFromMiddleTermPessimistic + ValueFromLongTermPessimistic;

            #endregion

            #region Optimistic

            previousYear = secondYearOptimistic;

            this.ValueFromShortTermOptimistic = 0;

            for (int i = 0; i < ShortTermYearsOptimistic; i++)
            {
                Model201ProFormaStatement proforma = new Model201ProFormaStatement();
                proforma.ProFormaStatementType = ProFormaStatementType.Forecast;
                proforma.FiscalYear = BsFiscalYearEndDate.Year + i + 3;

                proforma.NetIncomePerShare = previousYear.NetIncomePerShare * (1 + ShortTermEarningsGrowthRateOptimistic);

                proforma.DividendPerShare = proforma.NetIncomePerShare * ShortTermPayoutRatioOptimistic;

                proforma.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + proforma.NetIncomePerShare - proforma.DividendPerShare;

                proforma.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;

                proforma.ResidualOperatingIncome = proforma.NetIncomePerShare - proforma.ChargeForCommonEquity;

                proforma.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)i + 3);

                proforma.PresentValueOfResidualOperatingIncome = proforma.ResidualOperatingIncome / proforma.PresentValueFactor;
                this.ValueFromShortTermOptimistic += proforma.PresentValueOfResidualOperatingIncome;
                EarningsPathOptimistic.Add(proforma.NetIncomePerShare);
                ResidualEarningsPathOptimistic.Add(proforma.ResidualOperatingIncome);
                ProFormaStatementsOptimistic.Add(proforma);
                previousYear = proforma;

            }

            this.ValueFromMiddleTermOptimistic = 0;
            for (int i = 0; i < MiddleTermYearsOptimistic; i++)
            {
                Model201ProFormaStatement proforma = new Model201ProFormaStatement();
                proforma.ProFormaStatementType = ProFormaStatementType.Forecast;
                proforma.FiscalYear = BsFiscalYearEndDate.Year + i + 3 + ShortTermYearsOptimistic;

                proforma.NetIncomePerShare = previousYear.NetIncomePerShare * (1 + MiddleTermEarningsGrowthRateOptimistic);

                proforma.DividendPerShare = proforma.NetIncomePerShare * MiddleTermPayoutRatioOptimistic;

                proforma.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + proforma.NetIncomePerShare - proforma.DividendPerShare;

                proforma.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;

                proforma.ResidualOperatingIncome = proforma.NetIncomePerShare - proforma.ChargeForCommonEquity;

                proforma.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)i + 3 + ShortTermYearsOptimistic);

                proforma.PresentValueOfResidualOperatingIncome = proforma.ResidualOperatingIncome / proforma.PresentValueFactor;
                this.ValueFromMiddleTermOptimistic += proforma.PresentValueOfResidualOperatingIncome;
                EarningsPathOptimistic.Add(proforma.NetIncomePerShare);
                ResidualEarningsPathOptimistic.Add(proforma.ResidualOperatingIncome);
                ProFormaStatementsOptimistic.Add(proforma);
                previousYear = proforma;

            }

            this.ValueFromLongTermOptimistic = 0;
            for (int i = 0; i < Model201.MAX_LONG_TERM_YEARS; i++)
            {
                Model201ProFormaStatement proforma = new Model201ProFormaStatement();
                proforma.ProFormaStatementType = ProFormaStatementType.Terminal;
                proforma.FiscalYear = BsFiscalYearEndDate.Year + i + 3 + ShortTermYearsOptimistic + MiddleTermYearsOptimistic;

                proforma.NetIncomePerShare = previousYear.NetIncomePerShare * (1 + LongTermEarningsGrowthRateOptimistic);

                proforma.DividendPerShare = proforma.NetIncomePerShare * LongTermPayoutRatioOptimistic;

                proforma.ShareholdersEquityPerShare = previousYear.ShareholdersEquityPerShare + proforma.NetIncomePerShare - proforma.DividendPerShare;

                proforma.ChargeForCommonEquity = previousYear.ShareholdersEquityPerShare * this.CostOfCapital;

                proforma.ResidualOperatingIncome = proforma.NetIncomePerShare - proforma.ChargeForCommonEquity;

                proforma.PresentValueFactor = Math.Pow(1 + this.CostOfCapital, (double)i + 3 + ShortTermYearsOptimistic + MiddleTermYearsOptimistic);

                proforma.PresentValueOfResidualOperatingIncome = proforma.ResidualOperatingIncome / proforma.PresentValueFactor;

                this.ValueFromLongTermOptimistic += proforma.PresentValueOfResidualOperatingIncome;


                if (i == 0)
                {
                    ProFormaStatementsOptimistic.Add(proforma);
                }
                else if (proforma.PresentValueOfResidualOperatingIncome < .01)
                {
                    ProFormaStatementsOptimistic.Add(proforma);
                    break;
                }
                //else
                //    Model201.ProFormaStatements.Add(proforma);

                if (i < 5)
                {
                    EarningsPathOptimistic.Add(proforma.NetIncomePerShare);
                    ResidualEarningsPathOptimistic.Add(proforma.ResidualOperatingIncome);
                }
                previousYear = proforma;



            }

            TotalValuePerShareOptimistic = BookValuePerBasicShare + ValueFromNextYearOptimistic + ValueFromNextYearOptimistic 
                + ValueFromShortTermOptimistic
                + ValueFromMiddleTermOptimistic + ValueFromLongTermOptimistic;

            #endregion

        }

        public void CalculateImpliedGrowthRate()
        {
            double impliedg = -.10;
            for (int counter = 0; counter < 10000; counter++)
            {
                LongTermEarningsGrowthRate = impliedg;
                GenerateProformaStatements();
                if (TotalValuePerShare >= LastPrice)
                {
                    ImpliedGrowthRate = impliedg;
                    break;

                }

                impliedg = impliedg + .0001;

            }
        }


    }
}