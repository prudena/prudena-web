using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace Prudena.Web.Models
{
    public class BalanceSheet
    {
        public int ID { get; set; }

        [Required]
        public BalanceSheetSeries BalanceSheetSeries { get; set; }

        [Required]
        [Display(Name = "Balance Sheet Date", Description = "This is the date of the balance sheet.")]
        public DateTime BalanceSheetDate { get; set; }

        [Required]
        [Display(Name = "Current Assets", Description = "How much cash do you have?")]
        [Range(0, double.MaxValue,
            ErrorMessage = "Value for {0} cannot be negative.")]
        public decimal CurrentAssets { get; set; }

        [Display(Name = "Current Assets Description")]
        public string CurrentAssetsDescription { get; set; }

        [Display(Name = "Portfolio Assets")]
        [Range(0, double.MaxValue,
            ErrorMessage = "Value for {0} cannot be negative.")]
        public decimal PortfolioAssets { get; set; }

        [Required]
        [Display(Name = "Fixed Assets", Description = "These are things like real estate or a car.")]
        [Range(0, double.MaxValue,
            ErrorMessage = "Value for {0} cannot be negative.")]
        public decimal FixedAssets { get; set; }

        [Display(Name = "Fixed Assets Description")]
        public string FixedAssetsDescription { get; set; }

        [Required]
        [Display(Name = "Other Assets", Description = "Your baseball card collection?")]
        [Range(0, double.MaxValue,
            ErrorMessage = "Value for {0} cannot be negative.")]
        public decimal OtherAssets { get; set; }

        [Display(Name = "Other Assets Description")]
        public string OtherAssetsDescription { get; set; }

        [Required]
        [Display(Name = "Current Liabilities", Description = "Items like credit card debt.")]
        [Range(0, double.MaxValue,
            ErrorMessage = "Value for {0} cannot be negative.")]
        public decimal CurrentLiabilities { get; set; }

        [Display(Name = "Current Liabilities Description")]
        public string CurrentLiabilitiesDescription { get; set; }

        [Required]
        [Display(Name = "Long Term Liabilities", Description = "Items like a school loan or a mortgage.")]
        [Range(0, double.MaxValue,
            ErrorMessage = "Value for {0} cannot be negative.")]
        public decimal LongTermLiabilities { get; set; }

        [Display(Name = "Long Term Liabilities Description")]
        public string LongTermLiabilitiesDescription { get; set; }

        [Required]
        [Display(Name = "Other Liabilities", Description = "Anything else?")]
        [Range(0, double.MaxValue,
            ErrorMessage = "Value for {0} cannot be negative.")]
        public decimal OtherLiabilities { get; set; }


        public decimal Equity { get { return TotalAssets - TotalLiabilities; } }
        public bool IsCurrent { get; set; }


        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime DateModified { get; set; }
        public SystemUser CreateUser { get; set; }
        public SystemUser LastModifyUser { get; set; }

        [Display(Name = "Next Scheduled Review")]
        public DateTime NextScheduledReview { get; set; }

        #region Calculated Properties

        [Display(Name = "Total Liabilities")]
        public decimal TotalLiabilities { get { return  CurrentLiabilities + LongTermLiabilities + OtherLiabilities; } }

        [Display(Name = "Total Assets")]
        public decimal TotalAssets { get { return CurrentAssets + FixedAssets + PortfolioAssets + OtherAssets; } }
        
        public double WeightCurrentAssets { get { return (((double)CurrentAssets) / ((double)TotalAssets)); } }
        public double WeightPortfolioAssets { get { return (((double)PortfolioAssets) / ((double)TotalAssets)); } }
        public double WeightFixedAssets { get { return (((double)FixedAssets) / ((double)TotalAssets)); } }
        public double WeightOtherAssets { get { return (((double)OtherAssets) / ((double)TotalAssets)); } }

        public double WeightCurrentLiabilities{ get { return (((double)CurrentLiabilities) / ((double)TotalLiabilities)); } }
        public double WeightLongTermLiabilities { get { return (((double)LongTermLiabilities) / ((double)TotalLiabilities)); } }
        public double WeightOtherLiabilities { get { return (((double)OtherLiabilities) / ((double)TotalLiabilities)); } }
       
        public IEnumerable<Asset> Assets
        {
            get
            {
                List<Asset> assets = new List<Asset>();
                assets.Add(new Asset() { Name = "Portfolio", ID = 2, Value = PortfolioAssets, Weight = WeightPortfolioAssets, WeightText = WeightPortfolioAssets.ToString("#0%") });
                assets.Add(new Asset() { Name = "Current/Cash", ID = 1, Value = CurrentAssets, Weight = WeightCurrentAssets, WeightText = WeightCurrentAssets.ToString("#0%") });
                assets.Add(new Asset() { Name = "Fixed", ID = 3, Value = FixedAssets, Weight = WeightFixedAssets, WeightText = WeightFixedAssets.ToString("#0%") });
                assets.Add(new Asset() { Name = "Other", ID = 4, Value = OtherAssets, Weight = WeightOtherAssets, WeightText = WeightOtherAssets.ToString("#0%") });
                
                return assets.OrderBy(a => a.ID);
            }
        }

        public IEnumerable<Liability> Liabilities
        {
            get
            {
                List<Liability> liabilities = new List<Liability>();
                liabilities.Add(new Liability() { Name = "Current/Cash", ID = 2, Value = CurrentLiabilities, Weight = WeightCurrentLiabilities, WeightText = WeightCurrentLiabilities.ToString("#0%") });
                liabilities.Add(new Liability() { Name = "Long-Term", ID = 1, Value = CurrentAssets, Weight = WeightLongTermLiabilities, WeightText = WeightLongTermLiabilities.ToString("#0%") });
                liabilities.Add(new Liability() { Name = "Other", ID = 4, Value = OtherLiabilities, Weight = WeightOtherLiabilities, WeightText = WeightOtherLiabilities.ToString("#0%") });

                return liabilities.OrderBy(a => a.ID);
            }
        }

        public IEnumerable<BalanceSheetItem> LiabilitiesAndEquity
        {
            get
            {
                decimal equity = TotalAssets - TotalLiabilities;

                List<BalanceSheetItem> balanceSheetItems = new List<BalanceSheetItem>();
                balanceSheetItems.Add(new BalanceSheetItem() { Name = "Current", ID = 3, Value = CurrentLiabilities});
                balanceSheetItems.Add(new BalanceSheetItem() { Name = "Long-Term", ID = 1, Value = LongTermLiabilities });
                balanceSheetItems.Add(new BalanceSheetItem() { Name = "Other", ID = 2, Value = OtherLiabilities });
                if (equity >= 0)
                    balanceSheetItems.Add(new BalanceSheetItem() { Name = "Equity", ID = 4, Value = equity });
                
                decimal totalValue = balanceSheetItems.Sum(l => l.Value);
                if (totalValue == 0)
                {
                    foreach (BalanceSheetItem l in balanceSheetItems)
                    {
                        l.Weight = (double)(1/balanceSheetItems.Count);
                        l.WeightText = l.Weight.ToString("#0%");
                    }
                }
                else
                {
                    foreach (BalanceSheetItem l in balanceSheetItems)
                    {
                        
                        l.Weight = (double)(l.Value / totalValue);
                        l.WeightText = l.Weight.ToString("#0%");
                    }
                }


                return balanceSheetItems.OrderBy(a => a.ID);
            }
        }

        public IEnumerable<BalanceSheetItem> Summary
        {
            get
            {
                decimal equity = TotalAssets - TotalLiabilities;

                List<BalanceSheetItem> balanceSheetItems = new List<BalanceSheetItem>();
                balanceSheetItems.Add(new BalanceSheetItem() { Name = "Liabilities", ID = 3, Value = TotalLiabilities });
                balanceSheetItems.Add(new BalanceSheetItem() { Name = "Assets", ID = 1, Value = TotalAssets });
                if (equity >= 0)
                    balanceSheetItems.Add(new BalanceSheetItem() { Name = "Equity", ID = 3, Value = equity });

                decimal totalValue = balanceSheetItems.Sum(l => l.Value);
                if (totalValue == 0)
                {
                    foreach (BalanceSheetItem item in balanceSheetItems)
                    {
                        item.Weight = (double)(1 / balanceSheetItems.Count);
                        item.WeightText = item.Weight.ToString("#0%");
                    }
                }
                else
                {
                    foreach (BalanceSheetItem item in balanceSheetItems)
                    {

                        item.Weight = (double)(item.Value / totalValue);
                        item.WeightText = item.Weight.ToString("#0%");
                    }
                }


                return balanceSheetItems.OrderBy(a => a.ID);
            }
        }


        #endregion

    }
}