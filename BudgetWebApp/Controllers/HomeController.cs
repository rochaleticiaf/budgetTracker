using BudgetWebApp.Business.IService;
using BudgetWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BudgetWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Itb_categoryService _tb_categoryService;
        private readonly Itb_expensesService _tb_expensesService;

        public HomeController(ILogger<HomeController> logger,
            Itb_categoryService tb_categoryService,
            Itb_expensesService tb_expensesService)
        {
            _logger = logger;
            _tb_categoryService = tb_categoryService;
            _tb_expensesService = tb_expensesService;
        }

        public IActionResult Index()
        {
            IndexModel model = new()
            {
                CategoryList = _tb_categoryService.GetAll().ToList(),

                TotalSpent = _tb_expensesService.GetAll()
                                        .Where(expense => expense.Type.Category.Name != "Income")
                                        .Sum(x => x.Value),

                TotalBudget = _tb_expensesService.GetAll()
                                        .Where(expense => expense.Type.Category.Name == "Income")
                                        .Sum(x => x.Value)
            };

            var isOverbudeget = model.TotalSpent > model.TotalBudget;
            var overbudeget = model.TotalSpent - model.TotalBudget;
            model.Summary = (isOverbudeget) ?
                            $"You are overbudget by {overbudeget}" :
                            "You are within budget.";
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
