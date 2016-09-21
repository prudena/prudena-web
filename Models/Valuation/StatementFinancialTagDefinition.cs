
namespace Prudena.Web.Models.Valuation
{


    public class StatementFinancialTagDefinition
    {
        public int ID { get; set; }
        public SystemUser Owner { get; set; }
         public string TagName { get; set; }
        public string Name { get; set; }
        public FinancialStatementTagDefinitionType Type { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Ordinal { get; set; }
        public AccountingTreatment AccountingTreatment { get; set; }
        public double SplitPercentage { get; set; }
        
    }
}