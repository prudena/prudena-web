using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prudena.Web.Models.Valuation.ResidualEarnings
{
    public class VerySimpleResidualEarningsModel : IBurnuliEntity
    {

      
        #region Properties
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime DateModified { get; set; }
        public string BsFiscalQuarter { get; set; }
        public DateTime BsLastReportDate { get; set; }
        public Ticker Ticker { get; set; }
        public string TickerSymbol { get; set; }
        public decimal LastPrice { get; set; }
        public decimal CostOfCapital { get; set; }

        [Display(Name = "Shareholder Equity")]
        public decimal ShareholderEquity { get; set; }

        [Display(Name = "Common Shares Outstanding")]
        public decimal CommonSharesOutstanding { get; set; }

        [Display(Name = "Estimate - Next Fiscal Year Current Mean")]
        public decimal EstimateNextFiscalYearCurrentMean { get; set; }
        [Display(Name = "Estimate - Next Fiscal Year Current High")]
        public decimal EstimateNextFiscalYearCurrentHigh { get; set; }
        [Display(Name = "Estimate - Next Fiscal Year Current Low")]
        public decimal EstimateNextFiscalYearCurrentLow { get; set; }

        public DateTime EstimateNextFiscalYearEndDate { get; set; }

        [Display(Name = "Estimate - Current Fiscal Year Current Mean")]
        public decimal EstimateCurrentFiscalYearCurrentMean { get; set; }
        [Display(Name = "Estimate - Current Fiscal Year Current High")]
        public decimal EstimateCurrentFiscalYearCurrentHigh { get; set; }
        [Display(Name = "Estimate - Current Fiscal Year Current Low")]
        public decimal EstimateCurrentFiscalYearCurrentLow { get; set; }
        
        public DateTime EstimateCurrentFiscalYearEndDate { get; set; }
        public decimal BookValuePerBasicShare { get; set; }
        public decimal ResidualEarnings1 { get; set; }
        public decimal ResidualEarnings2 { get; set; }
        public decimal ShortTermValue1 { get; set; }
        public decimal ShortTermValue2 { get; set; }
        public decimal ValueOfSpeculativeGrowth { get; set; }
        public decimal ImpliedGrowthRate { get; set; }
        public decimal Dividend { get; set; }
        public decimal MarketCap { get { return this.CommonSharesOutstanding * this.LastPrice; } }

        [NotMapped]
        public decimal GivenLongTermGrowthRate { get; set; }

        public decimal NoGrowthValuePerShare { get; set; }
        public decimal SpeculativeValuePercentage { get; set; }
        public decimal Roce1 { get { try { return EstimateCurrentFiscalYearCurrentMean / BookValuePerBasicShare; } catch { return decimal.Zero; } } }
        public decimal PercentChangeInResidualEarnings{ get { try{return ResidualEarnings2/ResidualEarnings1 - 1m;} catch{ return decimal.Zero;}}}
        public decimal PercentChangeInEarnings { get { try { 
            return EstimateNextFiscalYearCurrentMean / EstimateCurrentFiscalYearCurrentMean - 1m; } catch { return decimal.Zero; } } }
        
        public DateTime DateCreated { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }

        public DateTime LastUpdateOfEstimates { get; set; }
        public DateTime LastUpdateOfBalanceSheetData { get; set; }

        [Display(Name = "Excess Cash")]
        public decimal ExcessCash { get; set; }

        [Display(Name = "Net Income As Reported")]
        public decimal NetIncomeAsReported { get; set; }

        [Display(Name = "Net Income Per Share")]
        public decimal NetIncomePerShare { get; set; }

        [Display(Name = "Basic Normalized Net Income Per Share")]
        public decimal BasicNormalizedNetIncomeShare { get; set; }

        public decimal CalculateValueUsingImpliedGrowth()
        {
            BookValuePerBasicShare = CommonSharesOutstanding == 0 ? 0 : ShareholderEquity / CommonSharesOutstanding;
            ResidualEarnings1 = EstimateCurrentFiscalYearCurrentMean - CostOfCapital * BookValuePerBasicShare;
            ShortTermValue1 = ResidualEarnings1 / ((decimal)1 + CostOfCapital);

            ResidualEarnings2 = EstimateNextFiscalYearCurrentMean - ((BookValuePerBasicShare + EstimateCurrentFiscalYearCurrentMean - Dividend) * CostOfCapital);

            decimal rho = (decimal)1 + CostOfCapital;
            ShortTermValue2 = ResidualEarnings2 / (rho * (CostOfCapital - ImpliedGrowthRate));

            decimal valuePerShare = BookValuePerBasicShare + ShortTermValue1 + ShortTermValue2;

            return valuePerShare;
            
        }

        public decimal CalculateValueUsingGivenGrowth(decimal givenGrowth)
        {
            BookValuePerBasicShare = CommonSharesOutstanding == 0 ? 0 : ShareholderEquity / CommonSharesOutstanding;
            ResidualEarnings1 = EstimateCurrentFiscalYearCurrentMean - CostOfCapital * BookValuePerBasicShare;
            ShortTermValue1 = ResidualEarnings1 / ((decimal)1 + CostOfCapital);

            ResidualEarnings2 = EstimateNextFiscalYearCurrentMean - ((BookValuePerBasicShare + EstimateCurrentFiscalYearCurrentMean - Dividend) * CostOfCapital);

            decimal rho = (decimal)1 + CostOfCapital;
            ShortTermValue2 = ResidualEarnings2 / (rho * (CostOfCapital - givenGrowth));

            decimal valuePerShare = BookValuePerBasicShare + ShortTermValue1 + ShortTermValue2;

            return valuePerShare;

        }
        
        public decimal CalculateNoEarningsGrowthValue()
        {
            BookValuePerBasicShare = CommonSharesOutstanding == 0 ? 0 : ShareholderEquity / CommonSharesOutstanding;
            ResidualEarnings1 = EstimateCurrentFiscalYearCurrentMean - CostOfCapital * BookValuePerBasicShare;
            ShortTermValue1 = ResidualEarnings1 / ((decimal)1 + CostOfCapital);

            ResidualEarnings2 = EstimateCurrentFiscalYearCurrentMean - ((BookValuePerBasicShare + EstimateCurrentFiscalYearCurrentMean - Dividend) * CostOfCapital);

            decimal rho = (decimal)1 + CostOfCapital;
            ShortTermValue2 = ResidualEarnings2 / (rho * (CostOfCapital));

            decimal valuePerShare = BookValuePerBasicShare + ShortTermValue1 + ShortTermValue2;

            return valuePerShare;

        }
 
        public void CalculateValues()
        {
            try
            {
                if (CostOfCapital == 0)
                    CostOfCapital = 0.1m;

                BookValuePerBasicShare = CommonSharesOutstanding == 0 ? 0 : ShareholderEquity / CommonSharesOutstanding;
                ResidualEarnings1 = EstimateCurrentFiscalYearCurrentMean - CostOfCapital * BookValuePerBasicShare;
                ShortTermValue1 = ResidualEarnings1 / ((decimal)1 + CostOfCapital);

                ResidualEarnings2 = EstimateNextFiscalYearCurrentMean - ((BookValuePerBasicShare + EstimateCurrentFiscalYearCurrentMean - Dividend) * CostOfCapital);

                decimal rho = (decimal)1 + CostOfCapital;
                ShortTermValue2 = ResidualEarnings2 / (rho * CostOfCapital);
                NoGrowthValuePerShare = ShortTermValue1 + ShortTermValue2 + BookValuePerBasicShare;

                ValueOfSpeculativeGrowth = LastPrice - ShortTermValue1 - ShortTermValue2 - BookValuePerBasicShare;
                ImpliedGrowthRate = CostOfCapital - (ResidualEarnings2 / ((LastPrice - BookValuePerBasicShare - ShortTermValue1) * (1 + CostOfCapital)));
                try
                {
                    SpeculativeValuePercentage = ValueOfSpeculativeGrowth / LastPrice;
                }
                catch
                {
                    SpeculativeValuePercentage = 1;
                }

                if (CommonSharesOutstanding == 0)
                    NetIncomePerShare = 0;
                else
                    NetIncomePerShare = NetIncomeAsReported / CommonSharesOutstanding;
            }
            catch
            {
            }
        }

        public List<decimal> GetEpsGrowthPath(List<decimal> reGrowthRatePath, out List<decimal> earningsReturnPath)
        {
            List<decimal> returnPath = new List<decimal>();
            earningsReturnPath = new List<decimal>();

            decimal book1 = (BookValuePerBasicShare + EstimateCurrentFiscalYearCurrentMean - Dividend);
            decimal earnings2 = ResidualEarnings2 + (CostOfCapital * book1);
            decimal deltaEarnings2;

            if (EstimateCurrentFiscalYearCurrentMean == 0)
                deltaEarnings2 = 0;
            else
                deltaEarnings2 = (EstimateNextFiscalYearCurrentMean / EstimateCurrentFiscalYearCurrentMean) - 1;
            
            decimal dividend = Dividend;
            decimal bookValue = book1;
            decimal residualEarnings = ResidualEarnings2;
            decimal earnings = earnings2;
            decimal deltaEarnings = deltaEarnings2;

            returnPath.Add(deltaEarnings);
            earningsReturnPath.Add(earnings);
            
            
            int i = 0;
            foreach (decimal residualEarningsGrowthRate in reGrowthRatePath)
            {
                if (i == 0)
                {
                    i++;
                    continue;
                }

                dividend = dividend * (1m + deltaEarnings);
                bookValue = bookValue + earnings - dividend;
                residualEarnings = residualEarnings * (1m + residualEarningsGrowthRate);
                decimal previousEarnings = earnings;
                earnings = residualEarnings + (CostOfCapital * bookValue);
                if (previousEarnings == 0)
                    deltaEarnings = 0;
                else
                    deltaEarnings = earnings / previousEarnings - 1m;
                returnPath.Add(deltaEarnings);
                earningsReturnPath.Add(earnings);
                i++;
            }

            return returnPath;
        }

        public string GetEpsGrowthPath(out string earningsPath, out string bookPath, out string dividendPath)
        {

            decimal book1 = (BookValuePerBasicShare + EstimateCurrentFiscalYearCurrentMean - Dividend);
            decimal earnings2 = ResidualEarnings2 + (CostOfCapital * book1);
            decimal deltaEarnings2 = (EstimateNextFiscalYearCurrentMean / EstimateCurrentFiscalYearCurrentMean) - 1;

            decimal dividend2 = Dividend * (1 + deltaEarnings2);
            decimal book2 = book1 + earnings2 - dividend2;
            decimal residualEarnings3 = (1 + ImpliedGrowthRate) * ResidualEarnings2;
            decimal earnings3 = residualEarnings3 + (CostOfCapital * book2);
            decimal deltaEarnings3 = (earnings3 / earnings2) - 1;

            decimal dividend3 = dividend2 * (1 + deltaEarnings3);
            decimal book3 = book2 + earnings3 - dividend3;
            decimal residualEarnings4 = (1 + ImpliedGrowthRate) * residualEarnings3;
            decimal earnings4 = residualEarnings4 + (CostOfCapital * book3);
            decimal deltaEarnings4 = (earnings4 / earnings3) - 1;

            decimal dividend4 = dividend3 * (1 + deltaEarnings4);
            decimal book4 = book3 + earnings4 - dividend4;
            decimal residualEarnings5 = (1 + ImpliedGrowthRate) * residualEarnings4;
            decimal earnings5 = residualEarnings5 + (CostOfCapital * book4);
            decimal deltaEarnings5 = (earnings5 / earnings4) - 1;

            decimal dividend5 = dividend4 * (1 + deltaEarnings5);
            decimal book5 = book4 + earnings5 - dividend5;
            decimal residualEarnings6 = (1 + ImpliedGrowthRate) * residualEarnings5;
            decimal earnings6 = residualEarnings6 + (CostOfCapital * book5);
            decimal deltaEarnings6 = (earnings6 / earnings5) - 1;

            decimal dividend6 = dividend5 * (1 + deltaEarnings6);
            decimal book6 = book5 + earnings6 - dividend6;
            decimal residualEarnings7 = (1 + ImpliedGrowthRate) * residualEarnings6;
            decimal earnings7 = residualEarnings7 + (CostOfCapital * book6);
            decimal deltaEarnings7 = (earnings7 / earnings6) - 1;

            decimal dividend7 = dividend6 * (1 + deltaEarnings7);
            decimal book7 = book6 + earnings7 - dividend7;
            decimal residualEarnings8 = (1 + ImpliedGrowthRate) * residualEarnings7;
            decimal earnings8 = residualEarnings8 + (CostOfCapital * book7);
            decimal deltaEarnings8 = (earnings8 / earnings7) - 1;

            string deltaEarnings = string.Format("{0:#.0}", deltaEarnings2 * 100) + ", ";
            deltaEarnings += string.Format("{0:#.0}", deltaEarnings3 * 100) + ", ";
            deltaEarnings += string.Format("{0:#.0}", deltaEarnings4 * 100) + ", ";
            deltaEarnings += string.Format("{0:#.0}", deltaEarnings5 * 100) + ", ";
            deltaEarnings += string.Format("{0:#.0}", deltaEarnings6 * 100) + ", ";
            deltaEarnings += string.Format("{0:#.0}", deltaEarnings7 * 100) + ", ";
            deltaEarnings += string.Format("{0:#.0}", deltaEarnings8 * 100);

            earningsPath = string.Format("{0:#.00}", EstimateCurrentFiscalYearCurrentMean) + ", ";
            earningsPath += string.Format("{0:#.00}", earnings2) + ", ";
            earningsPath += string.Format("{0:#.00}", earnings3) + ", ";
            earningsPath += string.Format("{0:#.00}", earnings4) + ", ";
            earningsPath += string.Format("{0:#.00}", earnings5) + ", ";
            earningsPath += string.Format("{0:#.00}", earnings6) + ", ";
            earningsPath += string.Format("{0:#.00}", earnings7) + ", ";
            earningsPath += string.Format("{0:#.00}", earnings8) + ", ";

            bookPath = string.Format("{0:#.00}", BookValuePerBasicShare) + ", ";
            bookPath += string.Format("{0:#.00}", book1) + ", ";
            bookPath += string.Format("{0:#.00}", book2) + ", ";
            bookPath += string.Format("{0:#.00}", book3) + ", ";
            bookPath += string.Format("{0:#.00}", book4) + ", ";
            bookPath += string.Format("{0:#.00}", book5) + ", ";
            bookPath += string.Format("{0:#.00}", book6) + ", ";
            bookPath += string.Format("{0:#.00}", book7) + ", ";

            dividendPath = string.Format("{0:#.00}", Dividend) + ", ";
            dividendPath += string.Format("{0:#.00}", dividend2) + ", ";
            dividendPath += string.Format("{0:#.00}", dividend3) + ", ";
            dividendPath += string.Format("{0:#.00}", dividend4) + ", ";
            dividendPath += string.Format("{0:#.00}", dividend5) + ", ";
            dividendPath += string.Format("{0:#.00}", dividend6) + ", ";
            dividendPath += string.Format("{0:#.00}", dividend7) + ", ";
            
            
            return deltaEarnings;
        }
  
        public List<decimal> GetResidualEarningsPath(decimal weight, decimal gdpGrowthRate, int yearsToCalculate)
        {
            List<decimal> rates = new List<decimal>();
            //going out 10 years
            decimal indexYearResidualEarningsGrowthRate = (ResidualEarnings2/ResidualEarnings1) - 1;
            rates.Add(indexYearResidualEarningsGrowthRate);

            int i = 0;
            while (indexYearResidualEarningsGrowthRate > gdpGrowthRate)
            {
                if (i > yearsToCalculate)
                    break;

                indexYearResidualEarningsGrowthRate = (decimal)((decimal)(weight * indexYearResidualEarningsGrowthRate) + ((decimal)(1m - weight) * gdpGrowthRate));
                rates.Add(indexYearResidualEarningsGrowthRate);
                i++;
            }
           

            return rates;
        }

        public decimal GetValueGivenResidualEarningsPath(decimal weight, decimal gdpGrowthRate, int yearsToCalculate)
        {
            decimal longTermValue = BookValuePerBasicShare;
            decimal rho = 1 + CostOfCapital;
            longTermValue += ResidualEarnings1 / rho;
            longTermValue += ResidualEarnings2 / (decimal)Math.Pow((double)rho, (double)2);

            decimal residualEarnings = ResidualEarnings2;
            
            int i = 3;
            foreach(decimal rate in GetResidualEarningsPath(weight, gdpGrowthRate, yearsToCalculate).OrderByDescending(p => p))
            {
                //some times the i gets big and this blows up.  If this is the case we just don't grow the value.
                try
                {
                    residualEarnings = residualEarnings * (1m + rate);
                    longTermValue += residualEarnings / (decimal)Math.Pow((double)rho, (double)i);
                }
                catch { }
                i++;
            }


            return longTermValue;
        }
 
        public class PriceWeightPair
        {
            public decimal Weight { get; set; }
            public decimal Price { get; set; }
        }
 
        public PriceWeightPair GetWeightImpliedByPrice(decimal weight, decimal gdpGrowthRate, int yearsToCalculate)
        {
            decimal step = .001m;

            decimal price = GetValueGivenResidualEarningsPath(weight, gdpGrowthRate, yearsToCalculate);

            if (price > LastPrice && weight > 0)
            {
                weight = weight - step;
                return GetWeightImpliedByPrice(weight, gdpGrowthRate, yearsToCalculate);
            }

            return new PriceWeightPair() { Price = price, Weight = weight };
        }
        
        #endregion

    }
}
