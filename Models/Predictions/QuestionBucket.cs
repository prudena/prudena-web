using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models.Predictions
{
    public class QuestionBucket
    {
        #region Basics

        public int ID { get; set; }
        [Required]

        public string Name { get; set; }

        public PredictionQuestion Question { get; set; }

     
        public int Ordinal { get; set; }

        #endregion

        #region Change Information

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

         #endregion

        #region Prediction Information
     
     
        public double Value{ get; set; }

        public string Label { get; set; }

        public double MinOfRange { get; set; }
        public double MaxOfRange { get; set; }
        public double ValueOfRange { get; set; }

        #endregion

    }
}