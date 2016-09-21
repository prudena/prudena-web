using System;
using System.ComponentModel.DataAnnotations;
using Prudena.Web.Models.Valuation;

namespace Prudena.Web.Models
{
    public class ResearchReportComment : IBurnuliEntity
    {
        #region Properties
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public double StarRating { get; set; }
        [Required]
        public ResearchReport ResearchReport { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsPublished { get; set; }

        public bool IsPendingApproval { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
   
        public string Email { get; set; }

        public bool IsFlagged { get; set; }

        public int Visits { get; set; }

        public int Likes { get; set; }

        public string Comment { get; set; }

        public bool AdminPost { get; set; }

        public int? ParentCommentId { get; set; }
        public virtual MorningMonteComment ParentComment { get; set; }

        public int? AuthorId { get; set; }
        public virtual SystemUser Author { get; set; }

        public bool NotifyOfFollowUpComments { get; set; }

        #endregion
    }
}