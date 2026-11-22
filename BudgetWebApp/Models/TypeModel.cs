
using BudgetWebApp.Business.Models;

namespace BudgetWebApp.Models
{
    public class TypeModel : BaseModel
    { 
        public string Name { get; set; }
        public string? Description { get; set; }
        public short Id_category { get; set; }
        public List<tb_type>? TypeList { get; set; }


    }

}
