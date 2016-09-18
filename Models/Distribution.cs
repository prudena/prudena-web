using System;
using System.ComponentModel;

namespace Prudena.Web.Models
{
    public enum DistributionType
    {
        Normal = 0,
        [Description("Log Normal")]
        LogNormal = 1,
        [Description("Student T")]
        StudentT = 2,
        [Description("Min Max Most-likely")]
        MinMaxMostLikely = 3,
    }
    public class Distribution
    {
        public int ID { get; set; }
        public double Kurtosis  { get; set; }
        public double Skewness { get; set; }
        public double StandardDeviation { get; set; }
        public double StandardDeviationPercentOfMeanAnnual { get; set; }
        
        public double Variance { get; set; }
        public double MaxValue { get; set; }
        public double MinValue { get; set; }
        public double Mean { get; set; }
        public bool IsSymetrical { get; set; }
        public double ScaleParameter { get; set; }
        public DistributionType Type { get; set; }
        public int DegreesOfFreedom { get; set; }
        public double NonCentrality { get; set; }
        public double ExpectedDailyVolatility { get { return this.StandardDeviationPercentOfMeanAnnual * Math.Sqrt(1 / 252); } }

    }
}