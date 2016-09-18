using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public class Portfolio : IBurnuliEntity
    {
        #region Properties
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public int? BalanceSheetSeriesId { get; set; }

        [Display(Name = "Cash Holdings")]
        public decimal CashHoldings{ get; set; }

        public DateTime DateCreated { get; set; }
        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public SystemUser Owner { get; set; }


        [Display(Name = "Default Trade Commission")]
        public decimal DefaultTradeCommission { get; set; }

        [Required]
        [Display(Name = "Next Scheduled Review")]
        public DateTime NextScheduledReview { get; set; }      
        
        [Display(Name = "Is Primary")]
        public bool IsPrimary { get; set; }

        [Display(Name = "Is Training")]
        public bool IsTraining { get; set; }

        [Display(Name = "Include In Balance Sheet")]
        public bool IncludeInBalanceSheet { get; set; }

        [Display(Name = "Include In Dashboard")]
        public bool IncludeInDashboard { get; set; }

        [Display(Name = "Include In Morning Monte")]
        public bool IncludeInMorningMonte { get; set; }

        [Display(Name = "Include In Monday Monte")]
        public bool IncludeInMondayMonte { get; set; }

        [Display(Name = "Include In Monthly Monte")]
        public bool IncludeInMonthlyMonte { get; set; }

        public decimal ValuePerShare { get; set; }

        public decimal Shares { get; set; }

        [Display(Name = "Auto Sync Positions with External Data")]
        public bool AutoSynchWithExternalData { get; set; }
        
        public bool SynchedWithExternalData { get; set; }
        public string ExternalPortfolioID { get; set; }
        public string ExternalPortfolioName { get; set; }
        public string ExternalBrokerageName { get; set; }
        public DateTime? LastExternalSynch { get; set; }

        public string ExternalPortfolioFullName
        {
            get
            { if (this.ExternalBrokerageName != string.Empty)
                return this.ExternalBrokerageName + ": " + this.ExternalPortfolioName; 
            else
                return this.ExternalPortfolioName;
            }
        }

        public decimal TotalValue { get; set; }

        public DateTime? LastExternalUpdate { get; set; }

        #endregion

        /*
        public static void SaveQuotesForAllPortfolios()
        {
            BurnuliDBContext db = new BurnuliDBContext();
            List<Portfolio> portfolios = (from p in db.Portfolios
                                            .Include("CreateUser")
                                            .Include("LastModifyUser")
                                            .Include("Owner")
                                            
                    .Where(x => x.Shares > 0) select p).ToList();
            
            foreach (Portfolio portfolio in portfolios)
            {

                PortfolioQuote lastQuote = db.PortfolioQuotes.Where(p => p.Portfolio.ID == portfolio.ID).OrderByDescending(q => q.TradeDate).Take(1).FirstOrDefault();
                bool isFirstQuote = (lastQuote == null) ? true : false;

                var portfolioHoldings = (from p in db.PortfolioHoldings
                      .Include("HoldingTicker")
                      .Include("HoldingPortfolio")
                      .Include("ExpectedPriceDistribution")
                      .Include("CreateUser")
                      .Include("LastModifyUser")
                      .Where(l => l.HoldingPortfolio.ID == portfolio.ID)
                                         select p);

                PortfolioSummary summary = new PortfolioSummary(portfolio, portfolioHoldings.ToList(), true, System.DateTime.Now.AddDays(-1), System.DateTime.Now);
               
                PortfolioQuote pQuote = db.PortfolioQuotes.Create();
                pQuote.LoadPortfolioQuote(summary, portfolio);
                if (isFirstQuote || pQuote.TradeDate != lastQuote.TradeDate)
                {
                    pQuote.DateCreated = DateTime.UtcNow;
                    pQuote.DateModified = DateTime.UtcNow;
                    pQuote.Symbol = string.Empty;
                    db.PortfolioQuotes.Add(pQuote);
                    db.SaveChanges();
                }
            }
            
        }

        public static void SaveQuotes(int id)
        {
            BurnuliDBContext db = new BurnuliDBContext();
            Portfolio portfolio = db.Portfolios.Find(id);

                var portfolioHoldings = (from p in db.PortfolioHoldings
                      .Include("HoldingTicker")
                      .Include("HoldingPortfolio")
                      .Include("ExpectedPriceDistribution")
                      .Where(l => l.HoldingPortfolio.ID == portfolio.ID)
                                         select p);

                PortfolioSummary summary = new PortfolioSummary(portfolio, portfolioHoldings.ToList());

                PortfolioQuote pQuote = db.PortfolioQuotes.Create();
                pQuote.LoadPortfolioQuote(summary, portfolio);
                pQuote.DateCreated = DateTime.UtcNow;
                pQuote.DateModified = DateTime.UtcNow;

                db.PortfolioQuotes.Add(pQuote);
                db.SaveChanges();
        }
        */  

    }
}