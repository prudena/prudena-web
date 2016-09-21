using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public class MorningMonte : IBurnuliEntity
    {
        #region Properties
        
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string PermanentLinkUrl { get; set; }

        public string Slug { get; set; }

        public string Summary { get; set; }

        //Models
        public int FinancialModelTypeID { get; set; }

        public string FinancialModelID { get; set; }

        [StringLength(250)]
        public string FinancialModelUrl { get; set; }

        public int RatingID { get; set; }

        [StringLength(250)]
        public string RatingUrl { get; set; }

        [StringLength(250)]
        public string VideoUrl { get; set; }


        [StringLength(512)]
        public string VideoTitle { get; set; }

        [StringLength(250)]
        [Display(Name = "Market Model Image Url")]
        public string InterpretationOfCurrentMarketPriceImageUrl { get; set; }

        [Display(Name = "Market Discussion")]
        public string InterpretationOfCurrentMarketPriceDiscussion { get; set; }
        
        [Display(Name = "Market Model Link")]
        public string InterpretationOfCurrentMarketPriceLink { get; set; }
        
        [Display(Name = "Market Model ID")]
        public int InterpretationOfCurrentMarketPriceSimpleReModelID { get; set; }
        
        public bool ShowInterpretationOfCurrentMarketPrice { get; set; } 

        [Display(Name = "My Model Image Url")]
        public string OurViewImageUrl { get; set; }
        
        [Display(Name = "My Model Link")]
        public string PlayWithAssumptionsLink { get; set; }

        [Display(Name = "My View Discussion")]
        public string OurViewDiscussion { get; set; }
        [Display(Name = "My Model ID")]
        public int PrimarySimpleReModelID { get; set; }
        
      [Display(Name = "Company Description")]
        public string CompanyDescription { get; set; }

        [Display(Name = "Bull Case")]
        public string BullCase { get; set; }

        [Display(Name = "Bear Case")]
        public string BearCase { get; set; }

        public string Discussion { get; set; }

        public string Conclusions { get; set; }
        
        public DateTime PublishDate { get; set; }
        public bool IsPublished { get; set; }
        public bool ElevateToHomepage { get; set; }
        public bool IsPublic { get; set; }
        public SystemUser Author { get; set; }
       
        public DateTime DateCreated { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public bool PublishEmailSent { get; set; }
        public Ticker Ticker { get; set; }
        public string Symbol { get; set; }
        
        public DateTime LastTradeDate { get; set; }
        //
        // Summary:
        //     The price value of the QuoteBaseData
        [Display(Name = "Last Price")]
        public double LastTradePriceOnly { get; set; }
        //
        // Summary:
        //     The time value of the data
        public DateTime LastTradeTime { get; set; }

        public Guid UID { get; set; }

        [Display(Name = "Include in Calendar")]
        public bool IncludeInCalendar { get; set; }
        public string CalendarTitle { get; set; }

        #endregion
     

    }
}