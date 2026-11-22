using BudgetWebApp.Business.Models;

namespace BudgetWebApp.Business.IService
{
    public interface Itb_typeService
    {
        IQueryable<tb_type> GetAll();
        tb_type GetByName(string name);
        tb_type Get(short id);
        tb_type Create(tb_type tb_type);
        tb_type Modify(tb_type tb_type);
        void Delete(tb_type tb_type);
    }
}
