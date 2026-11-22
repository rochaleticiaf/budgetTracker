using BudgetWebApp.Business.Data;
using BudgetWebApp.Business.IService;
using BudgetWebApp.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetWebApp.Business.Service
{
    public class TbTypeService : Itb_typeService
    {
        private readonly AppDBContext _context;

        public TbTypeService(AppDBContext context)
        {
            _context = context;
        }

        public IQueryable<tb_type> GetAll()
        {
            return _context.Tb_type.Include(type => type.Expenses)
                                    .Include(type => type.Category);
        }

        public tb_type Get(short id)
        {
            return _context.Tb_type.Include(type => type.Expenses)
                                    .Include(type => type.Category)
                                    .Single(x => x.Id == id);
        }

        public tb_type GetByName(string name)
        {
            return _context.Tb_type.Include(type => type.Expenses)
                                    .Include(type => type.Category)
                                    .Single(x => x.Name == name);
        }

        public tb_type Create(tb_type tb_type)
        {
            _context.Tb_type.Add(tb_type);
            _context.SaveChanges();
            return tb_type;
        }

        public tb_type Modify(tb_type tb_type)
        {
            _context.Tb_type.Update(tb_type);
            _context.SaveChanges();
            return tb_type;
        }

        public void Delete(tb_type tb_type)
        {
            _context.Tb_type.Remove(tb_type);
            _context.SaveChanges();
        }
    }
}
