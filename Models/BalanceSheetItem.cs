
namespace Prudena.Web.Models
{
  

    public class BalanceSheetItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string WeightText { get; set; }
        public decimal Value { get; set; }
        public string ValueText { get; set; }
        
    }
}