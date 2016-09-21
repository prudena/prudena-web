using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public class UserResearchReport
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public SystemUser ReportOwner { get; set; }

        [Required]
        public int ReportAuthorID { get; set; }
        [StringLength(1024)]

        public string ReportName { get; set; }
        [StringLength(512)]

        public string ReportAuthorName { get; set; }


        public bool OwnerIsAuthor { get; set; }

        [Required]
        public int ResearchReportID { get; set; }

        //[Index("IX_UserResearchReport_TickerSymbol", 1, IsUnique = false)]
        [StringLength(100)]
        public string TickerSymbol { get; set; }

        [StringLength(512)]
        public string TickerName { get; set; }

        [StringLength(512)]
        public string StripeChargeId { get; set; }

        [StringLength(512)]
        public string StripeStatus { get; set; }



        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }

        public bool IsFavorite { get; set; }
        
        public double ReportPrice { get; set; }

        public double TaxCollected { get; set; }

        public double TotalPricePaid { get; set; }
        public bool HasPaid { get; set; }

        public bool ReportIncludedInSubscription { get; set; }

        public bool RequiresPayment { get; set; }

        public bool CanAccessReport { get; set; }

        public string ReportNotes { get; set; }


    }

}