using System;

namespace Prudena.Web.Models
{
    public class AnnualStatementsSummary
    {
        public int ID { get; set; }
        public Ticker Ticker { get; set; }
        public DateTime BsReportDate { get; set; }
        public decimal AnnualDividend { get; set; }
        public decimal LastQuarterlyDividend { get; set; }
        public decimal NetIncome { get; set; }
        public decimal BasicNormalizedNetIncomeShare { get; set; }
        public decimal ShareholderEquity { get; set; }
        public decimal CommonSharesOutstanding { get; set; }
        
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCaptured { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser ModifyUser { get; set; }
        public SystemUser CaptureUser { get; set; }

        public bool IsCurrent { get; set; }




    }
}