using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models.Predictions
{
    public class PredictionRating
    {
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

        #region Rating Information
        
        public double Rating { get; set; }

         public string RatingComment { get; set; }

        #endregion



    }
}