using System;
using System.Collections.Generic;
using System.Linq;

namespace Prudena.Web.Models
{
   
    public class BalanceSheetSeries : BurnuliBaseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public SystemUser Owner { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public bool HasDefaultValues { get; set; }
        public Portfolio Portfolio { get; set; }
        public string Notes { get; set; }

        List<BalanceSheet> BalanceSheets { get; set; }

        public static void CreateDefaultBalanceSheet(BurnuliDBContext db, SystemUser currentUser)
        {
           /*
            BalanceSheetSeries balanceSheets = db.BalanceSheetSeries.Create();
            balanceSheets.Owner = currentUser;
            balanceSheets.DateCreated = DateTime.UtcNow;
            balanceSheets.DateModified = DateTime.UtcNow;
            balanceSheets.CreateUser = currentUser;
            balanceSheets.LastModifyUser = currentUser;
            balanceSheets.Name = @Resources.Resources.DefaultBalanceSheetName;
            balanceSheets.IsPrimary = true;
            balanceSheets.HasDefaultValues = true;
            db.BalanceSheetSeries.Add(balanceSheets);
            db.SaveChanges();

            BalanceSheet newBalanceSheet = db.BalanceSheets.Create();
            newBalanceSheet.BalanceSheetSeries = balanceSheets;
            newBalanceSheet.DateCreated = DateTime.UtcNow;
            newBalanceSheet.DateModified = DateTime.UtcNow;
            newBalanceSheet.LastModifyUser = currentUser;
            newBalanceSheet.CreateUser = currentUser;
            newBalanceSheet.BalanceSheetDate = DateTime.UtcNow;
            newBalanceSheet.CurrentAssets = 10;
            newBalanceSheet.PortfolioAssets = 50;
            newBalanceSheet.FixedAssets = 20;
            newBalanceSheet.OtherAssets = 2;
            newBalanceSheet.CurrentLiabilities = 2;
            newBalanceSheet.LongTermLiabilities = 5;
            newBalanceSheet.OtherLiabilities = 1;
            newBalanceSheet.IsCurrent = true;
            newBalanceSheet.NextScheduledReview = DateTime.UtcNow;

            db.BalanceSheets.Add(newBalanceSheet);
            db.SaveChanges();

            Portfolio primaryPorfolio = db.Portfolios.Create();
            primaryPorfolio.Owner = currentUser;
            primaryPorfolio.NextScheduledReview = DateTime.UtcNow;
            primaryPorfolio.DateCreated = DateTime.UtcNow;
            primaryPorfolio.DateModified = DateTime.UtcNow;
            primaryPorfolio.LastModifyUser = currentUser;
            primaryPorfolio.CreateUser = currentUser;
            primaryPorfolio.Name = @Resources.Resources.DefaultPrimaryPortfolioName;
            primaryPorfolio.IsPrimary = true;
            primaryPorfolio.IsTraining = false;
            primaryPorfolio.Shares = 100;
            primaryPorfolio.IncludeInBalanceSheet = true;
            primaryPorfolio.IncludeInDashboard = true;
            primaryPorfolio.BalanceSheetSeriesId = balanceSheets.ID;
            db.Portfolios.Add(primaryPorfolio);
            balanceSheets.Portfolio = primaryPorfolio;
            db.SaveChanges();

        */    

        }

    }
}