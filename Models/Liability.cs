using System;

namespace Prudena.Web.Models
{
    public enum LiabilityOperatingOrFinancial
    {
        Operating,
        Financial
    }
    public enum LiabilityType
    {
        ShortTerm,
        LongTerm,
        Other

    }
    public class Liability : BalanceSheetItem
    {
        public BalanceSheet BalanceSheet { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public LiabilityOperatingOrFinancial LiabilityOperatingOrFinancial { get; set; }
        public LiabilityType LiabilityType { get; set; }

    }
}