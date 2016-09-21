using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models.Valuation
{
    public class TickerAttribute
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Ordinal { get; set; }
        public string TagName { get; set; }
        public Ticker Ticker { get; set; }
        public SystemUser Owner { get; set; }
        public bool IsPrivate { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
  
      
        

    }
}