using System;

namespace Prudena.Web.Models
{
    public class AnnualEstimate
    {
        public int ID { get; set; }
        public Ticker Ticker { get; set; }
        public decimal NextFiscalYearMean { get; set; }
        public decimal NextFiscalYearHigh { get; set; }
        public decimal NextFiscalYearLow { get; set; }
        public DateTime NextFiscalYearEndDate { get; set; }
        public decimal CurrentFiscalYearMean { get; set; }
        public decimal CurrentFiscalYearLow { get; set; }
        public decimal CurrentFiscalYearHigh { get; set; }
        public DateTime CurrentFiscalYearEndDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCaptured { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser ModifyUser { get; set; }
        public SystemUser CaptureUser { get; set; }
        public bool IsCurrent { get; set; }




    }
}