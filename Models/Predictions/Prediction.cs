using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace Prudena.Web.Models.Predictions
{
    public class Prediction
    {
        #region Basics

        public int ID { get; set; }
        [Required]

        public string Name { get; set; }

        public SystemUser Owner { get; set; }

        public PredictionQuestion Question { get; set; }

        #endregion

        #region Change Information

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        public SystemUser CreateUser { get; set; }

        public SystemUser LastModifyUser { get; set; }

        #endregion

        #region Publish Information

        public bool IsPublished { get; set; }

        public bool IsPublic { get; set; }

        public DateTime? PublishDate { get; set; }

        public bool IsFlagged { get; set; }

        #endregion

        #region Ticker Information
        public bool HasTicker{ get; set; }

        //[Index("IX_PredictionQuestion_TickerID", 1, IsUnique = false)]
        public int TickerID { get; set; }

        //[Index("IX_PredictionQuestion_TickerSymbol", 1, IsUnique = false)]
        [StringLength(100)]
        public string TickerSymbol { get; set; }

        public string TickerName { get; set; }

        public double CurrentLastPrice { get; set; }

        public double PublishLastPrice { get; set; }

        #endregion

        public bool HasBenchmark { get; set; }

        [StringLength(512)]
        public string BenchmarkName { get; set; }

        [StringLength(64)]
        public string BenchmarkTicker { get; set; }

        public DateTime? BenchmarkPeriodStartDate { get; set; }

        public double BenchmarkPeriodStartValue { get; set; }

        public double BenchmarkCurrentValue { get; set; }

        public double BenchmarkResolutionValue { get; set; }

        public double PercentChangeRelativeToBenchmark { get; set; }


        #region Prediction Information


        public string PublicNotes { get; set; }

        public string PrivateNotes { get; set; }

        public double LastPriceAtTimeOfPrediction { get; set; }

        public double LastPriceOnResolutionDate { get; set; }

        public double MaxValue { get; set; }

        public double MinValue { get; set; }

        public int BucketCount { get; set; }

        public string PercentageString { get; set; }


        public double NinetyFivePercentConfidentGreaterThan { get; set; }

        public double NinetyFivePercentConfidentLessThan { get; set; }

        public double NinetyPercentConfidentGreaterThan { get; set; }

        public double NinetyPercentConfidentLessThan { get; set; }

        public double ModePrediction { get; set; }

        public double MeanPrediction { get; set; }

        public double MedianPrediction { get; set; }


        public List<PredictionBucket> PredictionBuckets { get; set; }

        public Distribution Distribution { get; set; }

        public void CalculateStatistics()
        {
            if (this.PredictionBuckets == null)
            {
                return;
            }

            
            List<double> voteList = new List<double>();

            double maxValue = 0 ;

            foreach (var item in this.PredictionBuckets)
            {
                if (item.Value > maxValue)
                {
                    maxValue = item.Value;
                    this.ModePrediction = item.QuestionBucket.ValueOfRange;
                }

                for (int i = 0; i < (int)item.Value; i++)
                {
                    voteList.Add(item.QuestionBucket.ValueOfRange);
                }


            }
            
            this.MedianPrediction = Median(voteList.ToArray());
            //this.MeanPrediction = voteList.Average();

        }


        private double Median(double[] xs)
        {
            var ys = xs.OrderBy(x => x).ToList();
            double mid = (ys.Count - 1) / 2.0;
            return (ys[(int)(mid)] + ys[(int)(mid + 0.5)]) / 2;
        }
        #endregion

    }
}