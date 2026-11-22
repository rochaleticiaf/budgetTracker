namespace BudgetWebApp.Business.Models
{
    public class tb_type
    {
        public short Id { get; set; }
        public short Id_category { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public tb_category Category { get; set; }
        public tb_expenses Expenses { get; set; }
    }
}
