using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public enum RiskRegisterState
    {
        Active = 0,
        Archived = 1,
     

    }
    public class RiskRegister : IBurnuliEntity
    {
        public int ID { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public SystemUser Owner { get; set; }

        public RiskRegisterState State { get { return (RiskRegisterState)RiskRegisterStateId; } }
        public int RiskRegisterStateId { get; set; }
    }
}