namespace BudgetWebApp.Business.Models
{
    public class tb_expenses
    {
        public short Id { get; set; }
        public short Id_Type { get; set; }
        public tb_type Type { get; set; }
        public double Value { get; set; }
    }
}
