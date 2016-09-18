using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models.Predictions
{
    public class PredictionBucket
    {
        #region Basics

        public int ID { get; set; }
        [Required]

        public string Name { get; set; }

        public Prediction Prediction { get; set; }

        public QuestionBucket QuestionBucket { get; set; }


        public int Ordinal { get; set; }

        #endregion

        #region Change Information

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        public SystemUser CreateUser { get; set; }

        public SystemUser LastModifyUser { get; set; }

        #endregion

        #region Prediction Information
     
     
        public double Value { get; set; }

        public string Label { get; set; }

        public double MinOfRange { get; set; }
        public double MaxOfRange { get; set; }

        #endregion

    }
}