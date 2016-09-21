using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Prudena.Web.Models.Blogs
{
    public class Blog : IBurnuliEntity
    {
        #region Properties
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        public List<BlogEntry> Entries { get; set; }

        public DateTime DateCreated { get; set; }
        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public SystemUser Owner { get; set; }

        public bool IsPublic { get; set; }

        public int Visits { get; set; }

        #endregion

    }
}