using BudgetWebApp.Business.IService;
using BudgetWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly Itb_categoryService _tb_categoryService;
        private readonly Itb_typeService _tb_typeService;
        private readonly Itb_expensesService _tb_expensesService;

        public CategoryController(ILogger<CategoryController> logger,
            Itb_categoryService tb_categoryService,
            Itb_typeService tb_typeService,
            Itb_expensesService tb_expensesService)
        {
            _logger = logger;
            _tb_categoryService = tb_categoryService;
            _tb_typeService = tb_typeService;
            _tb_expensesService = tb_expensesService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                bool Exists = _tb_categoryService.GetAll().Any(x => x.Name == model.Name);

                if (Exists)
                {
                    model.Error = $"Error: Category '{model.Name}' already exists.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    _tb_categoryService.Create(new Business.Models.tb_category()
                    {
                        Name = model.Name
                    });
                    model.Success = $"Success: Category '{model.Name}' was added.";

                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var category = _tb_categoryService.Get(model.Id);
                category.Name = model.Name;
                _tb_categoryService.Modify(category);

                model.Success = $"Success: Category '{model.Name}' was updated.";

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CategoryModel model)
        {
            var category = _tb_categoryService.Get(model.Id);

            if (category.tb_Types != null)
            {
                foreach (var type in category.tb_Types.ToList())
                {
                    if (type.Expenses != null)
                        _tb_expensesService.Delete(type.Expenses);

                    _tb_typeService.Delete(type);
                }
            }

            _tb_categoryService.Delete(category);

            model.Success = $"Success: Category '{model.Name}' was deleted.";

            return RedirectToAction("Index", "Home");
        }

    }
}
