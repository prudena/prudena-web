using System;
using System.ComponentModel.DataAnnotations;


namespace Prudena.Web.Models
{

    public enum AllocationType
    {
        [Display(Name = "Cash")]
        Cash = 0,
        
        [Display(Name = "US Equities")]
        USEquities = 1,

        [Display(Name = "European Equities")]
        EuropeanEquities = 2,

        [Display(Name = "Emerging Market Equities")]
        EmergingMarketEquities = 3,

        [Display(Name = "Bonds")]
        Bonds = 4,

        [Display(Name = "Commodities")]
        Commodities = 5,
        
        [Display(Name = "Real Estate")]
        RealEstate = 6,
        
        [Display(Name = "Other")]
        Other = 7,
       

    }

    public class PortfolioHolding
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Portfolio HoldingPortfolio { get; set; }

        [Required]
        public Ticker HoldingTicker { get; set; }

        [Required]
        [Display(Name = "Total Shares")]
        public double TotalShares { get; set; }

        [Required]
         [Display(Name = "Next Review")]
        public DateTime NextReviewDate { get; set; }


        [Display(Name = "Review Price")]
        public decimal ExpectedMeanPriceAtNextReview { get; set; }

        [Required]
        [Display(Name = "Expected Volatility")]
        public double ExpectedVolatility { get; set; }

        [Display(Name = "Notify If Below")]
        public decimal NotifyIfBelow { get; set; }

        [Display(Name = "Notify If Above")]
        public decimal NotifyIfAbove { get; set; }

        [Display(Name = "Ruling Reason")]
        public string RulingReason { get; set; }
        [Display(Name = "Counter Argument")]
        public string CounterArgument { get; set; }

        [Display(Name = "Send Email Notification")]
        
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
            if (quote < this.NotifyIfBelow || quote > this.NotifyIfAbove)
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
        [Required]
        public Distribution ExpectedPriceDistribution { get; set; }

        public double ExpectedAnnualReturns { get; set; }
        public AllocationType AllocationType { get { return (AllocationType)AllocationTypeId; } }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public int AllocationTypeId { get; set; }
        public bool NeedsReview
        {
            get
            {
                if (NextReviewDate != null && NextReviewDate < DateTime.UtcNow)
                    return true;
                else
                    return false;
            }
        }
        public string NeedsReviewText
        {
            get
            {
                if (NeedsReview)
                    return "Needs Review";
                else
                    return "OK";
            }
        }

        public bool Archived { get; set; }
        public string Currency { get; set; }
        public decimal TotalValue { get; set; }
        public string AssetClass { get; set; }
    }
}