using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Prudena.Web.Models
{
    

    public class EventLogItem : IBurnuliEntity
    {
        public enum LogItemCategory
        {
            [Description("Batch Process")]
            BatchProcess = 0,

            [Description("User Initiated Process")]
            UserInitiatedProcess = 1,

        }

        public enum LogItemType
        {
            [Description("Information")]
            Information = 0,

            [Description("Error")]
            Error = 1,


        }
        

        #region Properties
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Memo { get; set; }

        public string ItemCountTitle { get; set; }
        public int ItemCount { get; set; }

        public string ErrorCountTitle { get; set; }
        public int ErrorCount { get; set; }
        public string ErrorMessage { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }

        
        public int LogItemCategoryId { get; set; }
        public LogItemCategory Category { get { return (LogItemCategory)LogItemCategoryId; } }
        public string CategoryText { get { return ((LogItemCategory)LogItemCategoryId).ToDescription(); } }

        public int LogItemTypeId { get; set; }
        public LogItemType Type { get { return (LogItemType)LogItemTypeId; } }
        public string TypeText { get { return ((LogItemType)LogItemTypeId).ToDescription(); } }

        #endregion
     

    }
}