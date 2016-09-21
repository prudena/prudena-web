using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{

    public class Topic : IBurnuliEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public bool IsPublic { get; set; }
        public string Slug { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public bool ShowVideo { get; set; }
        public string VideoUrl { get; set; }
        public string VideoEmbedCode { get; set; }

        public string WikipediaUrl { get; set; }



    }
}