using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prudena.Web.Models
{
    public class Prudena500Edition
    {
        #region Properties

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(256)]
        public string PermanentLinkUrl { get; set; }

        //[Index("IX_Prudena500Edition_Slug", 1, IsUnique = true)]
        [StringLength(256)]
        public string Slug { get; set; }

        public string Summary { get; set; }


        public DateTime PublishDate { get; set; }
        public bool IsPublished { get; set; }

        public bool ApprovedForPublish { get; set; }
        public bool ElevateToHomepage { get; set; }
        public bool IsPublic { get; set; }

        public DateTime DateCreated { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public bool PublishEmailSent { get; set; }

        public Guid UID { get; set; }

        public int EditionNumber { get; set; }

        [NotMapped]
        public List<Prudena500EditionItem> Items { get; set; }

        
        #endregion


    }
}