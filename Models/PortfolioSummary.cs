using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Prudena.Web.Models
{
    [DataContract(Name = "PortfolioSummary")]
    public class PortfolioSummary 
    {
        
        [DataMember(Name = "PortfolioId")]
        public int PortfolioId { get; set; }



        [DataMember(Name = "PortfolioName")]
        public string PortfolioName { get; set; }

        [DataMember(Name = "CashHoldings")]
        public decimal CashHoldings { get; set; }

        [DataMember(Name = "PortfolioHoldings")]
        public List<PortfolioHoldingSummary>  PortfolioHoldings { get; set; }

        [DataMember(Name = "PortfolioTickerSummaries")]
        public List<PortfolioHoldingSummary> PortfolioTickerSummaries { get; set; }

        //[DataMember(Name = "PortfolioTreemap")]
        //public PortfolioTreemap PortfolioTreemap { get; set; }


        [DataMember(Name = "PortfolioTickers")]
        public List<PortfolioHoldingSummary> PortfolioTickers { get; set; }

        [DataMember(Name = "PortfolioAllocation")]
        public List<PortfolioHoldingSummary> PortfolioAllocation { get; set; }

        [DataMember(Name = "TotalValue")]
        public decimal TotalValue { get; set; }

        [DataMember(Name = "Shares")]
        public decimal Shares { get; set; }

        [DataMember(Name = "ValuePerShare")]
        public decimal ValuePerShare { get; set; }

        public PortfolioSummary()
        {
        }
        /*
        public PortfolioSummary(Portfolio portfolio, IEnumerable<PortfolioHolding> holdings) : this (portfolio, holdings, false, DateTime.UtcNow, DateTime.UtcNow)
        {
            
        }
        */
        /*
        public PortfolioSummary(Portfolio portfolio, IEnumerable<PortfolioHolding> holdings, bool historical, DateTime? fromDate, DateTime? toDate)
        {
            
            PortfolioId = portfolio.ID;
            PortfolioName = portfolio.Name;
            PortfolioHoldings = new List<PortfolioHoldingSummary>();
            Shares = portfolio.Shares;
            CashHoldings = portfolio.CashHoldings;
            PortfolioTickers = new List<PortfolioHoldingSummary>();
            
            
            if (holdings.Count() > 0)
            {
                List<string> quoteTickers = new List<string>();
                foreach (PortfolioHolding holding in holdings)
                {
                    quoteTickers.Add(holding.HoldingTicker.Symbol);
                    PortfolioHoldingSummary holdingSummary = new PortfolioHoldingSummary(holding);
                    holdingSummary.PortfolioId = portfolio.ID;

                    PortfolioHoldingSummary tickerSummary = new PortfolioHoldingSummary(holding);
                    tickerSummary.PortfolioId = portfolio.ID;
                    
                    System.Reflection.MemberInfo[] allocationInfo = AllocationType.Cash.GetType().GetMember(holding.AllocationType.ToString());

                    PortfolioTickers.Add(tickerSummary);
                    
                    if (allocationInfo != null && allocationInfo.Length > 0)
                    {
                        object[] attrs = allocationInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute),
                                                                        false);
                        if (attrs != null && attrs.Length > 0)
                            holdingSummary.AllocationText = ((System.ComponentModel.DataAnnotations.DisplayAttribute)attrs[0]).GetName();
                    }
                    if (PortfolioHoldings.Where(h => h.Symbol == holdingSummary.Symbol).Count() > 0)
                    {
                        PortfolioHoldings.Where(h => h.Symbol == holdingSummary.Symbol).FirstOrDefault().TotalShares += holdingSummary.TotalShares;
                        PortfolioHoldings.Where(h => h.Symbol == holdingSummary.Symbol).FirstOrDefault().MarketValue += holdingSummary.MarketValue;
                    }
                    else
                    {
                        PortfolioHoldings.Add(holdingSummary);
                        
                    }
                    
                }

                decimal totalValue = 0;
                List<Quote> quotes;
                if (!historical)
                {
                    quotes = FinancialData.GetQuotes(quoteTickers);
                }
                else
                {
                    quotes = new List<Quote>();
                    List<QuoteCollection> quoteCollection = FinancialData.GetHistoricalQuoteData(quoteTickers.AsEnumerable(), fromDate.Value, toDate.Value);
                    foreach (QuoteCollection collection in quoteCollection)
                    {
                        HistoricalQuote histQuote = collection.Quotes.OrderByDescending(o => o.TradingDate).FirstOrDefault();
                        Quote quote = new Quote()
                        {
                            Symbol = collection.Ticker,
                            LastTradeDate = histQuote.TradingDate,
                            DaysHigh = histQuote.High,
                            DaysLow = histQuote.Low,
                            Open = histQuote.Open,
                            Volume = histQuote.Volume,
                            LastTradePriceOnly = histQuote.Close,
 
                        };
                         quotes.Add(quote);
                    }

                }
                foreach (PortfolioHoldingSummary summary in PortfolioHoldings)
                {
                    Quote quote = quotes.Where(q => q.Symbol == summary.Symbol).FirstOrDefault();
                    if (quote != null)
                    {
                        summary.LastPrice = (decimal)quote.LastTradePriceOnly;
                        summary.OpenPrice = (decimal)quote.Open;
                        summary.Volume = quote.Volume;
                        summary.DaysHigh = (decimal)quote.DaysHigh;
                        summary.DaysLow = (decimal)quote.DaysLow;
                        summary.LastTradeDate = quote.LastTradeDate;
                        summary.LastTradeTime = quote.LastTradeTime;
                        //summary.ChangeInPercentSincePreviousClose = 1; // (quote.LastTradePriceOnly - quote.PreviewClose) / quote.PreviewClose;
                        summary.ChangeInPercent = quote.ChangeInPercent;
                        summary.SetHoldingStatusText(quote.LastTradePriceOnly);
                        summary.SetAlertHighColor(quote.LastTradePriceOnly);
                        summary.SetAlertLowColor(quote.LastTradePriceOnly);
                        summary.MarketValue = (decimal)(summary.TotalShares) * (decimal)(quote.LastTradePriceOnly);
                        totalValue += (decimal)summary.MarketValue;
                    } 

                    else
                    {
                        summary.SetAlertHighColor(0);
                        summary.SetAlertLowColor(0);
                        summary.MarketValue = 0;
                    }
                    
                }

                foreach (PortfolioHoldingSummary tickerSummary in PortfolioTickers)
                {
                    tickerSummary.LastPrice = PortfolioHoldings.Where(h => h.TickerId == tickerSummary.TickerId).First().LastPrice;
                    tickerSummary.MarketValue = tickerSummary.LastPrice * (decimal)tickerSummary.TotalShares ;
                    tickerSummary.OpenPrice = PortfolioHoldings.Where(h => h.TickerId == tickerSummary.TickerId).First().OpenPrice;
                    tickerSummary.Volume = PortfolioHoldings.Where(h => h.TickerId == tickerSummary.TickerId).First().Volume;
                    tickerSummary.DaysHigh = PortfolioHoldings.Where(h => h.TickerId == tickerSummary.TickerId).First().DaysHigh;
                    tickerSummary.DaysLow = PortfolioHoldings.Where(h => h.TickerId == tickerSummary.TickerId).First().DaysLow;
                    tickerSummary.LastTradeDate = PortfolioHoldings.Where(h => h.TickerId == tickerSummary.TickerId).First().LastTradeDate;
                    tickerSummary.LastTradeTime = PortfolioHoldings.Where(h => h.TickerId == tickerSummary.TickerId).First().LastTradeTime;
                    tickerSummary.ChangeInPercent = PortfolioHoldings.Where(h => h.TickerId == tickerSummary.TickerId).First().ChangeInPercent;
                    tickerSummary.HoldingStatusText = PortfolioHoldings.Where(h => h.TickerId == tickerSummary.TickerId).First().HoldingStatusText;
                    tickerSummary.AlertHighColor = PortfolioHoldings.Where(h => h.TickerId == tickerSummary.TickerId).First().AlertHighColor;
                    tickerSummary.AlertLowColor = PortfolioHoldings.Where(h => h.TickerId == tickerSummary.TickerId).First().AlertLowColor;
                    
                }

                PortfolioHoldingSummary cashHolding = new PortfolioHoldingSummary()
                {
                    Symbol = "CASH",
                    MarketValue = portfolio.CashHoldings,
                    PortfolioName = portfolio.Name,
                    ValuationOpinion = "",
                    HoldingStatusText = "Green",
                    AllocationText = "Cash",    
                    TotalShares = (double)portfolio.CashHoldings
                };
                
                PortfolioHoldings.Add(cashHolding);
                
                TotalValue = totalValue + portfolio.CashHoldings;

                foreach (PortfolioHoldingSummary summary in PortfolioHoldings)
                {
                    if (totalValue == 0 || totalValue == portfolio.CashHoldings)
                        summary.Weight = 1;
                    else
                        summary.Weight = (double)(summary.MarketValue / totalValue);
                }
                
                PortfolioHoldings = PortfolioHoldings.Where(h => h.TotalShares != 0).OrderBy(h => h.Symbol).ToList();
                if (PortfolioHoldings == null)
                    PortfolioHoldings = new List<PortfolioHoldingSummary>();

                List<PortfolioHoldingSummary> allocation = new List<PortfolioHoldingSummary>();
                foreach (PortfolioHoldingSummary sum in PortfolioHoldings)
                {
                    if (allocation.Where(a => a.AllocationText == sum.AllocationText).Count() > 0)
                    {
                        allocation.Where(a => a.AllocationText == sum.AllocationText).First().MarketValue += sum.MarketValue;
                        allocation.Where(a => a.AllocationText == sum.AllocationText).First().Weight += sum.Weight;
                    }
                    else
                    {
                        allocation.Add(new PortfolioHoldingSummary() { AllocationText = sum.AllocationText, Weight = sum.Weight,MarketValue = sum.MarketValue });
                    }
                }
                PortfolioAllocation = allocation;
            }
            else
            {
                TotalValue = 0;
            }

            
        }
        */
        
    }
    

    [DataContract(Name = "PortfolioHoldingSummary")]
    public class PortfolioHoldingSummary
    {
        [DataMember(Name = "PortfolioHoldingId")]
        public int PortfolioHoldingId { get; set; }

        [DataMember(Name = "PortfolioId")]
        public int PortfolioId { get; set; }

        [DataMember(Name = "PortfolioName")]
        public string PortfolioName { get; set; }

        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "Sector")]
        public string GicsSector { get; set; }

        [DataMember(Name = "TickerName")]
        public string TickerName { get; set; }

        public bool Archived { get; set; }

        [DataMember(Name = "TickerId")]
        public int TickerId { get; set; }

        [DataMember(Name = "Weight")]
        public double Weight { get; set; }

        [DataMember(Name = "MarketValue")]
        public decimal MarketValue { get; set; }

        [DataMember(Name = "TotalValue")]
        public decimal TotalValue { get; set; }

        public string AssetClass { get; set; }
        public string Currency { get; set; }

        public decimal? ReturnOnEquity { get; set; }
        public decimal? ReturnOnAssets { get; set; }
        public decimal? ReturnOnSales { get; set; }
        public decimal? SustainableGrowthRate { get; set; }

            [DataMember(Name = "RequiredReturn")]
    public double RequiredReturn { get; set; }

        [DataMember(Name = "Shares")]
        public double TotalShares { get; set; }

        [DataMember(Name = "NeedsReviewText")]
        public string NeedsReviewText { get; set; }

        [DataMember(Name = "NextReviewDate")]
        public DateTime NextReviewDate { get; set; }

        [DataMember(Name = "ExpectedMeanPrice")]
        public double ExpectedMeanPrice { get; set; }

        [DataMember(Name = "ExpectedStandardDeviation")]
        public double ExpectedStandardDeviation { get; set; }

        [DataMember(Name = "NoGrowthValue")]
        public decimal NoGrowthValue { get; set; }

        [DataMember(Name = "BookValuePerBasicShare")]
        public double BookValuePerBasicShare { get; set; }

        [DataMember(Name = "NetIncome")]
        public double NetIncome { get; set; }

        [DataMember(Name = "CurrentYearMeanEstimate")]
        public double CurrentYearMeanEstimate { get; set; }


        [DataMember(Name = "ImpliedGrowthRate")]
        public double ImpliedGrowthRate { get; set; }

        [DataMember(Name = "ImpliedGrowthRateText")]
        public string ImpliedGrowthRateText { get; set; }


        [DataMember(Name = "HoldingStatusText")]
        public string HoldingStatusText { get; set; }

        [DataMember(Name = "AllocationText")]
        public string AllocationText { get; set; }


        [DataMember(Name = "MaxPrice")]
        public double MaxPrice { get; set; }
        [DataMember(Name = "MinPrice")]
        public double MinPrice { get; set; }

        [DataMember(Name = "ValuationOpinion")]
        public string ValuationOpinion { get; set; }

        [DataMember(Name = "ModelUrl")]
        public string ModelUrl { get; set; }

        [DataMember(Name = "ModelLinkText")]
        public string ModelLinkText { get; set; }

        [DataMember(Name = "AlertHigh")]
        public decimal AlertHigh { get; set; }
        [DataMember(Name = "AlertHighColor")]
        public string AlertHighColor { get; set; }

        [DataMember(Name = "LastPriceColor")]
        public string LastPriceColor { get; set; }


        [DataMember(Name = "AlertLow")]
        public decimal AlertLow { get; set; }
        [DataMember(Name = "AlertLowColor")]
        public string AlertLowColor { get; set; }


        [DataMember(Name = "LastPrice")]
        public decimal LastPrice { get; set; }

        [DataMember(Name = "OpenPrice")]
        public decimal OpenPrice { get; set; }

        [DataMember(Name = "DaysHigh")]
        public decimal DaysHigh { get; set; }

        [DataMember(Name = "DaysLow")]
        public decimal DaysLow { get; set; }

        [DataMember(Name = "LastTradeTime")]
        public DateTime LastTradeTime { get; set; }


        [DataMember(Name = "LastTradeDate")]
        public DateTime LastTradeDate { get; set; }
        [DataMember(Name = "ChangeInPercent")]
        public double ChangeInPercent { get; set; }

        [DataMember(Name = "ChangeInPercentSincePreviousClose")]
        public double ChangeInPercentSincePreviousClose { get; set; }


        [DataMember(Name = "Volume")]
        public long Volume { get; set; }

        [DataMember(Name = "ExpectedDailyVolatility")]
        public double ExpectedDailyVolatility { get; set; }

        [DataMember(Name = "ExpectedAnnualReturns")]
        public double ExpectedAnnualReturns { get; set; }


        [DataMember(Name = "SendEmailNotification")]
        public bool SendEmailNotification { get; set; }

        [DataMember(Name = "SendEmailNotificationText")]
        public string SendEmailNotificationText { get; set; }

        public PortfolioHoldingSummary(PortfolioHolding holding)
        {
            GicsSector = holding.HoldingTicker.GicsSector;
            TotalValue = holding.TotalValue;
            PortfolioHoldingId = holding.HoldingPortfolio.ID;
            PortfolioName = holding.HoldingPortfolio.Name;
            PortfolioHoldingId = holding.ID;
            Symbol = holding.HoldingTicker.Symbol;
            TickerName = holding.HoldingTicker.Name;
            TickerId = holding.HoldingTicker.ID;
            TotalShares = holding.TotalShares;
            NeedsReviewText = holding.NeedsReviewText;
            ExpectedAnnualReturns = holding.ExpectedAnnualReturns;
            ExpectedMeanPrice = holding.ExpectedPriceDistribution.Mean;
            ExpectedStandardDeviation = holding.ExpectedPriceDistribution.StandardDeviation;
            MaxPrice = holding.ExpectedPriceDistribution.MaxValue;
            MinPrice = holding.ExpectedPriceDistribution.MinValue;
            AlertHigh = holding.NotifyIfAbove;
            AlertLow = holding.NotifyIfBelow;
            NextReviewDate = holding.NextReviewDate;
            ValuationOpinion = "Not Set";
            ExpectedDailyVolatility = holding.ExpectedPriceDistribution.ExpectedDailyVolatility;
            SendEmailNotification = holding.SendEmailNotification;
            SendEmailNotificationText = SendEmailNotification ? "On" : "Off";

        }

        public void SetAlertLowColor(double currentPrice)
        {
            //first find out
            if (currentPrice <= (double) AlertLow)
                AlertLowColor = "Red";
            else
                AlertLowColor = "Green";
        }

        public string CIK { get; set; }

        public void SetAlertHighColor(double currentPrice)
        {
            //first find out
            if (currentPrice >= (double) AlertHigh)
                AlertHighColor = "Red";
            else
                AlertHighColor = "Green";
        }

        public void SetHoldingStatusText(double currentPrice)
        {
            //first find out
            string strReturn = string.Empty;
            string red = "Red";
            string green = "Green";
            string yellow = "Yellow";
            string orange = "Orange";

            //ok so first we determin the distance to the review
            TimeSpan timeSpan = NextReviewDate - DateTime.UtcNow;

            int daysToReview = timeSpan.Days;
            if (daysToReview < 1)
            {
                HoldingStatusText = red;
                return;
            }
            double portionOfAYear = (double)daysToReview / (double)365;
            int tradingDaysPerYear = 263;
            double tradingDaysToNextReview = portionOfAYear * tradingDaysPerYear;
            double timeSpanVolatility = (double)ExpectedStandardDeviation *(double) (Math.Pow(portionOfAYear,0.5));

            if (currentPrice > MaxPrice || currentPrice < MinPrice)
                HoldingStatusText  = red;

            else if (currentPrice < ExpectedMeanPrice + ExpectedMeanPrice * (double)(timeSpanVolatility)
                && currentPrice > ExpectedMeanPrice - ExpectedMeanPrice * (double)(timeSpanVolatility))
                HoldingStatusText = green;
            else if (currentPrice < ExpectedMeanPrice + ExpectedMeanPrice * (double)(timeSpanVolatility * 1.5)
                && currentPrice > ExpectedMeanPrice - ExpectedMeanPrice * (double)(timeSpanVolatility * 1.5))
                HoldingStatusText = yellow;
            else if (currentPrice < ExpectedMeanPrice + ExpectedMeanPrice * (double)(timeSpanVolatility * 2.0)
               && currentPrice > ExpectedMeanPrice - ExpectedMeanPrice * (double)(timeSpanVolatility * 2.0))
                HoldingStatusText = orange;
            else 
                HoldingStatusText = red;
        }

        public PortfolioHoldingSummary()
        { }

    }
}