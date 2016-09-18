
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{

    public class PortfolioPermission
    {
        public int ID { get; set; }
        [Required]
        public Portfolio Portfolio { get; set; }
        [Required]
        SystemUser User { get; set; }

        public bool Read { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Admin { get; set; }
        public bool FullControl { get; set; }


    }
}