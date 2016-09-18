
namespace Prudena.Web.Models
{
    
    public class UserNewsSource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public NewsSource NewsSource { get; set; }
        public SystemUser Owner { get; set; }
        public string Keywords { get; set; }
        public bool IsActive { get; set; }
    }
}