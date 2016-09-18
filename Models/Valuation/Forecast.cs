using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models.Valuation
{

    public class Forecast : BurnuliBaseModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Name Length is 250")]


        public string Name { get; set; }
        public SystemUser Owner { get; set; }

        public Ticker Ticker { get; set; }

        public double RequiredReturn { get; set; }
    

    }
}