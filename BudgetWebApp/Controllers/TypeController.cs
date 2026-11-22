using BudgetWebApp.Business.IService;
using BudgetWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using BudgetWebApp.Business.Models;

namespace BudgetWebApp.Controllers
{
    public class TypeController : Controller
    {
        private readonly ILogger<TypeController> _logger;
        private readonly Itb_typeService _tb_typeService;
        private readonly Itb_expensesService _tb_expensesService;

        public TypeController(ILogger<TypeController> logger,
            Itb_typeService tb_typeService,
            Itb_expensesService tb_expensesService)
        {
            _logger = logger;
            _tb_typeService = tb_typeService;
            _tb_expensesService = tb_expensesService;
        }

        const string index = "Index";
        const string indexController = "Home";


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TypeModel model)
        {
            if (ModelState.IsValid)
            {
                bool TypeExists = _tb_typeService.GetAll().Any(type => type.Name == model.Name);

                if (TypeExists)
                {
                    model.Error = $"Error: Type '{model.Name}' already exists.";
                    return RedirectToAction(index, indexController);
                }
                else
                {
                    // Redirect to a success page or return a response

                    _tb_typeService.Create(new tb_type()
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Id_category = model.Id_category
                    });
                    return RedirectToAction(index, indexController);
                }
            }
            return RedirectToAction(index, indexController);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TypeModel model)
        {
            if (ModelState.IsValid)
            {
                var type = _tb_typeService.Get(model.Id);

                type.Name = model.Name;
                _tb_typeService.Modify(type);

                return RedirectToAction(index, indexController);
            }
            return RedirectToAction(index, indexController);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(TypeModel model)
        {
            var type = _tb_typeService.Get(model.Id);

            if (type.Expenses != null)
                _tb_expensesService.Delete(type.Expenses);

            _tb_typeService.Delete(type);
            return RedirectToAction(index, indexController);
        }

    }
}
