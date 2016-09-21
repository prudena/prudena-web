using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prudena.Web.Models.Predictions
{
    public class PredictionQuestion
    {

        public PredictionQuestion()
        {
          
        }
        #region Basics

        public int ID { get; set; }
        [Required]

        public string Name { get; set; }

        public SystemUser Owner { get; set; }

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

        [StringLength(512)]
        public string TickerName { get; set; }

        public bool ShowCurrentValue{ get; set; }

        public bool ShowValueAtTimeOfPrediction { get; set; }

        public bool ShowResolutionValue { get; set; }


        public double CurrentLastPrice { get; set; }

        public double PublishLastPrice { get; set; }

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

     
        #endregion


        #region Question Information

        [StringLength(512)]

        public string QuestionText { get; set; }

        public DateTime ClosingDate { get; set; }

        public DateTime ResolutionDate { get; set; }

        public int DaysToResolution { get; set; }

        public int PublicPredictionCount { get; set; }

        public int DefaultNumberOfBuckets { get; set; }

        public double BucketStep { get; set; }

        public double MinValue { get; set; }

        public double MaxOfMinBucket { get; set; }

        public double MinOfMaxBucket { get; set; }

        public double MaxValue { get; set; }

        [StringLength(64)]
        public string LabelFormatString { get; set; }

        public string QuestionDescription { get; set; }

        public List<QuestionBucket> Buckets { get; set; }

        [NotMapped]
        public List<Prediction> Predictions { get; set; }

        [NotMapped]
        public List<PredictionQuestionFollower> Followers { get; set; }

        #endregion

    }
}