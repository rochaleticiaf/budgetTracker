
using BudgetWebApp.Business.Models;

namespace BudgetWebApp.Models
{
    public class IndexModel
    {
        public List<tb_type> TypeList { get; set; }
        public List<tb_category> CategoryList { get; set; }
        public Dictionary<short, decimal> BudgetValues { get; set; } = new();
        public Dictionary<short, decimal> ExpenseValues { get; set; } = new();
        public double TotalBudget { get; set; }
        public double TotalSpent { get; set; }
        public string Summary { get; set; }

    }

}
