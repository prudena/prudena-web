using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Prudena.Web.Models.Blogs
{
    public class BlogEntry : IBurnuliEntity
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

        public int Visits { get; set; }

        public string Title { get; set; }

        public string ShortContent { get; set; }

        public string Content { get; set; }

        public List<BlogEntryComment> Comments { get; set; }

    
        #endregion

    }
}