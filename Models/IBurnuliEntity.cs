using System;

namespace Prudena.Web.Models
{
    interface IBurnuliEntity
    {
        int ID { get; set; }
        string Name{ get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
        SystemUser CreateUser { get; set; }
        SystemUser LastModifyUser { get; set; }

             
    }
}
