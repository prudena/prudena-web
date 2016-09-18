using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public class ResearchReportRequest : IBurnuliEntity
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public Ticker Ticker { get; set; }

        public bool IsPending { get; set; }
        public DateTime DateCreated { get; set; }
        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
    }
}