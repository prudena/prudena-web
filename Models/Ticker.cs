using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public class Ticker : IBurnuliEntity
    {
        public static int NUMBER_FOR_FREE_REPORT = 25;
        public static int NUMBER_OF_ALLOWED_PENDING_REPORT_REQUESTS = 3;
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public int PendingRequestsForReport { get; set; }

        public int AdditionalRequiredRequestsForReport { get; set; }

        public int TotalRequestsRequiredForNewReport { get; set; }

        public bool CurrentUserHasPendingRequest { get; set; }


        [Required]
        //[Index("IX_Ticker_Symbol", 1, IsUnique = true)]
        [StringLength(100)]
        public string Symbol { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }

        public bool HasPrimaryAnalyst { get; set; }

        public int? PrimaryAnalystID { get; set; }

        public bool HasSecondaryAnalist { get; set; }
        public int? SecondaryAnalystID { get; set; }
        public bool IsDow30 { get; set; }
        public bool IsSandP500 { get; set; }
        public bool IsSandP100 { get; set; }
        public bool IsRussell2000 { get; set; }
        public bool IsRussell3000 { get; set; }
        public string CIK { get; set; }
        public string SIC { get; set; }
        public string SICDescription { get; set; }
        public string SICGroup { get; set; }
        public string Sector { get; set; }
        public string CompanyType { get; set; }
        public string Taxonomy { get; set; }
        public string GicsSector { get; set; }
        public string GicsSubIndustry { get; set; }

        public bool OnlineFinancialDataUnavilableViaAPI { get; set; }

        public bool HasDetailedFinancialStatementData { get; set; }
        public string DetailedFinancialStatementTemplateSlug { get; set; }
        public string DetailedFinancialStatementTemplateName { get; set; }
        
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }

        public DateTime? Model101ScreenLastUpdated { get; set; }
        public DateTime? Model201ScreenLastUpdated { get; set; }

        public DateTime? Model301ScreenLastUpdated { get; set; }

        public string LongName { get { return this.Name + " (" + this.Symbol + ")"; } }
        public Ticker() : base()
        {
            DateCreated = DateTime.UtcNow;
            DateModified = DateTime.UtcNow;

        }
    }
}