using BudgetWebApp.Business.Data;
using BudgetWebApp.Business.IService;
using BudgetWebApp.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetWebApp.Business.Service
{
    public class tb_expensesService : Itb_expensesService
    {
        private readonly AppDBContext _context;

        public tb_expensesService(AppDBContext context)
        {
            _context = context;
        }

        public IQueryable<tb_expenses> GetAll()
        {
            return _context.Tb_expenses;
        }

        public tb_expenses Get(short id)
        {
            return _context.Tb_expenses.Single(x => x.Id == id);
        }

        public tb_expenses Create(tb_expenses tb_expenses)
        {
            _context.Tb_expenses.Add(tb_expenses);
            _context.SaveChanges();
            return tb_expenses;
        }

        public tb_expenses Modify(tb_expenses tb_expenses)
        {
            _context.Tb_expenses.Update(tb_expenses);
            _context.SaveChanges();
            return tb_expenses;
        }

        public void Delete(tb_expenses tb_expenses)
        {
            _context.Tb_expenses.Remove(tb_expenses);
            _context.SaveChanges();
        }
    }
}
