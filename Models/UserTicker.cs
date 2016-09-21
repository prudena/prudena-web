using System;
using System.ComponentModel.DataAnnotations;
using Prudena.Web.Models.Valuation;

namespace Prudena.Web.Models
{
    public enum UserTickerWorkflowState
    {
        Default = 0
    }
    public class UserTicker
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public SystemUser SystemUser { get; set; }

        [Required]

        public Ticker Ticker { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }

        public double CurrentRatingVeryInterestingLongAt { get; set; }
        public double CurrentRatingInterestingLongAt { get; set; }

        public double CurrentRatingVeryInterestingShortAt { get; set; }

        public double CurrentRatingInterestingShortAt { get; set; }
        public double CurrentLastPrice { get; set; }

        public bool CurrentRatingSet { get; set; }

        public bool PriceTriggerSet { get; set; }


        public double PriceTriggerHigh1 { get; set; }
        public double PriceTriggerHigh2 { get; set; }
        public double PriceTriggerHigh3 { get; set; }
        
        public double PriceTriggerLow1 { get; set; }
        public double PriceTriggerLow2 { get; set; }
        public double PriceTriggerLow3 { get; set; }


        public double LastPrice { get; set; }

        public double ChangeInPercent { get; set; }

        public int WorkflowStateID{ get; set; }

        public string WorkflowStateText { get; set; }

        public double ImpliedGrowthRate { get; set; }
        public double SavedLongTermGrowthRate { get; set; }
        public double ValueGivenRrAndSavedGrowthRate { get; set; }
        public double ValueGivenRrAndSavedGrowthRatePercent { get; set; }

        public string ExternalModelUrl { get; set; }

        public string ExternalNotesUrl { get; set; }

        public bool HasExternalModel { get; set; }

        public bool HasExternalNotes { get; set; }


        public double MarginOfSafetyAmount
        {
            get
            { return ValueGivenRrAndSavedGrowthRate - LastPrice; }
        }
        
        public bool ColorScaleIsReversed { get; set; }

        public double ImpliedGrowthTriggerHigh1 { get; set; }
        public double ImpliedGrowthTriggerHigh2 { get; set; }
        public double ImpliedGrowthTriggerHigh3 { get; set; }
        public double ImpliedGrowthTriggerLow1 { get; set; }
        public double ImpliedGrowthTriggerLow2 { get; set; }
        public double ImpliedGrowthTriggerLow3 { get; set; }

        public double RequiredReturn { get; set; }

     


        public string Notes { get; set; }

        public string PublicNotes { get; set; }

        public int ValuationOpinionId { get; set; }
        public ValuationOpinion ValuationOpinion { get { return (ValuationOpinion)ValuationOpinionId; } }
        public string ValuationOpinionText { get; set; }
        public bool UseUserDefaultRequiredReturn { get; set; }

        [Display(Name = "Send Email Notification")]
        public bool SendEmailNotification { get; set; }
        public double AlertHigh { get; set; }
        public double AlertLow { get; set; }

        public bool ShowAlert { get; set; }
        public bool ShowAlertLow { get; set; }
        public bool ShowAlertHigh { get; set; }
        public bool RequiresNotification { get; set; }
        public bool NotificationOneSent { get; set; }
        public DateTime? NotificationOneDateTime { get; set; }
        public bool NotificationTwoSent { get; set; }
        public DateTime? NotificationTwoDateTime { get; set; }
        public bool NotificationThreeSent { get; set; }
        public DateTime? NotificationThreeDateTime { get; set; }

        public bool HasModel { get; set; }

        public bool ModelIsCurrent { get; set; }
        public DateTime? MostRecentModelDate { get; set; }
        public string MostRecentModelUrl { get; set; }

        public bool HasRating { get; set; }

        public bool RatingIsCurrent { get; set; }
        public DateTime? MostRecentRatingDate { get; set; }

        public int CurrentResearchStatusLevel { get; set; }

        public string CurrentResearchColor { get; set; }

        public string CurrentPriceAlertColor { get; set; }

        public string CurrentPriceAlertText { get; set; }

        public bool HasSharedARating { get; set; }
        public bool HasSharedAModel { get; set; }
        public bool SetRequiresNotification(decimal quote)
        {
            if (quote < (decimal)this.AlertLow || quote > (decimal)this.AlertHigh)
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

        public bool IncludeInWatchList { get; set; }
        public bool UseCustomColors { get; set; }
        public string ColorTriggerLow1 { get; set; }
        public string ColorTriggerLow2 { get; set; }
        public string ColorTriggerLow3 { get; set; }
        public string ColorTriggerHigh1 { get; set; }
        public string ColorTriggerHigh2 { get; set; }
        public string ColorTriggerHigh3 { get; set; }
        public string ColorNormal { get; set; }

        public bool IncludeInPublicCoverageList { get; set; }

        public bool IncludeInPrivateCoverageList { get; set; }
        public void SetDefaultColors()
        {
            this.ColorNormal = "#DDDDDD";
            this.ColorTriggerLow3 = "#FF0000";
            this.ColorTriggerLow2 = "#FFA500";
            this.ColorTriggerLow1 = "#FFFF00";

            this.ColorTriggerHigh1 = "#BCED91";
            this.ColorTriggerHigh2 = "#00ff00";
            this.ColorTriggerHigh3 = "#66CCCC";

        }


        public string TickerSymbol
        {
            get
            {
                if (Ticker != null)
                    return Ticker.Symbol;
                else
                    return "";
            }
        }

        public string TickerName
        {
            get
            {
                if (Ticker != null)
                    return Ticker.Name;
                else
                    return "";
            }
        }
 
        public string Symbol
        {
            get
            {
                if (Ticker != null)
                    return Ticker.Symbol;
                else
                    return "";
            }
        }

        public void LoadDefaultTriggerValues(double lastPrice)
        {
            this.PriceTriggerLow3 = lastPrice * .95;
            this.PriceTriggerLow2 = lastPrice * .97;
            this.PriceTriggerLow1 = lastPrice * .99;

            this.PriceTriggerHigh1 = lastPrice * 1.01;
            this.PriceTriggerHigh2 = lastPrice * 1.02;
            this.PriceTriggerHigh3 = lastPrice * 1.05;

            this.ImpliedGrowthTriggerLow3 = .06;
            this.ImpliedGrowthTriggerLow2 = .05;
            this.ImpliedGrowthTriggerLow1 = .02;

            this.ImpliedGrowthTriggerHigh1 = .01;
            this.ImpliedGrowthTriggerHigh2 = .0;
            this.ImpliedGrowthTriggerHigh3 = -.01;


        }
    }

}