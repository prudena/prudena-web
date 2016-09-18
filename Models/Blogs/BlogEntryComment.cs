using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models.Blogs
{
    public class BlogEntryComment : IBurnuliEntity
    {
        #region Properties
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsPublished { get; set; }

        public bool IsFlagged { get; set; }

        public int Visits { get; set; }

        public string Comment { get; set; }

        public bool AdminPost { get; set; }

        #endregion

    }
}