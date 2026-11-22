namespace BudgetWebApp.Business.Models
{
    public class tb_category
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public List<tb_type> tb_Types { get; set; }
    }
}
