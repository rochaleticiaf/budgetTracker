using BudgetWebApp.Business.Data;
using BudgetWebApp.Business.IService;
using BudgetWebApp.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetWebApp.Business.Service
{
    public class tb_categoryService : Itb_categoryService
    {
        private readonly AppDBContext _context;

        public tb_categoryService(AppDBContext context)
        {
            _context = context;
        }

        public IQueryable<tb_category> GetAll()
        {
            return _context.Tb_category
                .Include(category => category.tb_Types)
                .ThenInclude(type => type.Expenses);
        }

        public tb_category Get(short id)
        {
            return _context.Tb_category.Include(category => category.tb_Types)
                                        .ThenInclude(type => type.Expenses)
                                        .Single(x => x.Id == id);
        }

        public tb_category GetByName(string name)
        {
            return _context.Tb_category.Include(category => category.tb_Types)
                                        .ThenInclude(type => type.Expenses)
                                        .Single(x => x.Name == name);
        }

        public tb_category Create(tb_category tb_category)
        {
            _context.Tb_category.Add(tb_category);
            _context.SaveChanges();
            return tb_category;
        }

        public tb_category Modify(tb_category tb_category)
        {
            _context.Tb_category.Update(tb_category);
            _context.SaveChanges();
            return tb_category;
        }

        public void Delete(tb_category tb_category)
        {
            _context.Tb_category.Remove(tb_category);
            _context.SaveChanges();
        }
    }
}
