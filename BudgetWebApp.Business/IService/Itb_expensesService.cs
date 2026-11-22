using BudgetWebApp.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetWebApp.Business.IService
{
    public interface Itb_expensesService
    {
        IQueryable<tb_expenses> GetAll();
        tb_expenses Get(short id);
        tb_expenses Create(tb_expenses tb_expenses);
        tb_expenses Modify(tb_expenses tb_expenses);
        void Delete(tb_expenses tb_expenses);
    }
}