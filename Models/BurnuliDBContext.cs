using Microsoft.EntityFrameworkCore;
using Prudena.Web.Models.Valuation;
using Prudena.Web.Models.Valuation.ResidualEarnings;
using Prudena.Web.Models.Predictions;
using Prudena.Web.Models.Blogs;

namespace Prudena.Web.Models
{
    public class BurnuliDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        //System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Prudena.Web.Models.BurnuliDBContext>());
        /*
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VerySimpleResidualEarningsModel>().Property(o => o.ImpliedGrowthRate).HasPrecision(28, 10);
            modelBuilder.Entity<SystemUser>().Property(o => o.DefaultRequiredReturn).HasPrecision(28, 10);

            base.OnModelCreating(modelBuilder);
        }
        */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["BloggingDatabase"].ConnectionString);
        }
        public DbSet<SimpleResidualEarningsModel> SimpleResidualEarningsModels { get; set; }
        public DbSet<VerySimpleResidualEarningsModel> VerySimpleResidualEarningsModels { get; set; }

        public DbSet<PressRelease> PressReleases { get; set; }

        public DbSet<Model201> Model201s { get; set; }

        public DbSet<Model301> Model301s { get; set; }

        //public DbSet<MarketStripeCharge> MarketStripeCharges { get; set; }

        public DbSet<StoredImage> StoredImages { get; set; }

        public DbSet<StoredReport> StoredReports { get; set; }

        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<DashboardQuote> DashboardQuotes { get; set; }
        
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioHolding> PortfolioHoldings { get; set; }
        public DbSet<PortfolioQuote> PortfolioQuotes { get; set; }
        
        public DbSet<Ticker> Tickers { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<BalanceSheetSeries> BalanceSheetSeries { get; set; }
        public DbSet<BalanceSheet> BalanceSheets { get; set; }

        public DbSet<Prudena.Web.Models.Trade> Trades { get; set; }
       
        public DbSet<Prudena.Web.Models.Asset> Assets { get; set; }

        public DbSet<Prudena.Web.Models.Valuation.Schema> Schemata { get; set; }
        public DbSet<Prudena.Web.Models.Valuation.TickerAnnualHistoricalRatioSet> TickerAnnualHistoricalRatioSets { get; set; }

        public DbSet<PortfolioPermission> PortfolioPermissions { get; set; }

        public DbSet<RiskRegister> RiskRegisters { get; set; }

        public DbSet<Risk> Risks { get; set; }
        public DbSet<Topic> Topics { get; set; }


        public DbSet<FinancialStatementTagDefinition> FinancialStatementTagDefinitions { get; set; }

        public DbSet<AnnualEstimate> AnnualEstimates { get; set; }
        public DbSet<AnnualStatementsSummary> AnnualStatementsSummaries { get; set; }
        public DbSet<MorningMonteRun> MorningMonteRuns { get; set; }
        public DbSet<EventLogItem> EventLogItems { get; set; }

        public DbSet<StatementFinancialTagDefinition> StatementFinancialTagDefinitions { get; set; }
        public DbSet<UserFinancialStatementTagSet> UserFinancialStatementTagSets { get; set; }
        public DbSet<UserFinancialStatementTagDefinition> UserFinancialStatementTagDefinitions { get; set; }
        public DbSet<UserFinancialStatementTagSetItem> UserFinancialStatementTagSetItems { get; set; }

        public DbSet<TickerAttributeType> TickerAttributeTypes { get; set; }

        public DbSet<TickerAttribute> TickerAttributes { get; set; }
        public DbSet<TickerAttributeItem> TickerAttributeItems { get; set; }

        public DbSet<MorningMonte> MorningMontes { get; set; }
        public DbSet<MorningMonteComment> MorningMonteComments { get; set; }

        public DbSet<ResearchReportComment> ResearchReportComments { get; set; }

        public DbSet<ResearchReportRequest> ResearchReportRequests { get; set; }

        public DbSet<UserResearchReport> UserResearchReports { get; set; }


        public DbSet<UserTicker> UserTickers { get; set; }

        public DbSet<UserTickerRating> UserTickerRatings { get; set; }
        public DbSet<UserNewsItem> UserNewsItems { get; set; }
        public DbSet<NewsSource> NewsSources { get; set; }
        public DbSet<UserNewsSource> UserNewsSources { get; set; }
        public DbSet<TaggedNewsItem> TaggedNewsItems { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogEntry> BlogEntries { get; set; }
        public DbSet<BlogEntryComment> Blogentrycomments { get; set; }

        public DbSet<LendingClubLoan> LendingClubLoans { get; set; }

        public DbSet<Forecast> Forecasts { get; set; }

        public DbSet<ResearchReport> ResearchReports { get; set; }
        
        public DbSet<Prediction> Predictions { get; set; }

        public DbSet<PredictionQuestion> PredictionQuestions { get; set; }

        public DbSet<PredictionBucket> PredictionBuckets { get; set; }

        public DbSet<PredictionQuestionFollower> PredictionQuestionFollower { get; set; }

        public DbSet<PredictionRating> PredictionRating { get; set; }

        public DbSet<QuestionBucket> QuestionBuckets { get; set; }

        public DbSet<Prudena500Edition> Prudena500Editions { get; set; }
        public DbSet<Prudena500EditionItem> Prudena500EditionItems { get; set; }

    }
}
