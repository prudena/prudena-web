using System;

namespace Prudena.Web.Models
{
    
    public class UserNewsItem 
    {
        public int ID { get; set; }
        public string Name { get; set; }
    
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public SystemUser Owner { get; set; }
        public string Source { get; set; }
        public string Headline { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime RetrieveDate { get; set; }
        public string URL { get; set; }
        public string Body { get; set; }

    }
}