
using BudgetWebApp.Business.Models;

namespace BudgetWebApp.Models
{
    public class BaseModel
    {
        public short Id { get; set; }     
        public string? Error { get; set; }
        public string? Success { get; set; }

    }

}
