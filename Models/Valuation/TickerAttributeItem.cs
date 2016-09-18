using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models.Valuation
{
    public class TickerAttributeItem : BurnuliBaseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Ordinal { get; set; }
        public string TagName { get; set; }
        public TickerAttribute TickerAttribute { get; set; }
        public SystemUser Owner { get; set; }
        public bool IsPrivate { get; set; }
        public string StatementNumber { get; set; }
        public double Value { get; set; }
        public string Url { get; set; }
        public string TextValue { get; set; }
        public string Notes { get; set; }
        public string FindReferenceText { get; set; }
        public string SourceName { get; set; }
        public int FiscalYear { get; set; }
        public int FiscalQuarter { get; set; }
        public int FinancialStatementPeriodTypeId { get; set; }
        //public FinancialStatementPeriodType FinancialStatementPeriodType { get { return (FinancialStatementPeriodType)FinancialStatementPeriodTypeId; } }

        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }
  
    }
}