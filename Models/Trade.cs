using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public enum TradeStatus
    {
        Unknown = 0,
        Green = 1,
        Red = 2,
    }

    
    public enum TradeState
    {
        Idea = 1,
        Evaluating = 2,
        Ready = 3,
        Executed = 4,
        Archived = 5,
    }
    public enum TradeType
    {
        Buy = 1,
        
        [Display(Name = "Buy To Cover")]
        BuyToCover = 2,
        
        Sell = 3,
        
        [Display(Name = "Sell Short")]
        SellShort= 4
        
    }

    public enum TradeCategory
    {
        Training = 0,
        Live = 1,
    }

    public enum Benchmark
    {
        
        None = 0,
        Event = 1,
        
        [Display(Name = "S&P 500")]
        SandP500 = 2,

        [Display(Name = "Absolute Return")]
        AbsoluteReturn = 3,

     
    }

    public class Trade : BurnuliBaseModel, IBurnuliEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Required]
        public TradeState State { get { return (TradeState)StateId; } }

        public string StateText { get; set; }
        
        [Required]
        public int StateId { get; set; }

        [Required]
        public TradeCategory TradeCategory { get { return (TradeCategory)TradeCategoryId; } }
        [Required]
        public int TradeCategoryId { get; set; }

        public string TradeCategoryText { get; set; }

        [Required]
        public Portfolio Portfolio { get; set; }

        [Required]
        [Display(Name = "Current Benchmark Level")]
        public double CurrentBenchmarkLevel { get; set; }

        [Required]
        [Display(Name = "Change vs. Benchmark at Close")]
        public double ChangeVsBenchmarkAtClose { get; set; }


        public ICollection<Ticker> Tickers { get; set; }
        public Ticker PrimaryTicker { get; set; }

        public ICollection<PortfolioHolding> PortfolioHoldings { get; set; }
        public PortfolioHolding PrimaryPortfolioHolding { get; set; }


        public Benchmark Benchmark { get { return (Benchmark)BenchmarkId; } }
        public int BenchmarkId { get; set; }
        
        public DateTime? ExecutionDate { get; set; }
        public decimal ExecutionCommission { get; set; }
        public decimal ExecutionPrice { get; set; }
        public double Shares { get; set; }
        
        [Required]
        public TradeType TradeType { get { return (TradeType)TradeTypeId; } }

        [Required]
        public int TradeTypeId { get; set; }

        public string TradeTypeText { get; set; }
     
        public DateTime? CloseDate { get; set; }
        public decimal? ClosePrice { get; set; }
        public double RealizedVolatility { get; set; }

       
        public DateTime? ReviewDate { get; set; }
        public string ReviewDateText { get; set; }
        
        public Distribution ExpectedReturnsDistribution { get; set; }

        public string RulingReason { get; set; }

        public string CounterArgument { get; set; }

        public string OpenNotes { get; set; }

        public string CloseNotes { get; set; }


        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }

        public decimal ExpectedClosePriceMean { get; set; }

        public bool Anchoring { get; set; }
        
        public bool Emotion { get; set; }
        
        public bool Overconfidence { get; set; }

        public bool Framing { get; set; }

        public bool IntertemporalChoice { get; set; }
        public bool Experts { get; set; }
        public bool CognitiveEffort { get; set; }
        public bool Consistency { get; set; }

        public decimal ExpectedCloseBelow90Percent { get; set; }
        public decimal ExpectedCloseAbove90Percent { get; set; }

        public decimal ExpectedCloseBelow60Percent { get; set; }
        public decimal ExpectedCloseAbove60Percent { get; set; }
        
        public decimal ExpectedCloseBelow40Percent { get; set; }
        public decimal ExpectedCloseAbove40Percent { get; set; }

        public decimal ExpectedCloseBelow95Percent { get; set; }
        public decimal ExpectedCloseAbove95Percent { get; set; }

        public decimal? CurrentPrice { get; set; }

        public TradeStatus Status40Percent
        {
            get
            {
                if (CurrentPrice.HasValue)
                {
                    if (CurrentPrice > ExpectedCloseAbove40Percent && CurrentPrice < ExpectedCloseBelow40Percent)
                        return TradeStatus.Green;
                    else
                        return TradeStatus.Red;
                }
                else
                {
                    return TradeStatus.Unknown;
                }
            }
        }
        public string Status40PercentText { get; set; }
        public string Status60PercentText { get; set; }
        public string Status90PercentText { get; set; }
        public string Status95PercentText { get; set; }
        public void SetStatusText()
        {
            Status40PercentText = Status40Percent.ToString();
            Status60PercentText = Status60Percent.ToString();
            Status90PercentText = Status90Percent.ToString();
            Status95PercentText = Status95Percent.ToString();
        }
        public TradeStatus Status60Percent
        {
            get
            {
                if (CurrentPrice.HasValue)
                {
                    if (CurrentPrice > ExpectedCloseAbove60Percent && CurrentPrice < ExpectedCloseBelow60Percent)
                        return TradeStatus.Green;
                    else
                        return TradeStatus.Red;
                }
                else
                {
                    return TradeStatus.Unknown;
                }
            }
        }
        public TradeStatus Status90Percent
        {
            get
            {
                if (CurrentPrice.HasValue)
                {
                    if (CurrentPrice > ExpectedCloseAbove90Percent && CurrentPrice < ExpectedCloseBelow90Percent)
                        return TradeStatus.Green;
                    else
                        return TradeStatus.Red;
                }
                else
                {
                    return TradeStatus.Unknown;
                }
            }
        }
        public TradeStatus Status95Percent
        {
            get
            {
                if (CurrentPrice.HasValue)
                {
                    if (CurrentPrice > ExpectedCloseAbove95Percent && CurrentPrice < ExpectedCloseBelow95Percent)
                        return TradeStatus.Green;
                    else
                        return TradeStatus.Red;
                }
                else
                {
                    return TradeStatus.Unknown;
                }
            }
        }
    }
}