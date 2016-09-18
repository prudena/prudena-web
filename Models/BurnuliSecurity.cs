using System.Security.Principal;

namespace Prudena.Web.Models
{
    public class BurnuliSecurity
    {
        #region Constants

        public const string ADMINISTRATOR = "Administrator";
        public const string SUPER_USER = "SuperUser";
        public const string PREMIUM_SUBSCRIBER = "PremiumSubscriber";
        public const string BASIC_SUBSCRIBER = "BasicSubscriber";
        public const string NEWS_SUBSCRIBER = "NewsSubscriber";
        public const string SYSTEM_USER = "SystemUser";
        public const string REGMETRICS_ADMIN = "RegMetricsAdmin";
        public const string REGMETRICS_SUBSCRIBER = "RegMetricsSubscriber";
        public const string EXTERNAL_BROKERAGE_USER = "ExternalBrokerageUser";
        public const string CONTENT_EDITOR = "ContentEditor";
        public const string CONTENT_CONTRIBUTOR = "ContentContributor";
        public const string FIXED_INCOME_USER = "FixedIncomeUser";
     


        #endregion

        #region Permissions Enum

        public enum BurnuliPermissions
        {
            AccessSandP500RiskScreen = 1,
            AccessSandP100RiskScreen = 2 ,
            ImpliedGrowthRateCalculatorAccess = 3,
            FilingsView = 4,
            FilingsLatestView = 5,
            MarginOfSafetyAccess = 6,
            FadeFactorAccess = 7,
            FadeFactorMonteCarloAccess = 8,
            ComponentFactTableAccess = 9,
            MarginOfSafetyMonteCarloAccess = 10,
            AccessFunadementals = 11,
            AccessRegMetricsRatings = 12,
            AccessExternalAccountData = 13,
            AccessFundamentalStats = 14,
            AccessNewContructsRatings = 15,
            AccessMorningMonte = 16,
            AccessModel301 = 17,
            AccessModel201 = 18


        }

        #endregion

        #region Static Methods

        public static bool HasBasicSubscriberPermissions(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return false;

            if (user.IsInRole(BurnuliSecurity.BASIC_SUBSCRIBER)
                || user.IsInRole(BurnuliSecurity.PREMIUM_SUBSCRIBER)
                || user.IsInRole(BurnuliSecurity.ADMINISTRATOR)

                )
            {
                return true;
            }

            return false;

        }

        public static bool HasPremiumSubscriberPermissions(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return false;

            if (user.IsInRole(BurnuliSecurity.PREMIUM_SUBSCRIBER)
                || user.IsInRole(BurnuliSecurity.ADMINISTRATOR)

                )
            {
                return true;
            }

            return false;

        }

        public static bool HasAdministratorPermissions(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return false;

            if (user.IsInRole(BurnuliSecurity.ADMINISTRATOR))
            {
                return true;
            }

            return false;

        }

        public static bool HasRegMetrcsAdminPermissions(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return false;

            if (user.IsInRole(BurnuliSecurity.ADMINISTRATOR)  || user.IsInRole(BurnuliSecurity.REGMETRICS_ADMIN))
            {
                return true;
            }

            return false;

        }

        public static bool HasPermission(IPrincipal user, BurnuliPermissions permission)
        {
            
            switch (permission)
            {
                case BurnuliPermissions.AccessSandP500RiskScreen:
                    return AccessSandP500RiskScreen(user);
                case BurnuliPermissions.AccessSandP100RiskScreen:
                    return AccessSandP100RiskScreen(user);
                case BurnuliPermissions.AccessExternalAccountData:
                    return AccessExternalAccountData(user);
                case BurnuliPermissions.AccessFundamentalStats:
                    return AccessFundamentalStats(user);
                case BurnuliPermissions.AccessNewContructsRatings:
                    return AccessNewContructsRatings(user);
                case BurnuliPermissions.AccessMorningMonte:
                    return AccessMorningMonte(user);
                default:
                    return false;
                    
            }
        }

