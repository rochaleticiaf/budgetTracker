using BudgetWebApp.Business.Models;

namespace BudgetWebApp.Business.IService
{
    public interface Itb_categoryService
    {
        IQueryable<tb_category> GetAll();
        tb_category GetByName(string name);
        tb_category Get(short id);
        tb_category Create(tb_category tb_category);
        tb_category Modify(tb_category tb_category);
        void Delete(tb_category tb_category);
    }
}
