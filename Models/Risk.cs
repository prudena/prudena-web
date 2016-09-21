using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public enum RiskType
    {
        Threat = 0,
        Opportunity = 1,
    }

    public enum RiskState
    {
        Open = 0,
        Closed = 1,
    }

    public enum QualitativeRiskRating
    {

         [DescriptionAttribute("Very Low")]
        VeryLow = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        [DescriptionAttribute("Very High")]
        VeryHigh = 4
    }

    public enum RiskTreatmentType
    {
        Accept = 0,
        Mitigate = 1,
        Transfer = 2,
        Exploit = 3
    }

    public class Risk
    {
        public int ID { get; set; }
        public RiskRegister RiskRegister { get; set; }

       [Display(Name = "Cause")]
        public string CauseDescription  { get; set; }
       
        [Required]
        [Display(Name = "Risk (Threat or Opportunity)")]
        public string RiskDescription { get; set; }

        [Display(Name = "Impact")]
        public string ImpactDescription { get; set; }

        [Display(Name = "Mitigation/Action")]
        public string MitigationDescription { get; set; }

        [Display(Name = "Control")]
        public string ControlDescription { get; set; }
        
        public RiskType RiskType { get { return (RiskType)RiskTypeId; } }
        public string RiskTypeText { get; set; }
        public int RiskTypeId { get; set; }
        public RiskState State { get { return (RiskState)StateId; } }
        public string StateText{ get; set; }
        public int StateId { get; set; }

        [Display(Name = "Treatment")]
        public RiskTreatmentType RiskTreatmentType { get { return (RiskTreatmentType)RiskTypeId; } }
        public int RiskTreatmentTypeId { get; set; }
        public string RiskTreatmentText { get; set; }
        public string Notes { get; set; }

        [Display(Name = "Probability")]
        
        public QualitativeRiskRating QualitativeProbability { get { return (QualitativeRiskRating)QualitativeProbabilityId; } }
        public string QualitativeProbabilityText { get; set; }
        public int QualitativeProbabilityId { get; set; }

        [Display(Name = "Impact")]
        
        public QualitativeRiskRating QualitativeImpact { get { return (QualitativeRiskRating)QualitativeImpactId; } }
        public int QualitativeImpactId { get; set; }
        public string QualitativeImpactText { get; set; }

        public QualitativeRiskRating QualitativeExposure { get { return (QualitativeRiskRating)QualitativeExposureId; } }
        public int QualitativeExposureId { get; set; }
        public string QualitativeExposureText { get; set; }

         [Display(Name = "Residual Exposure")]
        public QualitativeRiskRating QualitativeResidualExposure { get { return (QualitativeRiskRating)QualitativeResidualExposureId; } }
        public int QualitativeResidualExposureId { get; set; }
        public string QualitativeResidualExposureText { get; set; }

        public void SetQualitativeExposure() {

            if (QualitativeProbability == QualitativeRiskRating.VeryHigh)
            {
                if (QualitativeImpact == QualitativeRiskRating.VeryLow)
                    QualitativeExposureId = (int)QualitativeRiskRating.Medium;
                else if (QualitativeImpact == QualitativeRiskRating.Low)
                    QualitativeExposureId = (int)QualitativeRiskRating.High;
                else 
                    QualitativeExposureId = (int)QualitativeRiskRating.VeryHigh;

            }
            else if (QualitativeProbability == QualitativeRiskRating.High)
            {
                if (QualitativeImpact == QualitativeRiskRating.VeryLow)
                    QualitativeExposureId = (int)QualitativeRiskRating.Low;
                else if (QualitativeImpact == QualitativeRiskRating.Low)
                    QualitativeExposureId = (int)QualitativeRiskRating.Medium;
                else if (QualitativeImpact == QualitativeRiskRating.Medium)
                    QualitativeExposureId = (int)QualitativeRiskRating.High;
                else
                    QualitativeExposureId = (int)QualitativeRiskRating.VeryHigh;
            }
            else if (QualitativeProbability == QualitativeRiskRating.Medium)
            {
                if (QualitativeImpact == QualitativeRiskRating.VeryLow)
                    QualitativeExposureId = (int)QualitativeRiskRating.Low;
                else if (QualitativeImpact == QualitativeRiskRating.Low)
                    QualitativeExposureId = (int)QualitativeRiskRating.Medium;
                else if (QualitativeImpact == QualitativeRiskRating.Medium)
                    QualitativeExposureId = (int)QualitativeRiskRating.Medium;
                else if (QualitativeImpact == QualitativeRiskRating.High)
                    QualitativeExposureId = (int)QualitativeRiskRating.High;
                else
                    QualitativeExposureId = (int)QualitativeRiskRating.VeryHigh;
            }
            else if (QualitativeProbability == QualitativeRiskRating.Low)
            {
                if (QualitativeImpact == QualitativeRiskRating.VeryLow)
                    QualitativeExposureId = (int)QualitativeRiskRating.VeryLow;
                else if (QualitativeImpact == QualitativeRiskRating.Low)
                    QualitativeExposureId = (int)QualitativeRiskRating.Low;
                else if (QualitativeImpact == QualitativeRiskRating.Medium)
                    QualitativeExposureId = (int)QualitativeRiskRating.Medium;
                else if (QualitativeImpact == QualitativeRiskRating.High)
                    QualitativeExposureId = (int)QualitativeRiskRating.Medium;
                else
                    QualitativeExposureId = (int)QualitativeRiskRating.High;
            }
            else if (QualitativeProbability == QualitativeRiskRating.VeryLow)
            {
                if (QualitativeImpact == QualitativeRiskRating.VeryLow)
                    QualitativeExposureId = (int)QualitativeRiskRating.VeryLow;
                else if (QualitativeImpact == QualitativeRiskRating.Low)
                    QualitativeExposureId = (int)QualitativeRiskRating.VeryLow;
                else if (QualitativeImpact == QualitativeRiskRating.Medium)
                    QualitativeExposureId = (int)QualitativeRiskRating.Low;
                else if (QualitativeImpact == QualitativeRiskRating.High)
                    QualitativeExposureId = (int)QualitativeRiskRating.Low;
                else
                    QualitativeExposureId = (int)QualitativeRiskRating.Medium;
            }
            QualitativeExposureText = QualitativeExposure.ToDescription();
        }

        public double QuantitativeProbabilityHigh { get; set; }
        public double QuantitativeProbabilityLikely { get; set; }
        public double QuantitativeProbabilityLow { get; set; }
        
        public double QuantitativeImpactHigh { get; set; }
        public double QuantitativeImpactLikely { get; set; }
        public double QuantitativeImpactLow { get; set; }

        public double QuantitativeExposureHigh { get; set; }
        public double QuantitativeExposureLikely { get; set; }
        public double QuantitativeExposureLow { get; set; }

        public double QuantitativeResidualExposureHigh { get; set; }
        public double QuantitativeResidualExposureLikely { get; set; }
        public double QuantitativeResidualExposureLow { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public SystemUser Owner { get; set; }


        public void SetTextValues()
        {
            QualitativeImpactText = QualitativeImpact.ToDescription();
            QualitativeProbabilityText = QualitativeProbability.ToDescription();
            SetQualitativeExposure();
            QualitativeExposureText = QualitativeExposure.ToDescription();
            QualitativeResidualExposureText = QualitativeResidualExposure.ToDescription();
            
            StateText = State.ToString();
            RiskTypeText = RiskType.ToString();
            
        }
        /*
        public static string GetQualitativeRiskRatingDisplayName(object member)
        {
            string returnString = string.Empty; // enumItem.ToString();

            foreach (object attribute in member.GetType().GetCustomAttributes(true))
            {
                Console.WriteLine(attribute);
            }
            return returnString;
        }
        */
    }
}