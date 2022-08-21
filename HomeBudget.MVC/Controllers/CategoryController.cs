using HomeBudget.Contracts;
using HomeBudget.Models.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoryController
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        // GET: CategoryController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreate categoryCreate)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrMsg"] = "Model State is Invalid";
                return View(categoryCreate);
            }
            else
            {
                if (await _categoryService.CreateCategoryAsync(categoryCreate))
                    return RedirectToAction("Index");
            }
            TempData["ErrMsg"] = "Unable to Create the Category. Please try again later.";
            return View(categoryCreate);
        }

        // GET: CategoryController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var category = await _categoryService.GetCategoryByIdAsync((int)id);
            if (category == null) return NotFound();    

            return View(category);
        }

        // GET: CategoryController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var category = await _categoryService.GetCategoryByIdAsync((int)id);
            if (category is null) return NotFound();


            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid || model is null)
            {
                TempData["ErrMsg"] = "Model State is Invalid";
                return View(model);
            }
            if (id != model.Id)
            {
                TempData["ErrMsg"] = "Model Id mismatch";
                return View(model);
            }

            if (await _categoryService.UpdateCategoryAsync(model))
                return RedirectToAction(nameof(Index));

            TempData["ErrMsg"] = "Unable to update Model to the Database";
            return UnprocessableEntity();
        }

        // GET: CategoryController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var category = await _categoryService.GetCategoryByIdAsync((int)id);
            if (category == null) return NotFound();

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return NotFound();

            if (await _categoryService.DeleteCategoryAsync((int)id))
                return RedirectToAction(nameof(Index));
            return UnprocessableEntity(id);
        }
    }
}
