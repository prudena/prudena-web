using System.Collections.Generic;

namespace Prudena.Web.Models.Valuation
{

    public class UserFinancialStatementTagSet
    {
        public int ID { get; set; }
        public SystemUser Owner { get; set; }
        public string StatementNumber { get; set; }
        public string Name { get; set; }
        public List<StatementFinancialTagDefinition> TagDefinitions { get; set; }
        public List<UserFinancialStatementTagSetItem> Items  { get; set; }
    }
}