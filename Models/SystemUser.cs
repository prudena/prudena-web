using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public class SystemUser 
    {
        #region Basic Properties
        public int ID { get; set; }
        public string Name { get; set; }
        
        [Required]
        //[Index("IX_SystemUser_Username", 1, IsUnique = true)]
        [Display(Name = "Username")]
        [StringLength(100)]
        public string UserName { get; set; }

         [Display(Name = "Stripe Customer ID")]
        [StringLength(100)]
        public string StripeCustomerId { get; set; }

        public string DisplayUsername { get
            {
                if (this.UserName.Contains("@")  || this.UserName == this.Email)
                    return "Not Set";
                else
                    return this.UserName;
            } }

        //[Index("IX_SystemUser_Email", 1, IsUnique = true)]
        [Display(Name = "Email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated{ get; set; }
        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; }
        [Display(Name = "Last Logon")]
        public DateTime LastLogon { get; set; }
        [Display(Name = "Last Logon IP")]
        public string LastLogonIpAddress { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Is Approved")]
        public bool IsApproved { get; set; }

        [Display(Name = "Pending Email Approval")]
        public bool PendingEmailApproval { get; set; }
        
        [Display(Name = "API Key")]
        public string ApiKey { get; set; }

        [Display(Name = "Email Confirmation Key")]
        public string EmailConfirmationKey { get; set; }

        public bool ShowWelcomeScreen { get; set; }

        public int DefaultDashboardTypeID { get; set; }

        public DashboardType DefaultDashboardType { get
            {
                return (DashboardType)DefaultDashboardTypeID;
            } }
        #endregion

        #region Basic User Settings

        [Display(Name = "Default Trade Commission")]
        public decimal DefaultTradeCommission { get; set; }

        [Display(Name = "Receive Promotional and Product Update Emails (From Prudena Only)")]
        public bool ReceivePromotionalEmails { get; set; }

        [Display(Name = "Receive Newletter")]

        public bool ReceiveNewsletter { get; set; }

        [Display(Name = "Receive the Morning Monte Email")]
        public bool ReceiveMorningMonte { get; set; }

        [Display(Name = "Receive the Monthly Monte Email")]
        public bool ReceiveMonthlyMonte { get; set; }

        [Display(Name = "Receive the Monday Monte Email")]
        public bool ReceiveMondayMonte { get; set; }

        public string HowDidYouHearAboutUs { get; set; }

        public long NumberOfLoginsTotal { get; set; }

        [Display(Name = "Registration Coupon Code")]
        public string RegistrationCouponCode { get; set; }

        [Display(Name = "Check Here to Accept Our Terms and Contitions")]

        public bool AcceptedTermsAndConditions { get; set; }

        public DateTime? AcceptedTermsAndConditionsDate { get; set; }

        [Display(Name = "Registration IP")]
        public string RegistrationIpAddress { get; set; }


        [Display(Name = "My Default Required Return")]
       
        public decimal DefaultRequiredReturn { get; set; }

        public string ColorTriggerLow1 { get; set; }
        public string ColorTriggerLow2 { get; set; }
        public string ColorTriggerLow3 { get; set; }
        public string ColorTriggerHigh1 { get; set; }
        public string ColorTriggerHigh2 { get; set; }
        public string ColorTriggerHigh3 { get; set; }
        public string ColorNormal { get; set; }

        [Display(Name = "Moderately Bad")]
        public double PercentTriggerLow1 { get; set; }
        [Display(Name = "Very Bad")]
        public double PercentTriggerLow2 { get; set; }
        [Display(Name = "Extremely Bad")]
        public double PercentTriggerLow3 { get; set; }
        [Display(Name = "Moderately Good")]
        public double PercentTriggerHigh1 { get; set; }
        [Display(Name = "Very Good")]
        public double PercentTriggerHigh2 { get; set; }
        [Display(Name = "Extremely Good")]
        public double PercentTriggerHigh3 { get; set; }

        [Display(Name = "Reset Price Heat Map Nightly")]
        public bool ResetPriceHeatMapNightly { get; set; }

        #endregion

        #region Profile Stuff

        [Display(Name = "Profile Is Public")]
        public bool ProfileIsPublic { get; set; }

        public int ProfileImageID { get; set; }


        [Display(Name = "Profile Summary")]
        public string ProfileSummary { get; set; }

        [Display(Name = "Profile Description")]
        public string ProfileDescription { get; set; }

        [Display(Name = "Show Name In Profile")]
        public bool ShowNameInUserDirectory { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Rank")]
        public int Rank { get; set; }

        [Display(Name = "Total Points")]
        public int TotalPoints { get; set; }

        [Display(Name = "Unused Points")]
        public int UnusedPoints { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Profile Flagged as Inappropriate")]
        public bool ProfileFlaggedAsInappropriate { get; set; }

        [Url]
        [Display(Name = "Professions Profile URL (e.g. LinkedIn)")]
        public string LinkedInProfileUrl { get; set; }

        [Url]
        [Display(Name = "Personal Url/Blog")]
        public string PersonalUrl { get; set; }

        #endregion

        #region Public Methods

        public void SetDefaultColors()
        {
            this.ColorNormal = "#DDDDDD";
            this.ColorTriggerLow3 = "#8F0000";
            this.ColorTriggerLow2 = "#DB4D4D";
            this.ColorTriggerLow1 = "#F5CCCC";

            this.ColorTriggerHigh1 = "#B2D1B2";
            this.ColorTriggerHigh2 = "#66A366";
            this.ColorTriggerHigh3 = "#006600";

        }

        #endregion
    }
}