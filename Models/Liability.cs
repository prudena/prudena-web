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
    public class Liability
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string WeightText { get; set; }
        public decimal Value { get; set; }
        public string ValueText { get; set; }
        public BalanceSheet BalanceSheet { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
        public LiabilityOperatingOrFinancial LiabilityOperatingOrFinancial { get; set; }
        public LiabilityType LiabilityType { get; set; }

    }
}