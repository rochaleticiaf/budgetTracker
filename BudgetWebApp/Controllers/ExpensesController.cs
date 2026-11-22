using BudgetWebApp.Business.IService;
using BudgetWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetWebApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ILogger<ExpensesController> _logger;
        private readonly Itb_expensesService _tb_expensesService;

        public ExpensesController(ILogger<ExpensesController> logger,
            Itb_expensesService tb_expensesService)
        {
            _logger = logger;
            _tb_expensesService = tb_expensesService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ExpensesModel model)
        {
            if (ModelState.IsValid)
            {
                var expense = _tb_expensesService.GetAll().SingleOrDefault(expense => expense.Id_Type == model.Id_Type);

                if (expense != null)
                {
                    expense.Value = model.Value;

                    _tb_expensesService.Modify(expense);
                }
                else
                {
                    _tb_expensesService.Create(new Business.Models.tb_expenses()
                    {
                        Id = model.Id,
                        Id_Type = model.Id_Type,
                        Value = model.Value

                    });
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ExpensesModel model)
        {
            if (ModelState.IsValid)
            {
                var expense = _tb_expensesService.Get(model.Id);

                _tb_expensesService.Delete(expense);

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
