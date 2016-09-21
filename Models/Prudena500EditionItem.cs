using System;
using System.ComponentModel.DataAnnotations;
using Prudena.Web.Models.Valuation.ResidualEarnings;

namespace Prudena.Web.Models
{
    public class Prudena500EditionItem
    {
        #region Properties

        #region Basic Information

        public int ID { get; set; }

        public Guid UID { get; set; }

        public int Rank { get; set; }

        public Prudena500Edition Edition { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string PermanentLinkUrl { get; set; }

        [StringLength(1024)]
        public string Summary { get; set; }

        [StringLength(1024)]
        public string Body { get; set; }

        public string Slug { get; set; }

        public DateTime DateCreated { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }

        public bool PublishEmailSent { get; set; }



        #endregion

        #region Ticker Information

        public Ticker Ticker { get; set; }

        //[Index("IX_Prudena500EditionItem_TickerSymbol", 1, IsUnique = false)]
        [StringLength(64)]
        public string TickerSymbol { get; set; }

        [StringLength(512)]
        public string TickerName { get; set; }

        #endregion

        #region Quote
        public bool QuoteUpdated { get; set; }

        public DateTime QuoteUpdateDate { get; set; }

        public double QuoteLastPrice { get; set; }

        public double QuoteChangeInPercent { get; set; }

        public double QuoteChangeInPercentAbsolute { get; set; }

        public int QuoteChangeRank { get; set; }

        public double QuoteChangeRating { get; set; }

        #endregion

        #region Estimates and Balance Sheet Data

        public bool AnnualEstimateUpdated { get; set; }

        public AnnualEstimate AnnualEstimate { get; set; }

        public AnnualEstimate PreviousAnnualEstimate { get; set; }

        public double PercentChangeInAverageCurrentYearEstimate { get; set; }

        public bool PercentChangeInAverageCurrentYearEstimateUpdated { get; set; }


        public DateTime? AnnualEstimateUpdateDate { get; set; }

        public bool AnnualStatementSummaryUpdated { get; set; }

        public AnnualStatementsSummary AnnualStatementsSummary { get; set; }

        public AnnualStatementsSummary PreviousAnnualStatementsSummary { get; set; }

        public DateTime? AnnualStatementSummaryUpdateDate { get; set; }

        
        #endregion

        #region Very Simple Residual Earnings Models

        public bool VSReModelUpdated { get; set; }

        public VerySimpleResidualEarningsModel VSReModel { get; set; }

        public VerySimpleResidualEarningsModel PreviousVSReModel { get; set; }

        public DateTime? VSReModelUpdateDate { get; set; }
        
        #endregion

        #endregion

    }
}