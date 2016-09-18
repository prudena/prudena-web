using System;

using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public  enum DashboardType
    {
        Default = 0,
        HoldingsList = 1,
        News = 2,
        Analyst = 3,
        Investor = 4
    }
    public class Dashboard : IBurnuliEntity
    {
        #region Properties
        
        public int ID { get; set; }
        
        public string Symbol { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal CashHoldings{ get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        
        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public SystemUser Owner { get; set; }

        [Required]
        [Display(Name = "Next Scheduled Review")]
        public DateTime NextScheduledReview { get; set; }      
        
        [Display(Name = "Is Primary")]
        public bool IsPrimary { get; set; }

        public decimal ValuePerShare { get; set; }
        public decimal Shares { get; set; }

        #endregion


    }
}