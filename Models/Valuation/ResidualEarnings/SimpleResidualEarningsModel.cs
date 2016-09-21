using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models.Valuation.ResidualEarnings
{
    public class SimpleResidualEarningsModel : IBurnuliEntity
    {

        public SimpleResidualEarningsModel()
        {
            SharesOutstanding = 1;
            CostOfCapitalFirm = .01;
            ModelDate = DateTime.UtcNow;
        }

        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ModelDate { get; set; }
        [Display(Name = "Model Url")]
        public string ModelUrl { get; set; }
        [Display(Name = "Publish Model Url")]
        public bool PublishModelUrl { get; set; }

        public bool UpdateModelValues { get; set; }
        [Display(Name = "Model Read Only Url")]
        public string ModelReadOnlyUrl { get; set; }
        [Display(Name = "Publish Model Read Only Url")]
        public bool PublishModelReadOnlyUrl { get; set; }
        
        [Display(Name = "Model Notes Url")]
        public string ModelNotesUrl { get; set; }
        [Display(Name = "Publish Notes Url")]
        public bool PublishNotesUrl { get; set; }

        [Display(Name = "Model Notes Read Only Url")]
        public string ModelNotesReadOnlyUrl { get; set; }
        [Display(Name = "Publish Notes Read Only Url")]
        public bool PublishNotesReadOnlyUrl { get; set; }
        

        [Display(Name = "Model Display Range")]
        public string ModelDisplayRange { get; set; }
        [Display(Name = "Model Document Name")]
        public string ModelDocumentName { get; set; }

        [Display(Name = "Ruling Reason")]
        public string RulingReason { get; set; }
        [Display(Name = "Counter Argument")]
        public string CounterArgument { get; set; }
        public string Notes { get; set; }
        public decimal? SharePriceOnModelDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public SystemUser Owner { get; set; }
        public Ticker Ticker { get; set; }
        public int ValuationOpinionId { get; set; }
        public ValuationOpinion ValuationOpinion { get { return (ValuationOpinion)ValuationOpinionId; } }
        public string ValuationOpinionText { get; set; }
        public bool UseUserDefaultRequiredReturn { get; set; }
       
        public bool PublishCostOfCapitalFirm { get; set; }
        public bool PublishCostOfCapitalEquity { get; set; }
        public bool PublishImpliedLongTermGrowthRate { get; set; }
        public bool PublishSharePriceOnModelDate { get; set; }
        public bool PublishModelDate { get; set; }
        public bool PublishOpinion { get; set; }

        public bool ShareModelPublicly { get; set; }
        public bool ApprovedForPublicDisplay { get; set; }
        public string ModelSummary { get; set; }
      

        [Required]
        [Display(Name = "Shares Outstanding")]
        [Range(1, long.MaxValue, ErrorMessage = "Value for {0} must be greater than zero.")]
        public long SharesOutstanding { get; set; }

        //[DisplayFormat(DataFormatString = "{0:0,0}", ApplyFormatInEditMode = false)]
        public decimal AssetsT0 { get; set; }
        public decimal AssetsTM1 { get; set; }

        [Display(Name = "Net Operating Assets T-1")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public decimal NetOperatingAssetsTM1 { get; set; }
        
        [Display(Name = "Net Operating Assets T0")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public decimal NetOperatingAssetsT0 { get; set; }
        [Display(Name = "Net Operating Assets T1")]
        public decimal NetOperatingAssetsT1 { get; set; }
        [Display(Name = "Net Operating Assets T2")]
        public decimal NetOperatingAssetsT2 { get; set; }
        [Display(Name = "Net Operating Assets T3")]
        public decimal NetOperatingAssetsT3 { get; set; }
        [Display(Name = "Net Operating Assets T4")]
        public decimal NetOperatingAssetsT4 { get; set; }
        [Display(Name = "Net Operating Assets T5")]
        public decimal NetOperatingAssetsT5 { get; set; }

        [Display(Name = "Change In Net Operating Assets T0")]
        public decimal NetOperatingAssetsDeltaT0 { get; set; }
        [Display(Name = "Change In Net Operating Assets T1")]
        public decimal NetOperatingAssetsDeltaT1 { get; set; }
        [Display(Name = "Change In Net Operating Assets T2")]
        public decimal NetOperatingAssetsDeltaT2 { get; set; }
        [Display(Name = "Change In Net Operating Assets T3")]
        public decimal NetOperatingAssetsDeltaT3 { get; set; }
        [Display(Name = "Change In Net Operating Assets T4")]
        public decimal NetOperatingAssetsDeltaT4 { get; set; }
        [Display(Name = "Change In Net Operating Assets T5")]
        public decimal NetOperatingAssetsDeltaT5 { get; set; }

        public decimal LiabilitiesT0 { get; set; }

        //[DisplayFormat(DataFormatString = "{0:0,0}",  ApplyFormatInEditMode = false)]
        public decimal EquityT0 { get; set; }

        //[DisplayFormat(DataFormatString = "{0:0,0}",  ApplyFormatInEditMode = false)]
        public decimal EquityT0PerShare { get; set; }
        public decimal EquityT0PerShareMax { get; set; }
        public decimal EquityT0PerShareMin { get; set; }
        
        //[DisplayFormat(DataFormatString = "{0:0,0}",  ApplyFormatInEditMode = false)]
        public bool PublishEquityT0PerShare { get; set; }

        public decimal AlertIfMoreThan { get; set; }

        public decimal AlertIfLessThan { get; set; }

        public decimal LastPrice { get; set; }
       
        [Required]
        [Display(Name = "Firm Cost of Capital")]
        [DisplayFormat(DataFormatString = "{0:P}",  ApplyFormatInEditMode = false)]
        public double CostOfCapitalFirm { get; set; }

        public double CalculateCostOfCapitalFirm()
        {
            double equityPortion = CostOfCapitalEquity * (double)(EquityT0 / AssetsT0);
            double debtPortion = NetBorrowingCost * (double)((AssetsT0 - EquityT0) / AssetsT0);
            return  equityPortion + debtPortion;
 
        }

        [Display(Name = "Non-Operating Assets And Excess Cash")]
        [Range(0, long.MaxValue, ErrorMessage = "Value for {0} cannot be negative.")]
        [DisplayFormat(DataFormatString = "{0:0,0}", ApplyFormatInEditMode = false)]
       
        public decimal ExcessCash { get; set; }
        [Required]
        [Display(Name = "Equity Cost of Capital")]
        public double CostOfCapitalEquity { get; set; }
        [Required]
        [Display(Name = "Net Borrowing Cost")]
        public double NetBorrowingCost { get; set; }
        [Display(Name = "Long-term Growth Rate")]
        public double LongTermGrowthRate { get; set; }
        public double LongTermGrowthRateMin { get; set; }
        public double LongTermGrowthRateMax { get; set; }

        [Display(Name = "Earnings Per Share Forcast T1")]
        public decimal EarningPerShareForcastT1 { get; set; }
        [Display(Name = "Earnings Per Share Forcast Min T1")]
        public decimal EarningPerShareForcastT1Min { get; set; }
        [Display(Name = "Earnings Per Share Forcast Max T1")]
        public decimal EarningPerShareForcastT1Max { get; set; }
        [Display(Name = "Earnings Per Share Forcast T2")]
        public decimal EarningPerShareForcastT2 { get; set; }

        public decimal EarningPerShareForcastT2Min { get; set; }
        public decimal EarningPerShareForcastT2Max { get; set; }
        
        [Display(Name = "Earnings Per Share Forcast T3")]
        public decimal EarningPerShareForcastT3 { get; set; }
        [Display(Name = "Earnings Per Share Forcast T4")]
        public decimal EarningPerShareForcastT4 { get; set; }
        [Display(Name = "Earnings Per Share Forcast T5")]
        public decimal EarningPerShareForcastT5 { get; set; }

        [Display(Name = "Operating Income T0")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public decimal OperatingIncomeT0 { get; set; }
        
        [Display(Name = "Operating Income T1")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public decimal OperatingIncomeT1 { get; set; }
        [Display(Name = "Operating Income T2")]
        public decimal OperatingIncomeT2 { get; set; }
        [Display(Name = "Operating Income T3")]
        public decimal OperatingIncomeT3 { get; set; }
        [Display(Name = "Operating Income T4")]
        public decimal OperatingIncomeT4 { get; set; }
        [Display(Name = "Operating Income T5")]
        public decimal OperatingIncomeT5 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0,0}", ConvertEmptyStringToNull = true, NullDisplayText = "[Null]")]
        public decimal ResidualOperatingIncomeT0 { get { return OperatingIncomeT0 - (decimal)CostOfCapitalFirm * ((NetOperatingAssetsTM1 + NetOperatingAssetsT0) / 2); } }
        
        [DisplayFormat(DataFormatString = "{0:0,0}", ConvertEmptyStringToNull = true, NullDisplayText = "[Null]")]
        public decimal ResidualOperatingIncomeNoGrowthT1 { get { return ResidualOperatingIncomeT0; } }
        
        [DisplayFormat(DataFormatString = "{0:0,0}", ConvertEmptyStringToNull = true, NullDisplayText = "[Null]")]
        public decimal OperatingIncomeNoGrowthT1 { get { return ResidualOperatingIncomeNoGrowthT1 + (NetOperatingAssetsT0 * (decimal)CostOfCapitalFirm); } }
        
        [Display(Name = "Residual Operating Income T1")]
        [DisplayFormat(DataFormatString = "{0:0,0}", ConvertEmptyStringToNull = true, NullDisplayText = "[Null]")]
        public decimal ResidualOperatingIncomeT1 { get { return OperatingIncomeT1 - (decimal)CostOfCapitalFirm * ((NetOperatingAssetsT0 + NetOperatingAssetsT1)/2); } }
        
        public decimal ResidualOperatingIncomeT2 { get { return OperatingIncomeT2 - (decimal)CostOfCapitalFirm * ((NetOperatingAssetsT1 + NetOperatingAssetsT2) / 2); } }
        public decimal ResidualOperatingIncomeT3 { get { return OperatingIncomeT3 - (decimal)CostOfCapitalFirm * ((NetOperatingAssetsT2 + NetOperatingAssetsT3) / 2); } }
        public decimal ResidualOperatingIncomeT4 { get { return OperatingIncomeT4 - (decimal)CostOfCapitalFirm * ((NetOperatingAssetsT3 + NetOperatingAssetsT4) / 2); } }
        public decimal ResidualOperatingIncomeT5 { get { return OperatingIncomeT5 - (decimal)CostOfCapitalFirm * ((NetOperatingAssetsT4 + NetOperatingAssetsT5) / 2); } }
        
        #endregion

        public decimal DividendMin { get; set; }
        public decimal Dividend { get; set; }
        public decimal DividendMax { get; set; }
        public bool SendEmailNotification { get; set; }
        public bool RequiresNotification { get; set; }
        public bool NotificationOneSent { get; set; }
        public DateTime? NotificationOneDateTime { get; set; }
        public bool NotificationTwoSent { get; set; }
        public DateTime? NotificationTwoDateTime { get; set; }
        public bool NotificationThreeSent { get; set; }
        public DateTime? NotificationThreeDateTime { get; set; }
        public bool SetRequiresNotification(decimal quote)
        {
            if (quote < this.AlertIfLessThan || quote > this.AlertIfMoreThan)
            {
                this.RequiresNotification = true;
                return true;
            }
            else
            {
                this.RequiresNotification = false;
                return false;
            }

        }
        #region Simple No Growth Model

        [Display(Name = "Value From Residual Operating Income T1")]
        public decimal ValueResidualOperatingIncomeT1
        {
            get
            {
                    return ResidualOperatingIncomeT1 / (decimal)(1 + CostOfCapitalFirm);
             }
        }

        public decimal? TerminalValueNoGrowth
        {
            get {
                try
                {
                    return (decimal)((double)ResidualOperatingIncomeT1 / (double)(CostOfCapitalFirm));
                }
                catch
                {
                    return null;
                }
            }
        }


        [Display(Name = "No Growth Value of Equity")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public decimal ValueOfEquityNoGrowth
        {
            get
            {
                if (CostOfCapitalFirm == 0)
                    CostOfCapitalFirm = .10;

                return EquityT0 + (decimal)((double)ResidualOperatingIncomeNoGrowthT1/CostOfCapitalFirm);
            }
        }
        [Display(Name = "No Growth Value Per Share")]
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ConvertEmptyStringToNull = true, NullDisplayText = "[Null]")]

        public decimal? ValueOfEquityPerShareNoGrowth
        {
            get
            {
                return ValueOfEquityNoGrowth / (decimal)SharesOutstanding;
            }
        }

        #endregion

        #region Simple Model With Growth

        
        [Display(Name = "Value of Equity with Growth")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public decimal ValueOfEquityWithGrowth 
        {
            get
            {
                if (CostOfCapitalFirm == LongTermGrowthRate)
                    return 0;
                else 
                return EquityT0 + (decimal)((double)ResidualOperatingIncomeT1/(double)(CostOfCapitalFirm - LongTermGrowthRate));
            }
        }
        [Display(Name = "Value Per Share with Growth")]
        [DisplayFormat(DataFormatString = "{0:0,0.00}", ConvertEmptyStringToNull = true, NullDisplayText = "[Null]")]

        public decimal? ValueOfEquityPerShareWithGrowth
        {
            get
            {
                return ValueOfEquityWithGrowth / (decimal)SharesOutstanding;
            }
        }

        #endregion

    }
}
