using System;

namespace Prudena.Web.Models
{
    public enum AssetOperatingOrFinancial
    {
        Operating,
        Financial
    }
    public enum AssetType
    {
        Current,
        Fixed,
        Other
       
    }

    public class Asset : BalanceSheetItem
    {
        public BalanceSheet BalanceSheet { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public AssetOperatingOrFinancial AssetOperatingOrFinancial { get; set; }
        public AssetType AssetType { get; set; }
    }
}