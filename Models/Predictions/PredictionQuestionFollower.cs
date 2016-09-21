using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models.Predictions
{
    public class PredictionQuestionFollower
    {
        #region Basics

        public int ID { get; set; }
        [Required]


        public string Name { get; set; }

        public SystemUser Follower { get; set; }

        public PredictionQuestion Question { get; set; }

        public bool AlertWhenNewPredictionsArePublished { get; set; }

        public bool IncludeEmailWithAlert { get; set; }


        #endregion

        #region Change Information

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        public SystemUser CreateUser { get; set; }

        public SystemUser LastModifyUser { get; set; }

        #endregion


    }
}