        public static bool HasPermission(IPrincipal user, BurnuliPermissions permission, Ticker ticker)
        {

            switch (permission)
            {
                case BurnuliPermissions.FilingsView:
                    return FilingsView(user, ticker);
                case BurnuliPermissions.FilingsLatestView:
                    return LatestFilingsView(user, ticker);
                case BurnuliPermissions.ImpliedGrowthRateCalculatorAccess:
                    return ImpliedGrowthRateCalculatorAccess(user, ticker);
                case BurnuliPermissions.MarginOfSafetyAccess:
                    return MarginOfSafetyAccess(user, ticker);
                case BurnuliPermissions.FadeFactorAccess:
                    return FadeFactorAccess(user, ticker);
                case BurnuliPermissions.ComponentFactTableAccess:
                    return ComponentFactTableAccess(user, ticker);
                case BurnuliPermissions.MarginOfSafetyMonteCarloAccess:
                    return MarginOfSafetyMonteCarloAccess(user, ticker);
                case BurnuliPermissions.AccessFunadementals:
                    return AccessFundamentals(user, ticker);
                case BurnuliPermissions.AccessRegMetricsRatings:
                    return AccessRegMetricsRatings(user, ticker);
                case BurnuliPermissions.AccessModel301:
                    return AccessModel301(user, ticker);
                case BurnuliPermissions.AccessModel201:
                    return AccessModel201(user, ticker);
                default:
                    return false;
                    
            }
        }

        #endregion

        #region Basic Features

        private static bool AccessSandP100RiskScreen(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return false;
            else
                return true;
        }

        private static bool AccessSandP500RiskScreen(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return false;

           return true;
        }

        private static bool AccessExternalAccountData(IPrincipal user)
        {
           return (HasAdministratorPermissions(user)  || user.IsInRole(EXTERNAL_BROKERAGE_USER));

        }

        private static bool ImpliedGrowthRateCalculatorAccess(IPrincipal user, Ticker ticker)
        {
            //promotional
            return true;
        }

        private static bool MarginOfSafetyAccess(IPrincipal user, Ticker ticker)
        {
            return true;
            /*
            if (ticker.IsDow30)
                return true;

            if (!user.Identity.IsAuthenticated)
                return false;

            if (ticker.IsSandP500)
                return true;

            if (HasBasicSubscriberPermissions(user))
                return true;

            return false;
             * */
        }

        private static bool AccessNewContructsRatings(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return false;

            else 
                return true;

        }

        private static bool AccessMorningMonte(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return false;
            else 
                return true;

        }
        private static bool AccessFundamentalStats(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return false;

            return true;

        }

        private static bool AccessFundamentals(IPrincipal user, Ticker ticker)
        {
            
            if (ticker.IsSandP500)
                return true;

            if (!user.Identity.IsAuthenticated)
                return false;

            return true;
        
        }

        private static bool AccessRegMetricsRatings(IPrincipal user, Ticker ticker)
        {
            return HasRegMetrcsAdminPermissions(user);
        }

        private static bool FadeFactorAccess(IPrincipal user, Ticker ticker)
        {
            return true;

            
        }

        private static bool MarginOfSafetyMonteCarloAccess(IPrincipal user, Ticker ticker)
        {
            if (ticker.IsDow30)
                return true;

            if (!user.Identity.IsAuthenticated)
                return false;
      
            return true;
        }

        #endregion

        #region Advanced Features

        private static bool FilingsView(IPrincipal user, Ticker ticker)
        {
            if (ticker.IsDow30)
                return true;

            if (!user.Identity.IsAuthenticated)
                return false;

            if (ticker.IsSandP500)
                return true;

            if (HasBasicSubscriberPermissions(user))
                return true;

            return false;
        }

        private static bool LatestFilingsView(IPrincipal user, Ticker ticker)
        {
            if (ticker.IsDow30)
                return true;

            if (!user.Identity.IsAuthenticated)
                return false;

            if (ticker.IsSandP500)
                return true;

            if (HasBasicSubscriberPermissions(user))
                return true;

            return false;
        }

        private static bool AccessModel301(IPrincipal user, Ticker ticker)
        {
            if (!user.Identity.IsAuthenticated)
                return false;

            if (HasAdministratorPermissions(user))
                return true;

            if (ticker.IsDow30)
                return true;

            if (ticker.IsSandP500 && HasBasicSubscriberPermissions(user))
                return true;

            if (HasPremiumSubscriberPermissions(user))
                return true;

            return false;

        }

        private static bool AccessModel201(IPrincipal user, Ticker ticker)
        {
            if (!user.Identity.IsAuthenticated)
                return false;

            if (HasAdministratorPermissions(user))
                return true;

          
            if (ticker.IsSandP500 || HasBasicSubscriberPermissions(user))
                return true;

            if (HasPremiumSubscriberPermissions(user))
                return true;

            return false;

        }

        

        private static bool ComponentFactTableAccess(IPrincipal user, Ticker ticker)
        {
            if (ticker.IsDow30)
                return true;

            if (!user.Identity.IsAuthenticated)
                return false;

            if (HasBasicSubscriberPermissions(user))
                return true;

            return false;
        }

        #endregion




    }

    
}