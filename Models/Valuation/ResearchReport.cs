using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;

namespace Prudena.Web.Models.Valuation
{
    public enum ResearchReportPublishStates
    {
        Private = 0,

        [Description("Public - Free for All")]
        FreeToAll = 1,
        [Description("Public - Free for Members")]
        FreeToMembers = 2,
        [Description("For Sale")]

        ForSale = 3,

    }
    

    public class ResearchReport
    {
        #region Basic Information
        public int ID { get; set; }

        public int StoredResearchReportID { get; set; }
        public bool IsArchived { get; set; }

        public ResearchReportState ResearchReportState { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ticker Name Max Length is 100")]
        [Display(Name = "Report Name")]
        public string Name { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        public string Slug { get; set; }

        #endregion
 
        #region Ticker Information
        public Ticker Ticker { get; set; }

        [StringLength(100, ErrorMessage = "Ticker Symbol Max Length is 100")]
        public string TickerSymbol { get; set; }

        [StringLength(250, ErrorMessage = "Ticker Name Max Length is 250")]
        public string TickerName { get; set; }

        public double LastPriceAtTimeOfRating { get; set; }

        public double LastPrice { get; set; }

        public double LastPriceChangeInPercent { get; set; }

        #endregion

        #region Author Information
        public SystemUser Owner { get; set; }

        [StringLength(100, ErrorMessage = "Username Max Length is 100")]
        public string Username { get; set; }

        public Guid UID { get; set; }

        public int Views { get; set; }

        #endregion

        #region Publish Information

        public ResearchReportPublishStates PublishState { get; set; }

        [Display(Name = "Published")]
        public bool IsPublishedPublicly { get; set; }

        public bool IsPublishedForMembers { get; set; }

        public bool IsPublishedForBasicSubscribers { get; set; }

        [StringLength(250, ErrorMessage = "PUblish Text Max Length is 250")]

        public string PublishText { get; set; }

        public bool IsPublishedForIndividualSale { get; set; }

        public double ListSalePrice { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsFlagged { get; set; }

        public double AggregateResearchReportRating { get; set; }

        public int CommentCount { get; set; }
        #endregion


        #region Content

        public bool IncludeModel { get; set; }

        public bool ModelComplete { get; set; }
        public bool HasModel { get; set; }
        [StringLength(250, ErrorMessage = "Model URL Max Length is 250")]
        public string ModelUrl { get; set; }

        public FinancialModelType FinancialModelType { get; set; }

        public int FinancialModelID { get; set; }

        public bool IncludeSummary { get; set; }

        public string Summary { get; set; }


        public bool IncludeForecast { get; set; }
        public Forecast Forecast { get; set; }

        public bool IncludeIndustryDiscussion { get; set; }
        public bool IndustryDiscussionComplete { get; set; }

        public string IndustryDiscussion { get; set; }


        public bool IncludeCompanyDiscussion { get; set; }
        
        public bool CompanyDiscussionComplete { get; set; }
        public string CompanyDiscussion { get; set; }


        public bool IncludeFinancialStatementsDiscussion { get; set; }
        public bool FinancialStatementsDiscussionComplete { get; set; }

        public string FinancialStatementsDiscussion { get; set; }

        public bool ConclusionsComplete { get; set; }
        public string Conclusions { get; set; }

        public bool IncludeRating { get; set; }
        public UserTickerRating Rating { get; set; }

        public string PrivateNotes { get; set; }

        public bool IncludeVideo { get; set; }

        [StringLength(512, ErrorMessage = "Model URL Max Length is 512")]

        public string VideoCaption { get; set; }

        [StringLength(250, ErrorMessage = "Video URL Max Length is 250")]

        public string VideoURL { get; set; }

        /*
        public void LoadForecast(BurnuliDBContext db)
        {
            if (this.Forecast == null)
                this.Forecast = new Forecast();

            if (HasModel)
            {
                if (FinancialModelType == FinancialModelType.Model101)
                {
                    MarginOfSafetyMonteCarlo model = new Burnuli.ViewModels.MarginOfSafetyMonteCarlo();
                    model.VsReModel = new VerySimpleResidualEarningsModel();

                    SimpleResidualEarningsModel savedModel = db.SimpleResidualEarningsModels.Include("Ticker").Include("CreateUser").Where(m => m.ID == FinancialModelID).FirstOrDefault();
                    if (savedModel != null)
                    {
                        Forecast.RequiredReturn = savedModel.CostOfCapitalEquity;
                    }
                    else
                    {
                        HasModel = false;
                    }
                }
                else if(this.FinancialModelType == FinancialModelType.Model201)
                {
                    Model201 model201 = db.Model201s.Where(m => m.ID == FinancialModelID).FirstOrDefault();

                    if (model201 != null)
                    {
                        Forecast.RequiredReturn = model201.CostOfCapital;
                    }
                    else
                    {
                        HasModel = false;
                    }
                }
                
            }

        }
        */
        public void SetPublishText()
        {
            if (IsPublishedPublicly)
            {
                PublishText = "Free";
            }
            else if (IsPublishedForMembers)
            {
                PublishText = "Free for Members";
            }
            else if (IsPublishedForBasicSubscribers)
            {
                PublishText = "Free for Subscribers";
            }
            else if (IsPublishedForIndividualSale)
            {
                PublishText = "For Sale: $" + string.Format("{0:#,##0.00}", this.ListSalePrice);
            }
            else
                PublishText = "Private";
            
        }
        #endregion

    }
}